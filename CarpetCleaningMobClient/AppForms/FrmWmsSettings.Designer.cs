namespace CarpetCleaningClient
{
    partial class FrmWmsSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWmsSettings));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.PBMenuBar = new System.Windows.Forms.PictureBox();
            this.PBBtnBck = new System.Windows.Forms.PictureBox();
            this.BtnSave = new System.Windows.Forms.PictureBox();
            this.PBSoftKeyb = new System.Windows.Forms.PictureBox();
            this.OnScreenKeyboard = new Microsoft.WindowsCE.Forms.InputPanel(this.components);
            this.lb = new System.Windows.Forms.Label();
            this.TB_CustomerReceives = new System.Windows.Forms.TextBox();
            this.pBoxCustomerReceives = new System.Windows.Forms.PictureBox();
            this.TB_SupplierReceives = new System.Windows.Forms.TextBox();
            this.pBoxSupplierReceives = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TB_CustomerShipping = new System.Windows.Forms.TextBox();
            this.pBoxCustomerShipping = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TB_SupplierShipping = new System.Windows.Forms.TextBox();
            this.pBoxSupplierShipping = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TB_DefaultReceivesBin = new System.Windows.Forms.TextBox();
            this.pBoxDefaulReceivesBin = new System.Windows.Forms.PictureBox();
            this.lb_DefaulReceivesBin = new System.Windows.Forms.Label();
            this.TB_InternalMove = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lb_InternalMove = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            // lb
            // 
            this.lb.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.lb.Location = new System.Drawing.Point(15, 20);
            this.lb.Name = "lb";
            this.lb.Size = new System.Drawing.Size(109, 9);
            this.lb.Text = "CustomerReceives";
            // 
            // TB_CustomerReceives
            // 
            this.TB_CustomerReceives.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.TB_CustomerReceives.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TB_CustomerReceives.Location = new System.Drawing.Point(21, 38);
            this.TB_CustomerReceives.Multiline = true;
            this.TB_CustomerReceives.Name = "TB_CustomerReceives";
            this.TB_CustomerReceives.Size = new System.Drawing.Size(49, 12);
            this.TB_CustomerReceives.TabIndex = 172;
            // 
            // pBoxCustomerReceives
            // 
            this.pBoxCustomerReceives.Image = ((System.Drawing.Image)(resources.GetObject("pBoxCustomerReceives.Image")));
            this.pBoxCustomerReceives.Location = new System.Drawing.Point(15, 32);
            this.pBoxCustomerReceives.Name = "pBoxCustomerReceives";
            this.pBoxCustomerReceives.Size = new System.Drawing.Size(56, 19);
            this.pBoxCustomerReceives.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // TB_SupplierReceives
            // 
            this.TB_SupplierReceives.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.TB_SupplierReceives.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TB_SupplierReceives.Location = new System.Drawing.Point(21, 67);
            this.TB_SupplierReceives.Multiline = true;
            this.TB_SupplierReceives.Name = "TB_SupplierReceives";
            this.TB_SupplierReceives.Size = new System.Drawing.Size(49, 12);
            this.TB_SupplierReceives.TabIndex = 176;
            // 
            // pBoxSupplierReceives
            // 
            this.pBoxSupplierReceives.Image = ((System.Drawing.Image)(resources.GetObject("pBoxSupplierReceives.Image")));
            this.pBoxSupplierReceives.Location = new System.Drawing.Point(15, 64);
            this.pBoxSupplierReceives.Name = "pBoxSupplierReceives";
            this.pBoxSupplierReceives.Size = new System.Drawing.Size(56, 19);
            this.pBoxSupplierReceives.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(15, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 9);
            this.label3.Text = "SupplierReceives";
            // 
            // TB_CustomerShipping
            // 
            this.TB_CustomerShipping.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.TB_CustomerShipping.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TB_CustomerShipping.Location = new System.Drawing.Point(21, 100);
            this.TB_CustomerShipping.Multiline = true;
            this.TB_CustomerShipping.Name = "TB_CustomerShipping";
            this.TB_CustomerShipping.Size = new System.Drawing.Size(49, 12);
            this.TB_CustomerShipping.TabIndex = 181;
            // 
            // pBoxCustomerShipping
            // 
            this.pBoxCustomerShipping.Image = ((System.Drawing.Image)(resources.GetObject("pBoxCustomerShipping.Image")));
            this.pBoxCustomerShipping.Location = new System.Drawing.Point(15, 97);
            this.pBoxCustomerShipping.Name = "pBoxCustomerShipping";
            this.pBoxCustomerShipping.Size = new System.Drawing.Size(56, 19);
            this.pBoxCustomerShipping.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(15, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 11);
            this.label4.Text = "CustomerShipping";
            // 
            // TB_SupplierShipping
            // 
            this.TB_SupplierShipping.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.TB_SupplierShipping.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TB_SupplierShipping.Location = new System.Drawing.Point(20, 132);
            this.TB_SupplierShipping.Multiline = true;
            this.TB_SupplierShipping.Name = "TB_SupplierShipping";
            this.TB_SupplierShipping.Size = new System.Drawing.Size(49, 12);
            this.TB_SupplierShipping.TabIndex = 186;
            // 
            // pBoxSupplierShipping
            // 
            this.pBoxSupplierShipping.Image = ((System.Drawing.Image)(resources.GetObject("pBoxSupplierShipping.Image")));
            this.pBoxSupplierShipping.Location = new System.Drawing.Point(14, 129);
            this.pBoxSupplierShipping.Name = "pBoxSupplierShipping";
            this.pBoxSupplierShipping.Size = new System.Drawing.Size(56, 19);
            this.pBoxSupplierShipping.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(14, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 11);
            this.label5.Text = "SupplierShipping";
            // 
            // TB_DefaultReceivesBin
            // 
            this.TB_DefaultReceivesBin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.TB_DefaultReceivesBin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TB_DefaultReceivesBin.Location = new System.Drawing.Point(22, 202);
            this.TB_DefaultReceivesBin.Multiline = true;
            this.TB_DefaultReceivesBin.Name = "TB_DefaultReceivesBin";
            this.TB_DefaultReceivesBin.Size = new System.Drawing.Size(49, 12);
            this.TB_DefaultReceivesBin.TabIndex = 211;
            // 
            // pBoxDefaulReceivesBin
            // 
            this.pBoxDefaulReceivesBin.Image = ((System.Drawing.Image)(resources.GetObject("pBoxDefaulReceivesBin.Image")));
            this.pBoxDefaulReceivesBin.Location = new System.Drawing.Point(16, 199);
            this.pBoxDefaulReceivesBin.Name = "pBoxDefaulReceivesBin";
            this.pBoxDefaulReceivesBin.Size = new System.Drawing.Size(56, 19);
            this.pBoxDefaulReceivesBin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // lb_DefaulReceivesBin
            // 
            this.lb_DefaulReceivesBin.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.lb_DefaulReceivesBin.Location = new System.Drawing.Point(14, 188);
            this.lb_DefaulReceivesBin.Name = "lb_DefaulReceivesBin";
            this.lb_DefaulReceivesBin.Size = new System.Drawing.Size(109, 11);
            this.lb_DefaulReceivesBin.Text = "DefaulReceivesBin";
            // 
            // TB_InternalMove
            // 
            this.TB_InternalMove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.TB_InternalMove.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TB_InternalMove.Location = new System.Drawing.Point(21, 167);
            this.TB_InternalMove.Multiline = true;
            this.TB_InternalMove.Name = "TB_InternalMove";
            this.TB_InternalMove.Size = new System.Drawing.Size(49, 12);
            this.TB_InternalMove.TabIndex = 216;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(15, 164);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(56, 19);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // lb_InternalMove
            // 
            this.lb_InternalMove.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.lb_InternalMove.Location = new System.Drawing.Point(14, 152);
            this.lb_InternalMove.Name = "lb_InternalMove";
            this.lb_InternalMove.Size = new System.Drawing.Size(109, 11);
            this.lb_InternalMove.Text = "InternalMove";
            // 
            // FrmWmsSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.ControlBox = false;
            this.Controls.Add(this.TB_InternalMove);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lb_InternalMove);
            this.Controls.Add(this.TB_DefaultReceivesBin);
            this.Controls.Add(this.pBoxDefaulReceivesBin);
            this.Controls.Add(this.lb_DefaulReceivesBin);
            this.Controls.Add(this.TB_SupplierShipping);
            this.Controls.Add(this.pBoxSupplierShipping);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TB_CustomerShipping);
            this.Controls.Add(this.pBoxCustomerShipping);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TB_SupplierReceives);
            this.Controls.Add(this.pBoxSupplierReceives);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TB_CustomerReceives);
            this.Controls.Add(this.pBoxCustomerReceives);
            this.Controls.Add(this.lb);
            this.Controls.Add(this.PBSoftKeyb);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.PBBtnBck);
            this.Controls.Add(this.PBMenuBar);
            this.Name = "FrmWmsSettings";
            this.Text = "WMS/Mobile - Ρυθμίσεις";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSettings_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PBMenuBar;
        private System.Windows.Forms.PictureBox PBBtnBck;
        private System.Windows.Forms.PictureBox BtnSave;
        private System.Windows.Forms.PictureBox PBSoftKeyb;
        private Microsoft.WindowsCE.Forms.InputPanel OnScreenKeyboard;
        private System.Windows.Forms.Label lb;
        private System.Windows.Forms.TextBox TB_CustomerReceives;
        private System.Windows.Forms.PictureBox pBoxCustomerReceives;
        private System.Windows.Forms.TextBox TB_SupplierReceives;
        private System.Windows.Forms.PictureBox pBoxSupplierReceives;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TB_CustomerShipping;
        private System.Windows.Forms.PictureBox pBoxCustomerShipping;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TB_SupplierShipping;
        private System.Windows.Forms.PictureBox pBoxSupplierShipping;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TB_DefaultReceivesBin;
        private System.Windows.Forms.PictureBox pBoxDefaulReceivesBin;
        private System.Windows.Forms.Label lb_DefaulReceivesBin;
        private System.Windows.Forms.TextBox TB_InternalMove;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lb_InternalMove;
    }
}