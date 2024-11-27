using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace CarpetCleaningClient
{

    public partial class FrmShippingMenu : Form
    {

        public FrmShippingMenu()
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
                GotoWmsTrans(AppGeneralSettings.mytranstypes.SupplierShipping);
            else if (e.KeyCode == Keys.NumPad2 || e.KeyCode == Keys.D2)
                GotoWmsTrans(AppGeneralSettings.mytranstypes.CustomerShipping);
            else if (e.KeyCode == Keys.Escape)
                GoToMainMenu();
 
        }


        #endregion





        #region Commands

        protected void GoToMainMenu()
        {
            Cursor.Current = Cursors.WaitCursor;
            this.Close();
            Cursor.Current = Cursors.Default;
        }

        private void GotoWmsTrans(int wmstranstype)
        {
            Cursor.Current = Cursors.WaitCursor;

            WMSForms.FrmSelectWmsTrans = new FrmSelectWmsTrans(wmstranstype);
            WMSForms.FrmSelectWmsTrans.Show();
            this.Close();
            Cursor.Current = Cursors.Default;

        }


        protected void TerminateApplication()
        {
            if (MessageBox.Show("Είστε Βέβαιοι για την Έξοδο από την εφαρμογή;", "Ερώτηση", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        #endregion



        private void pictureBox1_Click(object sender, EventArgs e)
        {
            GoToMainMenu();
        }


        private void PboxShippingSupplier_Click(object sender, EventArgs e)
        {
            GotoWmsTrans(AppGeneralSettings.mytranstypes.CustomerShipping);

        }

        private void PboxShippingCustomer_Click(object sender, EventArgs e)
        {
            GotoWmsTrans(AppGeneralSettings.mytranstypes.SupplierShipping);
        }        
    }
}