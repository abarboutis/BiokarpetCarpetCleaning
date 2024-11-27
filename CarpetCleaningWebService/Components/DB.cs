using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using System.Text;
using System.Configuration;
using System.Globalization;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace CarpetCleaningMobService
{

    public struct DBType
    {
        public static string ORACLEDB = "ORACLE";
        public static string MSSQLDB = "MSSQL";

    }

    public class DB
    {


        int _sqlcode;
        string _SQLErrText;
        string _SQLStatement;



        public static string _dbtype = DBType.MSSQLDB;

        public SqlConnection MSSQLConnection = new SqlConnection();

        ConnectionStringSettingsCollection connections = ConfigurationManager.ConnectionStrings;
        

        string MSSQLConnectionString = ConfigurationManager.ConnectionStrings["WMSSQLConnectionString"].ToString();

        public void WriteToLog(string message)
        {

            Console.WriteLine(message);
            string filepath;
            long LogMaxSize;


            try
            {
                filepath = ConfigurationManager.AppSettings["LogFilePath"].ToString();
                LogMaxSize = long.Parse(ConfigurationManager.AppSettings["LogMaxSize"].ToString());
                if (!File.Exists(filepath))
                {


                    using (FileStream fs = File.Create(filepath))
                    {
                        Byte[] info = new UTF8Encoding(true).GetBytes("Log File Created  ");
                        fs.Write(info, 0, info.Length);
                    }
                    using (StreamReader sr = File.OpenText(filepath))
                    {
                        string s = "";
                        while ((s = sr.ReadLine()) != null)
                        {
                            Console.WriteLine(s);
                        }
                    }

                }

                // Compose a string that consists of three lines.

                string lines = DateTime.Now.ToString() + " - " + message;
                // Write the string to a file.


                FileInfo f = new FileInfo(filepath);
                long s1 = f.Length;


                if (s1 > LogMaxSize)
                {
                    try
                    {
                        File.WriteAllText(filepath, String.Empty);
                    }
                    catch { }
                }
                TextWriter tsw = new StreamWriter(filepath, true);


                tsw.WriteLine(lines);
                tsw.Close();



            }
            catch
            {


            }

        }
        public DB()
        {
            MSSQLConnection.ConnectionString = MSSQLConnectionString;
        }




        #region Properties

        public string dbtype
        {
            get { return _dbtype; }
        }
        public int sqlcode
        {
            get
            { return _sqlcode; }
            set { _sqlcode = value; }
        }
        public string SQLErrText
        {
            get
            { return _SQLErrText; }
            set { _SQLErrText = value; }
        }
        public string SQLStatement
        {
            get
            { return _SQLStatement; }
            set { _SQLStatement = value; }
        }

        #endregion




        public void DBConnect()
        {
            ConnectionStringSettings consettings = new ConnectionStringSettings();
            MSSQLConnection.ConnectionString = MSSQLConnectionString;
            try
            {
                MSSQLConnection.Open();
            }
            catch (Exception ex)
            {
                sqlcode = -1;
                SQLErrText = ex.ToString();
            }



        }

        public void DBDisconnect()
        {
            if (MSSQLConnection.State == ConnectionState.Open)
            {
                MSSQLConnection.Close();
            }
        }

        //public int GetDBtype() {
        //    //1 MSSQL , 2 ORA
        //   ConnectionStringSettings consettings = new ConnectionStringSettings();

        //    consettings = connections[1];

        //    if (consettings.ProviderName == "System.Data.SqlClient") { return 1; } else { return 2; }

        //}

        public long DBGetNumResultFromSQLSelect(string SqlCmd)
        {

            string CmdResultNum = "";
            SqlDataReader SQLReaderRetSelCmdResult;
            SqlCommand SQLSelectCmd = new SqlCommand();

            SQLSelectCmd.CommandText = SqlCmd;

            if (MSSQLConnection.State != ConnectionState.Open)
            {
                DBConnect();
            }

            SQLSelectCmd.Connection = MSSQLConnection;
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
                f_sqlerrorlog(1, SqlCmd.Replace("'", "|"), ex.ToString(), "WebService");
                SQLErrText = ex.ToString();
                SQLStatement = SqlCmd;
                return -1;
            }

            SQLReaderRetSelCmdResult.Close();

            //
            MSSQLConnection.Close();
            SQLSelectCmd.Dispose();
            //
            try
            {
                if (long.Parse(CmdResultNum) > 0) { return long.Parse(CmdResultNum); } else { return -1; }
            }
            catch
            {

                return -1;
            }



        }

        //MULTIDATABASE READY

        public decimal DBGetDecimalResultFromSQLSelect(string SqlCmd)
        {

            string CmdResult = null;
            decimal rtrnvalue = 0;

            //MSSQL implementation
            SqlDataReader SQLReaderRetSelCmdResult;
            SqlCommand SQLSelectCmd = new SqlCommand();

            SQLSelectCmd.CommandText = SqlCmd;

            if (MSSQLConnection.State != ConnectionState.Open)
            {
                DBConnect();
            }

            if (MSSQLConnection.State != ConnectionState.Open)
            {
                return -10;  //connection failed
            }
            SQLSelectCmd.Connection = MSSQLConnection;
            SQLReaderRetSelCmdResult = SQLSelectCmd.ExecuteReader();


            try
            {
                while (SQLReaderRetSelCmdResult.Read())
                {
                    CmdResult = SQLReaderRetSelCmdResult.GetSqlDecimal(0).ToString();
                }

                if (!string.IsNullOrEmpty(CmdResult))
                {
                    rtrnvalue = decimal.Parse(CmdResult);
                }
            }
            catch (Exception ex)
            {
                SQLErrText = ex.Message.ToString();
                MSSQLConnection.Close();
                SQLSelectCmd.Dispose();
                f_sqlerrorlog(1, SqlCmd.Replace("'", "|"), ex.ToString(), "WebService");
                SQLStatement = SqlCmd;
                return -1;
            }

            SQLReaderRetSelCmdResult.Close();

            //
            MSSQLConnection.Close();
            SQLSelectCmd.Dispose();
            //

            return rtrnvalue;



        } 

        public IDataReader DBReturnDatareaderResults(string SqlCmd)
        {

            SqlDataReader SQLReaderRetSelCmdResult;
            SqlCommand SQLSelectCmd = new SqlCommand();

            SQLSelectCmd.CommandText = SqlCmd;

            if (MSSQLConnection.State != ConnectionState.Open)
            {
                DBConnect();
            }

            if (MSSQLConnection.State != ConnectionState.Open)
                return null;  //connection failed


            try
            {
                SQLSelectCmd.Connection = MSSQLConnection;
                SQLReaderRetSelCmdResult = SQLSelectCmd.ExecuteReader();

                return SQLReaderRetSelCmdResult;
            }
            catch (Exception ex)
            {
                SQLErrText = ex.Message.ToString();
                SQLStatement = SqlCmd;
                f_sqlerrorlog(1, SqlCmd.Replace("'", "|"), ex.ToString(), "WebService");
                return null;
            }



        }

        public string DBGetStrResultFromSQLSelect(string SqlCmd)
        {

            SqlDataReader SQLReaderRetSelCmdResult;
            string CmdResult = null;
            SqlCommand SQLSelectCmd = new SqlCommand();
            SQLSelectCmd.CommandText = SqlCmd;
            if (MSSQLConnection.State != ConnectionState.Open)
                DBConnect();
            if (MSSQLConnection.State != ConnectionState.Open)
                return "-10";  //connection failed

            SQLSelectCmd.Connection = MSSQLConnection;
            SQLReaderRetSelCmdResult = SQLSelectCmd.ExecuteReader();

            try
            {
                while (SQLReaderRetSelCmdResult.Read())
                {
                    CmdResult = SQLReaderRetSelCmdResult.GetString(0).ToString();
                }
            }
            catch (Exception ex)
            {
                SQLReaderRetSelCmdResult.Close();
                MSSQLConnection.Close();
                SQLSelectCmd.Dispose();
                SQLErrText = ex.Message.ToString();
                SQLStatement = SqlCmd;
                f_sqlerrorlog(1, SqlCmd.Replace("'", "|"), ex.ToString(), "WebService");
                return "Null";
            }

            SQLReaderRetSelCmdResult.Close();
            MSSQLConnection.Close();
            SQLSelectCmd.Dispose();

            return CmdResult;


        }

        public DataSet DBFillDataset(String SelectSqlStr, String FillTbl)
        {
            DataSet DbDS = new DataSet();
            if (MSSQLConnection.State != ConnectionState.Open)
                DBConnect();

            if (MSSQLConnection.State != ConnectionState.Open)
                return DbDS;  //connection failed

            SqlDataAdapter SqlDA = new SqlDataAdapter(SelectSqlStr, MSSQLConnection);

            try
            { SqlDA.Fill(DbDS, FillTbl); }
            catch (Exception ex)
            {
                MSSQLConnection.Close();
                SqlDA.Dispose();
                SQLErrText = ex.ToString();
                SQLStatement = SelectSqlStr;
                f_sqlerrorlog(1, SelectSqlStr.Replace("'", "|"), ex.ToString(), "WebService");
                return DbDS;
            }


            MSSQLConnection.Close();
            SqlDA.Dispose();

            return DbDS;


        }

        public DataTable DBFillDataTable(String SelectSqlStr, String FillTbl)
        {
            DataTable DbDT = new DataTable();

            if (MSSQLConnection.State != ConnectionState.Open)
                DBConnect();

            if (MSSQLConnection.State != ConnectionState.Open)
            {
                sqlcode = -1;
                return DbDT;  //connection failed

            }
            SqlDataAdapter SqlDA = new SqlDataAdapter(SelectSqlStr, MSSQLConnection);

            try
            { SqlDA.Fill(DbDT); }
            catch (Exception ex)
            { SQLErrText = ex.ToString();
            MSSQLConnection.Close();
            SqlDA.Dispose();
            f_sqlerrorlog(1, SelectSqlStr.Replace("'", "|"), ex.ToString(), "WebService");
            return DbDT;
            }
            MSSQLConnection.Close();
            SqlDA.Dispose();
            return DbDT;

        } 

        public long DBExecuteSQLCmd(String SqlExCmd)
        {
            long DBAffctRows;



            SqlCommand DBExSqlCommand;
            if (SqlExCmd.Length == 0 || SqlExCmd == "") { return -10; }
            try
            {
                if (MSSQLConnection.State != ConnectionState.Open)
                    DBConnect();
                if (MSSQLConnection.State != ConnectionState.Open)
                {
                    sqlcode = -1;
                    return -1;  //connection failed
                }

                DBExSqlCommand = new SqlCommand(SqlExCmd, MSSQLConnection);


                DBExSqlCommand.CommandType = CommandType.Text;
                DBAffctRows = DBExSqlCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                SQLErrText = ex.Message.ToString();
                MSSQLConnection.Close();
                WriteToLog(ex.ToString());
                f_sqlerrorlog(1, SqlExCmd.Replace("'", "|"), SQLErrText, "WebService");
                return -1;
            }
            if (DBAffctRows > 0)
            {
                MSSQLConnection.Close();
                return DBAffctRows;
            }
            else
            {
                MSSQLConnection.Close();
                return -1;


            } //MULTIDATABASE READY
        }

        public DataSet FDBFillDatasetFromSPWithParm(SqlCommand MyCommand, String FillTbl)
        {

            DataSet DbDS = new DataSet();

            SqlCommand SPCommand = new SqlCommand();
            SPCommand = MyCommand;
            DBConnect();
            if (MSSQLConnection.State != ConnectionState.Open)
            {
                sqlcode = -1;
                return DbDS;  //connection failed

            }

            SqlDataAdapter MysQLDA = new SqlDataAdapter(SPCommand);

            SPCommand.Connection = MSSQLConnection;
            MysQLDA.Fill(DbDS);

            MysQLDA.Dispose();
            MSSQLConnection.Close();
            SPCommand.Dispose();
            return DbDS;

        }
        
        public string DBDateFormatstring(string indate)
        {
            if (_dbtype == DBType.MSSQLDB)
                return "COVERT(DateTime,'" + indate + "',103)";
            else
                return "TO_DATE('" + indate + "','DD/MM/YYYY')";
        }

        public string DBDateTimeFormatstring(string indatetime)
        {
            if (_dbtype == DBType.MSSQLDB)
                return "COVERT(DateTime,'" + indatetime + "',103)";
            else
                return "TO_DATE('" + indatetime + "','DD/MM/YYYY HH:MM:SS')";
        }

        public string DBShortDatetoString(string indate)
        {
            IFormatProvider MyDateTimeFormat = new CultureInfo("el-GR");
            string shortdate = null;

            try
            {
                DateTime dt = DateTime.Parse(indate, MyDateTimeFormat);
                shortdate = dt.Day.ToString() + "/" + dt.Month.ToString() + "/" + dt.Year.ToString();
            }
            catch { }

            return shortdate;
        }

        public void f_sqlerrorlog(int CompId, String SrcCodeSnippet, String SqlErrText, String AppUserName)
        {

            StringBuilder sqlLOGstr = new StringBuilder();
            String AppUserStr = "";
            String CompIdStr = "";
            String LogSqlErrText = "";

            WriteToLog(SqlErrText);
            if (CompId > 0)
            {
                CompIdStr = CompId.ToString();
            }
            else
            {
                CompIdStr = "1";
            }

            if (AppUserName.Length > 0)
            {
                AppUserStr = AppUserName;
            }
            else
            {
                AppUserStr = "NULL";
            }

            if (SrcCodeSnippet.Length > 0)
            {
                LogSqlErrText = SrcCodeSnippet;
            }
            else
            {
                LogSqlErrText = ">>";
            }




            sqlLOGstr.Append("INSERT INTO TSYSEVENTLOGS(COMPID,LOGDATE,DBERRORCODE,DBErrorText,APPUSER)  ");
            sqlLOGstr.Append(" VALUES (" + CompIdStr + ",GETDATE(),'" + SqlErrText.Replace("'","|") + "','");
            sqlLOGstr.Append(LogSqlErrText.Replace("'", "|") + "','" + AppUserStr + "')");

            long DBAffctRows;

            SqlCommand DBExSqlCommand;


            if (sqlLOGstr.Length == 0 || sqlLOGstr.ToString() == "") { return; }

            DBExSqlCommand = new SqlCommand(sqlLOGstr.ToString(), MSSQLConnection);

            try
            {
                DBConnect();



                DBExSqlCommand.CommandType = CommandType.Text;
                DBAffctRows = DBExSqlCommand.ExecuteNonQuery();
            }
            catch
            {
                DBExSqlCommand.Dispose();
                MSSQLConnection.Close();
                return;
                // throw (ex);    // Rethrowing exception e
            }

            if (DBAffctRows > 0)
            {
                DBExSqlCommand.Dispose();
                MSSQLConnection.Close();
                return;
            }
            else
            {
                DBExSqlCommand.Dispose();
                MSSQLConnection.Close();
                return;
            }



        }
      


    }
}
