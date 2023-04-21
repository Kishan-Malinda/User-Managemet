using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Models.Models
{
    public class User
    {
        public int userID { get; set; }
        public string userName { get; set; }
        public DateTime DOB { get; set; }
        public string city { get; set; }
        public string gender { get; set; }
        public string password { get; set; }
        public bool active { get; set; }
    }
}
