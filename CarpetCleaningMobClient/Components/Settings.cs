
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;


namespace CarpetCleaningClient
{
    public static class WMSForms
    {
        public static FrmSettings FrmSettings;
        public static FrmBinTrans FrmBinTrans;
        public static FrmInternalBinTrans FrmInternalBinTrans;
        public static FrmReceivesMenu FrmReceivesMenu;
        public static FrmShippingMenu FrmShippingMenu;
        public static FrmWmsSettings FrmWmsSettings;
        public static FrmSelectWmsTrans FrmSelectWmsTrans;
        public static FrmTransListView FrmTransListView;
        public static FrmMenu FrmMenu;
    }

    public static class  AppGeneralSettings
    {

        public static int SyncRecordsAmount;
        public static short CompID;
        public static short BranchID;
        public static short KindID;
        public static int StoreID;
        public static string SERVERIP;
        public static CarpetCleaningWebService.WebService webServiceProvider = new CarpetCleaningWebService.WebService();
        public static WmsTransTypes mytranstypes;
        public static short defaultactivestatus = 1;
        public static OrderDetailStatus myorderstatus;
        public static short ReceiveAndPlace = 1;
        public static short InputDimensions = 1;
       

    }

    public struct OrderDetailStatus
    {
        public short StatusReceivedFromCustomer { get; set; }
        public short StatusSendToSupplier { get; set; }
        public short StatusReceivedFromSupplier { get; set; }
        public short StatusSendToCustomer { get; set; }
        public short StatusStored { get; set; }

    }

    public  struct WmsTransTypes
    {
        public int CustomerReceives { get; set; }
        public int SupplierReceives { get; set; }
        public int CustomerShipping { get; set; }
        public int SupplierShipping { get; set; }
        public int InventoryTrans { get; set; }
        public int InternalMove { get; set; }
        public int DefaultReceivesBIN { get; set; }

    }

    public  class AppSettings
    {
         short compid;
         short branchid;
         short kindid;
         int storeid;
         int m2munit;
         string websvcurl;
         string serverip;
         string configfile = "MyConfig.xml";
         public string ErrorMsg;
         public string UpdateURL;


        #region Properties

        public  short CompID
        { get { return compid; } set { compid = value; } }

        public short KindID
        { get { return kindid; } set { kindid = value; } }


        public short BranchID
        { get { return branchid; } set { branchid = value; } }

        public  int StoreID
        { get { return storeid; } set { storeid = value; } }

       

        public int M2Uunit
        { get { return m2munit; } set { m2munit = value; } }



        
        public string SERVERIP
        { get { return serverip; } set { serverip = value; } }
        

        public string WebSvcUrl
        { get { return websvcurl; } set { websvcurl = value; } }

        #endregion


        public  AppSettings()
        {
            SetOrderStatus();
            SettingsFromFile();
            WebServiceSetup();

            if (compid > 0) AppGeneralSettings.CompID = compid;
            if (branchid > 0) AppGeneralSettings.BranchID = branchid;
            if (storeid > 0) AppGeneralSettings.StoreID = storeid;
            if (kindid > 0) AppGeneralSettings.KindID = kindid;

            
            AppGeneralSettings.webServiceProvider.Url = websvcurl;

            AppGeneralSettings.SERVERIP = serverip;
            try { UpdateURL = websvcurl + "Download/CarpetCleaning_setup.CAB"; }
            catch { }
        }
        private void SetOrderStatus()
        {
            AppGeneralSettings.myorderstatus.StatusReceivedFromCustomer = 1;
            AppGeneralSettings.myorderstatus.StatusSendToSupplier = 2;
            AppGeneralSettings.myorderstatus.StatusReceivedFromSupplier = 3;
            AppGeneralSettings.myorderstatus.StatusSendToCustomer = 4;
            AppGeneralSettings.myorderstatus.StatusStored = 5;
        
        }

        private   void SettingsFromFile()
        {
            string XMLConfFile;
            string XMLFilePath;

            XMLFilePath = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;
            XMLConfFile = new FileInfo(XMLFilePath).DirectoryName + "\\" + configfile;


            XmlTextReader XMLConftReader = new System.Xml.XmlTextReader(XMLConfFile);
            XmlNameTable MyXmlNT   = XMLConftReader.NameTable;
         
            while (XMLConftReader.Read())
            {
                switch  (XMLConftReader.Name)
                    {
                    case "COMPID":
                            try { compid = short.Parse(XMLConftReader.ReadString()); }
                            catch { }
                            break;

                    case "BRANCHID":
                            try { branchid = short.Parse(XMLConftReader.ReadString()); }
                            catch { }
                            break;
                        
                    case "STOREID":
                            try { storeid = int.Parse(XMLConftReader.ReadString()); }
                            catch { }
                            break;

                    case "M2MUNIT":
                            try { m2munit = int.Parse(XMLConftReader.ReadString()); }
                            catch { }
                            break;
                    case "WMSService":
                            try { websvcurl = XMLConftReader.ReadString(); }
                            catch { }
                            break;

                    case "CUSTOMERRECEIVES":
                            try { AppGeneralSettings.mytranstypes.CustomerReceives = int.Parse(XMLConftReader.ReadString()); }
                            catch { }
                            break;
                    case "SUPPLIERRECEIVES":
                            try { AppGeneralSettings.mytranstypes.SupplierReceives = int.Parse(XMLConftReader.ReadString()); }
                            catch { }
                            break;
                    case "CUSTOMERSHIPPING":
                            try { AppGeneralSettings.mytranstypes.CustomerShipping =int.Parse(XMLConftReader.ReadString()); }
                            catch { }
                            break;
                    case "SUPPLIERSHIPPING":
                            try { AppGeneralSettings.mytranstypes.SupplierShipping = int.Parse(XMLConftReader.ReadString()); }
                            catch { }
                            break;
                    case "INTERNALMOVE":
                            try { AppGeneralSettings.mytranstypes.InternalMove = int.Parse(XMLConftReader.ReadString()); }
                            catch { }
                            break;
                    case "INVENTORYTRANS":
                            try { AppGeneralSettings.mytranstypes.InventoryTrans = int.Parse(XMLConftReader.ReadString()); }
                            catch { }
                            break;
                    case "DEFAULTRECEIVESBIN":
                            try { AppGeneralSettings.mytranstypes.DefaultReceivesBIN = int.Parse(XMLConftReader.ReadString()); }
                            catch { }
                            break;
                    case "INPUTDIMENSIONS":
                            try { AppGeneralSettings.InputDimensions = short.Parse(XMLConftReader.ReadString()); }
                            catch { }
                            break;
                        
                        

                    }



            }

            XMLConftReader.Close();
            
           
        }

        private  void WebServiceSetup()
        {
            if (!string.IsNullOrEmpty(websvcurl))
                AppGeneralSettings.webServiceProvider.Url = websvcurl;

            AppGeneralSettings.webServiceProvider.Timeout = 200000;
        }

        public  long SaveSettings()
        {
            int fcompid, fbranchid, fstoreid;
            int fm2munit;
            string fwebsvcurl;
      
            StringBuilder XmlStr = new StringBuilder();

            string XMLFilePath,XMLConfFile;

            if (compid > 0) fcompid = compid; else fcompid = 1;
            if (branchid > 0) fbranchid = branchid; else fbranchid = 0;
            if (storeid > 0) fstoreid = storeid; else fstoreid = 0;
            if (m2munit > 0) fm2munit = m2munit; else fm2munit = 0;
            if (compid > 0) AppGeneralSettings.CompID = compid;
            if (branchid > 0) AppGeneralSettings.BranchID = branchid;
            if (storeid > 0) AppGeneralSettings.StoreID = storeid;

           
            if (!string.IsNullOrEmpty(websvcurl)) fwebsvcurl = websvcurl; else fwebsvcurl = " ";

            XmlStr.AppendLine("<?xml version='1.0'?>");
            XmlStr.AppendLine("<AppConfig>");
            XmlStr.AppendLine("<COMPID>" + fcompid.ToString() + "</COMPID>");
            XmlStr.AppendLine("<BRANCHID>" + fbranchid.ToString() + "</BRANCHID>");
            XmlStr.AppendLine("<STOREID>" + fstoreid.ToString() + "</STOREID>");           
            XmlStr.AppendLine("<M2MUNIT>" + fm2munit.ToString() + "</M2MUNIT>");
            XmlStr.AppendLine("<WMSService>" + fwebsvcurl + "</WMSService>");
            XmlStr.AppendLine("<CUSTOMERRECEIVES>" + AppGeneralSettings.mytranstypes.CustomerReceives.ToString() + "</CUSTOMERRECEIVES>");
            XmlStr.AppendLine("<SUPPLIERRECEIVES>" + AppGeneralSettings.mytranstypes.SupplierReceives.ToString() + "</SUPPLIERRECEIVES>");
            XmlStr.AppendLine("<CUSTOMERSHIPPING>" + AppGeneralSettings.mytranstypes.CustomerShipping.ToString() + "</CUSTOMERSHIPPING>");
            XmlStr.AppendLine("<SUPPLIERSHIPPING>" + AppGeneralSettings.mytranstypes.SupplierShipping.ToString() + "</SUPPLIERSHIPPING>");
            XmlStr.AppendLine("<INTERNALMOVE>" + AppGeneralSettings.mytranstypes.InternalMove.ToString() + "</INTERNALMOVE>");
            XmlStr.AppendLine("<INVENTORYTRANS>" + AppGeneralSettings.mytranstypes.InventoryTrans.ToString() + "</INVENTORYTRANS>");
            XmlStr.AppendLine("<DEFAULTRECEIVESBIN>" + AppGeneralSettings.mytranstypes.DefaultReceivesBIN.ToString() + "</DEFAULTRECEIVESBIN>");
            XmlStr.AppendLine("<INPUTDIMENSIONS>" + AppGeneralSettings.InputDimensions.ToString() + "</INPUTDIMENSIONS>");
            XmlStr.AppendLine("</AppConfig>");
            
   
            
            XMLFilePath = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;
            XMLConfFile = new System.IO.FileInfo(XMLFilePath).DirectoryName + "\\" + configfile;


            try {File.Delete(XMLConfFile);} catch{}

            XmlDocument XmlConf = new XmlDocument();

            try
            {
                XmlConf.LoadXml(XmlStr.ToString());
                XmlConf.Save(XMLConfFile);
                return 1;
            }
            catch (Exception ex) { ErrorMsg = ex.ToString();return -1; }

            //return 0;
        }

        
    }

}
