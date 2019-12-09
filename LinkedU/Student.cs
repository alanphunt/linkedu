using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkedU
{
    public class Student
    {
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phone { get; set; }
        public string bio { get; set; }
        public string highSchool { get; set; }
        public string address { get; set; }
        public char subscribed { get; set; }
        public char SMS{ get; set; }
        public string gradYear { get; set; }
        public string GPA { get; set; }

        public Student()
        {

        }

        public Student(string username, string password, string email, string firstName, string lastName, string phone, string bio, string highSchool, string address, char subscribed, char sMS, string gradYear, string GPA)
        {
            this.username = username;
            this.password = password;
            this.email = email;
            this.firstName = firstName;
            this.lastName = lastName;
            this.phone = phone;
            this.bio = bio;
            this.highSchool = highSchool;
            this.address = address;
            this.subscribed = subscribed;
            this.SMS = sMS;
            this.gradYear = gradYear;
            this.GPA = GPA;
        }

        public static Student Current
        {
            get
            {
                Student stu = (Student)HttpContext.Current.Session["Student"];
                if(stu == null)
                {
                    stu = new Student();
                    HttpContext.Current.Session["Student"] = stu;
                }
                return stu;
            }
        }

    }
}