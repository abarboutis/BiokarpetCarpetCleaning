
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlServerCe;
using System.Data.SqlTypes;
using System.Xml;
using System.Net;
using System.IO;
using System.Reflection;
//using WMSRetailClient.SOARetailWMSMiniProvider;
using System.Runtime.InteropServices;
using CarpetCleaningClient.CarpetCleaningWebService;


namespace CarpetCleaningClient
{
    public class WmsTransHandler
    {
        //GetTransList(short compid, short branchid, short status, int wmstranstypeid)

        public DataTable GetTransList(short compid, short branchid, short status, int wmstranstypeid)
        {
            DataTable dt = new DataTable();

            TwmsTrans[] TransDataArray = AppGeneralSettings.webServiceProvider.GetTransList(compid, branchid, status, wmstranstypeid);
            List<TwmsTrans> TransDataList = new List<TwmsTrans>();
            
            try
            {

                for (int i = 0; i < TransDataArray.Length; i++)
                {
                    TransDataList.Add(TransDataArray[i]);
                }
            }
            catch (Exception ex) {  ex.ToString(); }


            return ToDataTable(TransDataList);   

        }

        public DataTable GetStoreTransList(long wmstransid)
        {
            DataTable dt = new DataTable();

            TWmsBinStoretrans[] StoreTransDataArray = AppGeneralSettings.webServiceProvider.GetStoreTransList(wmstransid);
            List<TWmsBinStoretrans> TransDataList = new List<TWmsBinStoretrans>();

            try
            {

                for (int i = 0; i < StoreTransDataArray.Length; i++)
                {
                    TransDataList.Add(StoreTransDataArray[i]);
                }
            }
            catch (Exception ex) { ex.ToString(); }


            return ToDataTable(TransDataList);

        }

        public TWmsBins GetBinInfo(string bincode)
        {
            TWmsBins thisbin = new TWmsBins();
            try
            {
                thisbin = AppGeneralSettings.webServiceProvider.GetBinInfoByCode(bincode);
            }
            catch 
            {
            
            
            }
            
            return thisbin;

        }

        public long BinitemsQtyUpdate(TWmsBinItemsQty mybinitemrow)
        {
           return AppGeneralSettings.webServiceProvider.BinitemsQtyUpdate(mybinitemrow);
        }

        
        public TWmsBinItemsQty GetBinItemQtyRecordByOrder(long orderdtlid)
        {
         return AppGeneralSettings.webServiceProvider.GetBinItemQtyRecord(orderdtlid);
        
        }


        public TOrderDetails GetOrderDetail(long orderdtlid)
        {

            return AppGeneralSettings.webServiceProvider.GetOrderDetail(orderdtlid);       
        }

        public TItems GetItem(string itemcode)
        {

            return AppGeneralSettings.webServiceProvider.GetItemByCode(itemcode);
        }
        
        public TWmsBins GetBinInfoByID(long whbinid)
        {

            return AppGeneralSettings.webServiceProvider.GetBinInfo(whbinid);
        
        }
       
        public long UpdateOrderDetailStatus(long orderdtlid, short status)
        {
            return AppGeneralSettings.webServiceProvider.UpdateOrderDetailStatus(orderdtlid, status);
        }
        
        public long MoveInternal(TWmsBinItemsQty binitemqtyrow,TWmsBinStoretrans thistrans)
    {
                try
            {
                return AppGeneralSettings.webServiceProvider.MoveInternal(binitemqtyrow, thistrans);
            }
            catch
            {
                return -1;

            }
    }

        public TWmsTransTypes GetTransTypeFromWmsTrans(int wmstransid) 
        {
            TWmsTransTypes mytranstype= new TWmsTransTypes();
            mytranstype = AppGeneralSettings.webServiceProvider.GetTransTypeInfoFromWmsTrans(wmstransid);
            return mytranstype;
        
        }

        public TWmsTransTypes GetTransTypeFromID(int transtypeID)
        {
            TWmsTransTypes mytranstype = new TWmsTransTypes();
            mytranstype = AppGeneralSettings.webServiceProvider.TransTypeInfo(transtypeID);
            return mytranstype;

        }

        public long GetTransListcount(long wmstransid) 
        {

            try
            {
                return AppGeneralSettings.webServiceProvider.GetTransListCount(wmstransid);
            }
            catch
            {
                return -1;

            }
        
        }

        public long DeleteTransList(long wmstransid) 
        {
            try
            {
                return AppGeneralSettings.webServiceProvider.DeleteWmsTranList(wmstransid);
            }
            catch 
            {
                return -1;
            
            }
        }

        public TWmsBinStoretrans GetStoreTransRecord(long storetransid) 
        {
            TWmsBinStoretrans thisbinstoretrans= new TWmsBinStoretrans();
            try { thisbinstoretrans = AppGeneralSettings.webServiceProvider.GetStoreTransRecord(storetransid); }
            catch
            {
                
            }
            return thisbinstoretrans;
        
        
        }

        public long InsertNewTrans(TwmsTrans newtrans) 
        {
            try { return AppGeneralSettings.webServiceProvider.NewWmsTransTask(newtrans); }
            catch { return -1; }
        
        
        }
    

#region List to Datatable
        public DataTable ToDataTable<T>(List<T> items)
        {
            var tb = new DataTable(typeof(T).Name);
            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in props)
            {
                Type t = GetCoreType(prop.PropertyType);
                tb.Columns.Add(prop.Name, t);
            }
            foreach (T item in items)
            {
                var values = new object[props.Length];
                for (int i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(item, null);
                }
                tb.Rows.Add(values);
            }
            return tb;
        }
        public static Type GetCoreType(Type t)
        {

            if (t != null && IsNullable(t))
            {
                if (!t.IsValueType)
                    return t;
                else
                    return Nullable.GetUnderlyingType(t);
            }
            else
                return t;
        }

        public static bool IsNullable(Type t)
        {
            return !t.IsValueType || (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>));
        }


#endregion


        public static class Logger
        {
            public static void Log(string logMessage, TextWriter w)
            {
                w.Write("\r\nLog Entry : ");
                w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                w.WriteLine("  :");
                w.WriteLine("  :{0}", logMessage);
                w.WriteLine("-------------------------------");
                // Update the underlying file.
                w.Flush();
            }

            public static void Flog(string errmsg)
            {

                string fname = new System.IO.FileInfo(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).DirectoryName + "\\" + "log.txt";

                try
                {
                    if (File.Exists(fname))
                    {
                        using (FileStream f = File.OpenRead(fname))
                        {
                            if (f.Length > 10240)
                            {
                                f.Close();
                                File.Delete(fname);
                            }
                            else
                                f.Close();
                        }

                    }
                }
                catch { }

                using (StreamWriter w = File.AppendText(fname))
                {
                    Log(errmsg, w);
                    w.Close();

                }


            }
        }


        public static class CoreTools
        {
            [DllImport("coredll.dll")]
            public static extern void SystemIdleTimerReset();
        }


    }
}
