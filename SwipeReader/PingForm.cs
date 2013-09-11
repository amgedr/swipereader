using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SwipeReader
{
    public partial class PingForm : Form
    {
        private string _IpAddress;

        public PingForm(string ipAddress)
        {
            InitializeComponent();

            _IpAddress = ipAddress;
        }

        private void PingForm_Load(object sender, EventArgs e)
        {
            Application.DoEvents();

            if (Networking.Ping(_IpAddress))
                this.DialogResult = System.Windows.Forms.DialogResult.Yes;
            else
                this.DialogResult = System.Windows.Forms.DialogResult.No;
        }
    }
}
