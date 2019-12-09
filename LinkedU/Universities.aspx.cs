using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LinkedU
{
    public partial class Universities : System.Web.UI.Page
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

        protected void UniSearch(object sender, EventArgs e)
        {
            SqlConnection dbConnection = new SqlConnection("Data Source=itkmssql;Integrated Security=true");
            if (searchoptions.SelectedValue == "0")
            {
                dbConnection.Open();
                dbConnection.ChangeDatabase("AAA368");
                String sqlCommand = "SELECT * FROM Schools ;";
                SqlCommand schoolSearch = new SqlCommand(sqlCommand, dbConnection);
                SqlDataReader SearchResult = schoolSearch.ExecuteReader();
                if (SearchResult.Read())
                {
                    results.Text += "<table width='100%' border='1'>";
                    results.Text += "<tr><th>School Name</th><th>Bio</th><th>Address</th><th>Email</th></tr>";
                    do
                    {
                        if (!(SearchResult["Email"].Equals("admin@admin.com")))
                        {
                            results.Text += "<tr>";
                            results.Text += "<td>"
                                + "<a href=\"UniProfile.aspx?email=" + SearchResult["Email"] + "\">" + SearchResult["School_Name"] + "</a>"
                                + "</td>";
                            results.Text += "<td>"
                                + SearchResult["Bio"]
                                + "</td>";
                            results.Text += "<td>"
                                + SearchResult["Address"]
                                + "</td>";
                            results.Text += "<td>"
                                + SearchResult["Email"]
                                + "</td>";
                            results.Text += "</tr>";
                        }
                    } while (SearchResult.Read());
                    results.Text += "</table>";
                }
                else
                    results.Text += "<p>Your search did dnot return any results</p>";
                dbConnection.Close();
            }
            else if (searchoptions.SelectedValue == "1")
            {
                dbConnection.Open();
                dbConnection.ChangeDatabase("AAA368");
                String sqlCommand = "SELECT * FROM Schools WHERE School_Name ='" + SearchText.Text + "' ;";
                SqlCommand schoolSearch = new SqlCommand(sqlCommand, dbConnection);
                SqlDataReader SearchResult = schoolSearch.ExecuteReader();
                if (SearchResult.Read())
                {
                    results.Text += "<table width='100%' border='1'>";
                    results.Text += "<tr><th>School</th><th>Bio</th><th>Location</th><th>Contact</th></tr>";
                    do
                    {
                        if (!(SearchResult["Email"].Equals("admin@admin.com")))
                        {

                            results.Text += "<tr>";
                            results.Text += "<td>"
                                + "<a href=\"UniProfile.aspx?email=" + SearchResult["Email"] + "\">" + SearchResult["School_Name"] + "</a>"
                                + "</td>";
                            results.Text += "<td>"
                                + SearchResult["Bio"]
                                + "</td>";
                            results.Text += "<td>"
                                + SearchResult["Address"]
                                + "</td>";
                            results.Text += "<td>"
                                + SearchResult["Email"]
                                + "</td>";
                            results.Text += "</tr>";
                        }
                    } while (SearchResult.Read());
                    results.Text += "</table>";
                }
                else
                    results.Text += "<p>Your search did dnot return any results</p>";
                dbConnection.Close();
            }

            else if (searchoptions.SelectedValue == "2")
            {
                dbConnection.Open();
                dbConnection.ChangeDatabase("AAA368");
                String sqlCommand = "SELECT * FROM Schools WHERE Address ='" + SearchText.Text + "' ;";
                SqlCommand schoolSearch = new SqlCommand(sqlCommand, dbConnection);
                SqlDataReader SearchResult = schoolSearch.ExecuteReader();
                if (SearchResult.Read())
                {
                    results.Text += "<table width='100%' border='1'>";
                    results.Text += "<tr><th>School</th><th>Bio</th><th>Location</th><th>Contact</th></tr>";
                    do
                    {
                        if (!(SearchResult["Email"].Equals("admin@admin.com")))
                        {

                            results.Text += "<tr>";
                            results.Text += "<td>"
                                + "<a href=\"UniProfile.aspx?email=" + SearchResult["Email"] + "\">" + SearchResult["School_Name"] + "</a>"
                                + "</td>";
                            results.Text += "<td>"
                                + SearchResult["Bio"]
                                + "</td>";
                            results.Text += "<td>"
                                + SearchResult["Address"]
                                + "</td>";
                            results.Text += "<td>"
                                + SearchResult["Email"]
                                + "</td>";
                            results.Text += "</tr>";
                        }
                    } while (SearchResult.Read());
                    results.Text += "</table>";
                }
                else
                    results.Text += "<p>Your search did dnot return any results</p>";
                dbConnection.Close();
            }

        }

    }
}