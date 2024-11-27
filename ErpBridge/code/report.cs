using System;
using System.Data;
using System.Globalization;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Linq;
using AtlantisWSClient;

namespace ReportGenerator
{

    public static class GlobVariables
    {
        public static DBTrans mydbtrans;
        public static string filename { get; set; }
        public static WebService.WMSSyncService webServiceProvider = new WebService.WMSSyncService();
        public static  AtlantisWSClientController awscontroller;
        public static string atluser { get; set; }
        public static string atlpass { get; set; }
        public static short erpbranchid { get; set; }
        public static string atlserviceurl { get; set; }
        public static string dbconstring { get; set; }
 

    }



    public class AppSettings
    {
    
            public void LoadSettings()
            {
                appsetlib.appsetfilesettings settings = appsetlib.appsetfilesettings.setxmlappsettingsdefault();
                settings.readsettings();
                GlobVariables.atluser = settings.returnsettingval("ATLANTISUSER");
                GlobVariables.atlpass = settings.returnsettingval("ATLANTISPASS");
                GlobVariables.erpbranchid = short.Parse(settings.returnsettingval("ERPBRANCHID"));
                GlobVariables.atlserviceurl = settings.returnsettingval("SERVICEURL");
                GlobVariables.webServiceProvider.Url = settings.returnsettingval("LOCALSERVICEURL");
                GlobVariables.dbconstring = settings.returnsettingval("SQLCONSTRING");
            //    GlobVariables.webServiceProvider.Url = ConfigurationManager.AppSettings["ServiceURL"].ToString();
                GlobVariables.webServiceProvider.Timeout = 100000;
                GlobVariables.awscontroller = new AtlantisWSClientController(GlobVariables.atlserviceurl);
                GlobVariables.mydbtrans = new DBTrans();


            }
    
    }

    class StoreTrans
    {

        public static string filename { get; set; }
        List<TransHeader> lh = new List<TransHeader>();
        List<TransDetail> ldtl = new List<TransDetail>();
        string sqlstr;
        string reportdate;

        public int CancelErpSend() 
        {
            long wmstransid = 0;


                try {
                    wmstransid = GlobVariables.mydbtrans.DBGetNumResultFromSQLSelect("select isnull(max(wmstransid),0) from TCancelErpSend");
                }
                catch { }

                if (wmstransid > 0) 
                {
                    try
                    {
                        if (GlobVariables.webServiceProvider.CarpetCleaningCancelTrans(wmstransid) > 0) 
                        {
                            GlobVariables.mydbtrans.DBExecuteSQLCmd("DELETE FROM TCancelErpSend WHERE wmstransid = " + wmstransid.ToString());
                        }
                    }
                    catch{}
                }
                 

            return 1;

        }


        public void SendTransactionsToERP()
        {
            lh.Clear();
            ldtl.Clear();
            StringBuilder sqlstr = new StringBuilder();
           // if (extracriteria.Length > 0) extracriteria += " AND " + extracriteria;


            sqlstr.Append(" SELECT DISTINCT ERPCOMPID,ERPBRACHID,WMSTRANSID,AlpisStoreTransID,AlpisStoreTransDate, ERPTransSeriesID, ERPCustomerID,ERPSupplierID, ERPTransCode, ");
            sqlstr.Append(" ERPFromStoreID, ERPToStoreID, 1 AS LOCALRATE,1 AS CURID,1 AS APPROVED FROM ZCLEANINGCARPETSTRANS WHERE ERPBRACHID =  " + GlobVariables.erpbranchid.ToString());
            sqlstr.Append(" AND ISNEW = 1 ");
            //sqlstr.Append(" SELECT DISTINCT ERPCOMPID,ERPBRACHID,ALPISSTORETRANSID,ALPISSTORETRANSDATE,ERPTRANSSERIESID,ERPCUSTOMERID, ");
            //sqlstr.Append(" ERPSUPPLIERID,ERPTRANSCODE,ERPFROMSTOREID,ERPTOSTOREID,SHIPPINGID,DOCTYPE ");
            //sqlstr.Append(" FROM ZALPISEXALCOSTORESTRANS WHERE ERPBRACHID =  " + branchid.ToString());
            // sqlstr.Append(" AND ALPISSTORETRANSID IN ( 129984,129966 ) ");
            //sqlstr.Append(" AND ISNEW = 1 ");
            //sqlstr.Append(extracriteria);


            GlobVariables.mydbtrans.mssqlDR = GlobVariables.mydbtrans.returnAsDataReader(sqlstr.ToString());
            while (GlobVariables.mydbtrans.mssqlDR.Read())
            {
                TransHeader h = new TransHeader();
                if (GlobVariables.mydbtrans.mssqlDR["ALPISSTORETRANSID"] != DBNull.Value) h.alpisstoretransid = int.Parse(GlobVariables.mydbtrans.mssqlDR["ALPISSTORETRANSID"].ToString());
                if (GlobVariables.mydbtrans.mssqlDR["ERPCOMPID"] != DBNull.Value) h.comid = int.Parse(GlobVariables.mydbtrans.mssqlDR["ERPCOMPID"].ToString());
                if (GlobVariables.mydbtrans.mssqlDR["ERPBRACHID"] != DBNull.Value) h.braid = int.Parse(GlobVariables.mydbtrans.mssqlDR["ERPBRACHID"].ToString());
                if (GlobVariables.mydbtrans.mssqlDR["ALPISSTORETRANSDATE"] != DBNull.Value) h.ftrdate = DateTime.Parse(GlobVariables.mydbtrans.mssqlDR["ALPISSTORETRANSDATE"].ToString()).ToString("dd/MM/yyyy"); ;
                if (GlobVariables.mydbtrans.mssqlDR["ERPTRANSSERIESID"] != DBNull.Value) h.dsrid = long.Parse(GlobVariables.mydbtrans.mssqlDR["ERPTRANSSERIESID"].ToString());
                if (GlobVariables.mydbtrans.mssqlDR["ERPCUSTOMERID"] != DBNull.Value) h.erpcustomerid = long.Parse(GlobVariables.mydbtrans.mssqlDR["ERPCUSTOMERID"].ToString());
                if (GlobVariables.mydbtrans.mssqlDR["APPROVED"] != DBNull.Value) h.approved = short.Parse(GlobVariables.mydbtrans.mssqlDR["APPROVED"].ToString());
                if (GlobVariables.mydbtrans.mssqlDR["ERPTRANSCODE"] != DBNull.Value) h.tradecode = GlobVariables.mydbtrans.mssqlDR["ERPTRANSCODE"].ToString();
                if (GlobVariables.mydbtrans.mssqlDR["ERPFROMSTOREID"] != DBNull.Value) h.stoid = long.Parse(GlobVariables.mydbtrans.mssqlDR["ERPFROMSTOREID"].ToString());
                if (GlobVariables.mydbtrans.mssqlDR["ERPTOSTOREID"] != DBNull.Value) h.secstoid = long.Parse(GlobVariables.mydbtrans.mssqlDR["ERPTOSTOREID"].ToString());
                if (GlobVariables.mydbtrans.mssqlDR["WMSTRANSID"] != DBNull.Value) h.shippingid = int.Parse(GlobVariables.mydbtrans.mssqlDR["WMSTRANSID"].ToString());
                lh.Add(h);


            }

            if (lh.Count == 0) { return; }

            StringBuilder storetransids = new StringBuilder();
            for (int i = 0; i < lh.Count; i++)
            {
                if (i == lh.Count - 1)
                {
                    storetransids.Append(lh[i].alpisstoretransid.ToString());
                }
                else
                {
                    storetransids.Append(lh[i].alpisstoretransid.ToString() + ",");
                }

            }
            // ISNEW = 1 AND
            GlobVariables.mydbtrans.mssqlDR.Close();
            GlobVariables.mydbtrans.mssqlDR = GlobVariables.mydbtrans.returnAsDataReader(" SELECT * FROM ZCLEANINGCARPETSTRANS WHERE ISNEW = 1 AND ALPISSTORETRANSID IN (" + storetransids.ToString() + ")");


            while (GlobVariables.mydbtrans.mssqlDR.Read())
            {
                TransDetail tdtl = new TransDetail();
                if (GlobVariables.mydbtrans.mssqlDR["ALPISSTORETRANSID"] != DBNull.Value) tdtl.header.alpisstoretransid = int.Parse(GlobVariables.mydbtrans.mssqlDR["ALPISSTORETRANSID"].ToString());
                if (GlobVariables.mydbtrans.mssqlDR["ERPCOMPID"] != DBNull.Value) tdtl.header.comid = int.Parse(GlobVariables.mydbtrans.mssqlDR["ERPCOMPID"].ToString());
                if (GlobVariables.mydbtrans.mssqlDR["ERPBRACHID"] != DBNull.Value) tdtl.header.braid = int.Parse(GlobVariables.mydbtrans.mssqlDR["ERPBRACHID"].ToString());
                if (GlobVariables.mydbtrans.mssqlDR["ALPISSTORETRANSDATE"] != DBNull.Value) tdtl.header.ftrdate = DateTime.Parse(GlobVariables.mydbtrans.mssqlDR["ALPISSTORETRANSDATE"].ToString()).ToString("dd/MM/yyyy"); ;
                if (GlobVariables.mydbtrans.mssqlDR["ERPTRANSSERIESID"] != DBNull.Value) tdtl.header.dsrid = long.Parse(GlobVariables.mydbtrans.mssqlDR["ERPTRANSSERIESID"].ToString());
                if (GlobVariables.mydbtrans.mssqlDR["ERPCUSTOMERID"] != DBNull.Value) tdtl.header.erpcustomerid = long.Parse(GlobVariables.mydbtrans.mssqlDR["ERPCUSTOMERID"].ToString());
                if (GlobVariables.mydbtrans.mssqlDR["ERPTRANSCODE"] != DBNull.Value) tdtl.header.tradecode = GlobVariables.mydbtrans.mssqlDR["ERPTRANSCODE"].ToString();
                if (GlobVariables.mydbtrans.mssqlDR["ERPFROMSTOREID"] != DBNull.Value) tdtl.header.stoid = long.Parse(GlobVariables.mydbtrans.mssqlDR["ERPFROMSTOREID"].ToString());
                if (GlobVariables.mydbtrans.mssqlDR["ERPTOSTOREID"] != DBNull.Value) tdtl.header.secstoid = long.Parse(GlobVariables.mydbtrans.mssqlDR["ERPTOSTOREID"].ToString());
                if (GlobVariables.mydbtrans.mssqlDR["WMSTRANSID"] != DBNull.Value) tdtl.header.shippingid = int.Parse(GlobVariables.mydbtrans.mssqlDR["WMSTRANSID"].ToString());


                if (GlobVariables.mydbtrans.mssqlDR["ERPITEMID"] != DBNull.Value) tdtl.erpitemid = long.Parse(GlobVariables.mydbtrans.mssqlDR["ERPITEMID"].ToString());

                if (GlobVariables.mydbtrans.mssqlDR["ERPITEMMUNIT"] != DBNull.Value) tdtl.erpitemmunit = short.Parse(GlobVariables.mydbtrans.mssqlDR["ERPITEMMUNIT"].ToString());
                if (GlobVariables.mydbtrans.mssqlDR["ITEMMAINCATID"] != DBNull.Value) tdtl.itemmaincatid = int.Parse(GlobVariables.mydbtrans.mssqlDR["ITEMMAINCATID"].ToString());
                if (GlobVariables.mydbtrans.mssqlDR["ERPITEMUNITPRICE"] != DBNull.Value) tdtl.munitprice = decimal.Parse(GlobVariables.mydbtrans.mssqlDR["ERPITEMUNITPRICE"].ToString());
                if (GlobVariables.mydbtrans.mssqlDR["ORDERBUNDLES"] != DBNull.Value) tdtl.orderbundles = int.Parse(GlobVariables.mydbtrans.mssqlDR["ORDERBUNDLES"].ToString());
                if (GlobVariables.mydbtrans.mssqlDR["ERPITEMQTY"] != DBNull.Value) tdtl.primaryqty = decimal.Parse(GlobVariables.mydbtrans.mssqlDR["ERPITEMQTY"].ToString());
                if (GlobVariables.mydbtrans.mssqlDR["ERPITEMSQTY"] != DBNull.Value) tdtl.secondaryqty = decimal.Parse(GlobVariables.mydbtrans.mssqlDR["ERPITEMSQTY"].ToString());
                if (GlobVariables.mydbtrans.mssqlDR["DISCPRICE"] != DBNull.Value) tdtl.discountprice = decimal.Parse(GlobVariables.mydbtrans.mssqlDR["DISCPRICE"].ToString());


                if (tdtl.erpitemmunit == 13) tdtl.linevalue = tdtl.munitprice * tdtl.secondaryqty; else tdtl.linevalue = tdtl.munitprice * tdtl.primaryqty;


                ldtl.Add(tdtl);


            }

            GlobVariables.mydbtrans.mssqlDR.Close();


            foreach (TransHeader h in lh)
            {
                List<TransDetail> ldoc = ldtl.Where(TransDetailsItem => TransDetailsItem.header.alpisstoretransid == h.alpisstoretransid).ToList();
                if (!GlobVariables.awscontroller.CreateCall(h, ldoc, GlobVariables.atluser, GlobVariables.atlpass).transok) return;
                GlobVariables.mydbtrans.DBExecuteSQLCmd("UPDATE ZCLEANINGCARPETSTRANS SET ISNEW = 0  WHERE ALPISSTORETRANSID = " + h.alpisstoretransid);


            }



        }


        public int GetStoretransDetails() 
        {

        StringBuilder sqlstr = new StringBuilder();
        long prodorderid = 0;
        int ReportType = 0;
        sqlstr.Append("SELECT TRANSID,ERPCompID, ERPBRACHID ,AlpisStoreTransID,WMSTRANSID, (CAST(DAY(AlpisStoreTransDate) as VARCHAR)+'/'+CAST(month(AlpisStoreTransDate) as VARCHAR)+'/'+CAST(year(AlpisStoreTransDate) as VARCHAR)) as  AlpisStoreTransDate, ");
        sqlstr.Append("ERPTransSeriesID, ERPCustomerID,ERPSupplierID,ERPFromStoreID, ");
        sqlstr.Append("ERPToStoreID, ERPItemID, ERPItemMUnit,ERPITEMSMUNIT,");
        sqlstr.Append("ERPItemQty,ERPITEMSQTY,ERPItemUnitPrice, ERPItemQtyPrice,EXTRASERVICE,ERPTRANSCODE,DOCTYPE,isnew from ZCLEANINGCARPETSTRANS");

        DataTable dt = GlobVariables.mydbtrans.DBFillDataTable(sqlstr.ToString(), "ReportHeader");

        WebService.CarpetTrans[] TransList;

        TransList = new WebService.CarpetTrans[dt.Rows.Count];
        if (dt.Rows.Count == 0) return -1;

        for (int i = 0;i<dt.Rows.Count; i++) 
        {
            TransList[i] = new WebService.CarpetTrans();
                if (!(dt.Rows[i]["ERPCompID"] == DBNull.Value)) TransList[i].ERPCompID = short.Parse(dt.Rows[i]["ERPCompID"].ToString());
                if (!(dt.Rows[i]["ERPBRACHID"] == DBNull.Value)) TransList[i].ERPBRACHID = short.Parse(dt.Rows[i]["ERPBRACHID"].ToString());
                if (!(dt.Rows[i]["DOCTYPE"] == DBNull.Value)) TransList[i].DOCTYPE = long.Parse(dt.Rows[i]["DOCTYPE"].ToString());
                if (!(dt.Rows[i]["AlpisStoreTransID"] == DBNull.Value)) TransList[i].AlpisStoreTransID = long.Parse(dt.Rows[i]["AlpisStoreTransID"].ToString());
                if (!(dt.Rows[i]["AlpisStoreTransDate"] == DBNull.Value)) TransList[i].AlpisStoreTransDate = dt.Rows[i]["ALPISSTORETRANSDATE"].ToString();
                if (!(dt.Rows[i]["ERPITEMSQTY"] == DBNull.Value)) TransList[i].ERPITEMSQTY = decimal.Parse(dt.Rows[i]["ERPITEMSQTY"].ToString());
                if (!(dt.Rows[i]["ERPItemQtyPrice"] == DBNull.Value)) TransList[i].ERPItemQtyPrice = decimal.Parse(dt.Rows[i]["ERPItemQtyPrice"].ToString());
                if (!(dt.Rows[i]["ERPItemUnitPrice"] == DBNull.Value)) TransList[i].ERPItemUnitPrice = decimal.Parse(dt.Rows[i]["ERPItemUnitPrice"].ToString());
                if (!(dt.Rows[i]["ERPSupplierID"] == DBNull.Value)) TransList[i].ERPSupplierID = long.Parse(dt.Rows[i]["ERPSupplierID"].ToString());
                if (!(dt.Rows[i]["ERPToStoreID"] == DBNull.Value)) TransList[i].ERPToStoreID = long.Parse(dt.Rows[i]["ERPToStoreID"].ToString());
                if (!(dt.Rows[i]["ERPTRANSCODE"] == DBNull.Value)) TransList[i].ERPTRANSCODE = dt.Rows[i]["ERPTRANSCODE"].ToString();
                if (!(dt.Rows[i]["ERPTransSeriesID"] == DBNull.Value)) TransList[i].ERPTransSeriesID = long.Parse(dt.Rows[i]["ERPTransSeriesID"].ToString());
                if (!(dt.Rows[i]["EXTRASERVICE"] == DBNull.Value)) TransList[i].EXTRASERVICE = dt.Rows[i]["EXTRASERVICE"].ToString();
                if (!(dt.Rows[i]["isnew"] == DBNull.Value)) TransList[i].isnew = short.Parse(dt.Rows[i]["isnew"].ToString());
                if (!(dt.Rows[i]["TRANSID"] == DBNull.Value)) TransList[i].TRANSID = long.Parse(dt.Rows[i]["TRANSID"].ToString());
                if (!(dt.Rows[i]["WMSTRANSID"] == DBNull.Value)) TransList[i].WMSTRANSID = long.Parse(dt.Rows[i]["WMSTRANSID"].ToString());
                if (!(dt.Rows[i]["ERPItemQty"] == DBNull.Value)) TransList[i].ERPItemQty = decimal.Parse(dt.Rows[i]["ERPItemQty"].ToString());
                if (!(dt.Rows[i]["ERPItemMUnit"] == DBNull.Value)) TransList[i].ERPItemMUnit = long.Parse(dt.Rows[i]["ERPItemMUnit"].ToString());
                if (!(dt.Rows[i]["ERPITEMSMUNIT"] == DBNull.Value)) TransList[i].ERPItemSMUnit = long.Parse(dt.Rows[i]["ERPITEMSMUNIT"].ToString());
                if (!(dt.Rows[i]["ERPItemID"] == DBNull.Value)) TransList[i].ERPItemID = long.Parse(dt.Rows[i]["ERPItemID"].ToString());
                if (!(dt.Rows[i]["ERPFromStoreID"] == DBNull.Value)) TransList[i].ERPFromStoreID = long.Parse(dt.Rows[i]["ERPFromStoreID"].ToString());
                 if (!(dt.Rows[i]["ERPCustomerID"] == DBNull.Value)) TransList[i].ERPCustomerID = long.Parse(dt.Rows[i]["ERPCustomerID"].ToString());
            
       
        }







        GlobVariables.webServiceProvider.CarpetCleaningTrans(TransList);

       return 1;
        }

        public void cleartempDB() 
        {
            GlobVariables.mydbtrans.DBExecuteSQLCmd("DELETE FROM ZCLEANINGCARPETSTRANS");
        
        }


    }

    class CustomerTasks
    {
                
     
        
        public void cleartempDB()
        {
            GlobVariables.mydbtrans.DBExecuteSQLCmd("DELETE FROM TGETCUSTOMER");

        }


        public void updateCustomerFromERP(string customercode,long customerid) 
        {
            StringBuilder sqlstr = new StringBuilder();
            WebService.Customer newcustomer = new WebService.Customer();
            newcustomer = GlobVariables.webServiceProvider.GetCustomerbycode(customercode);

        //    COMPID,CUSTOMERCODE,CUSTOMERCODE2,CUSTOMERTITLE,");
         //       sqlstr.Append("OCCUPATION,ADDRESS,ZIP,CITY, FAX,PHONE1,PHONE2,ERPID,ERPCODE) VALUES (1,");


           sqlstr.Append("UPDATE TCUSTOMERS SET ");
           if (!string.IsNullOrEmpty(newcustomer.CustomerTitle)) sqlstr.Append("CUSTOMERTITLE = '"+newcustomer.CustomerTitle+"',"); else   sqlstr.Append("CUSTOMERTITLE=NULL,");
           if (!string.IsNullOrEmpty(newcustomer.Occupation)) sqlstr.Append("Occupation = '"+newcustomer.Occupation+"',"); else   sqlstr.Append("Occupation=NULL,");
           if (!string.IsNullOrEmpty(newcustomer.STREET1)) sqlstr.Append("Address = '" + newcustomer.STREET1 + "',"); else sqlstr.Append("Address=NULL,");
           if (!string.IsNullOrEmpty(newcustomer.ZIPCODE1)) sqlstr.Append("zip = '"+newcustomer.ZIPCODE1+"',"); else   sqlstr.Append("zip=NULL,");
           if (!string.IsNullOrEmpty(newcustomer.CITY1)) sqlstr.Append("city = '"+newcustomer.CITY1+"',"); else   sqlstr.Append("city=NULL,");
           if (!string.IsNullOrEmpty(newcustomer.FAX1)) sqlstr.Append("Fax = '" + newcustomer.FAX1 + "',"); else sqlstr.Append("Fax=NULL,");
           if (!string.IsNullOrEmpty(newcustomer.phone1)) sqlstr.Append("phone1 = '" + newcustomer.phone1 + "',"); else sqlstr.Append("phone1=NULL,");
           if (!string.IsNullOrEmpty(newcustomer.phone2)) sqlstr.Append("phone2 = '" + newcustomer.phone2 + "',"); else sqlstr.Append("phone2=NULL,");
           if (!string.IsNullOrEmpty(newcustomer.CustomerCode)) sqlstr.Append("CustomerCode = '" + newcustomer.CustomerCode + "',"); else sqlstr.Append("CustomerCode=NULL,");
           if (newcustomer.erpCustomerID > 0) sqlstr.Append("erpid=" + newcustomer.erpCustomerID.ToString()); else sqlstr.Append("erpid=NULL");
            sqlstr.Append(" WHERE CUSTOMERID = "+customerid.ToString());
            GlobVariables.mydbtrans.DBExecuteSQLCmd(sqlstr.ToString());
           cleartempDB();
           return;
        }

        public void InsertCustomerFromERP() 
        {
            GlobVariables.mydbtrans.DBConnect();
         
         StringBuilder sqlstr = new StringBuilder();
        string customercode = "";
        string rtn;
        long customerid;
        customercode = GlobVariables.mydbtrans.DBSelectCmdRStr2Str("SELECT CUSTOMERCODE FROM TGETCUSTOMER");
        if ((customercode != "")||(customercode != "Null"))
            {
            //Check if customerexists or no

                customerid = GlobVariables.mydbtrans.DBGetNumResultFromSQLSelect("SELECT customerid FROM TCUSTOMERS WHERE CUSTOMERCODE = '" + customercode + "'");
               if (customerid > 0)
               {
               //update customer
                   updateCustomerFromERP(customercode, customerid);
                   return;
               }
                WebService.Customer newcustomer = new WebService.Customer();
                newcustomer = GlobVariables.webServiceProvider.GetCustomerbycode(customercode);
                sqlstr.Append("	INSERT INTO TCUSTOMERS(COMPID,CUSTOMERCODE,CUSTOMERCODE2,CUSTOMERTITLE,");
                sqlstr.Append("OCCUPATION,ADDRESS,ZIP,CITY, FAX,PHONE1,PHONE2,ERPID,ERPCODE) VALUES (1,");
                if (!string.IsNullOrEmpty(newcustomer.CustomerCode)) sqlstr.Append("'"+newcustomer.CustomerCode+"',");else sqlstr.Append("NULL,");
                if (!string.IsNullOrEmpty(newcustomer.ZALPISCODE)) sqlstr.Append("'"+newcustomer.ZALPISCODE+"',"); else sqlstr.Append("NULL,");
                if (!string.IsNullOrEmpty(newcustomer.CustomerTitle)) sqlstr.Append("'"+newcustomer.CustomerTitle+"',");   else  sqlstr.Append("NULL,");
                if (!string.IsNullOrEmpty(newcustomer.Occupation))  sqlstr.Append("'"+newcustomer.Occupation+"',"); else    sqlstr.Append("NULL,");
                if (!string.IsNullOrEmpty(newcustomer.STREET1))  sqlstr.Append("'"+newcustomer.STREET1+"',");    else  sqlstr.Append("NULL,");
                if (newcustomer.ZIPCODE1 != "")    sqlstr.Append("'"+newcustomer.ZIPCODE1+"',");  else  sqlstr.Append("NULL,");
                if (!string.IsNullOrEmpty(newcustomer.CITY1)) sqlstr.Append("'"+newcustomer.CITY1+"',");else sqlstr.Append("NULL,");
                if (!string.IsNullOrEmpty(newcustomer.FAX1)) sqlstr.Append("'"+newcustomer.FAX1+"',");else sqlstr.Append("NULL,");
                if (!string.IsNullOrEmpty(newcustomer.phone1))sqlstr.Append("'"+newcustomer.phone1+"',");  else sqlstr.Append("NULL,");
                if (!string.IsNullOrEmpty(newcustomer.phone2))    sqlstr.Append("'"+newcustomer.phone2+"',"); else   sqlstr.Append("NULL,");
                if (newcustomer.erpCustomerID > 0) sqlstr.Append( newcustomer.erpCustomerID+",");   else  sqlstr.Append("NULL,");
                if (!string.IsNullOrEmpty(newcustomer.CustomerCode))   sqlstr.Append("'"+newcustomer.CustomerCode+"')"); else  sqlstr.Append("NULL)");
                GlobVariables.mydbtrans.DBExecuteSQLCmd(sqlstr.ToString());
                cleartempDB();
                return;

        }
        return;
        
        }
    }
}

