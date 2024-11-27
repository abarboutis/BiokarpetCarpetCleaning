namespace ReportGenerator
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_connectinfo = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.pb_wait = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_wait)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(432, 88);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(53, 21);
            this.button2.TabIndex = 2;
            this.button2.Text = "Browse";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.AllowDrop = true;
            this.textBox1.Location = new System.Drawing.Point(335, 62);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(150, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label2.Location = new System.Drawing.Point(331, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Παρακαλώ επιλέξτε προορισμό";
            this.label2.Visible = false;
            // 
            // lb_connectinfo
            // 
            this.lb_connectinfo.AutoSize = true;
            this.lb_connectinfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lb_connectinfo.ForeColor = System.Drawing.Color.Red;
            this.lb_connectinfo.Location = new System.Drawing.Point(245, 10);
            this.lb_connectinfo.Name = "lb_connectinfo";
            this.lb_connectinfo.Size = new System.Drawing.Size(0, 13);
            this.lb_connectinfo.TabIndex = 1;
            this.lb_connectinfo.Visible = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(491, 88);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(72, 21);
            this.button3.TabIndex = 5;
            this.button3.Text = "Check DB";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            // 
            // pb_wait
            // 
            this.pb_wait.Image = ((System.Drawing.Image)(resources.GetObject("pb_wait.Image")));
            this.pb_wait.Location = new System.Drawing.Point(1, -3);
            this.pb_wait.Name = "pb_wait";
            this.pb_wait.Size = new System.Drawing.Size(191, 68);
            this.pb_wait.TabIndex = 6;
            this.pb_wait.TabStop = false;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(192, 58);
            this.Controls.Add(this.pb_wait);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lb_connectinfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Σύνδεση...";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_wait)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lb_connectinfo;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox pb_wait;
    }
}

