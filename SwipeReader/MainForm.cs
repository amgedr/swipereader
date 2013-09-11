using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Axzkemkeeper;
using System.Diagnostics;
using System.Data.SqlClient;

namespace SwipeReader
{
    public partial class MainForm : Form
    {
        //the state of the window before minimizing it
        private FormWindowState currentWindowState;

        //the transactions read from the device(s)
        private Queue<string> transactionsList = new Queue<string>(5);

        //the list of ConnectorForm objects. 1 per device
        private Dictionary<string, ConnectorForm> devicesList = new Dictionary<string, ConnectorForm>();

        //when should the synchronization start
        private int syncHour = Properties.Settings.Default.SyncHour;
        private int syncMinute = Properties.Settings.Default.SyncMinute;

        public MainForm()
        {
            InitializeComponent();
            
            DisplayTransaction("Attendance synchronization at: " + syncHour.ToString() + 
                ":" + syncMinute.ToString());
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            GetDevicesList();            
        }

        private void GetDevicesList()
        {
            SwipeReaderDataSetTableAdapters.DevicesTableAdapter adapter =
                new SwipeReaderDataSetTableAdapters.DevicesTableAdapter();
            var devicesTable = new SwipeReaderDataSet.DevicesDataTable();

            adapter.Fill(devicesTable);
            devicesDataGridView.Rows.Clear();

            //Fill devicesGridView manually
            foreach (SwipeReaderDataSet.DevicesRow dev in devicesTable.Rows)
            {
                devicesDataGridView.Rows.Add(dev.IpAddress, dev.IsLaborDevice, "");
            }

            //deselect the first row
            devicesDataGridView.Rows[0].Selected = false;
        }

        public void DisplayTransaction(string transaction)
        {
            transactionsList.Enqueue("[" + DateTime.Now.ToShortDateString() + " - " +
                DateTime.Now.ToShortTimeString() + "] " + transaction);

            //display the last 15 transaction only
            if (transactionsList.Count > 15)
                transactionsList.Dequeue();

            statusTextBox.Lines = transactionsList.ToArray<string>();
        }

        private void notifyIcon_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            this.WindowState = currentWindowState;
            notifyIcon.Visible = false;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
#if !DEBUG
            var retval = MessageBox.Show("Are your sure you want to exit the application?",
                "SwipeReader", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (retval == System.Windows.Forms.DialogResult.No)
                e.Cancel = true;
#endif
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                notifyIcon.Visible = true;
                this.Visible = false;
            }
            else
                currentWindowState = this.WindowState;
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            if (connectButton.Text == "Connect")
            {
                connectButton.Enabled = false;

                //loop through the datagrid's rows
                foreach (DataGridViewRow row in devicesDataGridView.Rows)
                {
                    string ip = row.Cells[0].Value.ToString();

                    ConnectorForm connector = new ConnectorForm(ip, this);

                    if (connector.Connect())
                    {
                        row.Cells[2].Value = "Connected";
                        DisplayTransaction("Connected to " + ip);
                        devicesList.Add(ip, connector);
                    }
                    else
                    {
                        row.Cells[2].Value = "Error";
                        DisplayTransaction("Could not connect to " + ip + ": " +
                            connector.LastError.ToString());
                    }
                }

                connectButton.Enabled = true;
                connectButton.Text = "Disconnect";
            }
            else
            {
                connectButton.Enabled = false;

                foreach (var connector in devicesList)
                {
                    connector.Value.Disconnect();
                    DisplayTransaction("Disconnected from " + connector.Value.IpAddress);
                }

                devicesList.Clear();

                connectButton.Enabled = true;
                connectButton.Text = "Connect";
            }
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            var settingsForm = new SettingsForm();
            if (settingsForm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                syncHour = settingsForm.Hour;
                syncMinute = settingsForm.Minutes;

                Properties.Settings.Default.SyncHour = syncHour;
                Properties.Settings.Default.SyncMinute = syncMinute;
                Properties.Settings.Default.Save();

                DisplayTransaction("Attendance synchronization at: " + syncHour.ToString() +
                    ":" + syncMinute.ToString());
            }            
        }

        private void deviceButton_Click(object sender, EventArgs e)
        {
            DevicesForm devicesForm = new DevicesForm();
            devicesForm.ShowDialog(this);
            GetDevicesList();
        }

        private void syncButton_Click(object sender, EventArgs e)
        {

        }

        private void recordCountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow d in devicesDataGridView.SelectedRows)
            {
                string ip = d.Cells[0].Value.ToString();

                if (devicesList.ContainsKey(ip))
                    DisplayTransaction(ip + " contains " + devicesList[ip].RecordCount().ToString() + " records");
                else
                    DisplayTransaction(ip + " is not connected!");
            }
        }

        private void sDKVersionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow d in devicesDataGridView.SelectedRows)
            {
                string ip = d.Cells[0].Value.ToString();

                if (devicesList.ContainsKey(ip))
                    DisplayTransaction(ip + " is using SDK version " + devicesList[ip].SdkVersion().ToString());
                else
                    DisplayTransaction(ip + " is not connected!");
            }
        }

        private void dataSyncTimer_Tick(object sender, EventArgs e)
        {

        }
    }
}
