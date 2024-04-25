using ServiceModelEx.ServiceBus;
using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Windows.Forms;
//using Microsoft.ServiceBus;
using System.Configuration;

namespace Host
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ServiceHost host = new ServiceBusHost(typeof(MyService));

            string sbKeyName = ConfigurationManager.AppSettings["sb-key-name"];
            string sbKeyValue = ConfigurationManager.AppSettings["sb-key-value"];

            host.SetServiceBusCredentialsWithSasPolicy(sbKeyName, sbKeyValue);
            host.Open();
            Application.Run(new Form1());

            host.Close();
        }
    }
}