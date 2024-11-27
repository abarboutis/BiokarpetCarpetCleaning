using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSMobileClient;
using System.Net;
using System.Xml;
using System.Web;
using CarpetCleaningClient;
using System.IO;


namespace CarpetCleaningClient
{
    public partial class FrmWmsSettings : Form
    {
        bool iHitEnter = false;
        AppSettings settings = new AppSettings();

        public FrmWmsSettings()
        {

            InitializeComponent();
            FixResolutionIssues();

            GetSettings();

       }

        #region Events
        private void FrmSettings_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && iHitEnter)
            {
                SaveChanges();
            }
            if (e.KeyCode == Keys.Escape)
            {
                GotoMenu();
            }

        }


        private void TBStoreID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                iHitEnter = true;                                
            }
            if (e.KeyCode == Keys.Escape)
                GotoMenu();
        }

        private void TBTransType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && iHitEnter)
            {
                iHitEnter = true;    
            }
            if (e.KeyCode == Keys.Escape)
            {
                GotoMenu();
            }

        }

        private void PBoxEnter_MouseMove(object sender, MouseEventArgs e)
        {
            BtnSave.Image = Properties.Resources.ENTER;
        }

        private void PBBtnBck_Click(object sender, EventArgs e)
        {
            GotoMenu();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveChanges();
        }

        private void PBBtnBck_GotFocus(object sender, EventArgs e)
        {
            PBBtnBck.Image = Properties.Resources.buttonback_on;
        }

        private void PBBtnBck_LostFocus(object sender, EventArgs e)
        {
            PBBtnBck.Image = Properties.Resources.buttonback;
        }

        private void PBBtnBck_MouseDown(object sender, MouseEventArgs e)
        {
            PBBtnBck.Image = Properties.Resources.buttonback_on;
        }

        private void PBBtnBck_MouseUp(object sender, MouseEventArgs e)
        {
            PBBtnBck.Image = Properties.Resources.buttonback;
        }

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

        private void PBoxEnter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SaveChanges();
            if (e.KeyCode == Keys.Escape)
                GotoMenu();
        }

 
 
        #endregion

        protected void GetSettings()
        {
            DisableEnter();
            TB_CustomerReceives.Text = AppGeneralSettings.mytranstypes.CustomerReceives.ToString();
            TB_CustomerShipping.Text = AppGeneralSettings.mytranstypes.CustomerShipping.ToString();
            TB_SupplierReceives.Text = AppGeneralSettings.mytranstypes.SupplierReceives.ToString();
            TB_SupplierShipping.Text = AppGeneralSettings.mytranstypes.SupplierShipping.ToString();
            TB_DefaultReceivesBin.Text = AppGeneralSettings.mytranstypes.DefaultReceivesBIN.ToString();
            TB_InternalMove.Text = AppGeneralSettings.mytranstypes.InternalMove.ToString();
           
        }

        protected void GotoMenu()
        {          
            this.Close();
            
        }

        protected void SaveChanges()
        {
             try { if (int.Parse(TB_CustomerReceives.Text) > 0 && AppGeneralSettings.mytranstypes.CustomerReceives != int.Parse(TB_CustomerReceives.Text)) AppGeneralSettings.mytranstypes.CustomerReceives= int.Parse(TB_CustomerReceives.Text); }
             catch { if (TB_CustomerReceives.Text.Length > 0) ErrorMessage(""); return; }

             try { if (int.Parse(TB_CustomerShipping.Text) > 0 && AppGeneralSettings.mytranstypes.CustomerShipping != int.Parse(TB_CustomerShipping.Text)) AppGeneralSettings.mytranstypes.CustomerShipping = int.Parse(TB_CustomerShipping.Text); }
             catch { if (TB_CustomerShipping.Text.Length > 0) ErrorMessage(""); return; }

             try { if (int.Parse(TB_SupplierReceives.Text) > 0 && AppGeneralSettings.mytranstypes.SupplierReceives != int.Parse(TB_SupplierReceives.Text)) AppGeneralSettings.mytranstypes.SupplierReceives = int.Parse(TB_SupplierReceives.Text); }
             catch { if (TB_SupplierReceives.Text.Length > 0) ErrorMessage(""); return; }


             try { if (int.Parse(TB_SupplierShipping.Text) > 0 && AppGeneralSettings.mytranstypes.SupplierShipping != int.Parse(TB_SupplierShipping.Text)) AppGeneralSettings.mytranstypes.SupplierShipping = int.Parse(TB_SupplierShipping.Text); }
             catch { if (TB_SupplierShipping.Text.Length > 0) ErrorMessage(""); return; }

             try { if (int.Parse(TB_DefaultReceivesBin.Text) > 0 && AppGeneralSettings.mytranstypes.DefaultReceivesBIN != int.Parse(TB_DefaultReceivesBin.Text)) AppGeneralSettings.mytranstypes.DefaultReceivesBIN = int.Parse(TB_DefaultReceivesBin.Text); }
             catch { if (TB_DefaultReceivesBin.Text.Length > 0) ErrorMessage(""); return; }

             try { if (int.Parse(TB_InternalMove.Text) > 0 && AppGeneralSettings.mytranstypes.InternalMove != int.Parse(TB_InternalMove.Text)) AppGeneralSettings.mytranstypes.InternalMove = int.Parse(TB_InternalMove.Text); }
             catch { if (TB_InternalMove.Text.Length > 0) ErrorMessage(""); return; }


            if (AppGeneralSettings.CompID > 0) settings.CompID = AppGeneralSettings.CompID;
            if (AppGeneralSettings.BranchID > 0) settings.BranchID = AppGeneralSettings.BranchID;
            if (AppGeneralSettings.StoreID > 0) settings.StoreID = AppGeneralSettings.StoreID;
            settings.SaveSettings();

        }





        protected void EnableEnter()
        {
            if (BtnSave.Image != Properties.Resources.buttonsave_on) BtnSave.Image = Properties.Resources.buttonsave_on;            
        }

        protected void DisableEnter()
        {
            if (BtnSave.Image != Properties.Resources.buttonsave) BtnSave.Image = Properties.Resources.buttonsave;
        }

        protected void ErrorMessage(string msg)
        {
            if (!string.IsNullOrEmpty(msg))
                MessageBox.Show("Μη έγκυρος αριθμός!", "Σφάλμα!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            else
                MessageBox.Show(msg, "Σφάλμα!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
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


                PBMenuBar.SizeMode = PictureBoxSizeMode.StretchImage;
                PBBtnBck.SizeMode = PictureBoxSizeMode.StretchImage;
                BtnSave.SizeMode = PictureBoxSizeMode.StretchImage;

                PBMenuBar.Width = Screen.PrimaryScreen.Bounds.Width;


            }
            else
            {

                //
                pBoxCustomerReceives.SizeMode = PictureBoxSizeMode.StretchImage;
                pBoxCustomerShipping.SizeMode = PictureBoxSizeMode.StretchImage;
                pBoxSupplierReceives.SizeMode = PictureBoxSizeMode.StretchImage;
                pBoxSupplierShipping.SizeMode = PictureBoxSizeMode.StretchImage;


                PBMenuBar.Location = new Point(PBMenuBar.Location.X, Screen.PrimaryScreen.Bounds.Height - PBMenuBar.Height - 25);
                PBBtnBck.Location = new Point(PBBtnBck.Location.X, PBMenuBar.Location.Y + oldbtny);
                BtnSave.Location = new Point(BtnSave.Location.X, PBMenuBar.Location.Y + oldbtny);

            }
        }





        private void PBSoftKeyb_Click(object sender, EventArgs e)
        {
            if (OnScreenKeyboard.Enabled)
                OnScreenKeyboard.Enabled = false;
            else
                OnScreenKeyboard.Enabled = true;
        }



        private void TBCustomerID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                iHitEnter = true;
                BtnSave.Focus();
            }
            if (e.KeyCode == Keys.Escape)
                GotoMenu();
        
        }

 



      
    }

}
 