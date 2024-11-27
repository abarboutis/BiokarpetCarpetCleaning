namespace CarpetCleaningClient
{
    partial class FrmInternalBinTrans
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInternalBinTrans));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.LBItemCode = new System.Windows.Forms.Label();
            this.lb_customername = new System.Windows.Forms.Label();
            this.LBMunitQty = new System.Windows.Forms.Label();
            this.TBQty = new System.Windows.Forms.TextBox();
            this.LBMsgBox = new System.Windows.Forms.Label();
            this.LBPrimMunit = new System.Windows.Forms.Label();
            this.LBScanned = new System.Windows.Forms.Label();
            this.LBAlterQty = new System.Windows.Forms.Label();
            this.LBBin = new System.Windows.Forms.Label();
            this.TBBin = new System.Windows.Forms.TextBox();
            this.BtnSave = new System.Windows.Forms.PictureBox();
            this.PBBtnBck = new System.Windows.Forms.PictureBox();
            this.PBoxBarcodeBin = new System.Windows.Forms.PictureBox();
            this.PBoxBin = new System.Windows.Forms.PictureBox();
            this.PBoxQty = new System.Windows.Forms.PictureBox();
            this.PBoxITemCode = new System.Windows.Forms.PictureBox();
            this.PBoxMessage = new System.Windows.Forms.PictureBox();
            this.PBMenuBar = new System.Windows.Forms.PictureBox();
            this.PBDownArrow = new System.Windows.Forms.PictureBox();
            this.OnScreenKeyboard = new Microsoft.WindowsCE.Forms.InputPanel(this.components);
            this.PBSoftKeyb = new System.Windows.Forms.PictureBox();
            this.LBAvailableqty = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lb_itemdesc = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.TBbin_from = new System.Windows.Forms.TextBox();
            this.PBUpArrow = new System.Windows.Forms.PictureBox();
            this.PBoxFrom = new System.Windows.Forms.PictureBox();
            this.TBOrderDTL = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LBItemCode
            // 
            this.LBItemCode.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.LBItemCode.Location = new System.Drawing.Point(53, 8);
            this.LBItemCode.Name = "LBItemCode";
            this.LBItemCode.Size = new System.Drawing.Size(56, 12);
            this.LBItemCode.Text = "BarCode";
            // 
            // lb_customername
            // 
            this.lb_customername.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lb_customername.ForeColor = System.Drawing.Color.Maroon;
            this.lb_customername.Location = new System.Drawing.Point(110, 9);
            this.lb_customername.Name = "lb_customername";
            this.lb_customername.Size = new System.Drawing.Size(98, 12);
            // 
            // LBMunitQty
            // 
            this.LBMunitQty.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.LBMunitQty.Location = new System.Drawing.Point(7, 152);
            this.LBMunitQty.Name = "LBMunitQty";
            this.LBMunitQty.Size = new System.Drawing.Size(100, 11);
            this.LBMunitQty.Text = "Ποσότητα";
            // 
            // TBQty
            // 
            this.TBQty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.TBQty.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TBQty.Enabled = false;
            this.TBQty.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.TBQty.Location = new System.Drawing.Point(12, 171);
            this.TBQty.Multiline = true;
            this.TBQty.Name = "TBQty";
            this.TBQty.Size = new System.Drawing.Size(85, 14);
            this.TBQty.TabIndex = 19;
            this.TBQty.TextChanged += new System.EventHandler(this.TBQty_TextChanged);
            this.TBQty.GotFocus += new System.EventHandler(this.TBQty_GotFocus);
            // 
            // LBMsgBox
            // 
            this.LBMsgBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(235)))), ((int)(((byte)(163)))));
            this.LBMsgBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.LBMsgBox.ForeColor = System.Drawing.Color.Brown;
            this.LBMsgBox.Location = new System.Drawing.Point(10, 212);
            this.LBMsgBox.Name = "LBMsgBox";
            this.LBMsgBox.Size = new System.Drawing.Size(217, 28);
            this.LBMsgBox.Visible = false;
            // 
            // LBPrimMunit
            // 
            this.LBPrimMunit.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.LBPrimMunit.Location = new System.Drawing.Point(116, 175);
            this.LBPrimMunit.Name = "LBPrimMunit";
            this.LBPrimMunit.Size = new System.Drawing.Size(30, 16);
            // 
            // LBScanned
            // 
            this.LBScanned.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.LBScanned.ForeColor = System.Drawing.Color.Maroon;
            this.LBScanned.Location = new System.Drawing.Point(156, 191);
            this.LBScanned.Name = "LBScanned";
            this.LBScanned.Size = new System.Drawing.Size(78, 14);
            // 
            // LBAlterQty
            // 
            this.LBAlterQty.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.LBAlterQty.Location = new System.Drawing.Point(145, 117);
            this.LBAlterQty.Name = "LBAlterQty";
            this.LBAlterQty.Size = new System.Drawing.Size(41, 14);
            // 
            // LBBin
            // 
            this.LBBin.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.LBBin.Location = new System.Drawing.Point(45, 108);
            this.LBBin.Name = "LBBin";
            this.LBBin.Size = new System.Drawing.Size(152, 12);
            this.LBBin.Text = "Σε Θέση Αποθήκευσης";
            this.LBBin.Visible = false;
            // 
            // TBBin
            // 
            this.TBBin.AcceptsReturn = true;
            this.TBBin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.TBBin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TBBin.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.TBBin.Location = new System.Drawing.Point(12, 131);
            this.TBBin.MaxLength = 20;
            this.TBBin.Multiline = true;
            this.TBBin.Name = "TBBin";
            this.TBBin.Size = new System.Drawing.Size(85, 15);
            this.TBBin.TabIndex = 75;
            this.TBBin.Visible = false;
            this.TBBin.GotFocus += new System.EventHandler(this.TBBin_GotFocus);
            this.TBBin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TBBin_KeyDown);
            this.TBBin.LostFocus += new System.EventHandler(this.TBBin_LostFocus);
            // 
            // BtnSave
            // 
            this.BtnSave.Image = ((System.Drawing.Image)(resources.GetObject("BtnSave.Image")));
            this.BtnSave.Location = new System.Drawing.Point(163, 273);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(64, 44);
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            this.BtnSave.GotFocus += new System.EventHandler(this.BtnSave_GotFocus);
            this.BtnSave.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnSave_MouseDown);
            this.BtnSave.LostFocus += new System.EventHandler(this.BtnSave_LostFocus);
            this.BtnSave.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnSave_MouseUp);
            // 
            // PBBtnBck
            // 
            this.PBBtnBck.Image = ((System.Drawing.Image)(resources.GetObject("PBBtnBck.Image")));
            this.PBBtnBck.Location = new System.Drawing.Point(6, 273);
            this.PBBtnBck.Name = "PBBtnBck";
            this.PBBtnBck.Size = new System.Drawing.Size(64, 44);
            this.PBBtnBck.Click += new System.EventHandler(this.PBBtnBck_Click);
            this.PBBtnBck.GotFocus += new System.EventHandler(this.PBBtnBck_GotFocus);
            this.PBBtnBck.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PBBtnBck_MouseDown);
            this.PBBtnBck.LostFocus += new System.EventHandler(this.PBBtnBck_LostFocus);
            this.PBBtnBck.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PBBtnBck_MouseUp);
            // 
            // PBoxBarcodeBin
            // 
            this.PBoxBarcodeBin.Image = ((System.Drawing.Image)(resources.GetObject("PBoxBarcodeBin.Image")));
            this.PBoxBarcodeBin.Location = new System.Drawing.Point(10, 112);
            this.PBoxBarcodeBin.Name = "PBoxBarcodeBin";
            this.PBoxBarcodeBin.Size = new System.Drawing.Size(33, 10);
            this.PBoxBarcodeBin.Visible = false;
            // 
            // PBoxBin
            // 
            this.PBoxBin.Image = ((System.Drawing.Image)(resources.GetObject("PBoxBin.Image")));
            this.PBoxBin.Location = new System.Drawing.Point(3, 125);
            this.PBoxBin.Name = "PBoxBin";
            this.PBoxBin.Size = new System.Drawing.Size(110, 25);
            this.PBoxBin.Visible = false;
            // 
            // PBoxQty
            // 
            this.PBoxQty.Image = ((System.Drawing.Image)(resources.GetObject("PBoxQty.Image")));
            this.PBoxQty.Location = new System.Drawing.Point(3, 166);
            this.PBoxQty.Name = "PBoxQty";
            this.PBoxQty.Size = new System.Drawing.Size(110, 23);
            // 
            // PBoxITemCode
            // 
            this.PBoxITemCode.Image = ((System.Drawing.Image)(resources.GetObject("PBoxITemCode.Image")));
            this.PBoxITemCode.Location = new System.Drawing.Point(3, 24);
            this.PBoxITemCode.Name = "PBoxITemCode";
            this.PBoxITemCode.Size = new System.Drawing.Size(235, 30);
            this.PBoxITemCode.Click += new System.EventHandler(this.PBoxITemCode_Click);
            // 
            // PBoxMessage
            // 
            this.PBoxMessage.Image = ((System.Drawing.Image)(resources.GetObject("PBoxMessage.Image")));
            this.PBoxMessage.Location = new System.Drawing.Point(2, 208);
            this.PBoxMessage.Name = "PBoxMessage";
            this.PBoxMessage.Size = new System.Drawing.Size(236, 38);
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
            // PBDownArrow
            // 
            this.PBDownArrow.Image = ((System.Drawing.Image)(resources.GetObject("PBDownArrow.Image")));
            this.PBDownArrow.Location = new System.Drawing.Point(123, 140);
            this.PBDownArrow.Name = "PBDownArrow";
            this.PBDownArrow.Size = new System.Drawing.Size(16, 16);
            this.PBDownArrow.Visible = false;
            // 
            // PBSoftKeyb
            // 
            this.PBSoftKeyb.Image = ((System.Drawing.Image)(resources.GetObject("PBSoftKeyb.Image")));
            this.PBSoftKeyb.Location = new System.Drawing.Point(212, 3);
            this.PBSoftKeyb.Name = "PBSoftKeyb";
            this.PBSoftKeyb.Size = new System.Drawing.Size(21, 10);
            this.PBSoftKeyb.Click += new System.EventHandler(this.PBSoftKeyb_Click);
            // 
            // LBAvailableqty
            // 
            this.LBAvailableqty.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.LBAvailableqty.Location = new System.Drawing.Point(145, 128);
            this.LBAvailableqty.Name = "LBAvailableqty";
            this.LBAvailableqty.Size = new System.Drawing.Size(53, 15);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(14, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(33, 10);
            // 
            // lb_itemdesc
            // 
            this.lb_itemdesc.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lb_itemdesc.ForeColor = System.Drawing.Color.Maroon;
            this.lb_itemdesc.Location = new System.Drawing.Point(7, 56);
            this.lb_itemdesc.Name = "lb_itemdesc";
            this.lb_itemdesc.Size = new System.Drawing.Size(228, 12);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(46, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 12);
            this.label1.Text = "Από Θέση Αποθήκευσης";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(9, 71);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(33, 10);
            // 
            // TBbin_from
            // 
            this.TBbin_from.AcceptsReturn = true;
            this.TBbin_from.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.TBbin_from.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TBbin_from.Enabled = false;
            this.TBbin_from.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.TBbin_from.Location = new System.Drawing.Point(12, 90);
            this.TBbin_from.MaxLength = 20;
            this.TBbin_from.Multiline = true;
            this.TBbin_from.Name = "TBbin_from";
            this.TBbin_from.Size = new System.Drawing.Size(85, 12);
            this.TBbin_from.TabIndex = 95;
            this.TBbin_from.GotFocus += new System.EventHandler(this.TBbin_from_GotFocus);
            this.TBbin_from.LostFocus += new System.EventHandler(this.TBbin_from_LostFocus);
            // 
            // PBUpArrow
            // 
            this.PBUpArrow.Image = ((System.Drawing.Image)(resources.GetObject("PBUpArrow.Image")));
            this.PBUpArrow.Location = new System.Drawing.Point(123, 123);
            this.PBUpArrow.Name = "PBUpArrow";
            this.PBUpArrow.Size = new System.Drawing.Size(16, 16);
            this.PBUpArrow.Visible = false;
            // 
            // PBoxFrom
            // 
            this.PBoxFrom.Image = ((System.Drawing.Image)(resources.GetObject("PBoxFrom.Image")));
            this.PBoxFrom.Location = new System.Drawing.Point(3, 83);
            this.PBoxFrom.Name = "PBoxFrom";
            this.PBoxFrom.Size = new System.Drawing.Size(110, 23);
            // 
            // TBOrderDTL
            // 
            this.TBOrderDTL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.TBOrderDTL.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TBOrderDTL.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.TBOrderDTL.Location = new System.Drawing.Point(9, 29);
            this.TBOrderDTL.Name = "TBOrderDTL";
            this.TBOrderDTL.Size = new System.Drawing.Size(203, 24);
            this.TBOrderDTL.TabIndex = 122;
            this.TBOrderDTL.GotFocus += new System.EventHandler(this.TBItemCode_GotFocus);
            this.TBOrderDTL.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TBItemCode_KeyDown);
            this.TBOrderDTL.LostFocus += new System.EventHandler(this.TBOrderDetailID_LostFocus);
            // 
            // FrmInternalBinTrans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.ControlBox = false;
            this.Controls.Add(this.TBOrderDTL);
            this.Controls.Add(this.TBbin_from);
            this.Controls.Add(this.PBoxFrom);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lb_itemdesc);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.LBAvailableqty);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.PBSoftKeyb);
            this.Controls.Add(this.PBBtnBck);
            this.Controls.Add(this.PBDownArrow);
            this.Controls.Add(this.PBUpArrow);
            this.Controls.Add(this.TBBin);
            this.Controls.Add(this.PBoxBarcodeBin);
            this.Controls.Add(this.LBBin);
            this.Controls.Add(this.PBoxBin);
            this.Controls.Add(this.LBScanned);
            this.Controls.Add(this.LBAlterQty);
            this.Controls.Add(this.LBPrimMunit);
            this.Controls.Add(this.LBMsgBox);
            this.Controls.Add(this.TBQty);
            this.Controls.Add(this.LBMunitQty);
            this.Controls.Add(this.PBoxQty);
            this.Controls.Add(this.lb_customername);
            this.Controls.Add(this.LBItemCode);
            this.Controls.Add(this.PBoxMessage);
            this.Controls.Add(this.PBMenuBar);
            this.Controls.Add(this.PBoxITemCode);
            this.Name = "FrmInternalBinTrans";
            this.Text = "Κίνηση Αποθήκης";
            this.Load += new System.EventHandler(this.FrmBinTrans_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmBinTrans_MouseDown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmBinTrans_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PBoxITemCode;
        private System.Windows.Forms.Label LBItemCode;
        private System.Windows.Forms.Label lb_customername;
        private System.Windows.Forms.PictureBox PBoxQty;
        private System.Windows.Forms.Label LBMunitQty;
        private System.Windows.Forms.TextBox TBQty;
        private System.Windows.Forms.Label LBMsgBox;
        private System.Windows.Forms.PictureBox PBoxMessage;
        private System.Windows.Forms.Label LBPrimMunit;
        private System.Windows.Forms.Label LBScanned;
        private System.Windows.Forms.Label LBAlterQty;
        private System.Windows.Forms.PictureBox PBoxBin;
        private System.Windows.Forms.Label LBBin;
        private System.Windows.Forms.PictureBox PBoxBarcodeBin;
        private System.Windows.Forms.TextBox TBBin;
        private System.Windows.Forms.PictureBox PBDownArrow;
        private System.Windows.Forms.PictureBox PBMenuBar;
        private System.Windows.Forms.PictureBox PBBtnBck;
        private System.Windows.Forms.PictureBox BtnSave;
        private Microsoft.WindowsCE.Forms.InputPanel OnScreenKeyboard;
        private System.Windows.Forms.PictureBox PBSoftKeyb;
        private System.Windows.Forms.Label LBAvailableqty;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lb_itemdesc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox TBbin_from;
        private System.Windows.Forms.PictureBox PBUpArrow;
        private System.Windows.Forms.PictureBox PBoxFrom;
        private System.Windows.Forms.TextBox TBOrderDTL;
    }
}