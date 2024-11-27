using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using CarpetCleaningClient.CarpetCleaningWebService;

namespace CarpetCleaningClient
{
    public partial class FrmSelectWmsTrans : Form
    {
        WmsTransHandler wmstranshandler = new WmsTransHandler();
        int WmsTransTypeID;
        int wmstransid;
          
        public FrmSelectWmsTrans(int fromWmsTransTypeID)
        {
            WmsTransTypeID = fromWmsTransTypeID;
            InitializeComponent();
            GetTranTypeInfo();
            GetPackingLists();
        }

        #region "FormEvents"
           


        private void PBoxMessage_Click(object sender, EventArgs e)
        {
            HideMessageBox();
        }

        private void GetTranTypeInfo()
        {
            if (WmsTransTypeID == AppGeneralSettings.mytranstypes.CustomerReceives)
            {
                
                lb_transtype.Text = "Παραλαβές << Πελάτη";
            }

            if (WmsTransTypeID == AppGeneralSettings.mytranstypes.CustomerShipping)
            {
                lb_transtype.Text = "Αποστολές >> Πελάτη";

            }
            if (WmsTransTypeID == AppGeneralSettings.mytranstypes.SupplierReceives)
            {
                lb_transtype.Text = "Παραλαβές << Καθαριστήριο";

            }
            if (WmsTransTypeID == AppGeneralSettings.mytranstypes.SupplierShipping)
            {
                lb_transtype.Text = "Αποστολές >> Καθαριστήριο";

            }

            if (WmsTransTypeID == AppGeneralSettings.mytranstypes.InventoryTrans)
            {
                lb_transtype.Text = "Απογραφή";

            }
 
        
        }

        private void PBoxEnter_MouseMove()
        {
            EnableEnter();
        }

        private void DGInvHeaderList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                GoBack();
            else if(e.KeyCode == Keys.Enter)
                GoWmsTrans();
        }

      
        private void FrmSelectInventoryHeader_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode ==Keys.Escape))
            {
                GoBack();
            }
            else if ((e.KeyCode == Keys.Enter))
            {
                GoWmsTrans();
            }
          

        }

        private void DGInvHeaderList_GotFocus(object sender, EventArgs e)
        {
            DisableEnter();
            DisableNew();
            DisableView();           
        }


        private void DGInvHeaderList_CurrentCellChanged(object sender, EventArgs e)
        {

            try { DGWmsTransList.Select(DGWmsTransList.CurrentRowIndex); }
            catch { }
        }

        

        #endregion

        protected void GetPackingLists()
        {
            DataTable DT = new DataTable();
            try
            {
                DT = wmstranshandler.GetTransList(AppGeneralSettings.CompID, AppGeneralSettings.BranchID, AppGeneralSettings.defaultactivestatus, WmsTransTypeID);
                

                if (DT.Rows.Count > 0){

        //                    public long wmstransid { get; set; }
        //public long userid { get; set; }
        //public long wmstranstypeid { get; set; }
        //public string wmstransdate { get; set; }
        //public string comments { get; set; }
        //public short status { get; set; }
                
                     DGWmsTransList.DataSource = DT;
                    DataGridTableStyle DGListStyle = new DataGridTableStyle();

                    DGListStyle.MappingName = "TwmsTrans";


                    DataGridTextBoxColumn col0 = new DataGridTextBoxColumn();
                    DataGridTextBoxColumn col1 = new DataGridTextBoxColumn();
                    DataGridTextBoxColumn col2 = new DataGridTextBoxColumn();
                    DataGridTextBoxColumn col3 = new DataGridTextBoxColumn();
                    DataGridTextBoxColumn col4 = new DataGridTextBoxColumn();
                    DataGridTextBoxColumn col5 = new DataGridTextBoxColumn();

                    col0.MappingName = "wmstransid";
                    col0.HeaderText = "test";
                    col0.Width = 0;
                    DGListStyle.GridColumnStyles.Add(col0);

                    col1.MappingName = "wmstransdate";
                    col1.HeaderText = "Ημ/νία";
                    col1.Format = "dd/MM/yy";
                    col1.Width = 85;
                    DGListStyle.GridColumnStyles.Add(col1);

                    col2.MappingName = "comments";
                    col2.HeaderText = "Παρατηρήσεις";
                    col2.Width = 120;
                    DGListStyle.GridColumnStyles.Add(col2);


                    DGWmsTransList.TableStyles.Clear();

                    DGWmsTransList.TableStyles.Add(DGListStyle);

                    if (DT.Rows.Count > 0) 
                    {
                        DGWmsTransList.Select(0);
                    }

                    
                    DT.Dispose();

               }
            }
            catch (Exception ex) { }

        }


        protected void EnableEnter()
        {
            if (PBBtnEnter.Image != Properties.Resources.enterselected_on) PBBtnEnter.Image = Properties.Resources.enterselected_on;
        }

        protected void DisableEnter()
        {
            if (PBBtnEnter.Image != Properties.Resources.enterselected) PBBtnEnter.Image = Properties.Resources.enterselected;
        }

        protected void EnableNew()
        {
            if (BtnNewPackHeader.Image != Properties.Resources.add_on) BtnNewPackHeader.Image = Properties.Resources.add_on;
        }

        protected void DisableNew()
        {
            if (BtnNewPackHeader.Image != Properties.Resources.add) BtnNewPackHeader.Image = Properties.Resources.add;
        }

        protected void EnableView()
        {
            if (BtnView.Image != Properties.Resources.view_on) BtnView.Image = Properties.Resources.view_on;
        }

        protected void DisableView()
        {
            if (BtnView.Image != Properties.Resources.view) BtnView.Image = Properties.Resources.view;
        }

        protected void ShowMessageBox(string msg)
        {
            PBoxMessage.Visible = true;
            LBMsgBox.Visible = true;
            if (!string.IsNullOrEmpty(msg)) LBMsgBox.Text = msg;
        }

        protected void HideMessageBox()
        {
            if (PBoxMessage.Visible) PBoxMessage.Visible = false;
            if (LBMsgBox.Visible) LBMsgBox.Visible = false;
        }


        protected void GoBack()
        {
            Cursor.Current = Cursors.WaitCursor;
            //WMSForms.FrmMain.Show();            
            this.Close();
            Cursor.Current = Cursors.Default;
        }


        protected void ViewPackingList()
        {
            string comments = null;
            try
            {
                wmstransid = int.Parse(DGWmsTransList[DGWmsTransList.CurrentRowIndex, 0].ToString());
                comments = DGWmsTransList[DGWmsTransList.CurrentRowIndex, 2].ToString();
            }
            catch
            {
                MessageBox.Show("Επιλέξτε εργασία");
                return;
            }
            Cursor.Current = Cursors.WaitCursor;

            WMSForms.FrmTransListView = new FrmTransListView(wmstransid, WmsTransTypeID,comments);
            WMSForms.FrmTransListView.Show();
            this.Close();
          

            Cursor.Current = Cursors.Default;
        }

        protected void GoWmsTrans()
        {
            string comments = "";
            try
            {
            wmstransid = int.Parse(DGWmsTransList[DGWmsTransList.CurrentRowIndex, 0].ToString());
            comments = DGWmsTransList[DGWmsTransList.CurrentRowIndex, 2].ToString();
            }catch{MessageBox.Show("Επιλέξτε εργασία");
            return;
            }

            if (wmstransid > 0)
            {
                Cursor.Current = Cursors.WaitCursor;

                WMSForms.FrmBinTrans = new FrmBinTrans(wmstransid, comments);
                WMSForms.FrmBinTrans.Show();
                this.Close();

                Cursor.Current = Cursors.Default;
            }
        }
               

        protected void FixResolutionIssues()
        {

            string oldpos = PBMenuBar.Location.X.ToString() + "X" + PBMenuBar.Location.Y.ToString();
            int oldbtny = PBBtnBck.Location.Y - PBMenuBar.Location.Y;

            if (Screen.PrimaryScreen.Bounds.Width > 240)
            {
                PBMenuBar.Location = new Point(PBMenuBar.Location.X, Screen.PrimaryScreen.Bounds.Height - PBMenuBar.Height - 30);

                PBBtnBck.Location = new Point(PBBtnBck.Location.X, PBMenuBar.Location.Y + oldbtny);
                BtnView.Location = new Point(BtnView.Location.X, PBMenuBar.Location.Y + oldbtny);

                BtnNewPackHeader.Location = new Point(BtnNewPackHeader.Location.X, PBMenuBar.Location.Y + oldbtny);
                PBBtnEnter.Location = new Point(PBBtnEnter.Location.X, PBMenuBar.Location.Y + oldbtny);


                PBMenuBar.SizeMode = PictureBoxSizeMode.StretchImage;
                PBBtnBck.SizeMode = PictureBoxSizeMode.StretchImage;
                BtnView.SizeMode = PictureBoxSizeMode.StretchImage;
                BtnNewPackHeader.SizeMode = PictureBoxSizeMode.StretchImage;
                PBBtnEnter.SizeMode = PictureBoxSizeMode.StretchImage;

                PBMenuBar.Width = Screen.PrimaryScreen.Bounds.Width;
            }
            else 
            {

                PBMenuBar.Location = new Point(PBMenuBar.Location.X, Screen.PrimaryScreen.Bounds.Height - PBMenuBar.Height - 25);

                PBBtnBck.Location = new Point(PBBtnBck.Location.X, PBMenuBar.Location.Y + oldbtny);
                BtnView.Location = new Point(BtnView.Location.X, PBMenuBar.Location.Y + oldbtny);

                BtnNewPackHeader.Location = new Point(BtnNewPackHeader.Location.X, PBMenuBar.Location.Y + oldbtny);
                PBBtnEnter.Location = new Point(PBBtnEnter.Location.X, PBMenuBar.Location.Y + oldbtny);
            
            
            
            }
        }

        private void BtnSync_Click(object sender, EventArgs e)
        {

        }

        private void PBBtnBck_Click(object sender, EventArgs e)
        {
            GoBack();
        }

        private void PBBtnBck_MouseDown(object sender, MouseEventArgs e)
        {
            PBBtnBck.Image = Properties.Resources.buttonback_on;
        }
        
        private void BtnNewInventory_Click(object sender, EventArgs e)
        {
            if (tb_taskcomments.Visible == true && tb_taskcomments.Text != "") 
            {
                CreateTask();
                return;
            }
            ShowNewTaskComponents();
        }

        private void PBBtnEnter_Click(object sender, EventArgs e)
        {
            GoWmsTrans();
        }

        private void BtnView_Click(object sender, EventArgs e)
        {
            EnableView();

            ViewPackingList();
        }

        private void BtnView_MouseDown(object sender, MouseEventArgs e)
        {           
            EnableView();
        }

        private void BtnView_GotFocus(object sender, EventArgs e)
        {           
            EnableView();
        }

        private void BtnNewInventory_GotFocus(object sender, EventArgs e)
        {
            EnableNew();
        }

        private void BtnNewInventory_MouseDown(object sender, MouseEventArgs e)
        {
            EnableNew();
        }

        private void FrmSelectInventoryHeader_Load(object sender, EventArgs e)
        {
            FixResolutionIssues();
            
        } 
        


        private void btn_newtask_Click(object sender, EventArgs e)
        {

            CreateTask();
        }




        private void CreateTask() 
        {
            
            TwmsTrans newtrans = new TwmsTrans();
            if (tb_taskcomments.Text == "") return;

            if (MessageBox.Show("Να δημιουργηθεί νέα εργασία;", "Ερώτηση", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No) return;
            Cursor.Current = Cursors.WaitCursor;
            newtrans.compid = AppGeneralSettings.CompID;
            newtrans.branchid = AppGeneralSettings.BranchID;
            newtrans.comments = tb_taskcomments.Text;
            newtrans.wmstranstypeid = WmsTransTypeID;
            newtrans.status = AppGeneralSettings.defaultactivestatus;

            if (wmstranshandler.InsertNewTrans(newtrans) > 0) 
            {
               // MessageBox.Show("Δημιουργία εργασίας επιτυχής");
                
                GetPackingLists();
                HideNewTaskComponents();
                Cursor.Current = Cursors.Default;

            }else 
            {
                MessageBox.Show("Απέτυχε η δημιουργία της εργασίας , παρακαλώ προσπαθήστε ξανά");
                Cursor.Current = Cursors.Default;
            }


        
        
        }


        private void ShowNewTaskComponents()
        {
            tb_taskcomments.Visible = true;
            btn_newtask.Visible = true;
            tb_taskcomments.Focus();
        }

        private void HideNewTaskComponents()
        {
            tb_taskcomments.Visible = false;
            btn_newtask.Visible = false;
            DGWmsTransList.Focus();
        }

        private void PBSoftKeyb_Click(object sender, EventArgs e)
        {

        }

        private void PBSoftKeyb_Click_1(object sender, EventArgs e)
        {
            if (OnScreenKeyboard.Enabled)
                OnScreenKeyboard.Enabled = false;
            else
                OnScreenKeyboard.Enabled = true;
        }

        private void BtnNewPackHeader_MouseUp(object sender, MouseEventArgs e)
        {
            DisableNew();
        }

        private void PBBtnBck_MouseUp(object sender, MouseEventArgs e)
        {
            PBBtnBck.Image = Properties.Resources.buttonback;
        }

        private void BtnView_MouseUp(object sender, MouseEventArgs e)
        {
            DisableView();
        }

        private void tb_taskcomments_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter))
            {
                CreateTask();
            }

        }

        private void PBSync_Click(object sender, EventArgs e)
        {

        }

        private void PBSync_Click_1(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            GetPackingLists();
            Cursor.Current = Cursors.Default;
        }

        private void tb_taskcomments_TextChanged(object sender, EventArgs e)
        {

        }


   }

      

      
       

        
      

       

        

       
    }

        

