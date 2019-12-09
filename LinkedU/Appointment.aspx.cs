using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LinkedU
{
    public partial class Appointment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Student.Current.username == null && University.Current.username != null)
                HyperLink1.NavigateUrl = "UniProfile.aspx";
            else if (University.Current.username == null && Student.Current.username != null)
                HyperLink1.NavigateUrl = "StuProfile.aspx";
            else if (University.Current.username == null && Student.Current.username == null)
                HyperLink1.NavigateUrl = "#";
        }

        protected void dateSelected(Object Source, EventArgs E)
        {
            date.Text = Calendar1.SelectedDate.ToString("d");
        }

        protected void ForgotPW(object sender, EventArgs e)
        {
            MailMessage emailMessage = new MailMessage();
            MailAddress messageTo = new MailAddress(email.Text);

            /*INSERT YOUR EMAIL WHERE MINE IS*/
            MailAddress messageFrom = new MailAddress("aphunt@ilstu.edu", "Appointment Confirmation");
            emailMessage.Subject = "LinkedU Appointment Scheduled";
            emailMessage.From = messageFrom;
            emailMessage.To.Add(messageTo);
            emailMessage.AlternateViews.Add(Mail_Body(email.Text));
            emailMessage.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.office365.com";
            smtp.EnableSsl = true;

            /*INSERT YOUR ISU EMAIL AND YOUR PASSWORD*/
            NetworkCredential NetworkCred = new NetworkCredential("aphunt@ilstu.edu", "0p9o8i*Mknjbh");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = 587;

            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.ServicePoint.MaxIdleTime = 0;
            smtp.ServicePoint.SetTcpKeepAlive(true, 2000, 2000);
            emailMessage.Priority = MailPriority.High;

            smtp.Send(emailMessage);
            status.Text = "Please check your email for your confirmation.";
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
                        <p>Your appointment is scheduled! </p>" +
                       "<p>Please see the following details: </p>" +
                       "<p>Your name: " + firstName.Text + " " + lastName.Text + "</p>" +
                       "<p>Appointment date: " + date.Text + "</p>"
                       + " </div> ";



            AlternateView AV =
            AlternateView.CreateAlternateViewFromString(str, null, MediaTypeNames.Text.Html);
            AV.LinkedResources.Add(Img);
            return AV;
        }
    }
}