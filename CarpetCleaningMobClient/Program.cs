using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace CarpetCleaningClient
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main()
        {

            //constructor set app default settings to ApplicationSettings static object
            AppSettings appsettings = new AppSettings();

            Application.Run(new FrmMenu());
        }
    }
}