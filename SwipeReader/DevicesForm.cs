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
            this.Validate();
            this.devicesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.swipeReaderDataSet);

        }

        private void DevicesForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'swipeReaderDataSet.Devices' table. You can move, or remove it, as needed.
            this.devicesTableAdapter.Fill(this.swipeReaderDataSet.Devices);

        }
    }
}
