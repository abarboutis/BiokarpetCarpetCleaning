using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace CarpetCleaningClient
{

    public partial class FrmReceivesMenu : Form
    {

        public FrmReceivesMenu()
        {
            InitializeComponent();

            FixREsolutionIssues();

        }


        


        private void FrmMenu_Load(object sender, EventArgs e)
        {
 
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
                GotoWmsTrans(AppGeneralSettings.mytranstypes.CustomerReceives);
            else if (e.KeyCode == Keys.NumPad2 || e.KeyCode == Keys.D2)
                GotoWmsTrans(AppGeneralSettings.mytranstypes.SupplierReceives);
            else if (e.KeyCode == Keys.Escape)
                GoToMainMenu();
 
        }


        #endregion

        #region Click events

       #endregion
       
        #region otherevents


       #endregion


        #region Commands

        protected void GoToMainMenu()
        {

            Cursor.Current = Cursors.WaitCursor;
            this.Close();
            Cursor.Current = Cursors.Default;

        }




        #endregion


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            GoToMainMenu();
        }



        private void GotoWmsTrans(int wmstranstype) 
        {
            Cursor.Current = Cursors.WaitCursor;

            WMSForms.FrmSelectWmsTrans = new FrmSelectWmsTrans(wmstranstype);
            WMSForms.FrmSelectWmsTrans.Show();
            this.Close();
            Cursor.Current = Cursors.Default;
        
        }

        private void PBOXreceivesCustomer_Click(object sender, EventArgs e)
        {
            GotoWmsTrans(AppGeneralSettings.mytranstypes.CustomerReceives);
        }

        private void PboxReceivesSupplier_Click(object sender, EventArgs e)
        {
            GotoWmsTrans(AppGeneralSettings.mytranstypes.SupplierReceives);
        }

    }
}