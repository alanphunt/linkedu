using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LinkedU
{
    public partial class Blog : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {


            SqlConnection dbConnection = new SqlConnection("Data Source=itkmssql;Integrated Security=true");

            dbConnection.Open();
            dbConnection.ChangeDatabase("AAA368");
            String sqlCommand = "SELECT * FROM Schools WHERE showcase = 'y';";
            SqlCommand schoolSearch = new SqlCommand(sqlCommand, dbConnection);
            SqlDataReader SearchResult = schoolSearch.ExecuteReader();
            if (SearchResult.Read())
            {

                do
                {
                    string school = SearchResult["School_Name"].ToString();

                    h4.Text = "More details about " + SearchResult["Username"].ToString();
                    Name.Text = "<span class=\"info\">School Name: " + SearchResult["School_Name"].ToString() + "</span>";
                    Email.Text = "<span class=\"info\">Email: " + SearchResult["Email"].ToString() + "</span>";
                    Address.Text = "<span class=\"info\">Address: " + SearchResult["Address"].ToString() + "</span>";
                    bio.Text = "<span class=\"info\">Bio " + SearchResult["Bio"].ToString() + "</span>";
                    HyperLink2.NavigateUrl = "Apply.aspx?school=" + school;
                } while (SearchResult.Read());
            }


            dbConnection.Close();

            if (Student.Current.username == null && University.Current.username != null)
                HyperLink1.NavigateUrl = "UniProfile.aspx";
            else if (University.Current.username == null && Student.Current.username != null)
                HyperLink1.NavigateUrl = "StuProfile.aspx";
            else if (University.Current.username == null && Student.Current.username == null)
                HyperLink1.NavigateUrl = "#";


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
    }
}