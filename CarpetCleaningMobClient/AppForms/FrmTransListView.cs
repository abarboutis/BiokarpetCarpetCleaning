using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CarpetCleaningClient.CarpetCleaningWebService;

namespace CarpetCleaningClient
{
    public partial class FrmTransListView : Form
    {
        WmsTransHandler mywmstranshandler = new WmsTransHandler();
        string isearchterm = null;
        string icomments = null;
        bool iGetLastrecs = false;

        long storetransid = 0;
        int iwmstransid = 0;
        int iwmstranstype = 0;

        public FrmTransListView(int wmstransid, int wmstranstype,string comments)
        {            
            InitializeComponent();
            iwmstransid = wmstransid;
            iwmstranstype = wmstranstype;
            icomments = comments;
            GetPackingItemsList();
            this.Text = comments;
           // this.Text += "-" + packdtlid.PackingListHeaderTitle(Program.iPackHeader.PackingListHeaderID);
        }

        #region "FormEvents"

        private void FrmInventoryView_Load(object sender, EventArgs e)
        {

            FixResolutionIssues();

        }

        private void FrmInventoryView_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Escape))
                GoBack();
            else
                EnableBackKey(e);
        }

        private void DGInventorytemsList_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Escape))
                GoBack();            
        }


        private void DGInventorytemsList_CurrentCellChanged(object sender, EventArgs e)
        {
            try { DGWMStransList.Select(DGWMStransList.CurrentRowIndex); }
            catch { }
            
            if (LBMsgBox.Visible)
                HideMessageBox();
        }

        private void TBSearch_GotFocus(object sender, EventArgs e)
        {
            //TBSearch.BackColor = Color.Lavender;
            PBoxSearch.Image = Properties.Resources.textbox_focus;
        }

        private void TBSearch_LostFocus(object sender, EventArgs e)
        {
            //TBSearch.BackColor = Color.White;
            PBoxSearch.Image = Properties.Resources.textbox_xsmall;
        }

        private void CkBoxLastRecords_CheckStateChanged(object sender, EventArgs e)
        {
            PerformSearch();
        }

        private void TBSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                PerformSearch();
            else if (e.KeyCode == Keys.Escape)
                GoBack();
        }

        private void TBSearch_TextChanged(object sender, EventArgs e)
        {
            if (CkBoxLastRecords.Checked) CkBoxLastRecords.Checked = false;
        }

        #endregion

        protected void GetPackingItemsList()
        {
            DataTable DT = new DataTable();
           
           
            long packinglistid=0;


            
            Cursor.Current = Cursors.WaitCursor;

           
            try
            {
                DT = mywmstranshandler.GetStoreTransList(iwmstransid);

               
                if (DT.Rows.Count > 0)
                {
                    DGWMStransList.DataSource = DT;

                    DataGridTableStyle DGListStyle = new DataGridTableStyle();
                    DGWMStransList.TableStyles.Clear();

                    DGListStyle.MappingName = "TWmsBinStoretrans";


                    DataGridTextBoxColumn col1 = new DataGridTextBoxColumn();
                    DataGridTextBoxColumn col2 = new DataGridTextBoxColumn();
                    DataGridTextBoxColumn col3 = new DataGridTextBoxColumn();
                    DataGridTextBoxColumn col4 = new DataGridTextBoxColumn();
                    DataGridTextBoxColumn col5 = new DataGridTextBoxColumn();
                     DataGridTextBoxColumn col6 = new DataGridTextBoxColumn();


                    col1.MappingName = "binstoretransid";
                    col1.HeaderText = "#";
                    col1.Width = 0;
                    DGListStyle.GridColumnStyles.Add(col1);



                    col6.MappingName = "orderdtlid";
                    col6.HeaderText = "BarCode";
                    col6.Width = 40;
                    DGListStyle.GridColumnStyles.Add(col6);
                    


                    col2.MappingName = "customertitle";
                    col2.HeaderText = "Πελάτης";
                    col2.Width = 70;
                    DGListStyle.GridColumnStyles.Add(col2);

                    col3.MappingName = "itemdesc";
                    col3.HeaderText = "Είδος";
                    col3.Width = 70;
                    DGListStyle.GridColumnStyles.Add(col3);

                    col4.MappingName = "itemqtyprimary";
                    col4.HeaderText = "Μ2";
                    col4.Width = 40;
                    DGListStyle.GridColumnStyles.Add(col4);

                    col5.MappingName = "servicedescription";
                    col5.HeaderText = "Υπηρεσία";
                    col5.Width = 70;
                    DGListStyle.GridColumnStyles.Add(col5);



                    DGWMStransList.TableStyles.Add(DGListStyle);

                    DGWMStransList.Select(DGWMStransList.CurrentRowIndex);

                    packinglistid = long.Parse(DGWMStransList[DGWMStransList.CurrentRowIndex, 0].ToString());

        
                }
                else
                {
                    //ImgButtonDelete.Visible = false;
                    ShowMessageBox("Δεν υπάρχουν εγγραφές σε αυτήν την διακίνηση!");
                }
            }
            catch (Exception Ex) { }
           
               Cursor.Current = Cursors.Default;
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
            WMSForms.FrmSelectWmsTrans = new FrmSelectWmsTrans(iwmstranstype);
            WMSForms.FrmSelectWmsTrans.Show();
            this.Close();
        }

        protected void GoExport()
        {
            //WMSForms.FrmExportPackingList = new FrmExportPackingList();
           // WMSForms.FrmExportPackingList.Show();
            this.Close();
        }

        protected void GoTrans()
        {
            Cursor.Current = Cursors.WaitCursor;
            try { storetransid = long.Parse(DGWMStransList[DGWMStransList.CurrentRowIndex, 0].ToString()); }
            catch { }
            WMSForms.FrmBinTrans = new FrmBinTrans(iwmstransid,storetransid,icomments);
            WMSForms.FrmBinTrans.Show();
            this.Close();
            Cursor.Current = Cursors.Default;
        }

        protected void DeleteWmsTransList()
        {
            if (MessageBox.Show("Είστε Βέβαιοι για την Διαγραφή της διακίνησης;\n ΟΛΕΣ οι εγγραφές θα διαγραφούν!", "Ερώτηση", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                return;

            Cursor.Current = Cursors.WaitCursor;
            if (mywmstranshandler.DeleteTransList(iwmstransid) >= 0)
            {
                MessageBox.Show("Διαγραφή Εργασίας επιτυχής");

            }
            else
            {
                MessageBox.Show("Συνέβη σφάλμα !");

            }
            GoBack();
            Cursor.Current = Cursors.Default;
        }

        protected void PerformSearch()
        {
            isearchterm = TBSearch.Text.Trim() ;

            if (CkBoxLastRecords.Checked)
            {
                iGetLastrecs = true;
                isearchterm = null;
                TBSearch.Text = "";
            }
            else
                iGetLastrecs = false;

            GetPackingItemsList();
        }

        private void PBBtnBck_Click(object sender, EventArgs e)
        {
            GoBack();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DeleteWmsTransList();
        }

        private void BtnSync_Click(object sender, EventArgs e)
        {
            GoExport();
        }

        private void BtnView_Click(object sender, EventArgs e)
        {
            GoTrans();
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
                BtnSync.Location = new Point(BtnSync.Location.X, PBMenuBar.Location.Y + oldbtny);
                BtnDelete.Location = new Point(BtnDelete.Location.X, PBMenuBar.Location.Y + oldbtny);
                //PBBtnEnter.Location = new Point(PBBtnEnter.Location.X, PBMenuBar.Location.Y + oldbtny);


                PBMenuBar.SizeMode = PictureBoxSizeMode.StretchImage;
                PBBtnBck.SizeMode = PictureBoxSizeMode.StretchImage;
                BtnView.SizeMode = PictureBoxSizeMode.StretchImage;
                BtnDelete.SizeMode = PictureBoxSizeMode.StretchImage;

                BtnSync.SizeMode = PictureBoxSizeMode.StretchImage;


                PBMenuBar.Width = Screen.PrimaryScreen.Bounds.Width;
            }
            else {

                PBMenuBar.Location = new Point(PBMenuBar.Location.X, Screen.PrimaryScreen.Bounds.Height - PBMenuBar.Height - 25);

                PBBtnBck.Location = new Point(PBBtnBck.Location.X, PBMenuBar.Location.Y + oldbtny);
                BtnView.Location = new Point(BtnView.Location.X, PBMenuBar.Location.Y + oldbtny);
                BtnSync.Location = new Point(BtnSync.Location.X, PBMenuBar.Location.Y + oldbtny);
                BtnDelete.Location = new Point(BtnDelete.Location.X, PBMenuBar.Location.Y + oldbtny);
            
            
            }
        }

        protected void EnableBackKey(KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Escape)||(e.KeyCode == Keys.F1))
                    GoBack();
            }
        }




      

      

     
      
       

            
    }
