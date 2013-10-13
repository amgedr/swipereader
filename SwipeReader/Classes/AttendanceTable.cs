using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace SwipeReader
{
    public class AttendanceTable
    {
        private MySqlConnection connection;
        private bool forLabors;
        private int locationId;
        
        public Dictionary<string, UserRecord> Users { get; private set; }

        public AttendanceTable(bool isLaborMachine, int location)
        {
            forLabors = isLaborMachine;
            locationId = location;
            Users = new Dictionary<string, UserRecord>();

            //local test server
            connection = new MySqlConnection(
                "server=localhost; database=seidco_attendance; uid=root; password=;");

            if (forLabors)
                connection = new MySqlConnection(Properties.Settings.Default.LaborsDB);
            else
                connection = new MySqlConnection(Properties.Settings.Default.EmployeesDB);
        }

        /// <summary>
        /// Save a single attendance record.
        /// </summary>
        public void SaveAttendanceRecord(string userId, string timeStamp, int attendanceType, int authenticationType)
        {
            try
            {
                //labor machines use employee_id instead of user_id. Because its easier for
                //HR to locate them in their excel sheets and hardcopies
                if (this.forLabors)
                {
                    MySqlCommand laborsCommand = new MySqlCommand(
                        "SELECT `user_id` FROM `users` WHERE `employee_id`='" + userId + "'",
                        connection);

                    userId = laborsCommand.ExecuteScalar().ToString();
                }

                //user_id, time_stamp, attendance_type, location_id, authentication_type_id, whereabout_id
                string sql = String.Format(
                    "INSERT IGNORE INTO `attendance_log` (`user_id`, `time_stamp`, `attendance_type`, " +
                    "`location_id` ,`authentication_type_id` ,`whereabout_id`) " +
                    "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', NULL);",
                    userId, timeStamp, attendanceType, locationId, authenticationType);

                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Change the card number field of a user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="cardNumber"></param>
        public void SaveCardNumber(string userId, string cardNumber)
        {
            try
            {
                //labor machines use employee_id instead of user_id. Because its easier for
                //HR to locate them in their excel sheets and hardcopies
                if (this.forLabors)
                {
                    MySqlCommand laborsCommand = new MySqlCommand(
                        "SELECT `user_id` FROM `users` WHERE `employee_id`='" + userId + "'",
                        connection);

                    userId = laborsCommand.ExecuteScalar().ToString();
                }

                //user_id, time_stamp, attendance_type, location_id, authentication_type_id, whereabout_id
                string sql = String.Format(
                    "UPDATE `users` SET `card_number`='{0}' WHERE `user_id`={1};",
                    cardNumber, userId);

                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ReadUsersList()
        {
            MySqlCommand usersTable = new MySqlCommand(
                "SELECT `user_id` , `employee_id`, `fullname`, `card_number`, `access_level`, `active` FROM `users`", 
                connection);

            if (Users.Count > 0)
                Users.Clear();

            using (MySqlDataReader usersReader = usersTable.ExecuteReader())
            {
                while (usersReader.Read())
                {
                    UserRecord r = new UserRecord();

                    r.employee_id = usersReader["employee_id"].ToString();
                    r.fullname = usersReader["fullname"].ToString();
                    r.card_no = usersReader["card_number"].ToString();
                    r.status = (bool)usersReader["active"];
                    r.privilege = Convert.ToInt32(usersReader["access_level"].ToString());

                    if (this.forLabors)
                    {
                        r.user_id = usersReader["employee_id"].ToString();

                        if(r.employee_id != "")
                            Users.Add(r.employee_id, r);
                    }
                    else
                    {
                        r.user_id = usersReader["user_id"].ToString();
                        Users.Add(r.user_id, r);
                    }                    
                }
            }
                        
            usersTable.Dispose();
        }

        public void Connect()
        {
            connection.Open();
        }

        public void Disconnect()
        {
            connection.Close();
        }
    }
}
