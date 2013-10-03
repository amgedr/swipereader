using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwipeReader
{
    public class UserRecord
    {
        public string user_id { get; set; }
        public string employee_id { get; set; }
        public string fullname { get; set; }
        public string card_no { get; set; }
        public bool status { get; set; }
        public int privilege { get; set; }
    }
}
