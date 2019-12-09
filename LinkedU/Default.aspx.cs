using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Reflection;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LinkedU
{
    public partial class Default : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
                MultiView1.SetActiveView(View1);

            if (Student.Current.username == null && University.Current.username != null)
            {
                MultiView1.SetActiveView(View11);
                UNLabel.Text = University.Current.username;
                HyperLink1.NavigateUrl = "UniProfile.aspx";
                HyperLink2.NavigateUrl = "UniProfile.aspx";
            }
            else if (University.Current.username == null && Student.Current.username != null)
            {
                MultiView1.SetActiveView(View11);
                UNLabel.Text = Student.Current.username;
                HyperLink1.NavigateUrl = "StuProfile.aspx";
                HyperLink2.NavigateUrl = "StuProfile.aspx";
            }   
            else if (University.Current.username == null && Student.Current.username == null)
                HyperLink1.NavigateUrl = "#";

        }

        protected void Logout(object sender, EventArgs e)
        {
            if (Student.Current.username != null || University.Current.username != null)
            {
                Student.Current.username = null;
                Student.Current.password = null;
                Student.Current.email = null;
                Student.Current.firstName = null;
                Student.Current.lastName = null;
                Student.Current.phone = null;
                Student.Current.bio = null;
                Student.Current.highSchool = null;
                Student.Current.address = null;
                Student.Current.gradYear = null;
                Student.Current.GPA = null;
                Student.Current.subscribed = ' ';
                Student.Current.SMS = ' ';
                University.Current.username =null;
                University.Current.password = null;
                University.Current.email =null;
                University.Current.schoolName = null;
                University.Current.address = null;
                University.Current.bio = null;
                University.Current.showcase = ' ';
            }
            MultiView1.SetActiveView(View1);

        }

        protected void ViewOne(object sender, EventArgs e)
        {
            MultiView1.SetActiveView(View1);
        }

        protected void SetStudentView(object sender, EventArgs e)
        {
            MultiView1.SetActiveView(View2);
        }
        protected void SetUniversityView(object sender, EventArgs e)
        {
            MultiView1.SetActiveView(View3);
        }

        protected void StuLoginView(object sender, EventArgs e)
        {
            MultiView1.SetActiveView(View4);
        }
        protected void UniLoginView(object sender, EventArgs e)
        {
            MultiView1.SetActiveView(View10);
        }

        protected void StudentRegister(object sender, EventArgs e)
        {
            MultiView1.SetActiveView(View5);
        }

        protected void StudentRegister2(object sender, EventArgs e)
        {
            MultiView1.SetActiveView(View8);
        }

        protected void StudentRegister3(object sender, EventArgs e)
        {
            MultiView1.SetActiveView(View9);
        }

        protected void UniRegister(object sender, EventArgs e)
        {
            MultiView1.SetActiveView(View6);
        }

        protected void UniRegister2(object sender, EventArgs e)
        {
            MultiView1.SetActiveView(View7);
        }

        protected void ForgotPWView(object sender, EventArgs e)
        {
            MultiView1.SetActiveView(View12);
        }

        protected void StudentProcessing(object sender, EventArgs e)
        {
            char subbed;
            char sms;

            if (SMS.Checked)
            {
                sms = 'y';
                ServiceReference1.TextSenderClient client = new ServiceReference1.TextSenderClient();
                client.sendSMS(DropDownList1.SelectedValue, stuNumber.Text, "Thank you for joining Linked U.");
                String[] supportedCarriers = client.getCarriers();
                for (int i = 0; i < supportedCarriers.Length; i++)
                {
                    Response.Write("Carrier #" + (i + 1) + " = " + supportedCarriers[i] + "<br/>");
                }

            }
            else
                sms = 'n';

            if (CheckBox2.Checked)
                subbed = 'y';
            else
                subbed = 'n';

            DatabaseProcessing db = new DatabaseProcessing();

            db.NewStudent(stuUsername.Text, stuPassword.Text, stuEmail.Text, stuFirstName.Text, stuLastName.Text, stuNumber.Text, stuAddress.Text, stuBio.Text, stuSchool.Text, stuGradYear.Text, stuGPA.Text, subbed, sms);

            Response.Redirect("StuProfile.aspx");
        }

        protected void UniversityProcessing(object sender, EventArgs e)
        {
            char showcase;

            if (upgrade.Checked)
                showcase = 'y';
            else
                showcase = 'n';

            DatabaseProcessing db = new DatabaseProcessing();

            db.NewUniversity(uniUser.Text, uniPassword.Text, uniEmail.Text, uniName.Text, uniAddress.Text, uniBio.Text, showcase);

            Response.Redirect("UniProfile.aspx");
        }

        protected void LoginStu(object sender, EventArgs e)
        {
            DatabaseProcessing db = new DatabaseProcessing();
            if (db.StuLogin(usernameStu.Text, passwordStu.Text)) {
                if ((usernameStu.Text.Equals("admin") && passwordStu.Text.Equals("admin")))
                {
                    Response.Redirect("Admin.aspx");
                }else
                    Response.Redirect("StuProfile.aspx");
            }
            else
                invalidStuCreds.Text = "Invalid credentials.";
        }

        protected void LoginUni(object sender, EventArgs e)
        {
            DatabaseProcessing db = new DatabaseProcessing();
            if (db.UniLogin(usernameUni.Text, passwordUni.Text))
            {
                
                    if ((usernameUni.Text.Equals("admin") && passwordUni.Text.Equals("admin")))
                    {
                        Response.Redirect("Admin.aspx");
                    }
                    else
                        Response.Redirect("UniProfile.aspx");
            }
            else
                invalidUniCreds.Text = "Invalid credentials.";

        }

        protected void ForgotPW(object sender, EventArgs e)
        {
            MailMessage emailMessage = new MailMessage();
            MailAddress messageTo = new MailAddress(LostPW.Text);

            MailAddress messageFrom = new MailAddress("aphunt@ilstu.edu", "Password Retrieval");
            emailMessage.Subject = "LinkedU Password Retrieval";
            emailMessage.From = messageFrom;
            emailMessage.To.Add(messageTo);
            emailMessage.AlternateViews.Add(Mail_Body(LostPW.Text));
            emailMessage.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.office365.com";
            smtp.EnableSsl = true;

            NetworkCredential NetworkCred = new NetworkCredential("aphunt@ilstu.edu", "0p9o8i*Mknjbh");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = 587;

            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.ServicePoint.MaxIdleTime = 0;
            smtp.ServicePoint.SetTcpKeepAlive(true, 2000, 2000);
            emailMessage.Priority = MailPriority.High;

            smtp.Send(emailMessage);
            status.Text = "Please check your email for further instructions.";
        }

        private AlternateView Mail_Body(String email)
        {
                     Random r = new Random();
                     int rand = r.Next();

        string path = Server.MapPath("./images/logo.JPG");
            LinkedResource Img = new LinkedResource(path, MediaTypeNames.Image.Jpeg);
            
            Img.ContentId = "MyImage";
            string str = @"  
                    <div width='100%' >
                      <img src=cid:MyImage  id='img' alt='logo' style='margin: 0 auto;'/>   
                        <p>You've requested to reset your password. </p>" +
                       "<p>Please follow the link to do so.</p>" +
                       "<a href=\"http://localhost:49403/Reset.aspx?reset=" + rand + "&email=" + email + "\">Click Here.</a> "
                       + " </div> ";
            

            AlternateView AV =
            AlternateView.CreateAlternateViewFromString(str, null, MediaTypeNames.Text.Html);
            AV.LinkedResources.Add(Img);
            return AV;
        }

       


    }

}
