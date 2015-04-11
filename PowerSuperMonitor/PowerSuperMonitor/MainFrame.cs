using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace PowerSuperMonitor
{
    public partial class MainFrame : Form
    {
        public MainFrame()
        {
            InitializeComponent();
        }

        private void btn_test_Click(object sender, EventArgs e)
        {
            var proxy = new ChannelFactory<PowerServer.ServerAil.IPowerService>("PowerService").CreateChannel();
            MessageBox.Show(proxy.checkUser("user","passwd").ToString());
        }
    }
}
