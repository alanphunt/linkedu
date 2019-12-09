using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkedU
{
    public class University
    {
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string schoolName { get; set; }
        public string address { get; set; }
        public string bio { get; set; }
        public char showcase { get; set; }

        public University()
        {

        }

        public University(string username, string password, string email, string schoolName, string address, string bio, char showcase)
        {
            this.username = username;
            this.password = password;
            this.email = email;
            this.schoolName = schoolName;
            this.address = address;
            this.bio = bio;
            this.showcase = showcase;
        }

        public static University Current
        {
            get
            {
                University uni = (University)HttpContext.Current.Session["University"];
                if (uni == null)
                {
                    uni = new University();
                    HttpContext.Current.Session["University"] = uni;
                }
                return uni;
            }
        }
    }
}