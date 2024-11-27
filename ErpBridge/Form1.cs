        using System;
        using System.ComponentModel;
        using System.Data;
        using System.Text;
        using System.Windows.Forms;

        namespace ReportGenerator
        {

            public partial class Form1 : Form
            {
                
                StoreTrans mystoretrans = new StoreTrans();
                CustomerTasks customertasks = new CustomerTasks();
                int connected;
               
                
                public Form1()
                {
                    InitializeComponent();
                    LoadSettings();
                }


                private void LoadSettings() 
                {
                    AppSettings mysettings = new AppSettings();
                    mysettings.LoadSettings();
                }
                private void DoJob() 
                {
                    if (connected != 1)
                    {
                        MessageBox.Show("Παρακαλώ συνδεθείτε ");
                        return;
                    }

                    customertasks.InsertCustomerFromERP();
                     mystoretrans.CancelErpSend();

                     
 
                   // mystoretrans.SendTransactionsToERP();

                    if (mystoretrans.GetStoretransDetails() > 0)
                    {
                        mystoretrans.cleartempDB();
                        Application.Exit();
                    }
                    else
                    {
                    }
                
                }

                private void Form1_Load(object sender, EventArgs e)
                {
                    testcon();
                    DoJob();
                    Application.Exit();
                }


                public void testcon()
                {

                    if (GlobVariables.mydbtrans.CheckSourceDBcon() > 0)
                    {
                        lb_connectinfo.Text = "Connection OK ! ";
                        lb_connectinfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
                        connected = 1;
                    }
                    else
                    {
                        lb_connectinfo.Text = "Connection Failed ! ";
                        lb_connectinfo.ForeColor = System.Drawing.Color.Red;
                        connected = 0;
                    }
                
                }

                private void button1_Click(object sender, EventArgs e)
                {
                    StoreTrans mytrans = new StoreTrans();
                    mytrans.GetStoretransDetails();
                }

        }




                }
