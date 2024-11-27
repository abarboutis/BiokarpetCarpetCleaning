namespace CarpetCleaningClient
{
    partial class FrmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSettings));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.TBWebService = new System.Windows.Forms.TextBox();
            this.LBWEBService = new System.Windows.Forms.Label();
            this.TBCompID = new System.Windows.Forms.TextBox();
            this.TBBranchID = new System.Windows.Forms.TextBox();
            this.LBBRanchID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TBStoreID = new System.Windows.Forms.TextBox();
            this.PBoxStoreID = new System.Windows.Forms.PictureBox();
            this.PBoxBranchID = new System.Windows.Forms.PictureBox();
            this.PBoxCompID = new System.Windows.Forms.PictureBox();
            this.BtnCheckWSConnection = new System.Windows.Forms.Button();
            this.PBoxWSConStatus = new System.Windows.Forms.PictureBox();
            this.LLbUpdate = new System.Windows.Forms.LinkLabel();
            this.LbVersion = new System.Windows.Forms.Label();
            this.PBMenuBar = new System.Windows.Forms.PictureBox();
            this.PBBtnBck = new System.Windows.Forms.PictureBox();
            this.BtnSave = new System.Windows.Forms.PictureBox();
            this.PBSoftKeyb = new System.Windows.Forms.PictureBox();
            this.OnScreenKeyboard = new Microsoft.WindowsCE.Forms.InputPanel(this.components);
            this.LBIpAddress = new System.Windows.Forms.Label();
            this.PBoxWebService = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_wmssettings = new System.Windows.Forms.Button();
            this.cb_placewithreceive = new System.Windows.Forms.CheckBox();
            this.cb_inputdimensions = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TBWebService
            // 
            this.TBWebService.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.TBWebService.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TBWebService.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.TBWebService.Location = new System.Drawing.Point(16, 36);
            this.TBWebService.Multiline = true;
            this.TBWebService.Name = "TBWebService";
            this.TBWebService.Size = new System.Drawing.Size(193, 19);
            this.TBWebService.TabIndex = 6;
            this.TBWebService.GotFocus += new System.EventHandler(this.TBWebService_GotFocus);
            this.TBWebService.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TBWebService_KeyDown);
            this.TBWebService.LostFocus += new System.EventHandler(this.TBWebService_LostFocus);
            // 
            // LBWEBService
            // 
            this.LBWEBService.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.LBWEBService.Location = new System.Drawing.Point(15, 15);
            this.LBWEBService.Name = "LBWEBService";
            this.LBWEBService.Size = new System.Drawing.Size(75, 13);
            this.LBWEBService.Text = "WEB Service";
            // 
            // TBCompID
            // 
            this.TBCompID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.TBCompID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TBCompID.Location = new System.Drawing.Point(13, 78);
            this.TBCompID.Multiline = true;
            this.TBCompID.Name = "TBCompID";
            this.TBCompID.Size = new System.Drawing.Size(35, 11);
            this.TBCompID.TabIndex = 21;
            this.TBCompID.GotFocus += new System.EventHandler(this.TBCompID_GotFocus);
            this.TBCompID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TBCompID_KeyDown);
            this.TBCompID.LostFocus += new System.EventHandler(this.TBCompID_LostFocus);
            // 
            // TBBranchID
            // 
            this.TBBranchID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.TBBranchID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TBBranchID.Location = new System.Drawing.Point(13, 109);
            this.TBBranchID.Multiline = true;
            this.TBBranchID.Name = "TBBranchID";
            this.TBBranchID.Size = new System.Drawing.Size(35, 11);
            this.TBBranchID.TabIndex = 25;
            this.TBBranchID.GotFocus += new System.EventHandler(this.TBBranchID_GotFocus);
            this.TBBranchID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TBBranchID_KeyDown);
            this.TBBranchID.LostFocus += new System.EventHandler(this.TBBranchID_LostFocus);
            // 
            // LBBRanchID
            // 
            this.LBBRanchID.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.LBBRanchID.Location = new System.Drawing.Point(9, 95);
            this.LBBRanchID.Name = "LBBRanchID";
            this.LBBRanchID.Size = new System.Drawing.Size(47, 9);
            this.LBBRanchID.Text = "Branchid";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(10, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 11);
            this.label2.Text = "Compid";
            // 
            // TBStoreID
            // 
            this.TBStoreID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.TBStoreID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TBStoreID.Location = new System.Drawing.Point(13, 143);
            this.TBStoreID.Multiline = true;
            this.TBStoreID.Name = "TBStoreID";
            this.TBStoreID.Size = new System.Drawing.Size(35, 11);
            this.TBStoreID.TabIndex = 32;
            this.TBStoreID.GotFocus += new System.EventHandler(this.TBStoreID_GotFocus);
            this.TBStoreID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TBStoreID_KeyDown);
            this.TBStoreID.LostFocus += new System.EventHandler(this.TBStoreID_LostFocus);
            // 
            // PBoxStoreID
            // 
            this.PBoxStoreID.Image = ((System.Drawing.Image)(resources.GetObject("PBoxStoreID.Image")));
            this.PBoxStoreID.Location = new System.Drawing.Point(9, 139);
            this.PBoxStoreID.Name = "PBoxStoreID";
            this.PBoxStoreID.Size = new System.Drawing.Size(44, 19);
            this.PBoxStoreID.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PBoxStoreID.Click += new System.EventHandler(this.PBoxStoreID_Click);
            // 
            // PBoxBranchID
            // 
            this.PBoxBranchID.Image = ((System.Drawing.Image)(resources.GetObject("PBoxBranchID.Image")));
            this.PBoxBranchID.Location = new System.Drawing.Point(9, 106);
            this.PBoxBranchID.Name = "PBoxBranchID";
            this.PBoxBranchID.Size = new System.Drawing.Size(44, 19);
            this.PBoxBranchID.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PBoxBranchID.Click += new System.EventHandler(this.PBoxBranchID_Click);
            // 
            // PBoxCompID
            // 
            this.PBoxCompID.Image = ((System.Drawing.Image)(resources.GetObject("PBoxCompID.Image")));
            this.PBoxCompID.Location = new System.Drawing.Point(9, 74);
            this.PBoxCompID.Name = "PBoxCompID";
            this.PBoxCompID.Size = new System.Drawing.Size(44, 19);
            this.PBoxCompID.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PBoxCompID.Click += new System.EventHandler(this.PBoxCompID_Click);
            // 
            // BtnCheckWSConnection
            // 
            this.BtnCheckWSConnection.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BtnCheckWSConnection.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.BtnCheckWSConnection.Location = new System.Drawing.Point(99, 10);
            this.BtnCheckWSConnection.Name = "BtnCheckWSConnection";
            this.BtnCheckWSConnection.Size = new System.Drawing.Size(65, 16);
            this.BtnCheckWSConnection.TabIndex = 69;
            this.BtnCheckWSConnection.Text = "Έλεγχος";
            this.BtnCheckWSConnection.Click += new System.EventHandler(this.BtnCheckWSConnection_Click);
            this.BtnCheckWSConnection.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BtnCheckWSConnection_KeyDown);
            // 
            // PBoxWSConStatus
            // 
            this.PBoxWSConStatus.Location = new System.Drawing.Point(180, 6);
            this.PBoxWSConStatus.Name = "PBoxWSConStatus";
            this.PBoxWSConStatus.Size = new System.Drawing.Size(22, 21);
            this.PBoxWSConStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PBoxWSConStatus.Visible = false;
            // 
            // LLbUpdate
            // 
            this.LLbUpdate.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Underline);
            this.LLbUpdate.Location = new System.Drawing.Point(5, 212);
            this.LLbUpdate.Name = "LLbUpdate";
            this.LLbUpdate.Size = new System.Drawing.Size(101, 14);
            this.LLbUpdate.TabIndex = 78;
            this.LLbUpdate.Text = "Download Update";
            this.LLbUpdate.Click += new System.EventHandler(this.LLbUpdate_Click);
            // 
            // LbVersion
            // 
            this.LbVersion.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.LbVersion.ForeColor = System.Drawing.Color.OliveDrab;
            this.LbVersion.Location = new System.Drawing.Point(9, 196);
            this.LbVersion.Name = "LbVersion";
            this.LbVersion.Size = new System.Drawing.Size(122, 10);
            this.LbVersion.Text = "Version 1.00  19042017";
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
            this.PBBtnBck.Location = new System.Drawing.Point(5, 273);
            this.PBBtnBck.Name = "PBBtnBck";
            this.PBBtnBck.Size = new System.Drawing.Size(64, 44);
            this.PBBtnBck.Click += new System.EventHandler(this.PBBtnBck_Click);
            this.PBBtnBck.GotFocus += new System.EventHandler(this.PBBtnBck_GotFocus);
            this.PBBtnBck.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PBBtnBck_MouseDown);
            this.PBBtnBck.LostFocus += new System.EventHandler(this.PBBtnBck_LostFocus);
            this.PBBtnBck.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PBBtnBck_MouseUp);
            // 
            // BtnSave
            // 
            this.BtnSave.Image = ((System.Drawing.Image)(resources.GetObject("BtnSave.Image")));
            this.BtnSave.Location = new System.Drawing.Point(165, 273);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(64, 44);
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            this.BtnSave.GotFocus += new System.EventHandler(this.BtnSave_GotFocus);
            this.BtnSave.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnSave_MouseDown);
            this.BtnSave.LostFocus += new System.EventHandler(this.BtnSave_LostFocus);
            this.BtnSave.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnSave_MouseUp);
            // 
            // PBSoftKeyb
            // 
            this.PBSoftKeyb.Image = ((System.Drawing.Image)(resources.GetObject("PBSoftKeyb.Image")));
            this.PBSoftKeyb.Location = new System.Drawing.Point(213, 8);
            this.PBSoftKeyb.Name = "PBSoftKeyb";
            this.PBSoftKeyb.Size = new System.Drawing.Size(21, 10);
            this.PBSoftKeyb.Click += new System.EventHandler(this.PBSoftKeyb_Click);
            // 
            // LBIpAddress
            // 
            this.LBIpAddress.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.LBIpAddress.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.LBIpAddress.Location = new System.Drawing.Point(5, 185);
            this.LBIpAddress.Name = "LBIpAddress";
            this.LBIpAddress.Size = new System.Drawing.Size(116, 10);
            // 
            // PBoxWebService
            // 
            this.PBoxWebService.Image = ((System.Drawing.Image)(resources.GetObject("PBoxWebService.Image")));
            this.PBoxWebService.Location = new System.Drawing.Point(11, 30);
            this.PBoxWebService.Name = "PBoxWebService";
            this.PBoxWebService.Size = new System.Drawing.Size(217, 28);
            this.PBoxWebService.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(11, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 9);
            this.label1.Text = "Storeid";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button1.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.button1.Location = new System.Drawing.Point(152, 202);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 24);
            this.button1.TabIndex = 153;
            this.button1.Text = "Exit Application";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_wmssettings
            // 
            this.btn_wmssettings.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_wmssettings.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.btn_wmssettings.Location = new System.Drawing.Point(153, 162);
            this.btn_wmssettings.Name = "btn_wmssettings";
            this.btn_wmssettings.Size = new System.Drawing.Size(82, 24);
            this.btn_wmssettings.TabIndex = 210;
            this.btn_wmssettings.Text = "WMS settings";
            this.btn_wmssettings.Click += new System.EventHandler(this.btn_wmssettings_Click);
            // 
            // cb_placewithreceive
            // 
            this.cb_placewithreceive.Font = new System.Drawing.Font("Tahoma", 7.5F, System.Drawing.FontStyle.Regular);
            this.cb_placewithreceive.Location = new System.Drawing.Point(57, 77);
            this.cb_placewithreceive.Name = "cb_placewithreceive";
            this.cb_placewithreceive.Size = new System.Drawing.Size(179, 16);
            this.cb_placewithreceive.TabIndex = 226;
            this.cb_placewithreceive.Text = "Παραλαβή > Τοποθέτηση";
            // 
            // cb_inputdimensions
            // 
            this.cb_inputdimensions.Font = new System.Drawing.Font("Tahoma", 7.5F, System.Drawing.FontStyle.Regular);
            this.cb_inputdimensions.Location = new System.Drawing.Point(57, 104);
            this.cb_inputdimensions.Name = "cb_inputdimensions";
            this.cb_inputdimensions.Size = new System.Drawing.Size(33, 21);
            this.cb_inputdimensions.TabIndex = 242;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 7.5F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(81, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 24);
            this.label3.Text = "Εισαγωγή διαστάσεων κατα  την παραλαβή από καθαριστήριο";
            // 
            // FrmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cb_inputdimensions);
            this.Controls.Add(this.cb_placewithreceive);
            this.Controls.Add(this.btn_wmssettings);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LBIpAddress);
            this.Controls.Add(this.PBSoftKeyb);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.PBBtnBck);
            this.Controls.Add(this.LbVersion);
            this.Controls.Add(this.LLbUpdate);
            this.Controls.Add(this.PBoxWSConStatus);
            this.Controls.Add(this.BtnCheckWSConnection);
            this.Controls.Add(this.TBStoreID);
            this.Controls.Add(this.PBoxStoreID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LBBRanchID);
            this.Controls.Add(this.TBBranchID);
            this.Controls.Add(this.PBoxBranchID);
            this.Controls.Add(this.TBCompID);
            this.Controls.Add(this.PBoxCompID);
            this.Controls.Add(this.LBWEBService);
            this.Controls.Add(this.TBWebService);
            this.Controls.Add(this.PBMenuBar);
            this.Controls.Add(this.PBoxWebService);
            this.Name = "FrmSettings";
            this.Text = "WMS/Mobile - Ρυθμίσεις";
            this.Load += new System.EventHandler(this.FrmSettings_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSettings_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox TBWebService;
        private System.Windows.Forms.Label LBWEBService;
        private System.Windows.Forms.TextBox TBCompID;
        private System.Windows.Forms.PictureBox PBoxCompID;
        private System.Windows.Forms.PictureBox PBoxBranchID;
        private System.Windows.Forms.TextBox TBBranchID;
        private System.Windows.Forms.Label LBBRanchID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox PBoxStoreID;
        private System.Windows.Forms.TextBox TBStoreID;
        private System.Windows.Forms.Button BtnCheckWSConnection;
        private System.Windows.Forms.PictureBox PBoxWSConStatus;
        private System.Windows.Forms.LinkLabel LLbUpdate;
        private System.Windows.Forms.Label LbVersion;
        private System.Windows.Forms.PictureBox PBMenuBar;
        private System.Windows.Forms.PictureBox PBBtnBck;
        private System.Windows.Forms.PictureBox BtnSave;
        private System.Windows.Forms.PictureBox PBSoftKeyb;
        private Microsoft.WindowsCE.Forms.InputPanel OnScreenKeyboard;
        private System.Windows.Forms.Label LBIpAddress;
        private System.Windows.Forms.PictureBox PBoxWebService;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_wmssettings;
        private System.Windows.Forms.CheckBox cb_placewithreceive;
        private System.Windows.Forms.CheckBox cb_inputdimensions;
        private System.Windows.Forms.Label label3;
    }
}