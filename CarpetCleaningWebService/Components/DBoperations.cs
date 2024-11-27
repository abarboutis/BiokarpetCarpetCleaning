using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Xml;
using System.Web;
using System.IO;
using System.Configuration;


namespace CarpetCleaningMobService
{

#region shipping

public class WMSTRANS
{

DB db = new DB();
long binitemqtyid;

    public List<TwmsTrans> GetWmsTrans(short compid, short branchid, short status,int wmstranstypeid)
            {
                List<TwmsTrans> WmsTransData = new List<TwmsTrans>();
                StringBuilder sqlstr = new StringBuilder();
                sqlstr.Append("SELECT compid,branchid,wmstransid,(CAST(DAY(wmstransdate) as VARCHAR)+'-'+CAST(month(wmstransdate) as VARCHAR)+'-'+CAST(year(wmstransdate) as VARCHAR)) as wmstransdate,comments FROM TWMSTRANS");
                sqlstr.Append(" WHERE isnull(confirmed,0) <> 1 AND wmstranstypeid = " + wmstranstypeid.ToString());

                IDataReader dr = db.DBReturnDatareaderResults(sqlstr.ToString());
       
                if (dr != null)
                {
                    while (dr.Read())
                    {
                        TwmsTrans wmstrans = new TwmsTrans();
                        if (dr["wmstransid"] != DBNull.Value) wmstrans.wmstransid = long.Parse(dr["wmstransid"].ToString());
                        if (dr["wmstransdate"] != DBNull.Value) wmstrans.wmstransdate = dr["wmstransdate"].ToString();
                        if (dr["comments"] != DBNull.Value) wmstrans.comments = dr["comments"].ToString();

                        WmsTransData.Add(wmstrans);
                        wmstrans = null;
                    }
                }

                db.DBDisconnect();
                return WmsTransData;
            }

    public List<TWmsBinStoretrans> GetWmsStoreTrans(long wmstranid)
    {
        StringBuilder sqlstr = new StringBuilder();
        List<TWmsBinStoretrans> WmsTransData = new List<TWmsBinStoretrans>();

       sqlstr.Append(" SELECT     TCustomers.CustomerTitle as CustomerTitle,TOrderDetails.orderdtlid as orderdtlid, TWMSBINSTORETRANS.BINSTORETRANSID as BINSTORETRANSID, TWMSBINSTORETRANS.ITEMQTYPRIMARY as ITEMQTYPRIMARY,");
       sqlstr.Append(" TItems.ItemDesc as ItemDesc,TWMSTRANS.wmstransid as wmstransid FROM     TWMSBINSTORETRANS INNER JOIN ");
       sqlstr.Append("               TWMSTRANS ON TWMSBINSTORETRANS.WMSTRANSID = TWMSTRANS.wmstransid INNER JOIN ");
       sqlstr.Append("               TItems ON TWMSBINSTORETRANS.ITEMID = TItems.ItemID INNER JOIN ");
       sqlstr.Append("               TOrderDetails ON TWMSBINSTORETRANS.ORDERDTLID = TOrderDetails.OrderdtlID INNER JOIN ");
       sqlstr.Append("               TOrders ON TOrderDetails.OrderID = TOrders.OrderID INNER JOIN ");
       sqlstr.Append("               TCustomers ON TOrders.CustomerID = TCustomers.CustomerID ");
       sqlstr.Append("        WHERE  TWMSTRANS.wmstransid = " + wmstranid.ToString());

        IDataReader dr = db.DBReturnDatareaderResults(sqlstr.ToString());

        if (dr != null)
        {
            while (dr.Read())
            {
                TWmsBinStoretrans wmstrans = new TWmsBinStoretrans();
                if (dr["orderdtlid"] != DBNull.Value) wmstrans.orderdtlid = long.Parse(dr["orderdtlid"].ToString());
                if (dr["binstoretransid"] != DBNull.Value) wmstrans.binstoretransid = long.Parse(dr["binstoretransid"].ToString());
                if (dr["customertitle"] != DBNull.Value) wmstrans.customertitle = dr["customertitle"].ToString();
                if (dr["wmstransid"] != DBNull.Value) wmstrans.wmstransid = long.Parse(dr["wmstransid"].ToString());
                if (dr["ItemDesc"] != DBNull.Value) wmstrans.itemdesc =  dr["ItemDesc"].ToString();
                if (dr["ITEMQTYPRIMARY"] != DBNull.Value) wmstrans.itemqtyprimary = decimal.Parse(dr["ITEMQTYPRIMARY"].ToString());               

                WmsTransData.Add(wmstrans);
                wmstrans = null;
            }
        }

        db.DBDisconnect();
        return WmsTransData;
    }

    public TWmsBinStoretrans GetStoreTransRecord(long BINSTORETRANSID)
    {
        StringBuilder sqlstr = new StringBuilder();
        TWmsBinStoretrans WmsTransRecord = new TWmsBinStoretrans();
        WMSBins wmsbins = new WMSBins();

        
 
  



        sqlstr.Append("SELECT     TCustomers.CustomerTitle, TOrderDetails.ItemWidth, TOrderDetails.ItemLength,  ");
        sqlstr.Append("TWMSBINSTORETRANS.BINSTORETRANSID,TWMSBINSTORETRANS.MUNITPRIMARY AS munitprimary,TWMSBINSTORETRANS.ITEMQTYPRIMARY, TItems.ItemDesc, TItems.ItemID AS itemid,   ");
        sqlstr.Append("TWMSBINSTORETRANS.MUNITSECONDARY, TWMSBINSTORETRANS.WHBINID, TWMSBINSTORETRANS.ORDERDTLID AS orderdtlid,   TWMSBINSTORETRANS.ORDERID AS OrderID, TWMSTRANS.wmstransid,TWMSBINS.WHBINCODE ");
        sqlstr.Append("  FROM         TWMSBINSTORETRANS INNER JOIN");
        sqlstr.Append("                TWMSTRANS ON TWMSBINSTORETRANS.WMSTRANSID = TWMSTRANS.wmstransid INNER JOIN");
        sqlstr.Append("                TItems ON TWMSBINSTORETRANS.ITEMID = TItems.ItemID INNER JOIN");
        sqlstr.Append("                 TOrderDetails ON TWMSBINSTORETRANS.ORDERDTLID = TOrderDetails.OrderdtlID INNER JOIN");
        sqlstr.Append("                  TOrders ON TOrderDetails.OrderID = TOrders.OrderID INNER JOIN");
        sqlstr.Append("                  TCustomers ON TOrders.CustomerID = TCustomers.CustomerID INNER JOIN");
        sqlstr.Append("                  TWMSBINS ON TWMSBINSTORETRANS.WHBINID = TWMSBINS.WHBINID");

        sqlstr.Append("        WHERE TWMSBINSTORETRANS.BINSTORETRANSID = " + BINSTORETRANSID.ToString());

        IDataReader dr = db.DBReturnDatareaderResults(sqlstr.ToString());

        if (dr != null)
        {
            while (dr.Read())
            {
                if (dr["whbinid"] != DBNull.Value) WmsTransRecord.whbinid = long.Parse(dr["whbinid"].ToString());
                if (dr["whbincode"] != DBNull.Value) WmsTransRecord.whbincode = dr["whbincode"].ToString();
                if (dr["binstoretransid"] != DBNull.Value) WmsTransRecord.binstoretransid = long.Parse(dr["binstoretransid"].ToString());
                if (dr["customertitle"] != DBNull.Value) WmsTransRecord.customertitle = dr["customertitle"].ToString();
                if (dr["wmstransid"] != DBNull.Value) WmsTransRecord.wmstransid = long.Parse(dr["wmstransid"].ToString());
                if (dr["ItemID"] != DBNull.Value) WmsTransRecord.itemid = long.Parse(dr["itemid"].ToString());
                if (dr["orderdtlid"] != DBNull.Value) WmsTransRecord.orderdtlid = long.Parse(dr["orderdtlid"].ToString());
                if (dr["orderid"] != DBNull.Value) WmsTransRecord.orderid = long.Parse(dr["orderid"].ToString());
                if (dr["munitprimary"] != DBNull.Value) WmsTransRecord.munitprimary = short.Parse(dr["munitprimary"].ToString());
                if (dr["munitsecondary"] != DBNull.Value) WmsTransRecord.munitsecondary = short.Parse(dr["munitsecondary"].ToString());
                if (dr["ItemDesc"] != DBNull.Value) WmsTransRecord.itemdesc = dr["ItemDesc"].ToString();
                if (dr["ITEMQTYPRIMARY"] != DBNull.Value) WmsTransRecord.itemqtyprimary = decimal.Parse(dr["ITEMQTYPRIMARY"].ToString());
                if (dr["ItemWidth"] != DBNull.Value) WmsTransRecord.width = decimal.Parse(dr["ItemWidth"].ToString());
                if (dr["ItemLength"] != DBNull.Value) WmsTransRecord.length = decimal.Parse(dr["ItemLength"].ToString());

            }
        }

        db.DBDisconnect();
        return WmsTransRecord;
    }
    
    
    public TWmsBinItemsQty GetBinItemQtyRecord(long orderdtlid)
    {
        StringBuilder sqlstr = new StringBuilder();
        TWmsBinItemsQty BinItemQtyRecord = new TWmsBinItemsQty();

        sqlstr.Append("         SELECT     TWMSBINITEMSQTY.BINITEMSQTYID,TWMSBINITEMSQTY.WHBINID,TWMSBINITEMSQTY.ITEMID,TWMSBINS.WHBINCODE,TWMSBINITEMSQTY.WMSTRANSID, ");
                sqlstr.Append("TWMSBINITEMSQTY.ITEMQTYPRIMARY, TWMSBINITEMSQTY.MUNITPRIMARY, TWMSBINITEMSQTY.ITEMQTYSECONDARY, ");
                sqlstr.Append("TWMSBINITEMSQTY.MUNITSECONDARY, TWMSBINITEMSQTY.ORDERDTLID, TWMSBINITEMSQTY.ORDERID, TCustomers.CustomerTitle,TItems.ItemDesc ");
                sqlstr.Append(" FROM         TWMSBINITEMSQTY INNER JOIN TOrderDetails ON TWMSBINITEMSQTY.ORDERDTLID = TOrderDetails.OrderdtlID INNER JOIN");
                sqlstr.Append(" TOrders ON TWMSBINITEMSQTY.ORDERID = TOrders.OrderID INNER JOIN TCustomers ON TOrders.CustomerID = TCustomers.CustomerID  ");
                sqlstr.Append(" INNER JOIN TItems ON TOrderDetails.ItemID = TItems.ItemID INNER JOIN dbo.TWMSBINS ON dbo.TWMSBINITEMSQTY.WHBINID = dbo.TWMSBINS.WHBINID");
                sqlstr.Append(" WHERE TWMSBINITEMSQTY.ORDERDTLID = " + orderdtlid.ToString());

        IDataReader dr = db.DBReturnDatareaderResults(sqlstr.ToString());

        if (dr != null)
        {
            while (dr.Read())
            {
                if (dr["BINITEMSQTYID"] != DBNull.Value) BinItemQtyRecord.binitemsqtyid = long.Parse(dr["binitemsqtyid"].ToString());
                if (dr["WHBINID"] != DBNull.Value) BinItemQtyRecord.whbinid =long.Parse(dr["WHBINID"].ToString());
                if (dr["ITEMID"] != DBNull.Value) BinItemQtyRecord.itemid = long.Parse(dr["ITEMID"].ToString());
                if (dr["WMSTRANSID"] != DBNull.Value) BinItemQtyRecord.wmstransid = long.Parse(dr["wmstransid"].ToString());
                if (dr["ITEMQTYPRIMARY"] != DBNull.Value) BinItemQtyRecord.itemqtyprimary = decimal.Parse(dr["ITEMQTYPRIMARY"].ToString());
                if (dr["MUNITPRIMARY"] != DBNull.Value) BinItemQtyRecord.munitprimary = short.Parse(dr["munitprimary"].ToString());
                if (dr["ITEMQTYSECONDARY"] != DBNull.Value) BinItemQtyRecord.itemqtysecondary = decimal.Parse(dr["ITEMQTYSECONDARY"].ToString());
                if (dr["MUNITSECONDARY"] != DBNull.Value) BinItemQtyRecord.munitsecondary = short.Parse(dr["munitsecondary"].ToString());
                if (dr["ORDERDTLID"] != DBNull.Value) BinItemQtyRecord.orderdtlid = long.Parse(dr["orderdtlid"].ToString());
                if (dr["ORDERID"] != DBNull.Value) BinItemQtyRecord.orderid = long.Parse(dr["orderid"].ToString());
                if (dr["CustomerTitle"] != DBNull.Value) BinItemQtyRecord.customertitle = dr["customertitle"].ToString();
                if (dr["ItemDesc"] != DBNull.Value) BinItemQtyRecord.itemdesc = dr["itemdesc"].ToString();
                if (dr["WHBINCODE"] != DBNull.Value) BinItemQtyRecord.whbincode = dr["WHBINCODE"].ToString();
            }
        }

        db.DBDisconnect();
        return BinItemQtyRecord;
    }


    public long InsertWmsTrans(TwmsTrans transdetails)
            {
                StringBuilder sqlstr = new StringBuilder();
                sqlstr.Append("INSERT INTO TWMSTRANS(");
                sqlstr.Append("compid,");
                sqlstr.Append("branchid,");
                sqlstr.Append("userid,");
                sqlstr.Append("wmstranstypeid,");
                sqlstr.Append("status,");
                sqlstr.Append("comments");
                sqlstr.Append(")");
                sqlstr.Append(" VALUES(");


                if (transdetails.compid > 0) sqlstr.Append(transdetails.compid.ToString() + ","); else sqlstr.Append("NULL,");
                if (transdetails.branchid > 0) sqlstr.Append(transdetails.branchid.ToString() + ","); else sqlstr.Append("NULL,");
                if (transdetails.userid > 0) sqlstr.Append(transdetails.userid.ToString() + ","); else sqlstr.Append("NULL,");
                if (transdetails.wmstranstypeid > 0) sqlstr.Append(transdetails.wmstranstypeid.ToString() + ","); else sqlstr.Append("NULL,");
                if (transdetails.status > 0) sqlstr.Append(transdetails.status.ToString() + ","); else sqlstr.Append("NULL,");
                if (!string.IsNullOrEmpty(transdetails.comments)) sqlstr.Append("'" + transdetails.comments + "'"); else sqlstr.Append("NULL");
                sqlstr.Append(")");


                long r = db.DBExecuteSQLCmd(sqlstr.ToString());

                return r;

            }

    public List<TWmsBinItemsQty> WmsBinItemsQtyData(string searchcriteria, string sortcriteria)
            {
                List<TWmsBinItemsQty> BinitemsData = new List<TWmsBinItemsQty>();


                string sqlstr = "SELECT * FROM VWMSBINITEMSQTY";
                if (!string.IsNullOrEmpty(searchcriteria))
                {
                    sqlstr += " WHERE " + searchcriteria;
                }

                if (!string.IsNullOrEmpty(sortcriteria))
                {
                    sqlstr += " ORDER BY " + searchcriteria;
                }


                IDataReader dr = db.DBReturnDatareaderResults(sqlstr);

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        TWmsBinItemsQty binitemsqtyrec = new TWmsBinItemsQty();

                        if (dr["BINITEMSQTYID"] != DBNull.Value) binitemsqtyrec.binitemsqtyid = long.Parse(dr["BINITEMSQTYID"].ToString());
                        if (dr["COMPID"] != DBNull.Value) binitemsqtyrec.compid = short.Parse(dr["COMPID"].ToString());
                        if (dr["BRANCHID"] != DBNull.Value) binitemsqtyrec.branchid = short.Parse(dr["BRANCHID"].ToString());
                        if (dr["WHBINID"] != DBNull.Value) binitemsqtyrec.whbinid = long.Parse(dr["WHBINID"].ToString());
                        if (dr["WHBINTYPE"] != DBNull.Value) binitemsqtyrec.whbintype = short.Parse(dr["WHBINTYPE"].ToString());
                        if (dr["WHBINCODE"] != DBNull.Value) binitemsqtyrec.whbincode = dr["WHBINCODE"].ToString();

                        if (dr["ITEMID"] != DBNull.Value) binitemsqtyrec.itemid = long.Parse(dr["ITEMID"].ToString());
                        if (dr["ITEMLOTID"] != DBNull.Value) binitemsqtyrec.itemlotid = long.Parse(dr["ITEMLOTID"].ToString());

                        if (dr["ITEMQTYPRIMARY"] != DBNull.Value) binitemsqtyrec.itemqtyprimary = decimal.Parse(dr["ITEMQTYPRIMARY"].ToString());
                        if (dr["MUNITPRIMARY"] != DBNull.Value) binitemsqtyrec.munitprimary = short.Parse(dr["MUNITPRIMARY"].ToString());
                        if (dr["ITEMQTYSECONDARY"] != DBNull.Value) binitemsqtyrec.itemqtysecondary = decimal.Parse(dr["ITEMQTYSECONDARY"].ToString());
                        if (dr["MUNITSECONDARY"] != DBNull.Value) binitemsqtyrec.munitsecondary = short.Parse(dr["MUNITSECONDARY"].ToString());
                        if (dr["MUNITPRIMARYDESC"] != DBNull.Value) binitemsqtyrec.munitprimarydesc = dr["MUNITPRIMARYDESC"].ToString();
                        if (dr["MUNITSECONDARYDESC"] != DBNull.Value) binitemsqtyrec.munitsecondarydesc = dr["MUNITSECONDARYDESC"].ToString();
                        if (dr["MUNITSRELATION"] != DBNull.Value) binitemsqtyrec.munitsrelation = decimal.Parse(dr["MUNITSRELATION"].ToString());

                        if (dr["PACKITEMQTY"] != DBNull.Value) binitemsqtyrec.packitemqty = decimal.Parse(dr["PACKITEMQTY"].ToString());
                                          if (dr["ORDERDTLID"] != DBNull.Value) binitemsqtyrec.orderdtlid = long.Parse(dr["ORDERDTLID"].ToString());
                        if (dr["ORDERID"] != DBNull.Value) binitemsqtyrec.orderid = long.Parse(dr["ORDERID"].ToString());
                        if (dr["ROUTEID"] != DBNull.Value) binitemsqtyrec.routeid = long.Parse(dr["ROUTEID"].ToString());
                        binitemsqtyrec.dbreccreatedate = dr["DBRECCREATEDATE"].ToString();
                        if (dr["DBRECCREATEUSER"] != DBNull.Value) binitemsqtyrec.dbreccreateuser = int.Parse(dr["DBRECCREATEUSER"].ToString());
                        binitemsqtyrec.dbrecmoddate = dr["DBRECMODDATE"].ToString();
                        if (dr["DBRECMODUSER"] != DBNull.Value) binitemsqtyrec.dbrecmoduser = int.Parse(dr["DBRECMODUSER"].ToString());


                        BinitemsData.Add(binitemsqtyrec);
                        binitemsqtyrec = null;
                    }
                }

                db.DBDisconnect();
                return BinitemsData;
            }

    public TOrderDetails GetOrderdetails(long orderdtlid)
            
            {
                StringBuilder sqlstr = new StringBuilder();
                TOrderDetails myorderdetailid = new TOrderDetails();
                sqlstr.Append("SELECT     TCustomers.CustomerTitle as CustomerTitle, TItems.ItemDesc as ItemDesc,");
                sqlstr.Append("      TOrderDetails.ItemqtyPrimary as ItemqtyPrimary,TOrderDetails.ItemWidth,TOrderDetails.ItemLength, TOrderDetails.MUnitPrimary as MUnitPrimary,TOrderDetails.ItemQtySecondary as ItemQtySecondary,TOrderDetails.ItemID as ItemID, TOrderDetails.MUnitSecondary as MUnitSecondary, ");
                sqlstr.Append("      TOrderDetails.OrderdtlID as OrderdtlID,TOrderDetails.OrderID as OrderID, TOrderDetails.ItemID as ItemID,TItems.ItemCode as ItemCode,TOrderDetails.OrderDtlStatus as OrderDtlStatus,TItemMunits.Munit as MunitPrimaryDesc,TItemMunits_1.Munit as MunitsecondaryDesc");
                sqlstr.Append(" FROM         TOrders INNER JOIN");
                sqlstr.Append("           TOrderDetails ON TOrders.OrderID = TOrderDetails.OrderID INNER JOIN");
                sqlstr.Append("           TItems ON TOrderDetails.ItemID = TItems.ItemID INNER JOIN");
                sqlstr.Append("        TCustomers ON TOrders.CustomerID = TCustomers.CustomerID INNER JOIN");
                sqlstr.Append("         dbo.TItemMunits ON dbo.TOrderDetails.MUnitPrimary = dbo.TItemMunits.MunitID INNER JOIN");
                sqlstr.Append("         dbo.TItemMunits AS TItemMunits_1 ON dbo.TOrderDetails.MUnitSecondary = TItemMunits_1.MunitID ");
                sqlstr.Append(" WHERE TOrderDetails.OrderdtlID = " + orderdtlid.ToString());
                IDataReader dr = db.DBReturnDatareaderResults(sqlstr.ToString());
                if (dr != null)
                {
                    while (dr.Read())
                    {
                        if (dr["CustomerTitle"] != DBNull.Value) myorderdetailid.customertitle = dr["CustomerTitle"].ToString();
                        if (dr["ItemDesc"] != DBNull.Value) myorderdetailid.itemdesc = dr["ItemDesc"].ToString();
                        if (dr["MunitPrimaryDesc"] != DBNull.Value) myorderdetailid.munitprimarydesc = dr["MunitPrimaryDesc"].ToString();
                        if (dr["MunitSecondaryDesc"] != DBNull.Value) myorderdetailid.munitsecondarydesc = dr["MunitSecondaryDesc"].ToString();
                        if (dr["ItemqtyPrimary"] != DBNull.Value) myorderdetailid.itemqtyprimary = decimal.Parse(dr["ItemqtyPrimary"].ToString());
                        if (dr["ItemWidth"] != DBNull.Value) myorderdetailid.width = decimal.Parse(dr["ItemWidth"].ToString());
                        if (dr["ItemLength"] != DBNull.Value) myorderdetailid.length = decimal.Parse(dr["ItemLength"].ToString());
                        if (dr["MUnitPrimary"] != DBNull.Value) myorderdetailid.munitprimary =short.Parse(dr["MUnitPrimary"].ToString());
                        if (dr["ItemQtySecondary"] != DBNull.Value) myorderdetailid.itemqtysecondary = decimal.Parse(dr["ItemQtySecondary"].ToString());
                        if (dr["ItemID"] != DBNull.Value) myorderdetailid.itemid = long.Parse(dr["ItemID"].ToString());
                        if (dr["ItemCode"] != DBNull.Value) myorderdetailid.itemcode = dr["ItemCode"].ToString();
                        if (dr["MUnitSecondary"] != DBNull.Value) myorderdetailid.munitsecondary = short.Parse(dr["MUnitSecondary"].ToString());
                        if (dr["OrderID"] != DBNull.Value) myorderdetailid.orderid = long.Parse(dr["OrderID"].ToString());
                        if (dr["OrderdtlID"] != DBNull.Value) myorderdetailid.orderdtlid = long.Parse(dr["OrderdtlID"].ToString());
                        if (dr["OrderDtlStatus"] != DBNull.Value) myorderdetailid.orderdtlstatus = short.Parse(dr["OrderDtlStatus"].ToString());

                                              

                    }
                }

                db.DBDisconnect();
                return myorderdetailid;
            
            }


    public long DeleteWMstrans(long wmstransid)
    {
        StringBuilder sqlstr = new StringBuilder();
        sqlstr.Append("delete from TWMSTRANS where wmstransid = " + wmstransid.ToString());
        long r = db.DBExecuteSQLCmd(sqlstr.ToString());
        sqlstr = new StringBuilder();
        sqlstr.Append("delete from twmsbinitemsqty where wmstransid = " + wmstransid.ToString());
        r = db.DBExecuteSQLCmd(sqlstr.ToString());
        sqlstr = new StringBuilder();
        sqlstr.Append("delete from twmsbinstoretrans where wmstransid = " + wmstransid.ToString());
        r = db.DBExecuteSQLCmd(sqlstr.ToString());
        return 1;

    }

    public long GetTransListCount(long wmstransid)
    {
        long r = 0;
        r = db.DBGetNumResultFromSQLSelect("SELECT  COUNT(BINSTORETRANSID) FROM twmsbinstoretrans WHERE WMSTRANSID = " + wmstransid.ToString());
        if (r < 0) return 0;
        else return r;

    }

    

}
    
#endregion

#region ITEMS,LOTS,MUNITS,BINS

    public class WMSTransTypes
    {
        DB db = new DB();

        public TWmsTransTypes WmsTransTypeInstance(int wmstransid)
        {
            long transtypeid;
            transtypeid = db.DBGetNumResultFromSQLSelect("SELECT WMSTRANSTYPEID FROM TWMSTRANS WHERE WMSTRANSID = " + wmstransid.ToString());
            TWmsTransTypes wmstranstype = IListTransTypes("WMSTRANSTYPEID=" + transtypeid.ToString(), "")[0];

            return wmstranstype;
        }


        public List<TWmsTransTypes> IListTransTypes(string searchcriteria, string sortcriteria)
        {
            List<TWmsTransTypes> transtypedata = new List<TWmsTransTypes>();

            string sqlstr = "SELECT * FROM TWMSTRANSTYPES ";
            if (!string.IsNullOrEmpty(searchcriteria))
            {
                sqlstr += " WHERE " + searchcriteria;
            }

            if (!string.IsNullOrEmpty(sortcriteria))
            {
                sqlstr += " ORDER BY " + searchcriteria;
            }


            IDataReader dr = db.DBReturnDatareaderResults(sqlstr);

            if (dr != null)
            {
                while (dr.Read())
                {
                    TWmsTransTypes transtype = new TWmsTransTypes();

                    if (dr["WMSTRANSTYPEID"] != DBNull.Value) transtype.wmstranstypeid = int.Parse(dr["WMSTRANSTYPEID"].ToString());
                   // if (dr["WMSTRANSTYPEDESC"] != DBNull.Value) transtype.wmstranstypedesc = dr["WMSTRANSTYPEDESC"].ToString();
                    if (dr["TRANSEX"] != DBNull.Value) transtype.transex = short.Parse(dr["TRANSEX"].ToString());
                    if (dr["WMSINTERNALTRANS"] != DBNull.Value)
                        transtype.wmsinternaltrans = (short.Parse(dr["WMSINTERNALTRANS"].ToString()) == 1 ? true : false);

                    if (dr["WMSBINDEFAULT"] != DBNull.Value) transtype.wmsbindefault = int.Parse(dr["WMSBINDEFAULT"].ToString());
                    if (dr["WMSBINFROM"] != DBNull.Value) transtype.wmsbinfrom = int.Parse(dr["WMSBINFROM"].ToString());
                    if (dr["WMSBINTO"] != DBNull.Value) transtype.wmsbinfrom = int.Parse(dr["WMSBINTO"].ToString());

                    transtypedata.Add(transtype);
                    transtype = null;
                }
            }
            db.DBDisconnect();
            return transtypedata;
        }

    }

    public class TitemTrans
    {
        DB db = new DB();
        public TItems GetItem(string itemcode) 
        {

            StringBuilder sqlstr = new StringBuilder();
            TItems myitem = new TItems();
            sqlstr.Append("SELECT  itemid,itemdesc,munitprimary,munitsecondary from titems ");
            sqlstr.Append(" WHERE itemcode = '" +itemcode+"'");
            IDataReader dr = db.DBReturnDatareaderResults(sqlstr.ToString());
            if (dr != null)
            {
                while (dr.Read())
                {
                    if (dr["itemid"] != DBNull.Value) myitem.itemid = long.Parse(dr["itemid"].ToString());
                    if (dr["itemdesc"] != DBNull.Value) myitem.itemdesc = dr["itemdesc"].ToString();
                    if (dr["munitprimary"] != DBNull.Value) myitem.munitprimary =short.Parse( dr["munitprimary"].ToString());
                    if (dr["munitsecondary"] != DBNull.Value) myitem.munitsecondary = short.Parse(dr["munitsecondary"].ToString());
                }
            }

            db.DBDisconnect();
            return myitem;
        
        
        }
    }

    public class WMSBins
    {
        DB db = new DB();

        public TWmsBins BinInfo(long id)
        {
            TWmsBins wmsbin = new TWmsBins();

            string sqlstr = "SELECT * FROM TWMSBINS ";

            string searchcriteria = (id > 0 ? " WHBINID=" + id.ToString() : null);

            if (!string.IsNullOrEmpty(searchcriteria))
            {
                sqlstr += " WHERE " + searchcriteria;
            }


            IDataReader dr = db.DBReturnDatareaderResults(sqlstr);

            while (dr.Read())
            {
                if (dr["WHBINID"] != DBNull.Value) wmsbin.whbinid = int.Parse(dr["WHBINID"].ToString());
                if (dr["BRANCHID"] != DBNull.Value) wmsbin.branchid = short.Parse(dr["BRANCHID"].ToString());
                if (dr["WHBINCODE"] != DBNull.Value) wmsbin.whbincode = dr["WHBINCODE"].ToString();

                if (dr["WHBINTYPE"] != DBNull.Value) wmsbin.whbintype = short.Parse(dr["WHBINTYPE"].ToString());
            }

            db.DBDisconnect();
            return wmsbin;
        }

        public List<TWmsBins> BinList(short branchid, short bintype)
        {
            List<TWmsBins> BinitemsData = new List<TWmsBins>();

            string sqlstr = "SELECT * FROM TWMSBINS ";
            string andsqlcluse = " WHERE ";
            if (branchid > 0)
            {
                sqlstr += " WHERE BRANCHID=" + branchid.ToString();
                andsqlcluse = " AND ";
            }


            if (bintype > 0)
                sqlstr += andsqlcluse + " WHBINTYPE=" + bintype.ToString();


            IDataReader dr = db.DBReturnDatareaderResults(sqlstr);

            while (dr.Read())
            {
                TWmsBins wmsbin = new TWmsBins();
                if (dr["WHBINID"] != DBNull.Value) wmsbin.whbinid = int.Parse(dr["WHBINID"].ToString());
                if (dr["BRANCHID"] != DBNull.Value) wmsbin.branchid = short.Parse(dr["BRANCHID"].ToString());
                if (dr["WHBINCODE"] != DBNull.Value) wmsbin.whbincode = dr["WHBINCODE"].ToString();

                if (dr["WHBINTYPE"] != DBNull.Value) wmsbin.whbintype = short.Parse(dr["WHBINTYPE"].ToString());

                BinitemsData.Add(wmsbin);
            }

            db.DBDisconnect();
            return BinitemsData;
        }

        public long BinIDByCode(short branchid, string bincode)
        {
            return db.DBGetNumResultFromSQLSelect("SELECT WHBINID FROM TWMSBINS WHERE WHBINCODE='" + bincode + "'" + (branchid > 0 ? " AND BRANCHID=" + branchid.ToString() : ""));
        }

        public TWmsBins BinByCode(string bincode)
        {
            TWmsBins wmsbin = new TWmsBins();

            string sqlstr = "SELECT * FROM TWMSBINS ";

            string searchcriteria = " WHBINCODE = '" + bincode + "'";

            if (!string.IsNullOrEmpty(searchcriteria))
            {
                sqlstr += " WHERE " + searchcriteria;
            }


            IDataReader dr = db.DBReturnDatareaderResults(sqlstr);

            while (dr.Read())
            {
                if (dr["WHBINID"] != DBNull.Value) wmsbin.whbinid = int.Parse(dr["WHBINID"].ToString());
                if (dr["BRANCHID"] != DBNull.Value) wmsbin.branchid = short.Parse(dr["BRANCHID"].ToString());
                if (dr["WHBINCODE"] != DBNull.Value) wmsbin.whbincode = dr["WHBINCODE"].ToString();
                if (dr["WHBINTYPE"] != DBNull.Value) wmsbin.whbintype = short.Parse(dr["WHBINTYPE"].ToString());
            }

            db.DBDisconnect();
            return wmsbin;
        }

        public long GetMinBinIDByType(short branchid, short bintype)
        {
            return db.DBGetNumResultFromSQLSelect("SELECT MIN(WHBINID) AS WHBINID FROM TWMSBINS WHERE WHBINTYPE=" + bintype.ToString() + (branchid > 0 ? " AND BRANCHID=" + branchid.ToString() : ""));
        }
    }






    public class WMSBinitemsqty
    {
        DB db = new DB();
        long binitemqtyid,rtn;
        Orders myorders = new Orders();

        public long InternalMove(TWmsBinItemsQty binitemqty, TWmsBinStoretrans thistrans) 
        {
            binitemqty.binstoretransid = 1;

            if (Update(binitemqty) > 0) 
            {
              rtn =  InsertTrans(thistrans);
            
            }

            return rtn;
        
        }


 

        public long UpdateBinItemsQty(TWmsBinItemsQty binitemsqtytablerow)
        {
            long rtrn = 0;

            if (!CheckTransStatus(binitemsqtytablerow.wmstransid)) return -5;


            if (ExistsToAnotherWMStask(binitemsqtytablerow))
            {
                return -3;
            
            }

            if (Exists(binitemsqtytablerow) &&  (!(binitemsqtytablerow.binstoretransid>0) && binitemsqtytablerow.transex >0) )
            {
                return -2;
            }

            
            if (Exists(binitemsqtytablerow)  ) 
                rtrn = Update(binitemsqtytablerow);
            else if(!(binitemsqtytablerow.updateonly))
                rtrn = Insert(binitemsqtytablerow);


            //if (binitemsqtytablerow.width > 0 && binitemsqtytablerow.length > 0 && (binitemsqtytablerow.transtype == 1 || binitemsqtytablerow.transtype == 2)) 
            //{
            
            
            //}
            
           
            if ((binitemsqtytablerow.binstoretransid > 0) || binitemsqtytablerow.updateonly)   
                {
                    rtrn = UpdateTrans(CreateTransRecordFromBinQty(binitemsqtytablerow));
                }
             else if( rtrn > 0 && !(binitemsqtytablerow.binstoretransid > 0) ) {
                    rtrn = InsertTrans(CreateTransRecordFromBinQty(binitemsqtytablerow)); 
                
                }

            return rtrn;
        }

        public bool TransExist(TWmsBinItemsQty binitemsqty)
        {
            binitemsqty.binstoretransid = db.DBGetNumResultFromSQLSelect("SELECT BINSTORETRANSID FROM  TWMSBINSTORETRANS WHERE WMSTRANSTYPE = "+binitemsqty.transtype.ToString()+" AND   ORDERDTLID =" + binitemsqty.orderdtlid.ToString());
            if (binitemsqty.binstoretransid > 0) return true;
            //          binitemsqty.binitemsqtyid = db.DBGetNumResultFromSQLSelect("SELECT BINITEMSQTYID FROM  twmsbinitemsqty WHERE WMSTRANSID = " + binitemsqty.wmstransid.ToString() + " AND ORDERDTLID =" + binitemsqty.orderdtlid.ToString());
            if (binitemsqty.binstoretransid > 0) return true;
            else return false;
        }



        public bool Exists(TWmsBinItemsQty binitemsqty)
        {
            binitemsqty.binitemsqtyid = db.DBGetNumResultFromSQLSelect("SELECT BINITEMSQTYID FROM  twmsbinitemsqty WHERE   ORDERDTLID =" + binitemsqty.orderdtlid.ToString());
            if (binitemsqty.binitemsqtyid > 0) return true;
            //          binitemsqty.binitemsqtyid = db.DBGetNumResultFromSQLSelect("SELECT BINITEMSQTYID FROM  twmsbinitemsqty WHERE WMSTRANSID = " + binitemsqty.wmstransid.ToString() + " AND ORDERDTLID =" + binitemsqty.orderdtlid.ToString());
            if (binitemsqty.binitemsqtyid > 0) return true;
            else   return false;
        }

        public bool ExistsToAnotherWMStask(TWmsBinItemsQty binitemsqty)
        {
            long BINSTORETRANSID = 0;
            BINSTORETRANSID = db.DBGetNumResultFromSQLSelect("SELECT BINSTORETRANSID FROM  twmsbinstoretrans  WHERE WMSTRANSID <> "+binitemsqty.wmstransid.ToString()+" AND WMSTRANSTYPE = " + binitemsqty.transtype.ToString() + " AND ORDERDTLID =" + binitemsqty.orderdtlid.ToString());
            if (BINSTORETRANSID > 0) return true;
            else return false;
        }

        public bool CheckIfQtyOrderDTLDexists(TWmsBinItemsQty binitemsqty )
        {
            long BINITEMSQTYID;
            if (binitemsqty.binitemsqtyid > 0) return true;
            BINITEMSQTYID = db.DBGetNumResultFromSQLSelect("SELECT BINSTORETRANSID FROM twmsbinstoretrans WHERE ORDERDTLID =" + binitemsqty.orderdtlid.ToString() + " AND wmstranstype = " + binitemsqty.transtype.ToString());
            if (BINITEMSQTYID > 0) return false; else return true;
        }


        long Insert(TWmsBinItemsQty binitemsqtytable)
        {
            StringBuilder sqlstr = new StringBuilder();
            sqlstr.Append("INSERT INTO TWMSBINITEMSQTY(");
            sqlstr.Append("COMPID,");
            sqlstr.Append("BRANCHID,");
            sqlstr.Append("WHBINID,");
            sqlstr.Append("WMSTRANSID,");
            sqlstr.Append("ITEMID,");
            sqlstr.Append("ITEMQTYPRIMARY,");
            sqlstr.Append("MUNITPRIMARY,");
            sqlstr.Append("ITEMQTYSECONDARY,");
            sqlstr.Append("MUNITSECONDARY,");
            sqlstr.Append("ORDERDTLID,");
            sqlstr.Append("ORDERID,");
            sqlstr.Append("ROUTEID,");
            sqlstr.Append("DBRECCREATEUSER");
            sqlstr.Append(")");
            sqlstr.Append(" VALUES(");

            if (binitemsqtytable.compid > 0) sqlstr.Append(binitemsqtytable.compid.ToString() + ","); else sqlstr.Append("NULL,");
            if (binitemsqtytable.branchid > 0) sqlstr.Append(binitemsqtytable.branchid.ToString() + ","); else sqlstr.Append("NULL,");
            if (binitemsqtytable.whbinid > 0) sqlstr.Append(binitemsqtytable.whbinid.ToString() + ","); else sqlstr.Append("NULL,");
            if (binitemsqtytable.wmstransid > 0) sqlstr.Append(binitemsqtytable.wmstransid.ToString() + ","); else sqlstr.Append("NULL,");
            if (binitemsqtytable.itemid > 0) sqlstr.Append(binitemsqtytable.itemid.ToString() + ","); else sqlstr.Append("NULL,");

            if (binitemsqtytable.munitprimary == 1)
            {
                if (binitemsqtytable.itemqtyprimary > 0) sqlstr.Append(binitemsqtytable.itemqtyprimary.ToString().Replace(",", ".") + ","); else sqlstr.Append("NULL,");

            }
            else 
            {
                if (binitemsqtytable.itemqtyprimary > 0) sqlstr.Append("1,"); else sqlstr.Append("NULL,");

            }

            if (binitemsqtytable.munitprimary > 0) sqlstr.Append(binitemsqtytable.munitprimary.ToString() + ","); else sqlstr.Append("NULL,");
            if (binitemsqtytable.itemqtysecondary > 0) sqlstr.Append(binitemsqtytable.itemqtysecondary.ToString().Replace(",", ".") + ","); else sqlstr.Append("NULL,");
            if (binitemsqtytable.munitsecondary > 0) sqlstr.Append(binitemsqtytable.munitsecondary.ToString() + ","); else sqlstr.Append("NULL,");
            if (binitemsqtytable.orderdtlid > 0) sqlstr.Append(binitemsqtytable.orderdtlid.ToString() + ","); else sqlstr.Append("NULL,");
            if (binitemsqtytable.orderid > 0) sqlstr.Append(binitemsqtytable.orderid.ToString() + ","); else sqlstr.Append("NULL,");
            if (binitemsqtytable.routeid > 0) sqlstr.Append(binitemsqtytable.routeid.ToString() + ","); else sqlstr.Append("NULL,");
            if (binitemsqtytable.dbreccreateuser > 0) sqlstr.Append(binitemsqtytable.dbreccreateuser.ToString() + ","); else sqlstr.Append("NULL");
            sqlstr.Append(")");
            long r = db.DBExecuteSQLCmd(sqlstr.ToString());
            if (!(r > 0)) db.f_sqlerrorlog(1, "WMSBinitemsqty.Update", sqlstr.ToString(), "WEBService");

            if ((r > 0) && ((binitemsqtytable.width > 0) || (binitemsqtytable.length > 0)) && (binitemsqtytable.transtype == 1 || binitemsqtytable.transtype == 2)) //only at receives
            {
                myorders.UpdateOrderDetailsDimensions(binitemsqtytable.orderdtlid, binitemsqtytable.width, binitemsqtytable.length, binitemsqtytable.itemqtyprimary, binitemsqtytable.munitprimary);
            }
            else 
            {

                WriteToLog("Δεν ενημέρωσε το update width=" + binitemsqtytable.width.ToString() + " length=" + binitemsqtytable.length.ToString() + " transtype=" + binitemsqtytable.transtype.ToString());
            }
            
            
            return r;
        }
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

        long Update(TWmsBinItemsQty binitemsqtytable)
        {
            if( (!(binitemsqtytable.binstoretransid > 0) && binitemsqtytable.transex > 0)) return 0;
            StringBuilder sqlstr = new StringBuilder();
            bool clearrecord = false;

            if ((binitemsqtytable.DeleteRecord > 0) || (binitemsqtytable.transex == -1)) clearrecord = true;



            if (clearrecord)
            {
                sqlstr.Append("DELETE FROM TWMSBINITEMSQTY WHERE  ORDERDTLID=" + binitemsqtytable.orderdtlid.ToString());
            }
            else
            {
                sqlstr.Append("UPDATE TWMSBINITEMSQTY SET ");


                if (binitemsqtytable.whbinid > 0) sqlstr.Append("WHBINID=" + binitemsqtytable.whbinid.ToString() + ",");
                if (binitemsqtytable.itemid > 0) sqlstr.Append("ITEMID=" + binitemsqtytable.itemid.ToString() + ","); else sqlstr.Append("ITEMID=NULL,");

                if (binitemsqtytable.munitprimary == 1)
                {
                    if (binitemsqtytable.itemqtyprimary > 0) sqlstr.Append("ITEMQTYPRIMARY= " + binitemsqtytable.itemqtyprimary.ToString().Replace(",", ".") + ","); else sqlstr.Append("ITEMQTYPRIMARY=NULL,");
                }
                else 
                {
                    if (binitemsqtytable.itemqtyprimary > 0) sqlstr.Append("ITEMQTYPRIMARY = 1,"); else sqlstr.Append("ITEMQTYPRIMARY=NULL,");
                
                }
                if (binitemsqtytable.itemqtysecondary > 0) sqlstr.Append("ITEMQTYSECONDARY=" + binitemsqtytable.itemqtysecondary.ToString().Replace(",", ".") + ","); else sqlstr.Append("ITEMQTYSECONDARY=NULL,");

                if (binitemsqtytable.munitprimary > 0) sqlstr.Append("MUNITPRIMARY=" + binitemsqtytable.munitprimary.ToString() + ","); else sqlstr.Append("MUNITPRIMARY=NULL,");

                if (binitemsqtytable.munitsecondary > 0) sqlstr.Append("MUNITSECONDARY=" + binitemsqtytable.munitsecondary.ToString() + ","); else sqlstr.Append("MUNITSECONDARY=NULL,");
                if (binitemsqtytable.orderdtlid > 0) sqlstr.Append("ORDERDTLID=" + binitemsqtytable.orderdtlid.ToString() + ","); else sqlstr.Append("ORDERDTLID=NULL,");
                if (binitemsqtytable.wmstransid > 0) sqlstr.Append("WMSTRANSID=" + binitemsqtytable.wmstransid.ToString() + ","); else sqlstr.Append("WMSTRANSID=NULL,");
                if (binitemsqtytable.orderid > 0) sqlstr.Append("ORDERID=" + binitemsqtytable.orderid.ToString() + ","); else sqlstr.Append("ORDERID=NULL,");
                if (binitemsqtytable.routeid > 0) sqlstr.Append("ROUTEID=" + binitemsqtytable.routeid.ToString() + ","); else sqlstr.Append("ROUTEID=NULL,");
                if (binitemsqtytable.dbrecmoduser > 0) sqlstr.Append("DBRECMODUSER=" + binitemsqtytable.dbrecmoduser.ToString() + ","); else sqlstr.Append("DBRECMODUSER=NULL,");
                if (!string.IsNullOrEmpty(binitemsqtytable.dbrecmoddate)) sqlstr.Append("DBRECMODDATE=" + db.DBDateTimeFormatstring(binitemsqtytable.dbrecmoddate)); else sqlstr.Append("DBRECMODDATE=NULL ");

                sqlstr.Append(" WHERE   ORDERDTLID = " + binitemsqtytable.orderdtlid.ToString());


            }

            if (binitemsqtytable.oldqty > 0)
            {
                myorders.UpdateOrderDetailsDimensions(binitemsqtytable.orderdtlid, binitemsqtytable.width, binitemsqtytable.length, binitemsqtytable.itemqtyprimary, binitemsqtytable.munitprimary);
            }


            long r = db.DBExecuteSQLCmd(sqlstr.ToString());

            if (r < 0) 
            {
                db.f_sqlerrorlog(1, "WMSBinitemsqty.Update", sqlstr.ToString(), "WEBService");
            
            }

            return r;

        }

        public List<TWmsBinItemsQty> WmsBinItemsQtyData(string searchcriteria, string sortcriteria)
        {
            List<TWmsBinItemsQty> BinitemsData = new List<TWmsBinItemsQty>();


            string sqlstr = "SELECT * FROM VWMSBINITEMSQTY";
            if (!string.IsNullOrEmpty(searchcriteria))
            {
                sqlstr += " WHERE " + searchcriteria;
            }

            if (!string.IsNullOrEmpty(sortcriteria))
            {
                sqlstr += " ORDER BY " + searchcriteria;
            }


            IDataReader dr = db.DBReturnDatareaderResults(sqlstr);

            if (dr != null)
            {
                while (dr.Read())
                {
                    TWmsBinItemsQty binitemsqtyrec = new TWmsBinItemsQty();

                    if (dr["BINITEMSQTYID"] != DBNull.Value) binitemsqtyrec.binitemsqtyid = long.Parse(dr["BINITEMSQTYID"].ToString());
                    if (dr["COMPID"] != DBNull.Value) binitemsqtyrec.compid = short.Parse(dr["COMPID"].ToString());
                    if (dr["BRANCHID"] != DBNull.Value) binitemsqtyrec.branchid = short.Parse(dr["BRANCHID"].ToString());
                    if (dr["WHBINID"] != DBNull.Value) binitemsqtyrec.whbinid = long.Parse(dr["WHBINID"].ToString());
                    if (dr["WHBINTYPE"] != DBNull.Value) binitemsqtyrec.whbintype = short.Parse(dr["WHBINTYPE"].ToString());
                    if (dr["WHBINCODE"] != DBNull.Value) binitemsqtyrec.whbincode = dr["WHBINCODE"].ToString();
                    if (dr["ITEMID"] != DBNull.Value) binitemsqtyrec.itemid = long.Parse(dr["ITEMID"].ToString());
                    if (dr["ITEMQTYPRIMARY"] != DBNull.Value) binitemsqtyrec.itemqtyprimary = decimal.Parse(dr["ITEMQTYPRIMARY"].ToString());
                    if (dr["MUNITPRIMARY"] != DBNull.Value) binitemsqtyrec.munitprimary = short.Parse(dr["MUNITPRIMARY"].ToString());
                    if (dr["ITEMQTYSECONDARY"] != DBNull.Value) binitemsqtyrec.itemqtysecondary = decimal.Parse(dr["ITEMQTYSECONDARY"].ToString());
                    if (dr["MUNITSECONDARY"] != DBNull.Value) binitemsqtyrec.munitsecondary = short.Parse(dr["MUNITSECONDARY"].ToString());
                    if (dr["MUNITPRIMARYDESC"] != DBNull.Value) binitemsqtyrec.munitprimarydesc = dr["MUNITPRIMARYDESC"].ToString();
                    if (dr["MUNITSECONDARYDESC"] != DBNull.Value) binitemsqtyrec.munitsecondarydesc = dr["MUNITSECONDARYDESC"].ToString();
                    if (dr["MUNITSRELATION"] != DBNull.Value) binitemsqtyrec.munitsrelation = decimal.Parse(dr["MUNITSRELATION"].ToString());
                    if (dr["ORDERDTLID"] != DBNull.Value) binitemsqtyrec.orderdtlid = long.Parse(dr["ORDERDTLID"].ToString());
                    if (dr["ORDERID"] != DBNull.Value) binitemsqtyrec.orderid = long.Parse(dr["ORDERID"].ToString());
                    if (dr["ROUTEID"] != DBNull.Value) binitemsqtyrec.routeid = long.Parse(dr["ROUTEID"].ToString());
                    binitemsqtyrec.dbreccreatedate = dr["DBRECCREATEDATE"].ToString();
                    if (dr["DBRECCREATEUSER"] != DBNull.Value) binitemsqtyrec.dbreccreateuser = int.Parse(dr["DBRECCREATEUSER"].ToString());
                    binitemsqtyrec.dbrecmoddate = dr["DBRECMODDATE"].ToString();
                    if (dr["DBRECMODUSER"] != DBNull.Value) binitemsqtyrec.dbrecmoduser = int.Parse(dr["DBRECMODUSER"].ToString());



                    BinitemsData.Add(binitemsqtyrec);
                    binitemsqtyrec = null;
                }
            }

            db.DBDisconnect();
            return BinitemsData;
        }

        public List<TWmsBinItemsQty> GetItemQtyAvailableByBinCode(short branchid, long itemid, long itemlotid, long packitemid)
        {
            List<TWmsBinItemsQty> BinitemsData = new List<TWmsBinItemsQty>();

            string searchcriteria = null, sortcriteria = null;
            string andstr = "";


            if (branchid > 0)
            {
                searchcriteria += andstr + " BRANCHID=" + branchid.ToString();
                andstr = " AND ";
            }
            if (packitemid > 0)
            {
                searchcriteria += andstr + " PACKITEMID=" + packitemid.ToString();
                andstr = " AND ";
            }
            else if (itemlotid > 0 && itemid > 0)
            {
                searchcriteria += andstr + " ITEMLOTID=" + itemlotid.ToString() + " AND ITEMID=" + itemid.ToString();
                andstr = " AND ";
            }
            else if (itemid > 0)
            {
                searchcriteria += andstr + " ITEMID=" + itemid.ToString();
            }


            BinitemsData = WmsBinItemsQtyData(searchcriteria, sortcriteria);

            return BinitemsData;
        }


        public long PrintPaletteLabel(short compid, short branchid, short whbuildid, long packitemid)
        {
            StringBuilder sqlstr = new StringBuilder();

            sqlstr.Append("INSERT INTO TWMSPRINTLABELS (COMPID,BRANCHID,PACKITEMID,WHBUILDID) VALUES (");
            sqlstr.Append(compid > 0 ? compid.ToString() + "," : "1,");
            sqlstr.Append(branchid > 0 ? branchid.ToString() + "," : "1,");
            sqlstr.Append(packitemid.ToString() + ",");
            sqlstr.Append(whbuildid > 0 ? whbuildid.ToString() : "1");
            sqlstr.Append(")");

            return db.DBExecuteSQLCmd(sqlstr.ToString());
        }

        public TWmsBinStoretrans CreateTransRecordFromBinQty(TWmsBinItemsQty binitemsqty)
        {
            TWmsBinStoretrans bintrans = new TWmsBinStoretrans();
            bintrans.whbinid = binitemsqty.whbinid;
            bintrans.binstoretransid = binitemsqty.binstoretransid;
            bintrans.DeleteRecord = binitemsqty.DeleteRecord;
            bintrans.compid = binitemsqty.compid;
            bintrans.orderid = binitemsqty.orderid;
            bintrans.orderdtlid = binitemsqty.orderdtlid;
            bintrans.wmstransid = binitemsqty.wmstransid;
            bintrans.branchid = binitemsqty.branchid;
            bintrans.itemid = binitemsqty.itemid;
            bintrans.munitprimary = binitemsqty.munitprimary;
            bintrans.itemqtyprimary = binitemsqty.itemqtyprimary;
            bintrans.oldqty = binitemsqty.oldqty;
            bintrans.munitsecondary = binitemsqty.munitsecondary;
            bintrans.itemqtysecondary = binitemsqty.itemqtysecondary;
            bintrans.transex = binitemsqty.transex;
            bintrans.wmstranstype = binitemsqty.transtype;


            if (binitemsqty.whbinidto > 0)
            {
                bintrans.whbinidfrom = binitemsqty.whbinid;
                bintrans.whbinidto = binitemsqty.whbinidto;
            }
            else
                bintrans.whbinid = binitemsqty.whbinid;

            bintrans.dbreccreateuser = binitemsqty.dbreccreateuser;


            return bintrans;
        }

        public long InsertTrans(TWmsBinStoretrans bintranstable)
        {
            long rowcount;
            StringBuilder sqlstr = new StringBuilder();

            //if (bintranstable.wmstranstype == 10) 
            //{
            //    try 
            //    {
            //        bintranstable.whbinid = db.DBGetNumResultFromSQLSelect(" SELECT WHBINID FROM TWMSBINITEMSQTY WHERE ORDERDTLID = " + bintranstable.orderdtlid.ToString());
            //    }
            //    catch { }
            //} 

            sqlstr.Append("INSERT INTO TWMSBINSTORETRANS(");
            sqlstr.Append("COMPID,");
            sqlstr.Append("BRANCHID,");
            sqlstr.Append("WHBINID,");
            sqlstr.Append("WMSTRANSTYPE,");
            sqlstr.Append("WMSTRANSID,");
            sqlstr.Append("TRANSEX,");
            sqlstr.Append("ITEMID,");
            sqlstr.Append("OLDQTY,");
            sqlstr.Append("ITEMQTYPRIMARY,");
            sqlstr.Append("MUNITPRIMARY,");
            sqlstr.Append("ITEMQTYSECONDARY,");
            sqlstr.Append("MUNITSECONDARY,");
            sqlstr.Append("ORDERID,");
            sqlstr.Append("ORDERDTLID,");
            sqlstr.Append("WHBINIDFROM,");
            sqlstr.Append("WHBINIDTO,");
            sqlstr.Append("TERMINAL,");
            sqlstr.Append("DBRECCREATEUSER");
            sqlstr.Append(")");
            sqlstr.Append(" VALUES(");

            if (bintranstable.compid > 0) sqlstr.Append(bintranstable.compid.ToString() + ","); else sqlstr.Append("NULL,");
            if (bintranstable.branchid > 0) sqlstr.Append(bintranstable.branchid.ToString() + ","); else sqlstr.Append("NULL,");
            if (bintranstable.whbinid > 0) sqlstr.Append(bintranstable.whbinid.ToString() + ","); else sqlstr.Append("NULL,");
            if (bintranstable.wmstranstype > 0) sqlstr.Append(bintranstable.wmstranstype.ToString() + ","); else sqlstr.Append("NULL,");
            if (bintranstable.wmstransid > 0) sqlstr.Append(bintranstable.wmstransid.ToString() + ","); else sqlstr.Append("NULL,");
            if (bintranstable.transex > -2) sqlstr.Append(bintranstable.transex.ToString() + ","); else sqlstr.Append("NULL,");
            if (bintranstable.itemid > 0) sqlstr.Append(bintranstable.itemid.ToString() + ","); else sqlstr.Append("NULL,");
            if (bintranstable.oldqty > 0) sqlstr.Append(bintranstable.oldqty.ToString().Replace(",", ".") + ","); else sqlstr.Append("NULL,");

            if (bintranstable.munitprimary == 1)
            {
                if (bintranstable.itemqtyprimary > 0) sqlstr.Append(bintranstable.itemqtyprimary.ToString().Replace(",", ".") + ","); else sqlstr.Append("NULL,");
            }
            else 
            {
                if (bintranstable.itemqtyprimary > 0) sqlstr.Append("1,"); else sqlstr.Append("NULL,");
            }
            
            if (bintranstable.munitprimary > 0) sqlstr.Append(bintranstable.munitprimary.ToString() + ","); else sqlstr.Append("NULL,");
            if (bintranstable.itemqtysecondary > 0) sqlstr.Append(bintranstable.itemqtysecondary.ToString().Replace(",", ".") + ","); else sqlstr.Append("NULL,");
            if (bintranstable.munitsecondary > 0) sqlstr.Append(bintranstable.munitsecondary.ToString() + ","); else sqlstr.Append("NULL,");
            if (bintranstable.orderid > 0) sqlstr.Append(bintranstable.orderid.ToString() + ","); else sqlstr.Append("NULL,");
            if (bintranstable.orderdtlid > 0) sqlstr.Append(bintranstable.orderdtlid.ToString() + ","); else sqlstr.Append("NULL,");
            if (bintranstable.whbinidfrom > 0) sqlstr.Append(bintranstable.whbinidfrom.ToString() + ","); else sqlstr.Append("NULL,");
            if (bintranstable.whbinidto > 0) sqlstr.Append(bintranstable.whbinidto.ToString() + ","); else sqlstr.Append("NULL,");
            if (!string.IsNullOrEmpty(bintranstable.terminal)) sqlstr.Append("'" + bintranstable.terminal + "',"); else sqlstr.Append("NULL,");
            if (bintranstable.dbreccreateuser > 0) sqlstr.Append(bintranstable.dbreccreateuser); else sqlstr.Append("NULL");
            sqlstr.Append(")");

            long r = db.DBExecuteSQLCmd(sqlstr.ToString());

            if (r > 0 && ( bintranstable.wmstranstype == 1 ||  bintranstable.wmstranstype == 2)) //Update TorderDetail Qty
             //   myorders.UpdateOrderDetailsQTY(bintranstable.orderdtlid, bintranstable.itemqtyprimary.ToString().Replace(",", "."));

            if (r > 0 && bintranstable.wmstransid > 0)
            {
                sqlstr = new StringBuilder();
                sqlstr.Append("SELECT COUNT(BINSTORETRANSID) FROM twmsbinstoretrans WHERE WMSTRANSID = "+bintranstable.wmstransid);
                r = db.DBGetNumResultFromSQLSelect(sqlstr.ToString());
            }
            return r;
        }
   
        public long UpdateTrans(TWmsBinStoretrans bintranstable)
        {
            if (!(bintranstable.binstoretransid > 0)) return 0;
            StringBuilder sqlstr = new StringBuilder();

            if (bintranstable.DeleteRecord > 0)
            {
                sqlstr.Append("DELETE FROM TWMSBINSTORETRANS WHERE BINSTORETRANSID=" + bintranstable.binstoretransid.ToString());


            }
            else
            {
                sqlstr.Append("UPDATE TWMSBINSTORETRANS SET ");
                if (bintranstable.whbinid > 0) sqlstr.Append("WHBINID=" + bintranstable.whbinid.ToString() + ","); else sqlstr.Append("WHBINID=NULL,");
                if (bintranstable.itemid > 0) sqlstr.Append("ITEMID=" + bintranstable.itemid.ToString() + ","); else sqlstr.Append("ITEMID=NULL,");
                if (bintranstable.oldqty > 0) sqlstr.Append("OLDQTY= " + bintranstable.oldqty.ToString().Replace(",", ".") + ","); else sqlstr.Append("OLDQTY=NULL,");

                if (bintranstable.munitprimary == 1)
                {
                    if (bintranstable.itemqtyprimary > 0) sqlstr.Append("ITEMQTYPRIMARY= " + bintranstable.itemqtyprimary.ToString().Replace(",", ".") + ","); else sqlstr.Append("ITEMQTYPRIMARY=NULL,");
                }
                else {
                    if (bintranstable.itemqtyprimary > 0) sqlstr.Append("ITEMQTYPRIMARY= 1,"); else sqlstr.Append("ITEMQTYPRIMARY=NULL,");
                }
                
                if (bintranstable.itemqtysecondary > 0) sqlstr.Append("ITEMQTYSECONDARY=" + bintranstable.itemqtysecondary.ToString().Replace(",", ".") + ","); else sqlstr.Append("ITEMQTYSECONDARY=NULL,");
                if (bintranstable.munitprimary > 0) sqlstr.Append("MUNITPRIMARY=" + bintranstable.munitprimary.ToString() + ","); else sqlstr.Append("MUNITPRIMARY=NULL,");
                if (bintranstable.munitsecondary > 0) sqlstr.Append("MUNITSECONDARY=" + bintranstable.munitsecondary.ToString() + ","); else sqlstr.Append("MUNITSECONDARY=NULL,");
                if (bintranstable.orderdtlid > 0) sqlstr.Append("ORDERDTLID=" + bintranstable.orderdtlid.ToString() + ","); else sqlstr.Append("ORDERDTLID=NULL,");
                if (bintranstable.wmstransid > 0) sqlstr.Append("WMSTRANSID=" + bintranstable.wmstransid.ToString() + ","); else sqlstr.Append("WMSTRANSID=NULL,");
                if (bintranstable.orderid > 0) sqlstr.Append("ORDERID=" + bintranstable.orderid.ToString() + ","); else sqlstr.Append("ORDERID=NULL,");
                if (bintranstable.dbrecmoduser > 0) sqlstr.Append("DBRECMODUSER=" + bintranstable.dbrecmoduser.ToString() + ","); else sqlstr.Append("DBRECMODUSER=NULL,");
                if (!string.IsNullOrEmpty(bintranstable.dbrecmoddate)) sqlstr.Append("DBRECMODDATE=" + db.DBDateTimeFormatstring(bintranstable.dbrecmoddate)); else sqlstr.Append("DBRECMODDATE=NULL ");
                sqlstr.Append(" WHERE BINSTORETRANSID=" + bintranstable.binstoretransid.ToString());

            }
            
            long r = db.DBExecuteSQLCmd(sqlstr.ToString());

            if (r > 0 && bintranstable.oldqty > 0) //Update TorderDetail Qty
                myorders.UpdateOrderDetailsQTY(bintranstable.orderdtlid, bintranstable.itemqtyprimary.ToString().Replace(",", "."));
                

            if (r < 0)
                db.f_sqlerrorlog(1, "WmsbinStoreTrans.Update", sqlstr.ToString(), "WEBService");
  

            return r;
        }

        public bool CheckTransStatus(long wmstransid)
        {
            if (db.DBGetNumResultFromSQLSelect("SELECT confirmed FROM TWMSTRANS WHERE WMSTRANSID = " + wmstransid.ToString()) > 0)
                return false;
            else return true;
            
        
        }

    }

#endregion


    
    public class Orders
    {
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
        DB db = new DB();

        public long UpdateOrderDetailsDimensions(long orderdtlid,decimal width,decimal length,decimal qty,int munitprimary)
        {
            if (munitprimary == 1)
            {
                WriteToLog("UPDATE TORDERDETAILS SET ITEMQTYPRIMARY = " + qty.ToString().Replace(",", ".") + ", ItemWidth = " + width.ToString().Replace(",", ".") + ",ItemLength = " + length.ToString().Replace(",", ".") + " WHERE ORDERDTLID=" + orderdtlid.ToString());

                return db.DBExecuteSQLCmd("UPDATE TORDERDETAILS SET ITEMQTYPRIMARY = " + qty.ToString().Replace(",", ".") + ", ItemWidth = " + width.ToString().Replace(",", ".") + ",ItemLength = " + length.ToString().Replace(",", ".") + " WHERE ORDERDTLID=" + orderdtlid.ToString());
            }
            else 
            {
                WriteToLog("UPDATE TORDERDETAILS SET ITEMQTYPRIMARY = 1,ITEMQTYSECONDARY = " + (width * length).ToString().Replace(",", ".") + ", ItemWidth = " + width.ToString().Replace(",", ".") + ",ItemLength = " + length.ToString().Replace(",", ".") + " WHERE ORDERDTLID=" + orderdtlid.ToString());

                return db.DBExecuteSQLCmd("UPDATE TORDERDETAILS SET ITEMQTYPRIMARY = 1,ITEMQTYSECONDARY = " + (width * length).ToString().Replace(",", ".") + ", ItemWidth = " + width.ToString().Replace(",", ".") + ",ItemLength = " + length.ToString().Replace(",", ".") + " WHERE ORDERDTLID=" + orderdtlid.ToString());
            }
        }

        public long DeleteReceive(long orderdtlid)
        {
            long i;
            i = db.DBExecuteSQLCmd("DELETE FROM TWMSBINITEMSQTY  WHERE ORDERDTLID=" + orderdtlid.ToString());
            i = db.DBExecuteSQLCmd("DELETE FROM TWMSBINSTORETRANS  WHERE ORDERDTLID=" + orderdtlid.ToString());
            i = db.DBExecuteSQLCmd("UPDATE TORDERDETAILS SET ORDERDTLSTATUS = 0 ,ItemWidth = null,ItemLength=null WHERE ORDERDTLID=" + orderdtlid.ToString());
            return i;
        }

        public long UpdateOrderDetailItemID(long orderdtlid, long itemid)
        {
            StringBuilder sqstr = new StringBuilder();
            sqstr.Append("update torderdetails set torderdetails.itemid = titems.itemid , torderdetails.priceperunit = titems.priceperunit ");
            sqstr.Append(",torderdetails.munitprimary = titems.munitprimary,torderdetails.munitsecondary = titems.munitsecondary ");
            sqstr.Append(" from torderdetails,titems where torderdetails.orderdtlid ="+orderdtlid.ToString()+" and titems.itemid = "+itemid.ToString());
            return db.DBExecuteSQLCmd(sqstr.ToString());

        }

        public long UpdateOrderDetailsQTY(long orderdtlid,string qty)
        {
            return db.DBExecuteSQLCmd("UPDATE TORDERDETAILS SET ITEMQTYPRIMARY = " + qty + " WHERE ORDERDTLID=" + orderdtlid.ToString());
        
        }

        public long UpdateOrderDetailStatus(long orderdtlid,short status)
        {
            return db.DBExecuteSQLCmd("UPDATE TORDERDETAILS SET ORDERDTLSTATUS =  "+status.ToString()+" WHERE ORDERDTLID = "+orderdtlid.ToString());

        }

        public long UpdateOrderStatus(long oprderid)
        {
            short minstatus, maxstatus, neworderstatus;
            long rtrn = 0;

            DataTable dt = db.DBFillDataTable("SELECT MIN(ORDERDTLSTATUS) AS MINSTATUS,MAX(ORDERDTLSTATUS) AS MAXSTATUS FROM TORDERDETAILS WHERE ORDERID=" + oprderid.ToString(), "dtorderstatus");

            if (dt.Rows.Count > 0)
            {
                minstatus = short.Parse(dt.Rows[0]["MINSTATUS"].ToString());
                maxstatus = short.Parse(dt.Rows[0]["MAXSTATUS"].ToString());


                //if (minstatus == maxstatus)
                //    neworderstatus = minstatus;
                //else if (minstatus < OrderStatusVariants.PartiallyDone && maxstatus > OrderStatusVariants.Undone)
                //    neworderstatus = OrderStatusVariants.PartiallyDone;
                //else
                //    neworderstatus = minstatus;




                rtrn = db.DBExecuteSQLCmd("UPDATE TORDERS SET ORDERSTATUS= WHERE ORDERID=" + oprderid.ToString());
            }

            return rtrn;

        }
    }


#region OTHERS
    public class DBGeneralOperations
    {

        public long CheckDBConnection()
        {
            DB db = new DB();
            try
            {
                return db.DBGetNumResultFromSQLSelect("SELECT COUNT(*) AS RCNT FROM TDual");
            }
            catch (Exception ex) 
            {

                db.f_sqlerrorlog(1, "Connection to db failed", ex.ToString().Replace("'", "|"), "WebServer");
                return -1; }
        }



    }

    public struct AppXMLFiles
    {
        public static string XMLItems = "XMLItems.xml";
        public static string XMLLots = "XMLLot.xml";
        public static string XMLStores = "XMLStores.xml";
        public static string XMLMUnits = "XMLMUnits.xml";
        public static string XMLInvHeaders = "XMLInvHeaders.xml";
    }




    #endregion









}
