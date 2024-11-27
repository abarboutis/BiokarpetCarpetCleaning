using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace CarpetCleaningClient
{

    public partial class FrmMenu : Form
    {
             
        public FrmMenu()
        {
            InitializeComponent();

            FixREsolutionIssues();

        }




        protected void TerminateApplication()
        {
            if (MessageBox.Show("Είστε Βέβαιοι για την Έξοδο από την εφαρμογή;", "Ερώτηση", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        protected void FixREsolutionIssues()
        {
            if (Screen.PrimaryScreen.Bounds.Width <= 240)
            {

            }
        }

        #region menu behaviour

        private void FrmMenu_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.NumPad1 || e.KeyCode == Keys.D1)
                GoToReceivesMenu();
            else if (e.KeyCode == Keys.NumPad3 || e.KeyCode == Keys.D2)
                GoToShippingMenu();
            else if (e.KeyCode == Keys.NumPad4 || e.KeyCode == Keys.D3)
                GoInternalMove();
            else if (e.KeyCode == Keys.NumPad5 || e.KeyCode == Keys.D4)
                GoToSettings();
            else if (e.KeyCode == Keys.NumPad0 || e.KeyCode == Keys.D0)
                TerminateApplication();
            else if (e.KeyCode == Keys.NumPad5 || e.KeyCode == Keys.D5)
                GoInventoryMenu();
        }


        #endregion

        #region Click events

       #endregion
       
        #region otherevents


       #endregion


        #region Commands


        protected void GoToSettings()
        {
            Cursor.Current = Cursors.WaitCursor;

            WMSForms.FrmSettings = new FrmSettings();
            WMSForms.FrmSettings.Show();

            Cursor.Current = Cursors.Default;
        }

        protected void GoToReceivesMenu()
        {
            Cursor.Current = Cursors.WaitCursor;

            WMSForms.FrmReceivesMenu = new FrmReceivesMenu();
            WMSForms.FrmReceivesMenu.Show();

            Cursor.Current = Cursors.Default;
        }


        protected void GoInventoryMenu()
        {
            Cursor.Current = Cursors.WaitCursor;

            WMSForms.FrmSelectWmsTrans = new FrmSelectWmsTrans(AppGeneralSettings.mytranstypes.InventoryTrans);
            WMSForms.FrmSelectWmsTrans.Show();

            Cursor.Current = Cursors.Default;
        }



        protected void GoToShippingMenu()
        {
            Cursor.Current = Cursors.WaitCursor;

            WMSForms.FrmShippingMenu = new FrmShippingMenu();
            WMSForms.FrmShippingMenu.Show();

            Cursor.Current = Cursors.Default;
        }

        protected void GoInternalMove()
        {
            Cursor.Current = Cursors.WaitCursor;

            WMSForms.FrmInternalBinTrans = new FrmInternalBinTrans(AppGeneralSettings.mytranstypes.InternalMove);
            WMSForms.FrmInternalBinTrans.Show();

            Cursor.Current = Cursors.Default;
        }




        #endregion


        private void PBOXsettings_Click(object sender, EventArgs e)
        {
            GoToSettings();
        }

        private void PBOXreceives_Click(object sender, EventArgs e)
        {
            GoToReceivesMenu();
        }

        private void PBOXshippments_Click(object sender, EventArgs e)
        {
            GoToShippingMenu();
        }

        private void PBOXput_Click(object sender, EventArgs e)
        {
            GoInternalMove();
        }

        private void PBOX_Inventory_Click(object sender, EventArgs e)
        {
            GoInventoryMenu();
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {

        }        
    }
}