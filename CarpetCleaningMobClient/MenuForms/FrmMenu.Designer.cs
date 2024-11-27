namespace CarpetCleaningClient
{
    partial class FrmMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenu));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.PBOXsettings = new System.Windows.Forms.PictureBox();
            this.PBOXput = new System.Windows.Forms.PictureBox();
            this.PBOXshippments = new System.Windows.Forms.PictureBox();
            this.PBOXreceives = new System.Windows.Forms.PictureBox();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.PBOX_Inventory = new System.Windows.Forms.PictureBox();
            this.SuspendLayout();
            // 
            // PBOXsettings
            // 
            this.PBOXsettings.Image = ((System.Drawing.Image)(resources.GetObject("PBOXsettings.Image")));
            this.PBOXsettings.Location = new System.Drawing.Point(8, 152);
            this.PBOXsettings.Name = "PBOXsettings";
            this.PBOXsettings.Size = new System.Drawing.Size(259, 33);
            this.PBOXsettings.Click += new System.EventHandler(this.PBOXsettings_Click);
            // 
            // PBOXput
            // 
            this.PBOXput.Image = ((System.Drawing.Image)(resources.GetObject("PBOXput.Image")));
            this.PBOXput.Location = new System.Drawing.Point(8, 112);
            this.PBOXput.Name = "PBOXput";
            this.PBOXput.Size = new System.Drawing.Size(259, 33);
            this.PBOXput.Click += new System.EventHandler(this.PBOXput_Click);
            // 
            // PBOXshippments
            // 
            this.PBOXshippments.Image = ((System.Drawing.Image)(resources.GetObject("PBOXshippments.Image")));
            this.PBOXshippments.Location = new System.Drawing.Point(8, 72);
            this.PBOXshippments.Name = "PBOXshippments";
            this.PBOXshippments.Size = new System.Drawing.Size(259, 33);
            this.PBOXshippments.Click += new System.EventHandler(this.PBOXshippments_Click);
            // 
            // PBOXreceives
            // 
            this.PBOXreceives.Image = ((System.Drawing.Image)(resources.GetObject("PBOXreceives.Image")));
            this.PBOXreceives.Location = new System.Drawing.Point(8, 32);
            this.PBOXreceives.Name = "PBOXreceives";
            this.PBOXreceives.Size = new System.Drawing.Size(259, 33);
            this.PBOXreceives.Click += new System.EventHandler(this.PBOXreceives_Click);
            // 
            // PictureBox1
            // 
            this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
            this.PictureBox1.Location = new System.Drawing.Point(8, 283);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(234, 23);
            // 
            // PBOX_Inventory
            // 
            this.PBOX_Inventory.Image = ((System.Drawing.Image)(resources.GetObject("PBOX_Inventory.Image")));
            this.PBOX_Inventory.Location = new System.Drawing.Point(6, 192);
            this.PBOX_Inventory.Name = "PBOX_Inventory";
            this.PBOX_Inventory.Size = new System.Drawing.Size(259, 33);
            this.PBOX_Inventory.Click += new System.EventHandler(this.PBOX_Inventory_Click);
            // 
            // FrmMenu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(480, 640);
            this.ControlBox = false;
            this.Controls.Add(this.PBOX_Inventory);
            this.Controls.Add(this.PictureBox1);
            this.Controls.Add(this.PBOXsettings);
            this.Controls.Add(this.PBOXput);
            this.Controls.Add(this.PBOXshippments);
            this.Controls.Add(this.PBOXreceives);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMenu";
            this.Text = "WMSClient - ΗΟΜΕ";
            this.Load += new System.EventHandler(this.FrmMenu_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmMenu_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PBOXreceives;
        private System.Windows.Forms.PictureBox PBOXshippments;
        private System.Windows.Forms.PictureBox PBOXput;
        private System.Windows.Forms.PictureBox PBOXsettings;
        internal System.Windows.Forms.PictureBox PictureBox1;
        private System.Windows.Forms.PictureBox PBOX_Inventory;

    }
}