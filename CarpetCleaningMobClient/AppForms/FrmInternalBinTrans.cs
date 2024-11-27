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
    public partial class FrmInternalBinTrans : Form
    {
        decimal qtyentered;
        bool iQtyEntered = false;
        TWmsBins binfrom = new TWmsBins();
        TWmsBins binto = new TWmsBins();
        TWmsBinItemsQty binitemqtyrecord = new TWmsBinItemsQty();
        TWmsBinStoretrans thisstoretrans = new TWmsBinStoretrans();
        TWmsTransTypes thistrans = new TWmsTransTypes();
        TOrderDetails myorderdetail = new TOrderDetails();
        WmsTransHandler mywmshandler = new WmsTransHandler();

        /// <summary>
        /// ////
        /// </summary>
        int iwmstranstypeid;
        int iwmstransid = 0;
        long istoretransid = 0;
        long rtn;
        long iselectedbin = 0;
        string icomments = null;

        public FrmInternalBinTrans(int wmstransid,string comments)
        {
            InitializeComponent();
            iwmstransid = wmstransid;
            GetTransTypeInfo();

        }
        public FrmInternalBinTrans(int wmstranstype)
        {
            InitializeComponent();
            iwmstranstypeid = wmstranstype;
            GetTransTypeInfo();
            InitEntry();
        }


        private void GetTransTypeInfo()
        {
            thistrans = mywmshandler.GetTransTypeFromID(iwmstranstypeid);
            if (thistrans.wmstranstypeid == AppGeneralSettings.mytranstypes.InternalMove)
            {
                
                EnableBinInput();
                this.Text = "Διακίνηση";
            }
            iwmstranstypeid = thistrans.wmstranstypeid;
            this.Text = thistrans.wmstranstypedesc;
        }



        private void FrmBinTrans_Load(object sender, EventArgs e)
        {
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
                GotoMenu();

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
            PBoxITemCode.Image = Properties.Resources.textbox_focus;            
            //DisableEnter();

           
        }

        private void DisableBinInput()
        {
            PBoxBin.Visible = false;
            LBBin.Visible = false;
            PBoxBarcodeBin.Visible = false;
            TBBin.Visible = false;
            PBUpArrow.Visible = false;
            PBDownArrow.Visible = false;
        
        }

        private void EnableBinInput()
        {
            PBoxBin.Visible = true;
            LBBin.Visible = true;
            PBoxBarcodeBin.Visible = true;
            TBBin.Visible = true;
            PBUpArrow.Visible = true;
            PBDownArrow.Visible = true;

        }

        protected void UpdateOrderDetailStatus()
        {
                mywmshandler.UpdateOrderDetailStatus(myorderdetail.orderdtlid, 5);

        }
        private void TBQty_GotFocus(object sender, EventArgs e)
        {
            PBoxQty.Image = Properties.Resources.textbox_small_focus;
        }

        private void PBoxITemCode_Click(object sender, EventArgs e)
        {
            TBOrderDTL.Focus();
        }

        
        private void PBoxEnter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SaveChanges();
            }
            if (e.KeyCode == Keys.Escape)
                GotoMenu();
        }

      private void TBItemCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Cursor.Current = Cursors.WaitCursor;
                CheckOrderDTLID();
                Cursor.Current = Cursors.Default;
            }
            else if (e.KeyCode == Keys.Escape)
                GotoMenu();
            else
                EnableBackKey(e);
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

        private void TBBin_GotFocus(object sender, EventArgs e)
        {
            PBoxBin.Image = Properties.Resources.textbox_small_focus;
        }


        private void TBBin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {                
                if (CheckBin()) SaveChanges();
            }
            if (e.KeyCode == Keys.Escape)
                GotoMenu();

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
                MessageBox.Show("Πρόβλημα στην ποσότητα");
                return -1;
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


                PBoxFrom.SizeMode = PictureBoxSizeMode.StretchImage; 
                PBoxBin.SizeMode = PictureBoxSizeMode.StretchImage;
                PBMenuBar.SizeMode = PictureBoxSizeMode.StretchImage;
                PBBtnBck.SizeMode = PictureBoxSizeMode.StretchImage;
                BtnSave.SizeMode = PictureBoxSizeMode.StretchImage;
                PBMenuBar.Width = Screen.PrimaryScreen.Bounds.Width;


            }
            else
            {
                {
                    PBoxFrom.SizeMode = PictureBoxSizeMode.StretchImage; 
                    PBoxITemCode.SizeMode = PictureBoxSizeMode.StretchImage;
                    PBoxQty.SizeMode = PictureBoxSizeMode.StretchImage;
                    PBoxBin.SizeMode = PictureBoxSizeMode.StretchImage;

                    PBMenuBar.Location = new Point(PBMenuBar.Location.X, Screen.PrimaryScreen.Bounds.Height - PBMenuBar.Height - 25);

                    PBBtnBck.Location = new Point(PBBtnBck.Location.X, PBMenuBar.Location.Y + oldbtny);
                    BtnSave.Location = new Point(BtnSave.Location.X, PBMenuBar.Location.Y + oldbtny);

                }
            }
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

        protected void ShowHideUpDownArrows(bool show)
        {
            if (show)
            {
                PBUpArrow.Visible = true;
                PBDownArrow.Visible = true;
            }
            else
            {
                PBUpArrow.Visible = true;
                PBDownArrow.Visible = true;
            }

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



        protected void GotoMenu()
        {
            Cursor.Current = Cursors.WaitCursor;

            WMSForms.FrmMenu = new FrmMenu();
            WMSForms.FrmMenu.Show();
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
            LBAlterQty.Visible = false;

            LBPrimMunit.Text = "";
            LBAlterQty.Text = "";

            TBOrderDTL.Text = "";
            lb_customername.Text = "";
            TBBin.Text = "";

            LBAvailableqty.Text = "";
            lb_itemdesc.Text = "";

            TBBin.Text = "";
            TBbin_from.Text = "";
            TBQty.Text = "";

            TBOrderDTL.Enabled = true;
            
            iselectedbin = 0;

            TBOrderDTL.Focus();
            DisableSaveChanges();
                                
        }

        private void SaveChanges() 
        {
            //SAVE INTERNAL MOVE CHANGE

           

            TWmsBinItemsQty mybinitemrow = new TWmsBinItemsQty();
            TWmsBinStoretrans thisbintrans = new TWmsBinStoretrans();
            
           
            //UPDATE BIN
            mybinitemrow =  binitemqtyrecord;
            mybinitemrow.createbintransrecord = true;
            mybinitemrow.whbinid = binto.whbinid;
            mybinitemrow.whbincode = binto.whbincode;
            mybinitemrow.transtype = (short) iwmstranstypeid;

         
            //DESIGN TRANS
            thisbintrans.branchid = AppGeneralSettings.BranchID;
            thisbintrans.compid = AppGeneralSettings.CompID;
            thisbintrans.itemid = mybinitemrow.itemid;
            thisbintrans.itemqtyprimary = mybinitemrow.itemqtyprimary;
            thisbintrans.itemqtysecondary = mybinitemrow.itemqtysecondary;
            thisbintrans.munitprimary = mybinitemrow.munitprimary;
            thisbintrans.munitsecondary =mybinitemrow.munitsecondary;
            thisbintrans.orderdtlid = mybinitemrow.orderdtlid;
            thisbintrans.orderid = mybinitemrow.orderid;
            thisbintrans.whbinidfrom = binfrom.whbinid;
            thisbintrans.whbinidto = mybinitemrow.whbinid;
            thisbintrans.wmstranstype = (short)thistrans.wmstranstypeid;
            thisbintrans.transex = thistrans.transex;

            rtn = mywmshandler.MoveInternal(mybinitemrow, thisbintrans);



           if (rtn > 0) 
           {

              // UpdateOrderDetailStatus();
               Beeper(2);
               InitEntry();
           }
           else if (rtn == -2) 
           {
               ShowMessageBox("Πρόβλημα καταχώρησης ,η καταχώρηση υπάρχει ήδη στο σύστημα", true);
               InitEntry();
           }
           else if (rtn == -3)
           {
               ShowMessageBox("Πρόβλημα καταχώρησης ,η καταχώρηση υπάρχει ήδη στο σύστημα", true);
               InitEntry();
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

        protected void CheckOrderDTLID()
        {
            long orderdtlid = 0;

            try { orderdtlid = long.Parse(TBOrderDTL.Text); }
            catch{ 
            ShowMessageBox("Το barcode δεν βρέθηκε!", true);
            return;
            }
            binitemqtyrecord = mywmshandler.GetBinItemQtyRecordByOrder(orderdtlid);
            if (!(binitemqtyrecord.binitemsqtyid > 0))
            {
                MessageBox.Show("Το είδος δεν υπάρχει στην αποθήκη");
                return;
            }
            myorderdetail = mywmshandler.GetOrderDetail(orderdtlid);
            if (myorderdetail.orderdtlid > 0)
            {
                //Check order dtl status , 
                //if myorderdetail.orderdtlstatus

                LBPrimMunit.Text = myorderdetail.munitprimarydesc;

                lb_itemdesc.Text = myorderdetail.itemdesc;
                lb_customername.Text = myorderdetail.customertitle;
                binfrom = mywmshandler.GetBinInfoByID(binitemqtyrecord.whbinid);
                TBbin_from.Text = binfrom.whbincode.ToString();
                TBQty.Text = myorderdetail.itemqtyprimary.ToString();

                TBBin.Focus();
            }
            else 
            {
                ShowMessageBox("Το barcode δεν βρέθηκε!", true);
            
            
            }
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
            if (CheckBin()) SaveChanges();
        }

        private void TBbin_from_GotFocus(object sender, EventArgs e)
        {
            PBoxFrom.Image = Properties.Resources.textbox_small_focus;
        }

        private void TBOrderDetailID_LostFocus(object sender, EventArgs e)
        {
            PBoxITemCode.Image = Properties.Resources.textbox;
        }

        private void TBbin_from_LostFocus(object sender, EventArgs e)
        {
            PBoxFrom.Image = Properties.Resources.textbox_small;
        }

        private void TBBin_LostFocus(object sender, EventArgs e)
        {
           PBoxBin.Image = Properties.Resources.textbox_small;
        }

   
        
        

        

                   
    }
}