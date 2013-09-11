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
    public partial class ConnectorForm : Form
    {
        private string _ipAddress;
        public string IpAddress { get { return _ipAddress; } }

        private MainForm _owner;

        private int _lastError = 0;
        public int LastError { get { return _lastError; } }

        public ConnectorForm(string ipAddress, MainForm owner)
        {
            InitializeComponent();

            _ipAddress = ipAddress;
            _owner = owner;
            Connect();
        }

        public bool Connect()
        {
            if (cardReader.Connect_Net(_ipAddress, 4370))
            {
                cardReader.MachineNumber = 1;
                cardReader.RegEvent(1, 32767);
                return true;
            }
            else
            {
                cardReader.GetLastError(ref _lastError);
                return false;
            }
        }

        public int RecordCount()
        {
            int recordCount = 0;
            cardReader.GetDeviceStatus(0, 6, ref recordCount);
            return recordCount;
        }

        public string SdkVersion()
        {
            string retVal;
            cardReader.GetSysOption(1, "~ZKFPVersion", out retVal);
            return retVal;
        }

        public void Disconnect()
        {
            cardReader.Disconnect();
        }

        /// <summary>
        /// Occurs when a user enters a new attendance record using fingerprint or card
        /// </summary>
        private void cardReader_OnAttTransactionEx(object sender, Axzkemkeeper._IZKEMEvents_OnAttTransactionExEvent e)
        {
            //user_id = e.enrollNumber
            //time_stamp
            //attendance_type = e.attState
            //location_id = 
            //authentication_type_id = e.verifyMethod -> Verification mode. 0: password, 1: fingerprint, 2: card
            //whereabout_id

            //display the transaction in the main form
            _owner.DisplayTransaction(string.Format("{0}: Transaction by user {1}. AttState: {2}",
                _ipAddress, e.enrollNumber, e.attState));

            //// Write the string to a file.
            //System.IO.StreamWriter file = new System.IO.StreamWriter(Application.StartupPath + "\\test.txt", true);
            //file.WriteLine("{0}:{1}:{2} {3}/{4}/{5} - IP: {11}, EnrollNumber: {6}, VerifyMethod: {7}, WorkCode: {8}, IsInValid: {9}, AttState: {10}",
            //    e.hour, e.minute, e.second, e.day, e.month, e.year, e.enrollNumber, e.verifyMethod, e.workCode, e.isInValid, e.attState, _ipAddress);
            //file.Close();
        }

        private void cardReader_OnAttTransaction(object sender, Axzkemkeeper._IZKEMEvents_OnAttTransactionEvent e)
        {
            //MessageBox.Show("OnAttTransaction");
        }

        private void cardReader_OnConnected(object sender, EventArgs e)
        {

        }

        private void cardReader_OnHIDNum(object sender, Axzkemkeeper._IZKEMEvents_OnHIDNumEvent e)
        {
            //MessageBox.Show("OnHIDNum: Card: " + e.cardNumber.ToString());
        }

        private void cardReader_OnKeyPress(object sender, Axzkemkeeper._IZKEMEvents_OnKeyPressEvent e)
        {
            //MessageBox.Show("OnKeyPress");
        }

        private void cardReader_OnVerify(object sender, Axzkemkeeper._IZKEMEvents_OnVerifyEvent e)
        {
            //MessageBox.Show("OnVerify");
        }

        private void cardReader_OnFinger(object sender, EventArgs e)
        {
            //MessageBox.Show("OnFinger");
        }

        private void cardReader_OnEMData(object sender, Axzkemkeeper._IZKEMEvents_OnEMDataEvent e)
        {
            //MessageBox.Show("OnEMData");
        }

        private void cardReader_OnEmptyCard(object sender, Axzkemkeeper._IZKEMEvents_OnEmptyCardEvent e)
        {
            //MessageBox.Show("OnEmptyCard");
        }

        private void cardReader_OnDisConnected(object sender, EventArgs e)
        {
            //occurs when disconnecting from the device
            //MessageBox.Show("OnDisConnected");
        }
    }
}
