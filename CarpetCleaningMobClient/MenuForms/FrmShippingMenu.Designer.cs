namespace CarpetCleaningClient
{
    partial class FrmShippingMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmShippingMenu));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.PboxShippingSupplier = new System.Windows.Forms.PictureBox();
            this.PboxShippingCustomer = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.SuspendLayout();
            // 
            // PboxShippingSupplier
            // 
            this.PboxShippingSupplier.Image = ((System.Drawing.Image)(resources.GetObject("PboxShippingSupplier.Image")));
            this.PboxShippingSupplier.Location = new System.Drawing.Point(8, 41);
            this.PboxShippingSupplier.Name = "PboxShippingSupplier";
            this.PboxShippingSupplier.Size = new System.Drawing.Size(259, 26);
            this.PboxShippingSupplier.Click += new System.EventHandler(this.PboxShippingCustomer_Click);
            // 
            // PboxShippingCustomer
            // 
            this.PboxShippingCustomer.Image = ((System.Drawing.Image)(resources.GetObject("PboxShippingCustomer.Image")));
            this.PboxShippingCustomer.Location = new System.Drawing.Point(8, 76);
            this.PboxShippingCustomer.Name = "PboxShippingCustomer";
            this.PboxShippingCustomer.Size = new System.Drawing.Size(259, 25);
            this.PboxShippingCustomer.Click += new System.EventHandler(this.PboxShippingSupplier_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(8, 270);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(54, 50);
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // FrmShippingMenu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(480, 640);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.PboxShippingCustomer);
            this.Controls.Add(this.PboxShippingSupplier);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmShippingMenu";
            this.Text = "ΑΠΟΣΤΟΛΕΣ";
            this.Load += new System.EventHandler(this.FrmMenu_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmMenu_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PboxShippingSupplier;
        private System.Windows.Forms.PictureBox PboxShippingCustomer;
        private System.Windows.Forms.PictureBox pictureBox1;

    }
}