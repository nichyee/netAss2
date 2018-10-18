using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class User
    {
        public string userName { get; set; }
        public string password { get; set; }
        public string permission { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string dateOfBirth { get; set; }

        public User(string username, string pass, string per, string first, string last, string dob)
        {
            this.userName = username;
            this.password = pass;
            this.permission = per;
            this.firstName = first;
            this.lastName = last;
            this.dateOfBirth = dob;
        }

        public override string ToString()
        {
            return (userName + "," + password + "," + permission + "," + firstName + "," + lastName + "," + dateOfBirth);
        }
    }
}
