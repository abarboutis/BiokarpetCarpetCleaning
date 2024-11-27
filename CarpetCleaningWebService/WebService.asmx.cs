using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Data;

namespace CarpetCleaningMobService
{
    /// <summary>
    /// Summary description for WebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]

    public class WebService : System.Web.Services.WebService
    {
        WMSTRANS mywmstrns = new WMSTRANS();
        WMSBinitemsqty binitems = new WMSBinitemsqty();


        [WebMethod]
        public long CheckDBConnection()
        {
            DBGeneralOperations dboperations = new DBGeneralOperations();

            return dboperations.CheckDBConnection();

        }
        [WebMethod]
        public List<TWmsBinItemsQty> BinitemsQty(string criteria, string sortcriteria)
        {
            WMSBinitemsqty test = new WMSBinitemsqty();

            return test.WmsBinItemsQtyData(criteria, sortcriteria);
        }


        [WebMethod]
        public long BinitemsQtyUpdate(TWmsBinItemsQty binitemqtyrecord)
        {
            WMSBinitemsqty binitemsqtyhandler = new WMSBinitemsqty();

            return binitemsqtyhandler.UpdateBinItemsQty(binitemqtyrecord);

        }

        [WebMethod]
        public long InsertBinTrans(TWmsBinItemsQty mbintrans)
        {
            WMSBinitemsqty binitemsqtyhandler = new WMSBinitemsqty();
            if (!binitemsqtyhandler.TransExist(mbintrans))
            {
                
                return binitemsqtyhandler.InsertTrans(binitemsqtyhandler.CreateTransRecordFromBinQty(mbintrans));
            }else
            {
                return -5;
            }
            
        }




        [WebMethod]
        public long BinIDByCode(short branchid, string bincode)
        {
            WMSBins wmsbins = new WMSBins();

            return wmsbins.BinIDByCode(branchid, bincode);
        }

        [WebMethod]
        public long UpdateOrderDetailStatus(long orderdtlid,short status)
        {
            Orders myorder = new Orders();
            return myorder.UpdateOrderDetailStatus(orderdtlid, status);
           
        }

        [WebMethod]
        public long UpdateOrderDetailItem(long orderdtlid, long newitemid)
        {
            Orders myorder = new Orders();
            return myorder.UpdateOrderDetailItemID(orderdtlid, newitemid);

        }


        [WebMethod]
        public long DeleteReceive(long orderdtlid,int transtype)
        {
            if (transtype!= 1)return -1;
            Orders myorder = new Orders();
            return myorder.DeleteReceive(orderdtlid);

        }

        [WebMethod]
        public TWmsBins GetBinInfo(long binid)
        {
            WMSBins wmsbins = new WMSBins();

            return wmsbins.BinInfo(binid);
        }

        [WebMethod]
        public TWmsBins GetBinInfoByCode(string bincode)
        {
            WMSBins wmsbins = new WMSBins();

            return wmsbins.BinByCode(bincode);
        }


        [WebMethod]
        public List<TWmsBins> BinList(short branchid, short bintype)
        {
            WMSBins wmsbins = new WMSBins();
            return wmsbins.BinList(branchid, bintype);
        }

        [WebMethod]
        public long NewWmsTransTask(TwmsTrans newtrans)
        {
            return mywmstrns.InsertWmsTrans(newtrans);
  
        }

        [WebMethod]
        public long testNewWmsTransTask()
        {
            TwmsTrans newtrans = new TwmsTrans();
            newtrans.compid = 1;
            newtrans.branchid = 1;
            newtrans.status = 0;
            newtrans.wmstransid = 1;

            return mywmstrns.InsertWmsTrans(newtrans);

        }

        [WebMethod]
        public List<TwmsTrans> GetTransList(short compid, short branchid, short status, int wmstranstypeid)
        {
            WMSTRANS wmstrans = new WMSTRANS();
            return wmstrans.GetWmsTrans(compid, branchid, status, wmstranstypeid);
        }

        [WebMethod]
        public long MoveInternal(TWmsBinItemsQty binitemqty, TWmsBinStoretrans thistrans)
        {
           WMSBinitemsqty binitemsqtyhandler = new WMSBinitemsqty();
           return binitemsqtyhandler.InternalMove(binitemqty, thistrans);
        }

        [WebMethod]
        public TWmsTransTypes TransTypeInfo(int transtypeid)
        {
            WMSTransTypes wmstranstypedata = new WMSTransTypes();
            return wmstranstypedata.IListTransTypes(" WMSTRANSTYPEID=" + transtypeid.ToString(), "")[0];
        }

        [WebMethod]
        public TWmsTransTypes GetTransTypeInfoFromWmsTrans(int wmstransid)
        {
            WMSTransTypes wmstranstypedata = new WMSTransTypes();

            return wmstranstypedata.WmsTransTypeInstance(wmstransid);
        }
        
        [WebMethod]
        public List<TWmsBinStoretrans> GetStoreTransList(long wmstransid) 
        {
            WMSTRANS mywmstrans = new WMSTRANS();
            return mywmstrans.GetWmsStoreTrans(wmstransid);
       // return wmstranstypedata.g
        }
        
        [WebMethod]
        public TWmsBinStoretrans GetStoreTransRecord(long storetransid)
        {
            WMSTRANS mywmstrans = new WMSTRANS();
            return mywmstrans.GetStoreTransRecord(storetransid);
        }

        [WebMethod]
        public TWmsBinItemsQty GetBinItemQtyRecord(long orderdtlid)
        {
            WMSTRANS mywmstrans = new WMSTRANS();
            return mywmstrans.GetBinItemQtyRecord(orderdtlid);
        }


        [WebMethod]
        public TOrderDetails GetOrderDetail(long orderdtlid)
        {
            return mywmstrns.GetOrderdetails(orderdtlid);

        }

        [WebMethod]
        public long DeleteWmsTranList(long wmstranid)
        {
            return mywmstrns.DeleteWMstrans(wmstranid);

        }

        [WebMethod]
        public long GetTransListCount(long wmstranid)
        {
            return mywmstrns.GetTransListCount(wmstranid);

        }

        [WebMethod]
        public TItems GetItemByCode(string itemcode)
        {
            TitemTrans myitemtrans = new TitemTrans();
            return  myitemtrans.GetItem(itemcode);
        

        }

        
       [WebMethod]
        public long Sqlerrorlog()
        {
            DB db = new DB();
            db.f_sqlerrorlog(0, "test", "test", "WebService");

            return 1;
        }


        //NEW METHODS FOR INV

    }

    }
 