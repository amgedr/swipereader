using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

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
        /// Get all the attendance records in the device and insert them in the database.
        /// </summary>
        public bool DownloadAttendance()
        {
            int _machineNumber = 1;
            int _verifyMode = 0;
            int _inOutMode = 0;
            int _year = 0;
            int _month = 0;
            int _day = 0;
            int _hour = 0;
            int _minute = 0;
            int _second = 0;
            int _workcode = 0;
            string _enrollNumber = "";

            if (cardReader.ReadAllGLogData(_machineNumber))
            {
                _owner.DisplayTransaction(_ipAddress + ": Downloading attendance records.");
                _owner.tablesList[_ipAddress].Connect();

                while (cardReader.SSR_GetGeneralLogData(_machineNumber, out _enrollNumber, 
                    out _verifyMode, out _inOutMode, out _year, out _month, out _day, out _hour, 
                    out _minute, out _second, ref _workcode))
                {
                    String attendance_time = String.Format("{0}-{1}-{2} {3}:{4}:{5}",
                        _year.ToString(), _month.ToString(), _day.ToString(), _hour.ToString(),
                        _minute.ToString(), _second.ToString());

                    _owner.tablesList[_ipAddress].SaveAttendanceRecord(
                        _enrollNumber, attendance_time, _inOutMode, _verifyMode);
                }

                cardReader.ClearGLog(_machineNumber);

                _owner.tablesList[_ipAddress].Disconnect();
                _owner.DisplayTransaction(_ipAddress + ": Downloading complete.");
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Occurs when a user enters a new attendance record using fingerprint or card
        /// </summary>
        private void cardReader_OnAttTransactionEx(object sender, Axzkemkeeper._IZKEMEvents_OnAttTransactionExEvent e)
        {
            //display the transaction in the main form
            _owner.DisplayTransaction(string.Format("{0}: Transaction by user {1}. AttState: {2}",
                _ipAddress, e.enrollNumber, e.attState));

            //save the transaction in attendance table
            var time = String.Format("{0}-{1}-{2} {3}:{4}:{5}",
                e.year, e.month, e.day, e.hour, e.minute, e.second);

            _owner.tablesList[_ipAddress].Connect();
            _owner.tablesList[_ipAddress].SaveAttendanceRecord(
                e.enrollNumber, time, e.attState, e.verifyMethod);
            _owner.tablesList[_ipAddress].Disconnect();
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
