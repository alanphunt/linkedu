using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LinkedU
{
    public partial class Students : System.Web.UI.Page
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

        protected void StuSearch(object sender, EventArgs e)
        {
            SqlConnection dbConnection = new SqlConnection("Data Source=itkmssql;Integrated Security=true");
            if (studentdropdownlist.SelectedValue == "0")
            {
                dbConnection.Open();
                dbConnection.ChangeDatabase("AAA368");
                String sqlCommand = "SELECT * FROM Students ;";
                SqlCommand studentSearch = new SqlCommand(sqlCommand, dbConnection);
                SqlDataReader SearchResult = studentSearch.ExecuteReader();
                if (SearchResult.Read())
                {

                    result.Text += "<table width='100%' border='1'>";
                    result.Text += "<tr><th>Compare?</th><th>Name</th><th>Bio</th><th>School</th><th>Grad Year</th><th>GPA</th></tr>";
                    do
                    {
                        if (!SearchResult["Email"].Equals("admin@admin.com")) {
                            result.Text += "<tr>";
                            result.Text += "<td><input type=\"checkbox\" class=\"cb\" value=\"" + SearchResult["Email"] + "\"></ td>";

                            result.Text += "<td><a href=\"StuProfile.aspx?email=" + SearchResult["Email"] + "\">"
                                + SearchResult["First_Name"]
                                + "</a></td>";
                            result.Text += "<td>"
                                + SearchResult["Bio"]
                                + "</td>";
                            result.Text += "<td>"
                                + SearchResult["High_School"]
                                + "</td>";
                            result.Text += "<td>"
                                + SearchResult["Graduating"]
                                + "</td>";
                            result.Text += "<td>"
                                + SearchResult["GPA"]
                                + "</td>";
                            result.Text += "</tr>";
                        }
                    } while (SearchResult.Read());
                    result.Text += "</table>";
                }
                else
                    result.Text += "<p>Your search did not return any results</p>";
                dbConnection.Close();
            }
            else if (studentdropdownlist.SelectedValue == "1")
            {
                dbConnection.Open();
                dbConnection.ChangeDatabase("AAA368");
                String sqlCommand = "SELECT * FROM Students WHERE First_Name ='" + TextBox1.Text + "' ;";
                SqlCommand studentSearch = new SqlCommand(sqlCommand, dbConnection);
                SqlDataReader SearchResult = studentSearch.ExecuteReader();
                if (SearchResult.Read())
                {
                    result.Text += "<table width='100%' border='1'>";
                    result.Text += "<tr><th>Compare?</th><th>Name</th><th>Bio</th><th>School</th><th>Grad Year</th><th>GPA</th></tr>";
                    do
                    {
                        if (!SearchResult["Email"].Equals("admin@admin.com"))
                        {
                            result.Text += "<tr>";
                            result.Text += "<td><input type=\"checkbox\" class=\"cb\" value=\"" + SearchResult["Email"] + "\"></ td>";

                            result.Text += "<td><a href=\"StuProfile.aspx?email=" + SearchResult["Email"] + "\">"
                               + SearchResult["First_Name"]
                               + "</a></td>";
                            result.Text += "<td>"
                                + SearchResult["Bio"]
                                + "</td>";
                            result.Text += "<td>"
                                + SearchResult["High_School"]
                                + "</td>";
                            result.Text += "<td>"
                                + SearchResult["Graduating"]
                                + "</td>";
                            result.Text += "<td>"
                                + SearchResult["GPA"]
                                + "</td>";
                            result.Text += "</tr>";
                        }
                    } while (SearchResult.Read());
                    result.Text += "</table>";
                }
                else
                    result.Text += "<p>Your search did not return any results</p>";
                dbConnection.Close();
            }
            else if (studentdropdownlist.SelectedValue == "2")
            {
                dbConnection.Open();
                dbConnection.ChangeDatabase("AAA368");
                String sqlCommand = "SELECT * FROM Students WHERE High_School ='" + TextBox1.Text + "' ;";
                SqlCommand studentSearch = new SqlCommand(sqlCommand, dbConnection);
                SqlDataReader SearchResult = studentSearch.ExecuteReader();
                if (SearchResult.Read())
                {
                    result.Text += "<table width='100%' border='1'>";
                    result.Text += "<tr<th>Compare?</th>><th>Name</th><th>Bio</th><th>School</th><th>Grad Year</th><th>GPA</th></tr>";
                    do
                    {
                        if (!SearchResult["Email"].Equals("admin@admin.com"))
                        {
                            result.Text += "<tr>";
                            result.Text += "<td><input type=\"checkbox\" class=\"cb\" value=\"" + SearchResult["Email"] + "\"></ td>";

                            result.Text += "<td><a href=\"StuProfile.aspx?email=" + SearchResult["Email"] + "\">"
                                + SearchResult["First_Name"]
                                + "</a></td>";
                            result.Text += "<td>"
                                + SearchResult["Bio"]
                                + "</td>";
                            result.Text += "<td>"
                                + SearchResult["High_School"]
                                + "</td>";
                            result.Text += "<td>"
                                + SearchResult["Graduating"]
                                + "</td>";
                            result.Text += "<td>"
                                + SearchResult["GPA"]
                                + "</td>";
                            result.Text += "</tr>";
                        }
                    } while (SearchResult.Read());
                    result.Text += "</table>";
                }
                else
                    result.Text += "<p>Your search did not return any results</p>";
                dbConnection.Close();
            }
            else if (studentdropdownlist.SelectedValue == "3")
            {
                dbConnection.Open();
                dbConnection.ChangeDatabase("AAA368");
                String sqlCommand = "SELECT * FROM Students WHERE GPA ='" + TextBox1.Text + "' ;";
                SqlCommand studentSearch = new SqlCommand(sqlCommand, dbConnection);
                SqlDataReader SearchResult = studentSearch.ExecuteReader();
                if (SearchResult.Read())
                {
                    result.Text += "<table width='100%' border='1'>";
                    result.Text += "<tr><th>Compare?</th><th>Name</th><th>Bio</th><th>School</th><th>Grad Year</th><th>GPA</th></tr>";
                    do
                    {
                        if (!SearchResult["Email"].Equals("admin@admin.com"))
                        {

                            result.Text += "<tr>";
                            result.Text += "<td><input type=\"checkbox\" class=\"cb\" value=\"" + SearchResult["Email"] + "\"></ td>";

                            result.Text += "<td><a href=\"StuProfile.aspx?email=" + SearchResult["Email"] + "\">"
                               + SearchResult["First_Name"]
                               + "</a></td>";
                            result.Text += "<td>"
                                + SearchResult["Bio"]
                                + "</td>";
                            result.Text += "<td>"
                                + SearchResult["High_School"]
                                + "</td>";
                            result.Text += "<td>"
                                + SearchResult["Graduating"]
                                + "</td>";
                            result.Text += "<td>"
                                + SearchResult["GPA"]
                                + "</td>";
                            result.Text += "</tr>";
                        }
                    } while (SearchResult.Read());
                    result.Text += "</table>";
                }
                else
                    result.Text += "<p>Your search did not return any results</p>";
                dbConnection.Close();
            }
            else if (studentdropdownlist.SelectedValue == "4")
            {
                dbConnection.Open();
                dbConnection.ChangeDatabase("AAA368");
                String sqlCommand = "SELECT * FROM Students WHERE Graduating ='" + TextBox1.Text + "' ;";
                SqlCommand studentSearch = new SqlCommand(sqlCommand, dbConnection);
                SqlDataReader SearchResult = studentSearch.ExecuteReader();
                if (SearchResult.Read())
                {
                    result.Text += "<table width='100%' border='1'>";
                    result.Text += "<tr><th>Compare?</th><th>Name</th><th>Bio</th><th>School</th><th>Grad Year</th><th>GPA</th></tr>";
                    do
                    {
                        if (!SearchResult["Email"].Equals("admin@admin.com"))
                        {

                            result.Text += "<tr>";
                            result.Text += "<td><input type=\"checkbox\" class=\"cb\" value=\"" + SearchResult["Email"]+"\"></ td>";
                            result.Text += "<td><a href=\"StuProfile.aspx?email=" + SearchResult["Email"] + "\">"
                               + SearchResult["First_Name"]
                               + "</a></td>";
                            result.Text += "<td>"
                                + SearchResult["Bio"]
                                + "</td>";
                            result.Text += "<td>"
                                + SearchResult["High_School"]
                                + "</td>";
                            result.Text += "<td>"
                                + SearchResult["Graduating"]
                                + "</td>";
                            result.Text += "<td>"
                                + SearchResult["GPA"]
                                + "</td>";
                            result.Text += "</tr>";
                        }
                    } while (SearchResult.Read());
                    result.Text += "</table>";
                }
                else
                    result.Text += "<p>Your search did not return any results</p>";
                dbConnection.Close();
            }

        }




    }
}