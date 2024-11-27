namespace CarpetCleaningClient
{
    partial class FrmReceivesMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReceivesMenu));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.PBOXreceivesCustomer = new System.Windows.Forms.PictureBox();
            this.PboxReceivesSupplier = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.SuspendLayout();
            // 
            // PBOXreceivesCustomer
            // 
            this.PBOXreceivesCustomer.Image = ((System.Drawing.Image)(resources.GetObject("PBOXreceivesCustomer.Image")));
            this.PBOXreceivesCustomer.Location = new System.Drawing.Point(8, 41);
            this.PBOXreceivesCustomer.Name = "PBOXreceivesCustomer";
            this.PBOXreceivesCustomer.Size = new System.Drawing.Size(259, 26);
            this.PBOXreceivesCustomer.Click += new System.EventHandler(this.PBOXreceivesCustomer_Click);
            // 
            // PboxReceivesSupplier
            // 
            this.PboxReceivesSupplier.Image = ((System.Drawing.Image)(resources.GetObject("PboxReceivesSupplier.Image")));
            this.PboxReceivesSupplier.Location = new System.Drawing.Point(8, 76);
            this.PboxReceivesSupplier.Name = "PboxReceivesSupplier";
            this.PboxReceivesSupplier.Size = new System.Drawing.Size(259, 25);
            this.PboxReceivesSupplier.Click += new System.EventHandler(this.PboxReceivesSupplier_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(8, 270);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(54, 50);
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // FrmReceivesMenu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(480, 640);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.PboxReceivesSupplier);
            this.Controls.Add(this.PBOXreceivesCustomer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmReceivesMenu";
            this.Text = "ΠΑΡΑΛΑΒΕΣ";
            this.Load += new System.EventHandler(this.FrmMenu_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmMenu_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PBOXreceivesCustomer;
        private System.Windows.Forms.PictureBox PboxReceivesSupplier;
        private System.Windows.Forms.PictureBox pictureBox1;

    }
}