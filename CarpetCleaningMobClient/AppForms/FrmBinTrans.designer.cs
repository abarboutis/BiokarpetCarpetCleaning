namespace CarpetCleaningClient
{
    partial class FrmBinTrans
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBinTrans));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.TBOrderDetailID = new System.Windows.Forms.TextBox();
            this.LBItemCode = new System.Windows.Forms.Label();
            this.lb_customername = new System.Windows.Forms.Label();
            this.LBMunitQty = new System.Windows.Forms.Label();
            this.TBQty = new System.Windows.Forms.TextBox();
            this.LBMsgBox = new System.Windows.Forms.Label();
            this.LBPrimMunit = new System.Windows.Forms.Label();
            this.LBScanned = new System.Windows.Forms.Label();
            this.BtnSave = new System.Windows.Forms.PictureBox();
            this.PBBtnBck = new System.Windows.Forms.PictureBox();
            this.PBoxQty = new System.Windows.Forms.PictureBox();
            this.PBoxOrderDTL = new System.Windows.Forms.PictureBox();
            this.PBoxMessage = new System.Windows.Forms.PictureBox();
            this.PBMenuBar = new System.Windows.Forms.PictureBox();
            this.OnScreenKeyboard = new Microsoft.WindowsCE.Forms.InputPanel(this.components);
            this.PBSoftKeyb = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BtnDelete = new System.Windows.Forms.PictureBox();
            this.lb_itemdesc = new System.Windows.Forms.Label();
            this.lb_transinfo = new System.Windows.Forms.Label();
            this.lb_bin = new System.Windows.Forms.Label();
            this.pb_barcode = new System.Windows.Forms.PictureBox();
            this.PBoxBin = new System.Windows.Forms.PictureBox();
            this.TBBin = new System.Windows.Forms.TextBox();
            this.TBLength = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PBoxLength = new System.Windows.Forms.PictureBox();
            this.TBWidth = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PBoxWidth = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSaveFake = new System.Windows.Forms.Button();
            this.tb_save = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbcode = new System.Windows.Forms.TextBox();
            this.PBoxItemCode = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.SuspendLayout();
            // 
            // TBOrderDetailID
            // 
            this.TBOrderDetailID.AcceptsReturn = true;
            this.TBOrderDetailID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.TBOrderDetailID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TBOrderDetailID.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular);
            this.TBOrderDetailID.Location = new System.Drawing.Point(13, 42);
            this.TBOrderDetailID.MaxLength = 20;
            this.TBOrderDetailID.Name = "TBOrderDetailID";
            this.TBOrderDetailID.Size = new System.Drawing.Size(160, 27);
            this.TBOrderDetailID.TabIndex = 5;
            this.TBOrderDetailID.TextChanged += new System.EventHandler(this.TBItemCode_TextChanged);
            this.TBOrderDetailID.GotFocus += new System.EventHandler(this.TBItemCode_GotFocus);
            this.TBOrderDetailID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TBItemCode_KeyDown);
            this.TBOrderDetailID.LostFocus += new System.EventHandler(this.TBOrderDetailID_LostFocus);
            // 
            // LBItemCode
            // 
            this.LBItemCode.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.LBItemCode.Location = new System.Drawing.Point(41, 21);
            this.LBItemCode.Name = "LBItemCode";
            this.LBItemCode.Size = new System.Drawing.Size(56, 12);
            this.LBItemCode.Text = "BarCode";
            // 
            // lb_customername
            // 
            this.lb_customername.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lb_customername.ForeColor = System.Drawing.Color.Maroon;
            this.lb_customername.Location = new System.Drawing.Point(110, 22);
            this.lb_customername.Name = "lb_customername";
            this.lb_customername.Size = new System.Drawing.Size(98, 12);
            // 
            // LBMunitQty
            // 
            this.LBMunitQty.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.LBMunitQty.Location = new System.Drawing.Point(137, 150);
            this.LBMunitQty.Name = "LBMunitQty";
            this.LBMunitQty.Size = new System.Drawing.Size(93, 13);
            this.LBMunitQty.Text = "Ποσότητα (M2)";
            // 
            // TBQty
            // 
            this.TBQty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.TBQty.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TBQty.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.TBQty.Location = new System.Drawing.Point(141, 169);
            this.TBQty.Name = "TBQty";
            this.TBQty.Size = new System.Drawing.Size(50, 19);
            this.TBQty.TabIndex = 19;
            this.TBQty.TextChanged += new System.EventHandler(this.TBQty_TextChanged);
            this.TBQty.GotFocus += new System.EventHandler(this.TBQty_GotFocus);
            this.TBQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TBQty_KeyDown);
            this.TBQty.LostFocus += new System.EventHandler(this.TBQty_LostFocus);
            // 
            // LBMsgBox
            // 
            this.LBMsgBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(235)))), ((int)(((byte)(163)))));
            this.LBMsgBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.LBMsgBox.ForeColor = System.Drawing.Color.Brown;
            this.LBMsgBox.Location = new System.Drawing.Point(10, 219);
            this.LBMsgBox.Name = "LBMsgBox";
            this.LBMsgBox.Size = new System.Drawing.Size(217, 28);
            this.LBMsgBox.Visible = false;
            // 
            // LBPrimMunit
            // 
            this.LBPrimMunit.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.LBPrimMunit.ForeColor = System.Drawing.Color.Maroon;
            this.LBPrimMunit.Location = new System.Drawing.Point(159, 113);
            this.LBPrimMunit.Name = "LBPrimMunit";
            this.LBPrimMunit.Size = new System.Drawing.Size(37, 16);
            // 
            // LBScanned
            // 
            this.LBScanned.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.LBScanned.ForeColor = System.Drawing.Color.Maroon;
            this.LBScanned.Location = new System.Drawing.Point(119, 198);
            this.LBScanned.Name = "LBScanned";
            this.LBScanned.Size = new System.Drawing.Size(111, 14);
            // 
            // BtnSave
            // 
            this.BtnSave.Image = ((System.Drawing.Image)(resources.GetObject("BtnSave.Image")));
            this.BtnSave.Location = new System.Drawing.Point(155, 273);
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
            // PBoxQty
            // 
            this.PBoxQty.Image = ((System.Drawing.Image)(resources.GetObject("PBoxQty.Image")));
            this.PBoxQty.Location = new System.Drawing.Point(136, 166);
            this.PBoxQty.Name = "PBoxQty";
            this.PBoxQty.Size = new System.Drawing.Size(80, 25);
            // 
            // PBoxOrderDTL
            // 
            this.PBoxOrderDTL.Image = ((System.Drawing.Image)(resources.GetObject("PBoxOrderDTL.Image")));
            this.PBoxOrderDTL.Location = new System.Drawing.Point(3, 36);
            this.PBoxOrderDTL.Name = "PBoxOrderDTL";
            this.PBoxOrderDTL.Size = new System.Drawing.Size(235, 37);
            this.PBoxOrderDTL.Click += new System.EventHandler(this.PBoxITemCode_Click);
            // 
            // PBoxMessage
            // 
            this.PBoxMessage.Image = ((System.Drawing.Image)(resources.GetObject("PBoxMessage.Image")));
            this.PBoxMessage.Location = new System.Drawing.Point(2, 215);
            this.PBoxMessage.Name = "PBoxMessage";
            this.PBoxMessage.Size = new System.Drawing.Size(236, 38);
            this.PBoxMessage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PBoxMessage.Visible = false;
            this.PBoxMessage.Click += new System.EventHandler(this.PBoxMessage_Click);
            // 
            // PBMenuBar
            // 
            this.PBMenuBar.Image = ((System.Drawing.Image)(resources.GetObject("PBMenuBar.Image")));
            this.PBMenuBar.Location = new System.Drawing.Point(0, 270);
            this.PBMenuBar.Name = "PBMenuBar";
            this.PBMenuBar.Size = new System.Drawing.Size(241, 50);
            // 
            // PBSoftKeyb
            // 
            this.PBSoftKeyb.Image = ((System.Drawing.Image)(resources.GetObject("PBSoftKeyb.Image")));
            this.PBSoftKeyb.Location = new System.Drawing.Point(214, 25);
            this.PBSoftKeyb.Name = "PBSoftKeyb";
            this.PBSoftKeyb.Size = new System.Drawing.Size(21, 10);
            this.PBSoftKeyb.Click += new System.EventHandler(this.PBSoftKeyb_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(8, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(33, 10);
            // 
            // BtnDelete
            // 
            this.BtnDelete.Image = ((System.Drawing.Image)(resources.GetObject("BtnDelete.Image")));
            this.BtnDelete.Location = new System.Drawing.Point(89, 273);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(46, 44);
            this.BtnDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // lb_itemdesc
            // 
            this.lb_itemdesc.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.lb_itemdesc.ForeColor = System.Drawing.Color.Maroon;
            this.lb_itemdesc.Location = new System.Drawing.Point(8, 76);
            this.lb_itemdesc.Name = "lb_itemdesc";
            this.lb_itemdesc.Size = new System.Drawing.Size(226, 20);
            // 
            // lb_transinfo
            // 
            this.lb_transinfo.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lb_transinfo.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lb_transinfo.Location = new System.Drawing.Point(14, 4);
            this.lb_transinfo.Name = "lb_transinfo";
            this.lb_transinfo.Size = new System.Drawing.Size(220, 16);
            // 
            // lb_bin
            // 
            this.lb_bin.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lb_bin.Location = new System.Drawing.Point(43, 95);
            this.lb_bin.Name = "lb_bin";
            this.lb_bin.Size = new System.Drawing.Size(41, 12);
            this.lb_bin.Text = "Ράφι";
            this.lb_bin.Visible = false;
            // 
            // pb_barcode
            // 
            this.pb_barcode.Image = ((System.Drawing.Image)(resources.GetObject("pb_barcode.Image")));
            this.pb_barcode.Location = new System.Drawing.Point(10, 97);
            this.pb_barcode.Name = "pb_barcode";
            this.pb_barcode.Size = new System.Drawing.Size(33, 10);
            this.pb_barcode.Visible = false;
            // 
            // PBoxBin
            // 
            this.PBoxBin.Image = ((System.Drawing.Image)(resources.GetObject("PBoxBin.Image")));
            this.PBoxBin.Location = new System.Drawing.Point(5, 108);
            this.PBoxBin.Name = "PBoxBin";
            this.PBoxBin.Size = new System.Drawing.Size(66, 25);
            this.PBoxBin.Visible = false;
            // 
            // TBBin
            // 
            this.TBBin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.TBBin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TBBin.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.TBBin.ForeColor = System.Drawing.Color.Maroon;
            this.TBBin.Location = new System.Drawing.Point(10, 113);
            this.TBBin.Name = "TBBin";
            this.TBBin.Size = new System.Drawing.Size(56, 19);
            this.TBBin.TabIndex = 33;
            this.TBBin.Visible = false;
            this.TBBin.TextChanged += new System.EventHandler(this.TBBin_TextChanged);
            this.TBBin.GotFocus += new System.EventHandler(this.TBBin_GotFocus);
            this.TBBin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TBBin_KeyDown);
            this.TBBin.LostFocus += new System.EventHandler(this.TBBin_LostFocus);
            // 
            // TBLength
            // 
            this.TBLength.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.TBLength.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TBLength.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.TBLength.Location = new System.Drawing.Point(82, 169);
            this.TBLength.Name = "TBLength";
            this.TBLength.Size = new System.Drawing.Size(41, 19);
            this.TBLength.TabIndex = 56;
            this.TBLength.TextChanged += new System.EventHandler(this.TBLength_TextChanged);
            this.TBLength.GotFocus += new System.EventHandler(this.TBLength_GotFocus);
            this.TBLength.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TBLength_KeyDown);
            this.TBLength.LostFocus += new System.EventHandler(this.TBLength_LostFocus);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(82, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 14);
            this.label1.Text = "Μήκος";
            // 
            // PBoxLength
            // 
            this.PBoxLength.Image = ((System.Drawing.Image)(resources.GetObject("PBoxLength.Image")));
            this.PBoxLength.Location = new System.Drawing.Point(78, 166);
            this.PBoxLength.Name = "PBoxLength";
            this.PBoxLength.Size = new System.Drawing.Size(50, 25);
            // 
            // TBWidth
            // 
            this.TBWidth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.TBWidth.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TBWidth.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.TBWidth.Location = new System.Drawing.Point(11, 169);
            this.TBWidth.Name = "TBWidth";
            this.TBWidth.Size = new System.Drawing.Size(41, 19);
            this.TBWidth.TabIndex = 61;
            this.TBWidth.TextChanged += new System.EventHandler(this.TBWidth_TextChanged);
            this.TBWidth.GotFocus += new System.EventHandler(this.TBWidth_GotFocus);
            this.TBWidth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TBWidth_KeyDown);
            this.TBWidth.LostFocus += new System.EventHandler(this.TBWidth_LostFocus);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(11, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 14);
            this.label2.Text = "Πλάτος";
            // 
            // PBoxWidth
            // 
            this.PBoxWidth.Image = ((System.Drawing.Image)(resources.GetObject("PBoxWidth.Image")));
            this.PBoxWidth.Location = new System.Drawing.Point(7, 166);
            this.PBoxWidth.Name = "PBoxWidth";
            this.PBoxWidth.Size = new System.Drawing.Size(50, 25);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(59, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 18);
            this.label3.Text = "Χ";
            // 
            // btnSaveFake
            // 
            this.btnSaveFake.Location = new System.Drawing.Point(183, 273);
            this.btnSaveFake.Name = "btnSaveFake";
            this.btnSaveFake.Size = new System.Drawing.Size(25, 21);
            this.btnSaveFake.TabIndex = 87;
            this.btnSaveFake.Text = "button1";
            // 
            // tb_save
            // 
            this.tb_save.BackColor = System.Drawing.Color.White;
            this.tb_save.Location = new System.Drawing.Point(215, 168);
            this.tb_save.Name = "tb_save";
            this.tb_save.Size = new System.Drawing.Size(2, 21);
            this.tb_save.TabIndex = 88;
            this.tb_save.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(120, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.Text = "Είδος";
            // 
            // tbcode
            // 
            this.tbcode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.tbcode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbcode.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.tbcode.ForeColor = System.Drawing.Color.Maroon;
            this.tbcode.Location = new System.Drawing.Point(91, 113);
            this.tbcode.Name = "tbcode";
            this.tbcode.Size = new System.Drawing.Size(56, 19);
            this.tbcode.TabIndex = 116;
            this.tbcode.GotFocus += new System.EventHandler(this.ΤΒItemCode_GotFocus);
            this.tbcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ΤΒItemCode_KeyDown);
            this.tbcode.LostFocus += new System.EventHandler(this.ΤΒItemCode_LostFocus);
            // 
            // PBoxItemCode
            // 
            this.PBoxItemCode.Image = ((System.Drawing.Image)(resources.GetObject("PBoxItemCode.Image")));
            this.PBoxItemCode.Location = new System.Drawing.Point(85, 108);
            this.PBoxItemCode.Name = "PBoxItemCode";
            this.PBoxItemCode.Size = new System.Drawing.Size(66, 25);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(87, 97);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(33, 10);
            // 
            // FrmBinTrans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.tbcode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_save);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TBWidth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PBoxWidth);
            this.Controls.Add(this.TBLength);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PBoxLength);
            this.Controls.Add(this.TBBin);
            this.Controls.Add(this.PBoxBin);
            this.Controls.Add(this.pb_barcode);
            this.Controls.Add(this.lb_bin);
            this.Controls.Add(this.lb_transinfo);
            this.Controls.Add(this.BtnDelete);
            this.Controls.Add(this.lb_itemdesc);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.PBSoftKeyb);
            this.Controls.Add(this.PBBtnBck);
            this.Controls.Add(this.LBScanned);
            this.Controls.Add(this.LBPrimMunit);
            this.Controls.Add(this.LBMsgBox);
            this.Controls.Add(this.TBQty);
            this.Controls.Add(this.LBMunitQty);
            this.Controls.Add(this.PBoxQty);
            this.Controls.Add(this.lb_customername);
            this.Controls.Add(this.LBItemCode);
            this.Controls.Add(this.TBOrderDetailID);
            this.Controls.Add(this.PBoxOrderDTL);
            this.Controls.Add(this.PBoxMessage);
            this.Controls.Add(this.PBMenuBar);
            this.Controls.Add(this.btnSaveFake);
            this.Controls.Add(this.PBoxItemCode);
            this.Name = "FrmBinTrans";
            this.Text = "Κίνηση Αποθήκης";
            this.Load += new System.EventHandler(this.FrmBinTrans_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmBinTrans_MouseDown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmBinTrans_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PBoxOrderDTL;
        private System.Windows.Forms.TextBox TBOrderDetailID;
        private System.Windows.Forms.Label LBItemCode;
        private System.Windows.Forms.Label lb_customername;
        private System.Windows.Forms.PictureBox PBoxQty;
        private System.Windows.Forms.Label LBMunitQty;
        private System.Windows.Forms.TextBox TBQty;
        private System.Windows.Forms.Label LBMsgBox;
        private System.Windows.Forms.PictureBox PBoxMessage;
        private System.Windows.Forms.Label LBPrimMunit;
        private System.Windows.Forms.Label LBScanned;
        private System.Windows.Forms.PictureBox PBMenuBar;
        private System.Windows.Forms.PictureBox PBBtnBck;
        private System.Windows.Forms.PictureBox BtnSave;
        private Microsoft.WindowsCE.Forms.InputPanel OnScreenKeyboard;
        private System.Windows.Forms.PictureBox PBSoftKeyb;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox BtnDelete;
        private System.Windows.Forms.Label lb_itemdesc;
        private System.Windows.Forms.Label lb_transinfo;
        private System.Windows.Forms.Label lb_bin;
        private System.Windows.Forms.PictureBox pb_barcode;
        private System.Windows.Forms.PictureBox PBoxBin;
        private System.Windows.Forms.TextBox TBBin;
        private System.Windows.Forms.TextBox TBLength;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox PBoxLength;
        private System.Windows.Forms.TextBox TBWidth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox PBoxWidth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSaveFake;
        private System.Windows.Forms.TextBox tb_save;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbcode;
        private System.Windows.Forms.PictureBox PBoxItemCode;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}