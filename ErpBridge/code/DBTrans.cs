using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;


namespace ReportGenerator
{

/// <summary>
/// Summary description for DBTrans
/// </summary>
/// 



public class DBTrans
{

    public SqlConnection SQLDBConnection;
    public IDataReader mssqlDR { get; set; }
    public string SQLConnectionString { get; set; }

 
  //  string SQLConnectionString = ConfigurationManager.ConnectionStrings["SQLconnectionString"].ToString();

    public DBTrans() 
    {
     SQLConnectionString = GlobVariables.dbconstring;
    }


    ~DBTrans()
    {
        SQLDBConnection = null;
    }
    
    public int CheckSourceDBcon() 
    
    {
        SQLDBConnection = new SqlConnection();

        SQLDBConnection.ConnectionString = SQLConnectionString;

        try
        {
            SQLDBConnection.Open();
            SQLDBConnection.Close();
            return 1;
        }
        catch
        {
            return -1;
        }
    
    }


    public void  DBConnect()
    {
        SQLDBConnection = new SqlConnection();

        SQLDBConnection.ConnectionString = SQLConnectionString;

        try
        { 
            SQLDBConnection.Open();
        }
        catch
        {}

    } //end DBConnectoWms()

    public void  DBDisConnect()
    {       
        try
        {
            SQLDBConnection.Close();
        }
        catch
        { }

    } //end DBConnectoWms()


    public string FDBCheckConnection()
    {
        return SQLDBConnection.State.ToString();

    }

    public DataTable DBFillDataTable(String SelectSqlStr, String FillTbl)
    {
        DataTable DbDT = new DataTable();


        DBConnect();

        if (SQLDBConnection.State != ConnectionState.Open)
            return DbDT;

        SqlDataAdapter SqlDA = new SqlDataAdapter(SelectSqlStr, SQLDBConnection);

        try
        {
            SqlDA.Fill(DbDT);
        }
        catch (Exception ex)
        {
           //F_SQLERROR
        }

        SqlDA.Dispose();
        SQLDBConnection.Close();

        return DbDT;

    } // End DBFillDataset

    public long DBExecuteSQLCmd(String SqlExCmd)
     {

         
        long DBAffctRows;

        SqlCommand DBExSqlCommand;


        if (SqlExCmd.Length == 0 || SqlExCmd == "") { return -10; }

        DBConnect();

        if (SQLDBConnection.State != ConnectionState.Open)                   
            return -1;

        DBExSqlCommand = new SqlCommand(SqlExCmd, SQLDBConnection);

        try
        {                    
            DBExSqlCommand.CommandType = CommandType.Text;
            DBAffctRows = DBExSqlCommand.ExecuteNonQuery();

        }
         catch (Exception ex)
        {
            SQLDBConnection.Close();
            //F_SQLERRORLOG
            return -1;                 
        }
        

        if (DBAffctRows > 0 )
        {
            DBExSqlCommand.Dispose();
            SQLDBConnection.Close();
            return DBAffctRows;
        }
        else
        {
            DBExSqlCommand.Dispose();
            SQLDBConnection.Close();
            return -1;
        }

     } //end DBExecuteSQLCmd

    public string FDBInsertDecimal(decimal inval)
    {
        string decstr = null;

        if (inval > 0)
        {
            decstr = inval.ToString();
            decstr = decstr.Replace(",", ".");
        }
        return decstr;
    }


    public long DBGetNumResultFromSQLSelect(string SqlCmd)
    {
        SqlDataReader SQLReaderRetSelCmdResult = null;


        long CmdResultNum = 0;
        SqlCommand SQLSelectCmd = new SqlCommand();

        SQLSelectCmd.CommandText = SqlCmd;

        DBConnect();


        SQLSelectCmd.Connection = SQLDBConnection;

        try
        {
            SQLReaderRetSelCmdResult = SQLSelectCmd.ExecuteReader();
        }
        catch (Exception ex)
        {
            SQLSelectCmd.Dispose();
            SQLReaderRetSelCmdResult.Dispose();
            SQLDBConnection.Close();
            return -1;
        }


        while (SQLReaderRetSelCmdResult.Read())
        {
            try { CmdResultNum = long.Parse(SQLReaderRetSelCmdResult.GetValue(0).ToString()); }
            catch { CmdResultNum = -1; }
        }

        SQLSelectCmd.Dispose();
        SQLReaderRetSelCmdResult.Close();
        SQLReaderRetSelCmdResult.Dispose();
        SQLDBConnection.Close();


        return CmdResultNum;

    }// End DBWmsExSelectCmdRN2String

    public string DBSelectCmdRN2String(string SqlCmd)
    {
        SqlDataReader SQLReaderRetSelCmdResult;

        String SQLRtrnRowValue;

        string CmdResultNum = "";
        SqlCommand SQLSelectCmd = new SqlCommand();

        SQLSelectCmd.CommandText = SqlCmd;

        if (SQLDBConnection.State != ConnectionState.Open)
            DBConnect();

        if (SQLDBConnection.State != ConnectionState.Open)
            return "Null";

        SQLSelectCmd.Connection = SQLDBConnection;
        SQLReaderRetSelCmdResult = SQLSelectCmd.ExecuteReader();


        try
        {
            while (SQLReaderRetSelCmdResult.Read())
            {
                CmdResultNum = SQLReaderRetSelCmdResult.GetValue(0).ToString();
            }
        }
        catch (Exception ex)
        {
        }
        SQLReaderRetSelCmdResult.Close();

        SQLDBConnection.Close();


        SQLRtrnRowValue = CmdResultNum;

        if (SQLRtrnRowValue.Length > 0)
        {
            return SQLRtrnRowValue;
        }
        else
        {
            return "Null";
        }

    }// End DBWmsExSelectCmdRN2String

    public string DBSelectCmdRStr2Str(string SqlCmd)
    {
        SqlDataReader SQLReaderRetSelCmdResult;

        String SQLRtrnRowValue;

        string CmdResultNum = "";
        SqlCommand SQLSelectCmd = new SqlCommand();

        SQLSelectCmd.CommandText = SqlCmd;

        if (SQLDBConnection.State != ConnectionState.Open)
            DBConnect();

        if (SQLDBConnection.State != ConnectionState.Open)
            return "Null";


        SQLSelectCmd.Connection = SQLDBConnection;
        SQLReaderRetSelCmdResult = SQLSelectCmd.ExecuteReader();


        try
        {
            while (SQLReaderRetSelCmdResult.Read())
            {
                CmdResultNum = SQLReaderRetSelCmdResult.GetValue(0).ToString();
            }
        }
        catch (Exception ex)
        {
        }
        SQLReaderRetSelCmdResult.Close();

        SQLDBConnection.Close();


        SQLRtrnRowValue = CmdResultNum;

        if (SQLRtrnRowValue.Length > 0)
        {
            return SQLRtrnRowValue;
        }
        else
        {
            return "Null";
        }

    }// End DBWmsExSelectCmdRN2String


    public IDataReader returnAsDataReader(string SqlCmd)
    {

        // SqlDataReader SQLReaderRetSelCmdResult;
        SqlCommand SQLSelectCmd = new SqlCommand();


        SQLSelectCmd.CommandText = SqlCmd;

        if (SQLDBConnection.State != ConnectionState.Open)
        {
            DBConnect();
        }

        if (SQLDBConnection.State != ConnectionState.Open)
            return null;  //connection failed


        try
        {
            SQLSelectCmd.Connection = SQLDBConnection;
            mssqlDR = SQLSelectCmd.ExecuteReader();

            return mssqlDR;
        }
        catch (Exception ex)
        {
            return null;
        }

    }


    public long f_sqlerrorlog(int CompId, string SrcCodeSnippet, string SqlErrText, string AppErrorText, string AppUserName, string WEBUserIPAddress)
     {

             
        String AppUserStr= ""; 
        String CompIdStr= ""; 
        String LogSqlErrText= "";

        StringBuilder sqlLOGstr = new StringBuilder();


        if (CompId > 0 ) 
         {
            CompIdStr = CompId.ToString();
        }
        else
         {
            CompIdStr = "1";
         }

        if (AppUserName.Length > 0 )
         {
            AppUserStr = AppUserName;
        }
        else
          {
            AppUserStr = "NULL";
         }

        if (SrcCodeSnippet.Length  > 0 )
         {
            LogSqlErrText = SrcCodeSnippet + ">>" ;
         }
        else
        {
            LogSqlErrText = ">>";
        }


          if (SqlErrText.Length  > 0 )
         {
            SqlErrText = SqlErrText + SqlErrText ;
         }
            else
        {
            SqlErrText = ">>";
        }


        sqlLOGstr.Append("INSERT INTO TSYSEVENTLOGS(COMPID,LOGDATE,DBERRORTEXT,AppErrorText,APPUSER,WEBUserIPAddress)  ");
        sqlLOGstr .Append(" VALUES (" + CompIdStr + ",GETDATE(),'" + LogSqlErrText + "'," );

        if (String.IsNullOrEmpty(AppErrorText))
            sqlLOGstr.Append("NULL,");
        else
            sqlLOGstr.Append("'" + AppErrorText + "',");

       sqlLOGstr.Append("'" + AppUserStr + "'");//)" );

        if (string.IsNullOrEmpty(WEBUserIPAddress))
            sqlLOGstr.Append("NULL)");
        else
            sqlLOGstr.Append("'" + WEBUserIPAddress  + "'");

        long DBAffctRows;

        SqlCommand DBExSqlCommand;


        if (sqlLOGstr.Length  == 0  ) { return -1;}


        DBConnect();
        if (SQLDBConnection.State != ConnectionState.Open)
            return -1;

        DBExSqlCommand = new SqlCommand(sqlLOGstr.ToString(), SQLDBConnection);
        DBExSqlCommand.CommandType = CommandType.Text;

        try
        {           
            DBAffctRows = DBExSqlCommand.ExecuteNonQuery();
            DBExSqlCommand.Dispose();
        }
        catch
        {
         DBExSqlCommand.Dispose();
         SQLDBConnection.Close();
         return -1;               
        }

        if (DBAffctRows > 0 ) 
        {
            SQLDBConnection.Close();
            return DBAffctRows;
        }
        else
        {
            SQLDBConnection.Close();
            return -1;
        } //if DBAffctRows
       
    } //enf f_sqlerorlog()
}

} //end namespace