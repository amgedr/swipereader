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
    public partial class UserSyncForm : Form
    {
        private AttendanceTable attendanceTable;
        private ConnectorForm connectorForm;
        private Dictionary<string, UserRecord> machineUsers;

        //to notify users if there are still conflicts/differences in card 
        //numbers between database and device when closing the form
        bool isConflictCleared = true;

        public UserSyncForm(AttendanceTable attTable, ConnectorForm conForm)
        {
            InitializeComponent();

            attendanceTable = attTable;
            attendanceTable.Connect();
            attendanceTable.ReadUsersList();

            connectorForm = conForm;

            machineUsers = new Dictionary<string, UserRecord>();

            if (connectorForm.cardReader.ReadAllUserID(1))
            {
                int _errorCode = 0;
                string _enrollNumber;				// User ID
                int _enrollMachineNumber = 0;		// Terminal that user enrolled at
                int _backupNumber = 0;				// Index of finger enrolled
                int _machinePrivilege = 0;			// Privileges of the user
                int _enable = 0;					// Determines if the user is enabled at the terminal
                int _value = 0;
                int _year = 0;
                int _month = 0;
                int _day = 0;
                int _hour = 0;
                int _minute = 0;
                int _dayOfWeek = 0;
                string _firmwareVersion = "";
                string _serialNumber = "";
                string _ipAddress = "";
                string _password = "";				// Password if used by the user
                string _name = "";					// User name stored in terminal
                string _privileges = "";
                bool _enabled = false;


                //TODO: disable device before syncing and enable when finished

                connectorForm.cardReader.ReadAllUserID(1);

                //loop through all the users in the device
                while (connectorForm.cardReader.SSR_GetAllUserInfo(1, out _enrollNumber, out _name,
                    out _password, out _machinePrivilege, out _enabled))
                {
                    //if the user is in the database add him to the dictionary
                    if (attendanceTable.Users.ContainsKey(_enrollNumber))
                    {
                        UserRecord user = new UserRecord();
                        user.user_id = _enrollNumber;
                        user.fullname = _name;
                        user.card_no = connectorForm.cardReader.get_CardNumber(0).ToString();
                        machineUsers.Add(_enrollNumber, user);  //add the users to list for comparing later

                        int priv = 0;
                        if (attendanceTable.Users[_enrollNumber].privilege == 5)
                            priv = 3;

                        //parameter 5: if user is admin in database set as admin in device too
                        //parameter 6: enable the user if he is active in the database
                        connectorForm.cardReader.SSR_SetUserInfo(1, _enrollNumber,
                            attendanceTable.Users[_enrollNumber].fullname, "", priv,
                            attendanceTable.Users[_enrollNumber].status);

                        //if users card number on the server and device dont match add to the grid
                        if (user.card_no != attendanceTable.Users[_enrollNumber].card_no)
                            usersDataGridView.Rows.Add(_enrollNumber, _name, "", user.card_no,
                                attendanceTable.Users[_enrollNumber].card_no);
                    }
                    else
                    {
                        //delete users on the machine that are not on the server
                        connectorForm.cardReader.SSR_DeleteEnrollDataExt(1, _enrollNumber, 12);
                    }
                }

                //loop through the users in the database
                foreach (KeyValuePair<string, UserRecord> devUser in attendanceTable.Users)
                {
                    //if user does not exist in the device
                    if (!machineUsers.ContainsKey(devUser.Value.user_id))
                    {
                        int priv = 0;

                        if (devUser.Value.privilege == 5)
                            priv = 3;

                        //add user to device
                        connectorForm.cardReader.SSR_SetUserInfo(1, devUser.Value.user_id,
                            devUser.Value.fullname, "", priv, devUser.Value.status);
                    }
                }

                HighlightConflicts();
            }
            else
            {
                MessageBox.Show("Could not read user data from device.", "SwipeReader",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UserSyncForm_Load(object sender, EventArgs e)
        {
            this.Text = connectorForm.IpAddress + " " + this.Text;
        }

        private void UserSyncForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isConflictCleared && this.DialogResult== System.Windows.Forms.DialogResult.OK)
            {
                MessageBox.Show("Some users' card numbers on this device don't match the ones on the server.",
                    "SwipeReader", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            attendanceTable.Disconnect();            
        }

        private void HighlightConflicts()
        {
            foreach (DataGridViewRow row in usersDataGridView.Rows)
            {
                if (row.Cells[3].Value.ToString() != row.Cells[4].Value.ToString())
                {
                    row.Cells[2].Style.BackColor = Color.Pink;
                    isConflictCleared = false;
                }
            }
        }

        private void usersDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = usersDataGridView.Rows[e.RowIndex];

            if (e.ColumnIndex == 3 || e.ColumnIndex == 4)
            {
                row.Cells[2].Value = row.Cells[e.ColumnIndex].Value;
                row.Cells[2].Style.BackColor = Color.White;

            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            isConflictCleared = true;

            //loop through the users on the grid, updating their card numbers
            foreach (DataGridViewRow row in usersDataGridView.Rows)
            {
                string cardNumber = row.Cells[2].Value.ToString();

                if (cardNumber != "")
                {
                    if (cardNumber == row.Cells[3].Value.ToString() && cardNumber != row.Cells[4].Value.ToString())
                    {
                        //TODO: set new card number in database
                        attendanceTable.SaveCardNumber(row.Cells[0].Value.ToString(), cardNumber);
                    }
                    else if (cardNumber != row.Cells[3].Value.ToString() && cardNumber == row.Cells[4].Value.ToString())
                    {
                        string name, password;
                        int privilege;
                        bool status;

                        //set new card number in device
                        connectorForm.cardReader.SSR_GetUserInfo(1, row.Cells[0].Value.ToString(), out name,
                            out password, out privilege, out status);

                        connectorForm.cardReader.set_CardNumber(0, Convert.ToInt32(cardNumber));
                        connectorForm.cardReader.SSR_SetUserInfo(1, row.Cells[0].Value.ToString(), name, password, privilege, status);
                    }
                }
                else
                    isConflictCleared = false;
            }
        }
    }
}
