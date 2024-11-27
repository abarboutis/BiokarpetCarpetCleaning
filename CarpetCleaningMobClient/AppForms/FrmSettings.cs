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
    public partial class FrmSettings : Form
    {
        bool iHitEnter = false;
        AppSettings settings = new AppSettings();

        public FrmSettings()
        {

            InitializeComponent();
            FixResolutionIssues();

            GetSettings();

            GetMobileDeviceIPAddress();
        }

        protected void GetMobileDeviceIPAddress()
        {
            IPHostEntry host;

            host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (IPAddress ip in host.AddressList)
                {
                    if (ip.AddressFamily.ToString() == "InterNetwork")
                    {
                        LBIpAddress.Text  = "ip: " + ip.ToString();
                    }
                }
            
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

        private void TBCompID_GotFocus(object sender, EventArgs e)
        {            
            PBoxCompID.Image = Properties.Resources.textbox_small_focus;
            DisableEnter();
        }

        private void TBCompID_LostFocus(object sender, EventArgs e)
        {                        
            PBoxCompID.Image = Properties.Resources.textbox_small;
        }

        private void TBBranchID_GotFocus(object sender, EventArgs e)
        {            
            PBoxBranchID.Image = Properties.Resources.textbox_small_focus;
            DisableEnter();
        }

        private void TBBranchID_LostFocus(object sender, EventArgs e)
        {            
            PBoxBranchID.Image = Properties.Resources.textbox_small;
        }

        private void TBStoreID_GotFocus(object sender, EventArgs e)
        {

            PBoxStoreID.Image = Properties.Resources.textbox_small_focus;
            DisableEnter();
        }


        private void TBStoreID_LostFocus(object sender, EventArgs e)
        {
            PBoxStoreID.Image = Properties.Resources.textbox_small;
        }

        private void TBWebService_GotFocus(object sender, EventArgs e)
        {
            PBoxWebService.Image = Properties.Resources.textbox_focus;
            DisableEnter();
        }

        private void TBWebService_LostFocus(object sender, EventArgs e)
        {
             PBoxWebService.Image = Properties.Resources.textbox;
        }

                        
        private void TBWebService_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                TBCompID.Focus();
            if (e.KeyCode == Keys.Escape)
                GotoMenu();
        }

        private void TBCompID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                TBBranchID.Focus();
            if (e.KeyCode == Keys.Escape)
                GotoMenu();
        }

        private void TBBranchID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                TBStoreID.Focus();
            if (e.KeyCode == Keys.Escape)
                GotoMenu();
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

 
        private void PBoxWebService_Click(object sender, EventArgs e)
        {
            TBWebService.Focus();
        }

        private void PBoxCompID_Click(object sender, EventArgs e)
        {
            TBCompID.Focus();
        }

        private void PBoxStoreID_Click(object sender, EventArgs e)
        {
            TBStoreID.Focus();
        }

        private void PBoxBranchID_Click(object sender, EventArgs e)
        {
            TBBranchID.Focus();
        }

        
        private void BtnCheckWSConnection_Click(object sender, EventArgs e)
        {
            CheckWSConnection();

        }

        private void BtnCheckWSConnection_KeyDown(object sender, KeyEventArgs e)
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





        private void LLbUpdate_Click(object sender, EventArgs e)
        {
            try { System.Diagnostics.Process.Start("iexplore", settings.UpdateURL); }catch{}

            if (MessageBox.Show("Έτοιμη για αναβάθμιση;", "Ερώτηση", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                try
                {
                    if (System.IO.File.Exists("\\My Documents\\CarpetCleaning_setup.CAB"))
                    {
                        Application.Exit();
                        System.Diagnostics.Process.Start("\\My Documents\\CarpetCleaning_setup.CAB", "");
                    }
                    else
                        MessageBox.Show(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        #endregion

        protected void GetSettings()
        {
            DisableEnter();
            if (AppGeneralSettings.ReceiveAndPlace == 1) cb_placewithreceive.Checked = true; else { cb_placewithreceive.Checked = false; };

            if (AppGeneralSettings.InputDimensions == 1) cb_inputdimensions.Checked = true; else { cb_inputdimensions.Checked = false; };

            TBBranchID.Text = AppGeneralSettings.BranchID.ToString();
            TBCompID.Text = AppGeneralSettings.CompID.ToString();
            TBStoreID.Text = AppGeneralSettings.StoreID.ToString();
            TBWebService.Text = AppGeneralSettings.webServiceProvider.Url.ToString();
            LLbUpdate.Text = "Download Update";
           
        }

        protected void GotoMenu()
        {          
           // WMSForms.FrmMenu.Show();
            this.Close();
            
        }

        protected void GotoWmsSettings()
        {
            Cursor.Current = Cursors.WaitCursor;

            WMSForms.FrmWmsSettings = new FrmWmsSettings();
            WMSForms.FrmWmsSettings.Show();

            Cursor.Current = Cursors.Default;

        }

        protected void SaveChanges()
        {
            try { if (int.Parse(TBCompID.Text) > 0 && AppGeneralSettings.CompID != int.Parse(TBCompID.Text)) AppGeneralSettings.CompID = short.Parse(TBCompID.Text); }
            catch { if (TBCompID.Text.Length > 0) ErrorMessage(""); return; }

            try { if (int.Parse(TBBranchID.Text) > 0 && AppGeneralSettings.BranchID != int.Parse(TBBranchID.Text)) AppGeneralSettings.BranchID = short.Parse(TBBranchID.Text); }
            catch { ErrorMessage(""); return; }

            try { if (int.Parse(TBStoreID.Text) > 0) AppGeneralSettings.StoreID = int.Parse(TBStoreID.Text); }
            catch { ErrorMessage(""); return; }

            if (cb_placewithreceive.Checked) { AppGeneralSettings.ReceiveAndPlace = 1; } else { AppGeneralSettings.ReceiveAndPlace = 0; }

            if (cb_inputdimensions.Checked) { AppGeneralSettings.InputDimensions = 1; } else { AppGeneralSettings.InputDimensions = 0; }

            settings.WebSvcUrl = TBWebService.Text;

            if (cb_placewithreceive.Checked == true)
            {
                

            }
            else { AppGeneralSettings.ReceiveAndPlace = 0; }

            if (AppGeneralSettings.CompID > 0) settings.CompID = AppGeneralSettings.CompID;
            if (AppGeneralSettings.BranchID > 0) settings.BranchID = AppGeneralSettings.BranchID;
            if (AppGeneralSettings.StoreID > 0) settings.StoreID = AppGeneralSettings.StoreID;

            if (settings.SaveSettings() > 0)
            {
                GotoMenu();
            }
            else
            {
                MessageBox.Show("Πρόβλημα με την αποθήκευση των ρυθμίσεων");
            }

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


        protected void CheckWSConnection()
        {

            Cursor.Current = Cursors.WaitCursor;

            long RTRN = -1;
            try
            {
                RTRN = AppGeneralSettings.webServiceProvider.CheckDBConnection();
                if (RTRN == -10)
                {
                    PBoxWSConStatus.Image = Properties.Resources.ok;
                    MessageBox.Show("Πρόβλημα με τη σύνδεση στη Β.Δ.!");
                }
                else if (RTRN > 0)
                    PBoxWSConStatus.Image = Properties.Resources.ok;
                else
                    PBoxWSConStatus.Image = Properties.Resources.error;
            }
            catch (Exception ex) { PBoxWSConStatus.Image = Properties.Resources.error; }
            PBoxWSConStatus.Visible = true;



            Cursor.Current = Cursors.Default;


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

                PBoxWebService.Width = 205;
                //PBoxWebService.Height = 35;
                PBoxWebService.SizeMode = PictureBoxSizeMode.StretchImage;
                //


               // PBoxStoreID.Width = 85;
               //PBoxStoreID.Height = 35;
                PBoxStoreID.SizeMode = PictureBoxSizeMode.StretchImage;
                //
                //PBoxCompID.Width = 85;
               //PBoxCompID.Height = 35;
                PBoxCompID.SizeMode = PictureBoxSizeMode.StretchImage;



                //PBoxBranchID.Width = 85;
                //PBoxBranchID.Height = 35;
                PBoxBranchID.SizeMode = PictureBoxSizeMode.StretchImage;





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


        private void cbStores_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show("ok");
        }

        private void btn_wmssettings_Click(object sender, EventArgs e)
        {
            GotoWmsSettings();
        }

        private void FrmSettings_Load(object sender, EventArgs e)
        {

        }

 
      
    }

}
 