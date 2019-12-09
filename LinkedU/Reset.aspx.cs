using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LinkedU
{
    public partial class Reset : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["reset"] != null && Request.QueryString["email"] != null && Page.IsPostBack)
            {
                string idiot = Request.QueryString["email"];
                using (SqlConnection dbConnection = new SqlConnection("Data Source=itkmssql;Integrated Security=true"))
                {
                    dbConnection.Open();
                    dbConnection.ChangeDatabase("AAA368");
                    string sqlCommand;


                    if (RadioButtonList1.SelectedValue.Equals("student"))
                     sqlCommand = "UPDATE dbo.Students SET Password = @Password WHERE Email = @Email";
                    else
                     sqlCommand = "UPDATE dbo.Schools SET Password = @Password WHERE Email = @Email";


                    using (SqlCommand unsub = new SqlCommand(sqlCommand, dbConnection))
                    {
                        unsub.Parameters.AddWithValue("@Email", idiot);
                        unsub.Parameters.AddWithValue("@Password", pwreset.Text);
                        unsub.ExecuteNonQuery();
                        dbConnection.Close();
                    }
                }
                Response.Redirect("Default.aspx");
            }

        }

        
    }
}