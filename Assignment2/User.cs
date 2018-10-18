using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class User
    {
        public string userName { get; set; }
        public string password { get; set; }
        public string permission { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }

        public User(string username, string pass, string per, string first, string last)
        {
            this.userName = username;
            this.password = pass;
            this.permission = per;
            this.firstName = first;
            this.lastName = last;
        }

        
    }
}
