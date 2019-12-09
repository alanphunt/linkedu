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
    public partial class StuProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["email"] == null && Student.Current.email != null )
            {
                info.Visible = false;
                logoutButton.Visible = true;

                h4.Text = "Welcome " + Student.Current.username;
                fName.Text = "<span class=\"info\">First Name: " + Student.Current.firstName + "</span>";
                lName.Text = "<span class=\"info\">Last Name: " + Student.Current.lastName + "</span>";
                Email.Text = "<span class=\"info\">Email: " + Student.Current.email + "</span>";
                Phone.Text = "<span class=\"info\">Phone: " + Student.Current.phone + "</span>";
                Address.Text = "<span class=\"info\">Address: " + Student.Current.address + "</span>";
                School.Text = "<span class=\"info\">Highschool: " + Student.Current.highSchool + "</span>";
                Grad.Text = "<span class=\"info\">Grad Year: " + Student.Current.gradYear + "</span>";
                GPA.Text = "<span class=\"info\">GPA: " + Student.Current.GPA + "</span>";
                bio.Text = "<span class=\"info\">Bio: " + Student.Current.bio + "</span>";

                if (Student.Current.subscribed == 'y')
                {
                    unsubscribe.Visible = true;
                    Label4.Text = "You are currently subscribed. Do you wish to unsubscribe?";
                    Button2.Text = "Unsubscribe";
                }
                else
                {
                    unsubscribe.Visible = true;
                    Label4.Text = "You are currently unsubscribed. Do you wish to subscribe?";
                    Button2.Text = "Subscribe";
                }
            }
            else
            {

                using (SqlConnection dbConnection = new SqlConnection("Data Source=itkmssql;Integrated Security=true"))
                {
                    h4.Text = "More Details.";
                    unsubscribe.Visible = false;
                    logoutButton.Visible = false;

                    dbConnection.Open();
                    dbConnection.ChangeDatabase("AAA368");
                    String sqlCommand = "SELECT * FROM dbo.Students WHERE Email = @Email";
                    using (SqlCommand studentSearch = new SqlCommand(sqlCommand, dbConnection))
                    {

                        studentSearch.Parameters.AddWithValue("@Email", Request.QueryString["email"]);
                        

                        int i = 0;

                        SqlDataReader SearchResult = studentSearch.ExecuteReader();
                        while (SearchResult.Read() && i!=1)
                        {
                            fName.Text = "<span class=\"info\">First Name: " + SearchResult.GetString(4) + "</span>";
                            lName.Text = "<span class=\"info\">Last Name: " + SearchResult.GetString(5) + "</span>";
                            Email.Text = "<span class=\"info\">Email: " + SearchResult["Email"].ToString() + "</span>";
                            Phone.Text = "<span class=\"info\">Phone: " + SearchResult["Phone"].ToString() + "</span>";
                            Address.Text = "<span class=\"info\">Address: " + SearchResult["Address"].ToString() + "</span>";
                            School.Text = "<span class=\"info\">Highschool: " + SearchResult["High_School"].ToString() + "</span>";
                            Grad.Text = "<span class=\"info\">Grad Year: " + SearchResult["Graduating"].ToString() + "</span>";
                            GPA.Text = "<span class=\"info\">GPA: " + SearchResult["GPA"].ToString() + "</span>";
                            bio.Text = "<span class=\"info\">Bio: " + SearchResult["Bio"].ToString() + "</span>";
                            i++;
                        }
                        dbConnection.Close();
                    }
                }
                upload.Visible = false;
                logoutButton.Visible = false;

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
                    Label2.Text += "<br>+ " + item.Value;

            }

        }

        protected void Unsubscribe(object sender, EventArgs e)
        {

            if (Student.Current.subscribed == 'y')
            {
                using (SqlConnection dbConnection = new SqlConnection("Data Source=itkmssql;Integrated Security=true"))
                {
                    dbConnection.Open();
                    dbConnection.ChangeDatabase("AAA368");
                    String sqlCommand = "UPDATE dbo.Students SET Subscribed = 'n' WHERE Username = @Username";
                    using (SqlCommand unsub = new SqlCommand(sqlCommand, dbConnection))
                    {

                        unsub.Parameters.AddWithValue("@Username", Student.Current.username);
                        unsub.ExecuteNonQuery();
                        dbConnection.Close();
                    }
                }
                Label4.Text = "You are currently unsubscribed. Do you wish to subscribe?";
                Button2.Text = "Subscribe";

            }
            else
            {
                using (SqlConnection dbConnection = new SqlConnection("Data Source=itkmssql;Integrated Security=true"))
                {
                    dbConnection.Open();
                    dbConnection.ChangeDatabase("AAA368");
                    String sqlCommand = "UPDATE dbo.Students SET Subscribed = 'y' WHERE Username = @Username";
                    using (SqlCommand unsub = new SqlCommand(sqlCommand, dbConnection))
                    {

                        unsub.Parameters.AddWithValue("@Username", Student.Current.username);
                        unsub.ExecuteNonQuery();
                        dbConnection.Close();
                    }
                }
                Label4.Text = "You are currently subscribed. Do you wish to unsubscribe?";
                Button2.Text = "Unsubscribe";

            }
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