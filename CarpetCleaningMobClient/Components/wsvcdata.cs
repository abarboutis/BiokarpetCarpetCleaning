using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Reflection;
using CarpetCleaningClient.CarpetCleaningWebService;

namespace CarpetCleaningClient
{
    class wsvcdata
    {
        public string wsvcerror = null;

        public long CheckConnection()
        {
            long RTRN = -1;
            try
            {
                RTRN = AppGeneralSettings.webServiceProvider.CheckDBConnection();
                return RTRN;
            }
            catch  {  }

            return RTRN;
        }



        public long BinitemsQtyUpdate(TWmsBinItemsQty binitemqtyrecord)
        {
            wsvcerror = null;

            long rtrn=0;
            try
            {
                rtrn = AppGeneralSettings.webServiceProvider.BinitemsQtyUpdate(binitemqtyrecord);
            }
            catch (Exception ex) { wsvcerror = ex.ToString(); }
            return rtrn;            
        }

        public List<TWmsBins> BinList(short bintype)
        {
            wsvcerror = null;

            TWmsBins[] wmsbins=null;
            List<TWmsBins> binlist = new List<TWmsBins>();

            try
            {
                wmsbins = AppGeneralSettings.webServiceProvider.BinList((short)AppGeneralSettings.BranchID, bintype);
            }
            catch (Exception ex) { wsvcerror = ex.ToString(); }

            for (int i = 0; i < wmsbins.Length; i++)
            {
                binlist.Add(wmsbins[i]);
            }


            return binlist;
        }


        public long BinIDByCode(string bincode)
        {
            wsvcerror = null;

            long binid = 0;

            try
            {
                binid = AppGeneralSettings.webServiceProvider.BinIDByCode((short)AppGeneralSettings.BranchID, bincode);
            }
            catch (Exception ex) { wsvcerror = ex.ToString(); }

            return binid;
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

        public static bool IsNullable(Type t)
        {
            return !t.IsValueType || (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>));
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
       
        #endregion       

    }

    public class OrderTrans : DataTable
    {
        

        public OrderTrans()
        {

            //this = new DataTable();
            this.Columns.Add(new DataColumn("WHBINID", typeof(long)));
            this.Columns.Add(new DataColumn("ORDERID", typeof(long)));
            this.Columns.Add(new DataColumn("ORDERDTLID", typeof(long)));
            this.Columns.Add(new DataColumn("ITEMID", typeof(long)));
            this.Columns.Add(new DataColumn("ITEMLOTID", typeof(long)));
            this.Columns.Add(new DataColumn("PACKITEMID", typeof(long)));
            this.Columns.Add(new DataColumn("ITEMQTYPRIMARY", typeof(decimal)));
            this.Columns.Add(new DataColumn("MUNITPRIMARY", typeof(short)));
            this.Columns.Add(new DataColumn("ITEMQTYSECONDARY", typeof(decimal)));
            this.Columns.Add(new DataColumn("MUNITSECONDARY", typeof(short)));
        }

    }
}
