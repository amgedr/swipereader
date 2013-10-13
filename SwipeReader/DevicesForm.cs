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
    public partial class DevicesForm : Form
    {
        public DevicesForm()
        {
            InitializeComponent();
        }

        private void devicesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {

        }

        private void DevicesForm_Load(object sender, EventArgs e)
        {
            devicesTextBox.Text = System.IO.File.ReadAllText(Application.StartupPath + "\\devices.dat");
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            System.IO.File.WriteAllText(Application.StartupPath + "\\devices.dat", devicesTextBox.Text);
        }
    }
}
