namespace CarpetCleaningClient
{
    partial class FrmSelectWmsTrans
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSelectWmsTrans));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.LBSelectInventory = new System.Windows.Forms.Label();
            this.LBMsgBox = new System.Windows.Forms.Label();
            this.PBoxMessage = new System.Windows.Forms.PictureBox();
            this.PBMenuBar = new System.Windows.Forms.PictureBox();
            this.PBBtnBck = new System.Windows.Forms.PictureBox();
            this.PBBtnEnter = new System.Windows.Forms.PictureBox();
            this.BtnView = new System.Windows.Forms.PictureBox();
            this.BtnNewPackHeader = new System.Windows.Forms.PictureBox();
            this.lb_transtype = new System.Windows.Forms.Label();
            this.DGWmsTransList = new System.Windows.Forms.DataGrid();
            this.tb_taskcomments = new System.Windows.Forms.TextBox();
            this.btn_newtask = new System.Windows.Forms.Button();
            this.PBSoftKeyb = new System.Windows.Forms.PictureBox();
            this.OnScreenKeyboard = new Microsoft.WindowsCE.Forms.InputPanel(this.components);
            this.PBSync = new System.Windows.Forms.PictureBox();
            this.SuspendLayout();
            // 
            // LBSelectInventory
            // 
            this.LBSelectInventory.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.LBSelectInventory.Location = new System.Drawing.Point(13, 36);
            this.LBSelectInventory.Name = "LBSelectInventory";
            this.LBSelectInventory.Size = new System.Drawing.Size(95, 14);
            this.LBSelectInventory.Text = "Επιλογή Εργασίας";
            // 
            // LBMsgBox
            // 
            this.LBMsgBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(235)))), ((int)(((byte)(163)))));
            this.LBMsgBox.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.LBMsgBox.ForeColor = System.Drawing.Color.Brown;
            this.LBMsgBox.Location = new System.Drawing.Point(12, 211);
            this.LBMsgBox.Name = "LBMsgBox";
            this.LBMsgBox.Size = new System.Drawing.Size(212, 30);
            this.LBMsgBox.Visible = false;
            // 
            // PBoxMessage
            // 
            this.PBoxMessage.Image = ((System.Drawing.Image)(resources.GetObject("PBoxMessage.Image")));
            this.PBoxMessage.Location = new System.Drawing.Point(6, 207);
            this.PBoxMessage.Name = "PBoxMessage";
            this.PBoxMessage.Size = new System.Drawing.Size(228, 38);
            this.PBoxMessage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PBoxMessage.Visible = false;
            this.PBoxMessage.Click += new System.EventHandler(this.PBoxMessage_Click);
            // 
            // PBMenuBar
            // 
            this.PBMenuBar.Image = ((System.Drawing.Image)(resources.GetObject("PBMenuBar.Image")));
            this.PBMenuBar.Location = new System.Drawing.Point(-1, 270);
            this.PBMenuBar.Name = "PBMenuBar";
            this.PBMenuBar.Size = new System.Drawing.Size(241, 50);
            // 
            // PBBtnBck
            // 
            this.PBBtnBck.Image = ((System.Drawing.Image)(resources.GetObject("PBBtnBck.Image")));
            this.PBBtnBck.Location = new System.Drawing.Point(1, 274);
            this.PBBtnBck.Name = "PBBtnBck";
            this.PBBtnBck.Size = new System.Drawing.Size(64, 44);
            this.PBBtnBck.Click += new System.EventHandler(this.PBBtnBck_Click);
            this.PBBtnBck.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PBBtnBck_MouseDown);
            this.PBBtnBck.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PBBtnBck_MouseUp);
            // 
            // PBBtnEnter
            // 
            this.PBBtnEnter.Image = ((System.Drawing.Image)(resources.GetObject("PBBtnEnter.Image")));
            this.PBBtnEnter.Location = new System.Drawing.Point(173, 273);
            this.PBBtnEnter.Name = "PBBtnEnter";
            this.PBBtnEnter.Size = new System.Drawing.Size(64, 44);
            this.PBBtnEnter.Click += new System.EventHandler(this.PBBtnEnter_Click);
            // 
            // BtnView
            // 
            this.BtnView.Image = ((System.Drawing.Image)(resources.GetObject("BtnView.Image")));
            this.BtnView.Location = new System.Drawing.Point(121, 273);
            this.BtnView.Name = "BtnView";
            this.BtnView.Size = new System.Drawing.Size(46, 44);
            this.BtnView.Click += new System.EventHandler(this.BtnView_Click);
            this.BtnView.GotFocus += new System.EventHandler(this.BtnView_GotFocus);
            this.BtnView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnView_MouseDown);
            this.BtnView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnView_MouseUp);
            // 
            // BtnNewPackHeader
            // 
            this.BtnNewPackHeader.Image = ((System.Drawing.Image)(resources.GetObject("BtnNewPackHeader.Image")));
            this.BtnNewPackHeader.Location = new System.Drawing.Point(69, 273);
            this.BtnNewPackHeader.Name = "BtnNewPackHeader";
            this.BtnNewPackHeader.Size = new System.Drawing.Size(46, 44);
            this.BtnNewPackHeader.Click += new System.EventHandler(this.BtnNewInventory_Click);
            this.BtnNewPackHeader.GotFocus += new System.EventHandler(this.BtnNewInventory_GotFocus);
            this.BtnNewPackHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnNewInventory_MouseDown);
            this.BtnNewPackHeader.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnNewPackHeader_MouseUp);
            // 
            // lb_transtype
            // 
            this.lb_transtype.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lb_transtype.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lb_transtype.Location = new System.Drawing.Point(9, 9);
            this.lb_transtype.Name = "lb_transtype";
            this.lb_transtype.Size = new System.Drawing.Size(207, 14);
            this.lb_transtype.Text = "Επιλογή Εργασίας";
            // 
            // DGWmsTransList
            // 
            this.DGWmsTransList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.DGWmsTransList.Location = new System.Drawing.Point(6, 53);
            this.DGWmsTransList.Name = "DGWmsTransList";
            this.DGWmsTransList.Size = new System.Drawing.Size(228, 102);
            this.DGWmsTransList.TabIndex = 9;
            this.DGWmsTransList.CurrentCellChanged += new System.EventHandler(this.DGInvHeaderList_CurrentCellChanged);
            this.DGWmsTransList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DGInvHeaderList_KeyDown);
            // 
            // tb_taskcomments
            // 
            this.tb_taskcomments.Location = new System.Drawing.Point(6, 162);
            this.tb_taskcomments.Name = "tb_taskcomments";
            this.tb_taskcomments.Size = new System.Drawing.Size(153, 21);
            this.tb_taskcomments.TabIndex = 19;
            this.tb_taskcomments.Visible = false;
            this.tb_taskcomments.TextChanged += new System.EventHandler(this.tb_taskcomments_TextChanged);
            this.tb_taskcomments.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_taskcomments_KeyDown);
            // 
            // btn_newtask
            // 
            this.btn_newtask.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.btn_newtask.Location = new System.Drawing.Point(167, 162);
            this.btn_newtask.Name = "btn_newtask";
            this.btn_newtask.Size = new System.Drawing.Size(66, 20);
            this.btn_newtask.TabIndex = 20;
            this.btn_newtask.Text = "Δημιουργία";
            this.btn_newtask.Visible = false;
            this.btn_newtask.Click += new System.EventHandler(this.btn_newtask_Click);
            // 
            // PBSoftKeyb
            // 
            this.PBSoftKeyb.Image = ((System.Drawing.Image)(resources.GetObject("PBSoftKeyb.Image")));
            this.PBSoftKeyb.Location = new System.Drawing.Point(217, 9);
            this.PBSoftKeyb.Name = "PBSoftKeyb";
            this.PBSoftKeyb.Size = new System.Drawing.Size(21, 10);
            this.PBSoftKeyb.Click += new System.EventHandler(this.PBSoftKeyb_Click_1);
            // 
            // PBSync
            // 
            this.PBSync.Image = ((System.Drawing.Image)(resources.GetObject("PBSync.Image")));
            this.PBSync.Location = new System.Drawing.Point(198, 28);
            this.PBSync.Name = "PBSync";
            this.PBSync.Size = new System.Drawing.Size(35, 24);
            this.PBSync.Click += new System.EventHandler(this.PBSync_Click_1);
            // 
            // FrmSelectWmsTrans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.ControlBox = false;
            this.Controls.Add(this.PBSync);
            this.Controls.Add(this.PBSoftKeyb);
            this.Controls.Add(this.btn_newtask);
            this.Controls.Add(this.tb_taskcomments);
            this.Controls.Add(this.DGWmsTransList);
            this.Controls.Add(this.lb_transtype);
            this.Controls.Add(this.BtnNewPackHeader);
            this.Controls.Add(this.BtnView);
            this.Controls.Add(this.PBBtnEnter);
            this.Controls.Add(this.PBBtnBck);
            this.Controls.Add(this.PBMenuBar);
            this.Controls.Add(this.LBMsgBox);
            this.Controls.Add(this.PBoxMessage);
            this.Controls.Add(this.LBSelectInventory);
            this.MinimizeBox = false;
            this.Name = "FrmSelectWmsTrans";
            this.Text = "Εργασίες ";
            this.Load += new System.EventHandler(this.FrmSelectInventoryHeader_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSelectInventoryHeader_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LBSelectInventory;
        private System.Windows.Forms.Label LBMsgBox;
        private System.Windows.Forms.PictureBox PBoxMessage;
        private System.Windows.Forms.PictureBox PBMenuBar;
        private System.Windows.Forms.PictureBox PBBtnBck;
        private System.Windows.Forms.PictureBox PBBtnEnter;
        private System.Windows.Forms.PictureBox BtnView;
        private System.Windows.Forms.PictureBox BtnNewPackHeader;
        private System.Windows.Forms.Label lb_transtype;
        private System.Windows.Forms.DataGrid DGWmsTransList;
        private System.Windows.Forms.TextBox tb_taskcomments;
        private System.Windows.Forms.Button btn_newtask;
        private System.Windows.Forms.PictureBox PBSoftKeyb;
        private Microsoft.WindowsCE.Forms.InputPanel OnScreenKeyboard;
        private System.Windows.Forms.PictureBox PBSync;
        
    }
}