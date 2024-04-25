using System;
using System.Configuration;
using System.Windows.Forms;
using ServiceModelEx.ServiceBus;

namespace Client
{
    public partial class Form1 : Form
    {
        private MyContractClient proxy;

        public Form1()
        {
            InitializeComponent();
            string sbKeyName = ConfigurationManager.AppSettings["sb-key-name"];
            string sbKeyValue = ConfigurationManager.AppSettings["sb-key-value"];

            this.proxy = new MyContractClient();
            this.proxy.SetServiceBusCredentials(sbKeyName, sbKeyValue);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            proxy.MyMethod();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.proxy.Close();
        }
    }
}
