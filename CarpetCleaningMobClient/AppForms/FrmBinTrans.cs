using System;
using System.Collections.Generic;
using System.Data;
using System.Media;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CarpetCleaningClient.CarpetCleaningWebService;

namespace CarpetCleaningClient
{
    public partial class FrmBinTrans : Form
    {
        
        
        
        decimal qtyentered;
        bool iQtyEntered = false;
        bool pics = false;
        short AfterOrderDetailStatus = 0;
        TWmsBinItemsQty binqtyfrom = new TWmsBinItemsQty();
        TWmsBinStoretrans thisstoretrans = new TWmsBinStoretrans();
        TWmsTransTypes thistrans = new TWmsTransTypes();
        TOrderDetails myorderdetail = new TOrderDetails();
        WmsTransHandler mywmshandler = new WmsTransHandler();
        TWmsBins binto = new TWmsBins();
        TItems newitem = new TItems();




        /// <summary>
        /// ////
        /// </summary>
        int iwmstranstypeid;
        int iwmstransid = 0;
        bool needbin = false;
        long istoretransid = 0;
        long rtn;
        long iselectedbin = 0;
        long binitemsqtyrecord;
        long thisbinid = 0;
        string icomments = null;
        public FrmBinTrans(int wmstransid,string comments)
        {
            InitializeComponent();
            iwmstransid = wmstransid;
            GetTransTypeInfo();
            BtnDelete.Visible = false;
            GetTransListCount();
            this.Text = comments;
            icomments = comments;

        }
        public FrmBinTrans(int wmstranstype)
        {
            InitializeComponent();
            GetTransTypeInfo();
            BtnDelete.Visible = false;
            iwmstranstypeid = wmstranstype;

        }

        public FrmBinTrans(int wmstransid, long transid, string comments)
        {
            InitializeComponent();
            iwmstransid = wmstransid;
            istoretransid = transid;
            GetTransTypeInfo();
            BtnDelete.Visible = true;
            GetTransListCount();
            GetTransrecord();
            this.Text = comments;
            icomments = comments;
        }

        private void GetTransrecord() 
        {
         
            thisstoretrans = mywmshandler.GetStoreTransRecord(istoretransid);
            TBOrderDetailID.Text = thisstoretrans.orderdtlid.ToString();
            TBQty.Text = thisstoretrans.itemqtyprimary.ToString();
            TBBin.Text = thisstoretrans.whbincode;
            TBWidth.Text = thisstoretrans.width.ToString();
            TBLength.Text = thisstoretrans.length.ToString();
            lb_customername.Text = thisstoretrans.customertitle;
            lb_itemdesc.Text = thisstoretrans.itemdesc;
            myorderdetail.compid = AppGeneralSettings.CompID;
            myorderdetail.itemid = thisstoretrans.itemid;
            myorderdetail.munitprimary = thisstoretrans.munitprimary;
            myorderdetail.munitsecondary = thisstoretrans.munitsecondary;
            myorderdetail.orderdtlid = thisstoretrans.orderdtlid;
            myorderdetail.orderid = thisstoretrans.orderid;
            myorderdetail.branchid = thisstoretrans.branchid;
            if (TBQty.Enabled) { TBQty.Focus(); } else { tb_save.Focus(); }
            
       
        }

        private void GetTransListCount() 
        {
          LBScanned.Text = "Εγγραφές : "+  mywmshandler.GetTransListcount(iwmstransid);

        }

        private void EnableBinInput() 
        {
            TBBin.Visible = true;
            PBoxBin.Visible = true;
            lb_bin.Visible = true;
            pb_barcode.Visible = true;
        }

        private void DisableBinInput()
        {

            TBBin.Visible = false;
            PBoxBin.Visible = false;
            lb_bin.Visible = false;
            pb_barcode.Visible = false;

        }

        private void GetTransTypeInfo()
        {

            if (AppGeneralSettings.ReceiveAndPlace > 0) EnableBinInput(); else DisableBinInput();

            thistrans = mywmshandler.GetTransTypeFromWmsTrans(iwmstransid);
            iwmstranstypeid = thistrans.wmstranstypeid;
            this.Text = thistrans.wmstranstypedesc;

            if (iwmstranstypeid == AppGeneralSettings.mytranstypes.CustomerReceives)
            {
                lb_transinfo.Text = "ΠΑΡΑΛΑΒΕΣ << ΠΕΛΑΤΗΣ";
                AfterOrderDetailStatus = AppGeneralSettings.myorderstatus.StatusReceivedFromCustomer;
                TBLength.Enabled = true;
                TBWidth.Enabled = true;
                needbin = true;
            }
            if (iwmstranstypeid == AppGeneralSettings.mytranstypes.SupplierShipping)
            {
                lb_transinfo.Text = "ΑΠΟΣΤΟΛΕΣ >> ΚΑΘΑΡΙΣΤΗΡΙΟ";
                AfterOrderDetailStatus = AppGeneralSettings.myorderstatus.StatusSendToSupplier;
                TBLength.Enabled = false;
                TBWidth.Enabled = false;
                TBQty.Enabled = false;
            }
            if (iwmstranstypeid == AppGeneralSettings.mytranstypes.SupplierReceives)
            {
                lb_transinfo.Text = "ΠΑΡΑΛΑΒΕΣ << ΚΑΘΑΡΙΣΤΗΡΙΟ";
                AfterOrderDetailStatus = AppGeneralSettings.myorderstatus.StatusReceivedFromSupplier;
                TBLength.Enabled = true;
                TBWidth.Enabled = true;
                needbin = true;
                TBQty.Enabled = true;
            }
            if (iwmstranstypeid == AppGeneralSettings.mytranstypes.CustomerShipping)
            {
                lb_transinfo.Text = "ΑΠΟΣΤΟΛΕΣ >> ΠΕΛΑΤΗΣ";
                AfterOrderDetailStatus = AppGeneralSettings.myorderstatus.StatusSendToCustomer;
                TBLength.Enabled = false;
                TBWidth.Enabled = false;
                TBQty.Enabled = false;

            }
            if (iwmstranstypeid == AppGeneralSettings.mytranstypes.InventoryTrans)
            {
                lb_transinfo.Text = "ΑΠΟΓΡΑΦΗ";
          //      AfterOrderDetailStatus = AppGeneralSettings.myorderstatus.StatusSendToCustomer;
                TBLength.Enabled = false;
                TBWidth.Enabled = false;
                TBQty.Enabled = false;

            }


        }

        private void FrmBinTrans_Load(object sender, EventArgs e)
        {

             DisableEnter();

            FixResolutionIssues();

        }

        #region Button Back Events 
        
        private void PBBtnBck_MouseDown(object sender, MouseEventArgs e)
        {
            PBBtnBck.Image = Properties.Resources.buttonback_on;
        }

        private void PBBtnBck_MouseUp(object sender, MouseEventArgs e)
        {
            PBBtnBck.Image = Properties.Resources.buttonback;
        }

        private void PBBtnBck_Click(object sender, EventArgs e)
        {
            if (istoretransid > 0)
            {
                GoTransView();
            }
            else {
                GotoMenu();

            }

        }

        private void PBBtnBck_GotFocus(object sender, EventArgs e)
        {
            PBBtnBck.Image = Properties.Resources.buttonback_on;
        }

        private void PBBtnBck_LostFocus(object sender, EventArgs e)
        {
            PBBtnBck.Image = Properties.Resources.buttonback;
        }
        #endregion

        #region Button Save Events        

        private void BtnSave_GotFocus(object sender, EventArgs e)
        {
            BtnSave.Image = Properties.Resources.buttonsave_on;
        }

        private void BtnSave_LostFocus(object sender, EventArgs e)
        {
            BtnSave.Image = Properties.Resources.buttonsave;
        }

        private void BtnSave_MouseDown(object sender, MouseEventArgs e)
        {
            BtnSave.Image = Properties.Resources.buttonsave_on;
        }

        private void BtnSave_MouseUp(object sender, MouseEventArgs e)
        {
            BtnSave.Image = Properties.Resources.buttonsave;
        }

        
        #endregion

        #region Form Events"

        private void FrmBinTrans_MouseDown(object sender, MouseEventArgs e)
        {
            if (LBMsgBox.Visible)
                HideMessageBox();
        }

       
        private void TBItemCode_GotFocus(object sender, EventArgs e)
        {
            //TBItemCode.BackColor = Color.Lavender;
            PBoxOrderDTL.Image = Properties.Resources.textbox_focus;            
            //DisableEnter();

           
        }


        private void TBQty_GotFocus(object sender, EventArgs e)
        {
            //TBQty.BackColor = Color.Lavender;
            PBoxQty.Image = Properties.Resources.textbox_small_focus;
            PBoxBin.Image = Properties.Resources.textbox_small_focus;
            DisableEnter();
            //CheckItemCode();
        }

        private void PBoxITemCode_Click(object sender, EventArgs e)
        {
            TBOrderDetailID.Focus();
        }

        
        private void PBoxEnter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                EnableEnter();
                SaveChanges();
            }
            if (e.KeyCode == Keys.Escape)
                GotoMenu();
        }

        private void PBoxEnter_GotFocus(object sender, EventArgs e)
        {
            EnableEnter();
        }

        private void PBoxEnter_LostFocus(object sender, EventArgs e)
        {
            DisableEnter();
        }
      private void TBItemCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CheckOrderDTLID();
            }
            else if (e.KeyCode == Keys.Escape)
                GotoMenu();
            else
                EnableBackKey(e);
        }

        private void PBoxEnter_MouseMove(object sender, MouseEventArgs e)
        {
            EnableEnter();
        }

        private void PBoxMessage_Click(object sender, EventArgs e)
        {
            HideMessageBox();
        }

        private void TBLotCode_TextChanged(object sender, EventArgs e)
        {
            iQtyEntered = false;

            HideMessageBox();
            
        }

        private void TBItemCode_TextChanged(object sender, EventArgs e)
        {
            iQtyEntered = false;
            HideMessageBox();
        }

        private void TBQty_TextChanged(object sender, EventArgs e)
        {

            iQtyEntered = true;
            HideMessageBox();
        }
           
        private void FrmBinTrans_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                GotoMenu();
                return;
            }
            else if ((e.KeyCode == Keys.Enter))
            {
                if (iQtyEntered || BtnSave.Focus())
                    SaveChanges();
            }
            else                 
                EnableBackKey(e);
        }


        private void PBSoftKeyb_Click(object sender, EventArgs e)
        {
            if (OnScreenKeyboard.Enabled)
                OnScreenKeyboard.Enabled = false;
            else
                OnScreenKeyboard.Enabled = true;
        }
        #endregion


        #region appearance

        protected decimal CheckQTY() 
        {


         decimal qtyentered;
            try
            {
           qtyentered = decimal.Parse(TBQty.Text);
            
            }catch{
                qtyentered = 0;
              }
            return qtyentered;
        
        
        }
        protected void FixResolutionIssues()
        {

            string oldpos = PBMenuBar.Location.X.ToString() + "X" + PBMenuBar.Location.Y.ToString();
            int oldbtny = PBBtnBck.Location.Y - PBMenuBar.Location.Y;

            if (Screen.PrimaryScreen.Bounds.Width > 240)
            {
                PBMenuBar.Location = new Point(PBMenuBar.Location.X, Screen.PrimaryScreen.Bounds.Height - PBMenuBar.Height - 30);

                PBBtnBck.Location = new Point(PBBtnBck.Location.X, PBMenuBar.Location.Y + oldbtny);
                BtnSave.Location = new Point(BtnSave.Location.X, PBMenuBar.Location.Y + oldbtny);

                BtnDelete.Location = new Point(BtnDelete.Location.X, PBMenuBar.Location.Y + oldbtny);

                PBMenuBar.SizeMode = PictureBoxSizeMode.StretchImage;
                PBBtnBck.SizeMode = PictureBoxSizeMode.StretchImage;
                BtnSave.SizeMode = PictureBoxSizeMode.StretchImage;
                BtnDelete.SizeMode = PictureBoxSizeMode.StretchImage;
                PBMenuBar.Width = Screen.PrimaryScreen.Bounds.Width;


            }
            else
            {
                {
                    PBoxOrderDTL.Width = 200;
                    PBoxOrderDTL.Height = 35;
                    PBoxOrderDTL.SizeMode = PictureBoxSizeMode.StretchImage;

                    PBoxQty.Width = 60;
                    PBoxQty.Height = 25;
                    PBoxQty.SizeMode = PictureBoxSizeMode.StretchImage;

                    PBoxItemCode.Width = 70;
                    PBoxItemCode.Height = 25;
                    PBoxItemCode.SizeMode = PictureBoxSizeMode.StretchImage;
                    
                    PBoxBin.Width = 70;
                    PBoxBin.Height = 25;
                    PBoxBin.SizeMode = PictureBoxSizeMode.StretchImage;


                    PBoxLength.Width = 50;
                    PBoxLength.Height = 25;
                    PBoxLength.SizeMode = PictureBoxSizeMode.StretchImage;


                    PBoxWidth.SizeMode = PictureBoxSizeMode.StretchImage;
                    PBoxWidth.Height = 25;
                    PBoxWidth.SizeMode = PictureBoxSizeMode.StretchImage;
                   
                    


                    PBMenuBar.Location = new Point(PBMenuBar.Location.X, Screen.PrimaryScreen.Bounds.Height - PBMenuBar.Height - 25);

                    PBBtnBck.Location = new Point(PBBtnBck.Location.X, PBMenuBar.Location.Y + oldbtny);
                    BtnSave.Location = new Point(BtnSave.Location.X, PBMenuBar.Location.Y + oldbtny);

                    BtnDelete.Location = new Point(BtnDelete.Location.X, PBMenuBar.Location.Y + oldbtny);


                }
            }
        }
 
        protected void EnableEnter()
        {
           // if (PBoxEnter.Image != Properties.Resources.ENTER) PBoxEnter.Image = Properties.Resources.ENTER;
        }

        protected void DisableEnter()
        {
            //if (PBoxEnter.Image != Properties.Resources.enter_disable) PBoxEnter.Image = Properties.Resources.enter_disable;
        }

        protected void ShowMessageBox(string msg,bool iserror)
        {
            if (iserror)
            {
                
                PBoxMessage.Image = Properties.Resources.msgbox_error;
                LBMsgBox.ForeColor = Color.FromArgb(244, 235, 163); 
                LBMsgBox.BackColor = Color.FromArgb(204, 51, 51);

                SystemSounds.Exclamation.Play();
            }
            else
            {
                LBMsgBox.ForeColor = Color.FromArgb(204, 51, 51); 
                LBMsgBox.BackColor = Color.FromArgb(244, 235, 163);             
                PBoxMessage.Image = Properties.Resources.msgbox;

                SystemSounds.Hand.Play();
            }

            PBoxMessage.Visible = true;
            LBMsgBox.Visible = true;
            if (!string.IsNullOrEmpty(msg)) LBMsgBox.Text = msg;
        }


        protected void HideMessageBox()
        {
            if (PBoxMessage.Visible) PBoxMessage.Visible = false;
            if (LBMsgBox.Visible) LBMsgBox.Visible = false;
        }

        protected void EnableSaveChanges()
        {
            BtnSave.Image = Properties.Resources.buttonsave_on;
        }

        protected void DisableSaveChanges()
        {
            BtnSave.Image = Properties.Resources.buttonsave;
        }

        protected void EnableBackKey(KeyEventArgs e)
        {
        }

        #endregion

        protected void GoTransView() 
        {
            Cursor.Current = Cursors.WaitCursor;
            WMSForms.FrmTransListView = new FrmTransListView(iwmstransid, iwmstranstypeid,icomments);
            WMSForms.FrmTransListView.Show();
            this.Close();
            Cursor.Current = Cursors.Default;
        
        }

        protected void GotoMenu()
        {
            Cursor.Current = Cursors.WaitCursor;
            WMSForms.FrmSelectWmsTrans = new FrmSelectWmsTrans(iwmstranstypeid);
            WMSForms.FrmSelectWmsTrans.Show();
            this.Close();

            Cursor.Current = Cursors.Default;
        }    

        protected void InitEntry()
        {
            
            myorderdetail = new TOrderDetails();
            mywmshandler = new WmsTransHandler();

            iQtyEntered = false;
            qtyentered = 0;
            LBPrimMunit.Visible = false;
            TBOrderDetailID.Enabled = true;

            LBPrimMunit.Text = "";
            lb_customername.Text = "";
            lb_itemdesc.Text = "";
            tbcode.Text = "";
             
  
            TBOrderDetailID.Text = "";
            TBBin.Text = "";
            TBLength.Text = "";
            TBWidth.Text = "";
            TBQty.Text = "";

            if (iwmstranstypeid == 1)
            {
                TBWidth.Enabled = true;
                TBLength.Enabled = true;
            }
            GetTransListCount();
            iselectedbin = 0;
            DisableSaveChanges(); 
            
            TBOrderDetailID.Focus();
                    
        }

        private void SaveChanges() 
        {
            TWmsBinItemsQty mybinitemrow = new TWmsBinItemsQty();
            mybinitemrow.transtype = (short) iwmstranstypeid;


            if (istoretransid > 0) 
            {
                mybinitemrow.whbinid = thisstoretrans.whbinid;
                mybinitemrow.whbincode = thisstoretrans.whbincode;
                mybinitemrow.binstoretransid = istoretransid;
                mybinitemrow.updateonly = true;
                if (thisstoretrans.itemqtyprimary != qtyentered) 
                {
                    mybinitemrow.oldqty = thisstoretrans.itemqtyprimary;
                }


            }
                mybinitemrow.createbintransrecord = true;
                mybinitemrow.branchid = AppGeneralSettings.BranchID;
                mybinitemrow.compid = AppGeneralSettings.CompID;
                mybinitemrow.wmstransid = iwmstransid;
                mybinitemrow.createbintransrecord = true;
                mybinitemrow.itemid = myorderdetail.itemid;

                if (pics) { 
                    mybinitemrow.itemqtyprimary = 1;
                    mybinitemrow.itemqtysecondary = qtyentered;
                } else 
                { 
                    mybinitemrow.itemqtyprimary = qtyentered;
                    mybinitemrow.itemqtysecondary = 1;
                }
                
                mybinitemrow.munitprimary = myorderdetail.munitprimary;
                mybinitemrow.munitsecondary = myorderdetail.munitsecondary;
                mybinitemrow.orderdtlid = myorderdetail.orderdtlid;
                mybinitemrow.orderid = myorderdetail.orderid;
                mybinitemrow.transex = thistrans.transex;
                mybinitemrow.transtype = short.Parse(thistrans.wmstranstypeid.ToString());
                if ((TBLength.Text.Length>0) && (TBWidth.Text.Length>0))
                {
                            mybinitemrow.width = decimal.Parse(TBWidth.Text);
                            mybinitemrow.length = decimal.Parse(TBLength.Text);
                }    
            


            if (iwmstranstypeid == AppGeneralSettings.mytranstypes.InventoryTrans)
            {
                mybinitemrow.whbinid = binqtyfrom.whbinid;
                InventoryEntry(mybinitemrow);
                return;
            
            }


            if (!(istoretransid > 0)){

                if ((AppGeneralSettings.ReceiveAndPlace > 0)&& needbin)
                {
                    if (!(binto.whbinid > 0))
                    {
                        ShowMessageBox("Δεν Βρέθηκε θέση αποθήκευσης", true);
                        return;
                    }
                    mybinitemrow.whbinid = binto.whbinid;

                }
                else if (needbin) 
                {

                    mybinitemrow.whbinid = thistrans.wmsbindefault;
                
                }
            }

           rtn = mywmshandler.BinitemsQtyUpdate(mybinitemrow);

           if (rtn > 0) 
           {
               LBScanned.Text = "Εγγραφές : " + rtn.ToString(); 

               Beeper(2);
               UpdateOrderDetailStatus();

               if (istoretransid > 0)
               {
                   GoTransView();
                   return;
               }
               InitEntry();
           }
           else if (rtn == -2) 
           {
               ShowMessageBox("Πρόβλημα καταχώρησης ,η καταχώρηση υπάρχει ήδη στο σύστημα!", true);
               InitEntry();
           }
           else if (rtn == -3)
           {
               ShowMessageBox("Πρόβλημα καταχώρησης ,η καταχώρηση υπάρχει ήδη στο σύστημα!", true);
               InitEntry();
           }
           else if (rtn == -5)
           {
               MessageBox.Show("Η εργασία έχει οριστικοποιηθεί!","Προσοχή",MessageBoxButtons.OK,MessageBoxIcon.Exclamation,MessageBoxDefaultButton.Button1);
               GotoMenu();
           }
        
        }


        protected void InventoryEntry(TWmsBinItemsQty mybinitemrow) 
        {
            rtn = AppGeneralSettings.webServiceProvider.InsertBinTrans(mybinitemrow);
            if (rtn > 0)
            {
                LBScanned.Text = "Εγγραφές : " + rtn.ToString();

                Beeper(2);
                //  UpdateOrderDetailStatus();

                InitEntry();
            }
            else 
            {
                ShowMessageBox(" Διπλή εγγραφή ", true);
            
            }
        
        }



        protected void UpdateOrderDetailStatus()
        {
            if (iwmstranstypeid == AppGeneralSettings.mytranstypes.CustomerReceives)
            { 
                mywmshandler.UpdateOrderDetailStatus(myorderdetail.orderdtlid,AppGeneralSettings.myorderstatus.StatusReceivedFromCustomer);
            }
            if (iwmstranstypeid == AppGeneralSettings.mytranstypes.SupplierShipping)
            {
                mywmshandler.UpdateOrderDetailStatus(myorderdetail.orderdtlid, AppGeneralSettings.myorderstatus.StatusSendToSupplier);
            }
            if (iwmstranstypeid == AppGeneralSettings.mytranstypes.SupplierReceives)
            {
                mywmshandler.UpdateOrderDetailStatus(myorderdetail.orderdtlid, AppGeneralSettings.myorderstatus.StatusReceivedFromSupplier);
            }
            if (iwmstranstypeid == AppGeneralSettings.mytranstypes.CustomerShipping)
            {
                mywmshandler.UpdateOrderDetailStatus(myorderdetail.orderdtlid, AppGeneralSettings.myorderstatus.StatusSendToCustomer);
            }

        }

        protected void CheckOrderDTLID()
        {
            long orderdtlid = 0;
            
            try{orderdtlid = long.Parse(TBOrderDetailID.Text);}
            catch{ 
            ShowMessageBox("Το barcode δεν βρέθηκε!", true);
            return;
            }

            if (thistrans.wmstranstypeid == AppGeneralSettings.mytranstypes.InventoryTrans) 
            {
                binqtyfrom = mywmshandler.GetBinItemQtyRecordByOrder(orderdtlid);
                TBBin.Text = binqtyfrom.whbincode;
            }

            
            if (thistrans.wmstranstypeid == AppGeneralSettings.mytranstypes.CustomerShipping || thistrans.wmstranstypeid == AppGeneralSettings.mytranstypes.SupplierShipping)
            {
              binqtyfrom =   mywmshandler.GetBinItemQtyRecordByOrder(orderdtlid);
              if (!(binqtyfrom.binitemsqtyid > 0))
              {
                  ShowMessageBox("Το Είδος  δεν βρέθηκε στην αποθήκη!", true);
                  return;
              }
              else 
              {
                  TBBin.Text = binqtyfrom.whbincode;
               //   TBQty.Focus();
              
              }
            }

            myorderdetail = AppGeneralSettings.webServiceProvider.GetOrderDetail(orderdtlid);


            if (myorderdetail.orderdtlid > 0)
            {
                if (myorderdetail.munitprimary == 7) pics = true; //Αν είναι τεμάχια


                //IF AN ITEM IS STORED THEN IT CAN GO ANYWHERE ??
                if ((myorderdetail.orderdtlstatus == AfterOrderDetailStatus)&&AfterOrderDetailStatus>0)
                {
                    ShowMessageBox("Η κίνηση έχει γίνει ήδη !", true);
                    return;

                }
                
                LBPrimMunit.Text = myorderdetail.munitprimarydesc;
                if (myorderdetail.width > 0) TBWidth.Text = myorderdetail.width.ToString();
                if (myorderdetail.length > 0) TBLength.Text = myorderdetail.length.ToString();
                tbcode.Text = myorderdetail.itemcode;
                lb_itemdesc.Text = myorderdetail.itemdesc;
                lb_customername.Text = myorderdetail.customertitle;


                if (pics) TBQty.Text = myorderdetail.itemqtysecondary.ToString(); else TBQty.Text = myorderdetail.itemqtyprimary.ToString();
                
                TBLength.Focus();
                if ((AppGeneralSettings.ReceiveAndPlace > 0) && needbin) TBBin.Focus(); else 
                {
                    if (TBQty.Enabled)
                    {
                        TBQty.SelectAll();
                        TBQty.Focus();
                    }
                    else
                    {
                        tb_save.Focus();
                    
                    }
                
                }

            }
            else 
            {
                ShowMessageBox("Το barcode δεν βρέθηκε!", true);
            }
        }
       
        protected void DeleteRecord()
        {
            if (MessageBox.Show("Είστε Βέβαιοι για την Διαγραφή της Εγγραφής;", "Ερώτηση", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                return;

            if (iwmstranstypeid == 1)
            {
               AppGeneralSettings.webServiceProvider.DeleteReceive(myorderdetail.orderdtlid, iwmstranstypeid);
               GoTransView();
               return;
            }
            TWmsBinItemsQty mybinitemrow = new TWmsBinItemsQty();
            mybinitemrow.wmstransid = iwmstransid;
            mybinitemrow.binstoretransid = istoretransid;
            mybinitemrow.orderdtlid = myorderdetail.orderdtlid;
            mybinitemrow.DeleteRecord = 1;
            rtn = mywmshandler.BinitemsQtyUpdate(mybinitemrow);
            myorderdetail = mywmshandler.GetOrderDetail(mybinitemrow.orderdtlid);
            //rollback orderdtlstatus
            int newstatus = myorderdetail.orderdtlstatus - 1;
            mywmshandler.UpdateOrderDetailStatus(mybinitemrow.orderdtlid,(short)newstatus);

        }
        
        protected void Beeper(int ntimes)
        {
            if (ntimes > 0)
            {
                for (int i = 1; i <= ntimes; i++)
                    SystemSounds.Beep.Play();
            }           
        }
       
        private void BtnSave_Click(object sender, EventArgs e)
        {
            qtyentered = CheckQTY();
            if (qtyentered > 0)
            {

                SaveChanges();

            };
        }

        private void TBQty_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                qtyentered = CheckQTY();
                if (qtyentered > 0)
                {

                    
                    SaveChanges();

                };
            }
            else if (e.KeyCode == Keys.Escape)
                GoTransView();
            
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DeleteRecord();

        }

        private void TBBin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (CheckBin()) { 
                    TBBin.SelectAll();
                    if ((pics) && (iwmstranstypeid == 1) && ((tbcode.Text=="2007")||(tbcode.Text=="2009"))) { TBWidth.Focus(); return; }
                    if ((pics) && (iwmstranstypeid == 2)) { TBWidth.Focus(); return; }
                    if ((pics)&&(iwmstranstypeid == 1)) { tb_save.Focus(); return; }

                    if (TBWidth.Enabled == true)
                    {
                        if ((TBWidth.Text.Length > 0) &&(TBLength.Text.Length > 0)&&(TBQty.Text.Length > 0))
                        {
                            tb_save.Focus();
                            return;
                        }

                        TBWidth.Focus();
                    }
                    else {
                        if (TBQty.Enabled)
                        {
                            TBQty.Focus();
                        }
                        else 
                        {
                            tb_save.Focus();
                        }
                    }
                }


            }

        }

        protected bool CheckBin()
        {
            binto = new TWmsBins();
            string bincode = TBBin.Text.Trim();

            if (bincode.Length > 0)
            {
                TBBin.Text = bincode;
                //  iselectedbin = servicedata.BinIDByCode(bincode);
                binto = mywmshandler.GetBinInfo(bincode);
                if (!(binto.whbinid > 0))
                {
                    ShowMessageBox("Η θέση αποθήκευσης δεν είναι έγγυρη!", true);
                    TBBin.Text = "";
                    TBBin.Focus();
                    return false;
                }
                else
                    return true;
            }
            return false;
        }

        private void TBBin_GotFocus(object sender, EventArgs e)
        {
            //TBQty.BackColor = Color.Lavender;
            PBoxBin.Image = Properties.Resources.textbox_small_focus;
            DisableEnter();
            //CheckItemCode();
        }

        private void TBQty_LostFocus(object sender, EventArgs e)
        {
            PBoxQty.Image = Properties.Resources.textbox_small;

        }

        private void TBBin_LostFocus(object sender, EventArgs e)
        {
            PBoxBin.Image = Properties.Resources.textbox_small;
        }

        private void TBOrderDetailID_LostFocus(object sender, EventArgs e)
        {
            PBoxOrderDTL.Image = Properties.Resources.textbox_small;
        }

        private void TBWidth_GotFocus(object sender, EventArgs e)
        {
            PBoxWidth.Image = Properties.Resources.textbox_small_focus;
        }

        private void TBWidth_LostFocus(object sender, EventArgs e)
        {
            PBoxWidth.Image = Properties.Resources.textbox_small;
        }

        private void TBLength_GotFocus(object sender, EventArgs e)
        {
            PBoxLength.Image = Properties.Resources.textbox_small_focus;
        }

        private void TBLength_LostFocus(object sender, EventArgs e)
        {
            PBoxLength.Image = Properties.Resources.textbox_small;
        }

        private void TBLength_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Back)
            {
                if (TBLength.Text.Length == 2) 
                {
                    TBLength.Text = "";
                
                }
            }

            if (e.KeyCode == Keys.Enter)
            {
                try
                {

                    decimal.Parse(TBLength.Text);

                    if (TBWidth.Text.Length > 0)
                    {
                        TBQty.Text = (decimal.Round(Decimal.Parse(TBWidth.Text) * Decimal.Parse(TBLength.Text), 2)).ToString();
                        TBQty.Focus();
                        

                    }
                    else 
                    {
                        TBWidth.Focus();
                    
                    }

                }
                catch
                {
                    ShowMessageBox("Λάθος Αριθμός", true);
                }


            }


        }

        private void TBWidth_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                if (TBWidth.Text.Length == 2)
                {
                    TBWidth.Text = "";

                }
            }

            if (e.KeyCode == Keys.Enter)
            {
                    try
                    {
                        if (TBWidth.Text.Length == 0)
                        {
                            tb_save.Focus();
                            return;
                        }
                        
                        if (TBLength.Text.Length > 0)
                        {
                            decimal.Parse(TBWidth.Text);
                            TBQty.Text = (decimal.Round(Decimal.Parse(TBWidth.Text) * Decimal.Parse(TBLength.Text), 2)).ToString();
                            TBQty.Focus();
                        }
                        else
                        {
                            TBLength.Focus();
                        }

                    }
                    catch
                    {
                        ShowMessageBox("Λάθος Αριθμός", true);
                    }
                

            }





        }

        private void TBLength_TextChanged(object sender, EventArgs e)
        {
            if (TBLength.Text.Length == 1) 
            {
                TBLength.Text = TBLength.Text + ",";
                TBLength.Select(TBLength.Text.Length, 0);
            }
        }

        private void TBWidth_TextChanged(object sender, EventArgs e)
        {
            if (TBWidth.Text.Length == 1)
            {
                TBWidth.Text = TBWidth.Text + ",";
                TBWidth.Select(TBWidth.Text.Length, 0);
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                qtyentered = CheckQTY();
                
                if ((pics)||(!pics && qtyentered > 0))
                {
                    SaveChanges();

                }
            }
        }

        private void ΤΒItemCode_GotFocus(object sender, EventArgs e)
        {
            PBoxItemCode.Image = Properties.Resources.textbox_small_focus;
        }

        private void ΤΒItemCode_LostFocus(object sender, EventArgs e)
        {
            PBoxItemCode.Image = Properties.Resources.textbox_small;
        }

        private void ΤΒItemCode_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)
            {
                changeItemOnOrder();
                if (TBBin.Text == "")
                {
                    TBBin.Focus();
                }
                else 
                {
                    TBWidth.Focus();
                
                }

            }
        }

        private void changeItemOnOrder()
        {
            if (iwmstranstypeid != 1) return;
            else{
            newitem = mywmshandler.GetItem(tbcode.Text);
            myorderdetail.itemid = newitem.itemid;
                if (newitem.itemid > 0)
                {
                    AppGeneralSettings.webServiceProvider.UpdateOrderDetailItem(myorderdetail.orderdtlid, newitem.itemid);
                }

                    
            myorderdetail.munitprimary = newitem.munitprimary;
            myorderdetail.munitsecondary = newitem.munitsecondary;
            lb_itemdesc.Text = newitem.itemdesc;
            
            }
              
        }

        private void TBBin_TextChanged(object sender, EventArgs e)
        {
            HideMessageBox();
        }

                   
    }
}