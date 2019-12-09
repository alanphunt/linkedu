using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LinkedU
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Student.Current.username == null && University.Current.username != null)
            {
                HyperLink1.NavigateUrl = "UniProfile.aspx";
            }
            else if (University.Current.username == null && Student.Current.username != null)
            {
                HyperLink1.NavigateUrl = "StuProfile.aspx";
            }
            else if (University.Current.username == null && Student.Current.username == null)
                HyperLink1.NavigateUrl = "#";
        }
    

        protected void Button1_Click(object sender, EventArgs e)
        {

                SqlConnection dbConnection = new SqlConnection("Data Source=itkmssql;Integrated Security=true");
                String sqlCommand = "UPDATE dbo.Schools SET Showcase = 'y' WHERE School_Name = @School_Name";
                SqlCommand cmd = new SqlCommand(sqlCommand, dbConnection);
                
                    cmd.Parameters.AddWithValue("@School_Name", name.Text);
                    dbConnection.Open();
                    dbConnection.ChangeDatabase("AAA368");
                    cmd.ExecuteNonQuery();
                    dbConnection.Close();
                    Label1.Text = "University has been added to showcase!";

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlConnection dbConnection = new SqlConnection("Data Source=itkmssql;Integrated Security=true");
            String sqlCommand = "UPDATE dbo.Schools SET Showcase = 'n' WHERE School_Name = @School_Name";
            SqlCommand cmd = new SqlCommand(sqlCommand, dbConnection);

            cmd.Parameters.AddWithValue("@School_Name", name.Text);
            dbConnection.Open();
            dbConnection.ChangeDatabase("AAA368");
            cmd.ExecuteNonQuery();
            dbConnection.Close();
            Label1.Text = "University has been removed from showcase!";
        }

    }
}