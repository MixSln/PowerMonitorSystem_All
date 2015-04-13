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
        private Reciever _recver;
        public MainFrame()
        {
            InitializeComponent();
            _recver = new Reciever();
        }

        private void btn_changeskin_Click(object sender, EventArgs e)
        {
            
        }

        private void MainFrame_Shown(object sender, EventArgs e)
        {
            this.MySkin.SkinFile = "Skin\\DeepCyan.ssk";
        }
    }
}
