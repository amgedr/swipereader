using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;


namespace SwipeReader.Classes
{
    class AttendanceTable
    {
        private MySqlConnection connection;
        private bool forLabors;

        public AttendanceTable(bool isLaborMachine)
        {
            forLabors = isLaborMachine;

            if (forLabors)
                connection = new MySqlConnection(Properties.Settings.Default.LaborsDB);
            else
                connection = new MySqlConnection(Properties.Settings.Default.EmployeesDB);
        }

        public void SaveAttendanceRecord(string userId, string timeStamp)
        {
            //user_id, time_stamp, attendance_type, location_id, authentication_type_id, whereabout_id

            
        }
    }
}
