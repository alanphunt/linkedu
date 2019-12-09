using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;

namespace LinkedU
{
    public partial class UniProfile : System.Web.UI.Page
    {
        Char sub = 'n';
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["email"] == null && University.Current.email != null)
            {
                h4.Text = "Welcome " + University.Current.username;
                Name.Text = "<span class=\"info\">School Name:" + University.Current.schoolName + "</span>";
                Email.Text = "<span class=\"info\">Email: " + University.Current.email + "</span>";
                Address.Text = "<span class=\"info\">Address: " + University.Current.address + "</span>";
                bio.Text = "<span class=\"info\">Bio: " + University.Current.bio + "</span>";

                info.Visible = false;
                logoutButton.Visible = true;
                HyperLink2.Visible = false;

                if (sub == 'y')
                {
                    unsubscribe.Visible = true;
                    Label4.Text = "You are currently subscribed. Do you wish to unsubscribe?";
                    Button2.Text = "Unsubscribe";
                    sub = 'n';
                }
                else
                {
                    unsubscribe.Visible = true;
                    Label4.Text = "You are currently unsubscribed. Do you wish to subscribe?";
                    Button2.Text = "Subscribe";
                    sub = 'y';
                }

            }
            else 
            {
                using (SqlConnection dbConnection = new SqlConnection("Data Source=itkmssql;Integrated Security=true"))
                {


                    dbConnection.Open();
                    dbConnection.ChangeDatabase("AAA368");
                    String sqlCommand = "SELECT * FROM dbo.Schools WHERE Email = @Email";
                    using (SqlCommand uniSearch = new SqlCommand(sqlCommand, dbConnection))
                    {

                        uniSearch.Parameters.AddWithValue("@Email", Request.QueryString["email"]);
                        int i = 0;
                        SqlDataReader SearchResult = uniSearch.ExecuteReader();
                        while (SearchResult.Read() && i != 1)
                        {
                            h4.Text = "More details about " + SearchResult["Username"].ToString();
                            Name.Text = "<span class=\"info\">School Name: " + SearchResult["School_Name"].ToString() + "</span>";
                            Email.Text = "<span class=\"info\">Email: " + SearchResult["Email"].ToString() + "</span>";
                            Address.Text = "<span class=\"info\">Address: " + SearchResult["Address"].ToString() + "</span>";
                            bio.Text = "<span class=\"info\">Bio " + SearchResult["Bio"].ToString() + "</span>";
                            HyperLink2.NavigateUrl = "Apply.aspx?school=" + SearchResult["School_Name"].ToString();

                            i++;
                        }
                    }
                }
                upload.Visible = false;
                HyperLink2.Visible = true;
                info.Visible = true;
                logoutButton.Visible = false;
                unsubscribe.Visible = false;
            }

            if (Student.Current.username == null && University.Current.username != null)
                HyperLink1.NavigateUrl = "UniProfile.aspx";
            else if (University.Current.username == null && Student.Current.username != null)
                HyperLink1.NavigateUrl = "StuProfile.aspx";
            else if (University.Current.username == null && Student.Current.username == null)
                HyperLink1.NavigateUrl = "#";

        }


        protected void AsyncFileUpload1_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {
            System.Threading.Thread.Sleep(10000);
            AsyncFileUpload1.SaveAs(Server.MapPath("~/UploadedFiles/") + Path.GetFileName(AsyncFileUpload1.FileName));
            string path = "~/UploadedFiles/" + Path.GetFileName(AsyncFileUpload1.FileName);
            UserPic.ImageUrl = path;
            Page_Load(sender, e);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label2.Text = "We will send you more information about ";
            foreach (ListItem item in CheckBoxList1.Items)
            {
                if (item.Selected == true)
                    Label2.Text += "<br>+" + item.Value;
                
            }

        }

        protected void Unsubscribe(object sender, EventArgs e)
        {
            sub = 'y';
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
                University.Current.username = null;
                University.Current.password = null;
                University.Current.email = null;
                University.Current.schoolName = null;
                University.Current.address = null;
                University.Current.bio = null;
                University.Current.showcase = ' ';
            }
            Response.Redirect("Default.aspx");

        }



    }
}