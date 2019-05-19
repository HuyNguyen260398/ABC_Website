using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABC_Website.Models
{
    public class Admin
    {
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}