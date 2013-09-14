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

        public AttendanceTable(bool isLaborMachine, int location)
        {
            forLabors = isLaborMachine;
            locationId = location;

            //local test server
            connection = new MySqlConnection(
                "server=localhost; database=seidco_attendance; uid=root; password=;");

            //if (forLabors)
            //    connection = new MySqlConnection(Properties.Settings.Default.LaborsDB);
            //else
            //    connection = new MySqlConnection(Properties.Settings.Default.EmployeesDB);
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
