using System.Data;
using System.Data.SqlClient;
using System.Data.Odbc;

namespace LinkedU
{
    public class DatabaseProcessing
    {

        private string connection = System.Configuration.ConfigurationManager.ConnectionStrings["UserConnectionString"].ConnectionString;


        public void NewStudent(string userName, string password, string email, string firstName, string lastName,
                          string phone, string bio, string highSchool, string address, string gradYear, string GPA, char subscribed, char sms)
        {
            string query = "INSERT INTO students (Username, Password, Email, First_Name, Last_Name, Phone, Bio, High_School, Address, Graduating, GPA, Subscribed, SMS) " +
                           "VALUES (@Username, @Password, @Email, @First_Name, @Last_Name, @Phone, @Bio, @High_School, @Address, @Graduating, @GPA, @Subscribed, @SMS) ";

            using (OdbcConnection cn = new OdbcConnection(connection))
            using (OdbcCommand cmd = new OdbcCommand(query, cn))
            {
                cmd.Parameters.Add("@Username", OdbcType.VarChar, 20).Value = userName;
                cmd.Parameters.Add("@Password", OdbcType.VarChar, 20).Value = password;
                cmd.Parameters.Add("@Email", OdbcType.VarChar, 50).Value = email;
                cmd.Parameters.Add("@First_Name", OdbcType.VarChar, 20).Value = firstName;
                cmd.Parameters.Add("@Last_Name", OdbcType.VarChar, 20).Value = lastName;
                cmd.Parameters.Add("@Phone", OdbcType.VarChar, 10).Value = phone;
                cmd.Parameters.Add("@Bio", OdbcType.VarChar, 300).Value = bio;
                cmd.Parameters.Add("@High_School", OdbcType.VarChar, 30).Value = highSchool;
                cmd.Parameters.Add("@Address", OdbcType.VarChar, 30).Value = address;
                cmd.Parameters.Add("@Graduating", OdbcType.VarChar, 4).Value = gradYear;
                cmd.Parameters.Add("@GPA", OdbcType.VarChar, 4).Value = GPA;
                cmd.Parameters.Add("@Subscribed", OdbcType.Char, 1).Value = subscribed;
                cmd.Parameters.Add("@SMS", OdbcType.Char, 1).Value = sms;

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

                StuLogin(userName, password);
                
            }
        }


        public void NewUniversity(string username, string password, string email, string schoolName,
                        string address, string bio, char showcase)
        {
            string query = "INSERT INTO schools (Username, Password, Email, School_Name, Address, Bio, Showcase) " +
                           "VALUES (@Username, @Password, @Email, @School_Name, @Address, @Bio, @Showcase) ";

            using (OdbcConnection cn = new OdbcConnection(connection))
            using (OdbcCommand cmd = new OdbcCommand(query, cn))
            {
                cmd.Parameters.Add("@Username", OdbcType.VarChar, 20).Value = username;
                cmd.Parameters.Add("@Password", OdbcType.VarChar, 20).Value = password;
                cmd.Parameters.Add("@Email", OdbcType.VarChar, 30).Value = email;
                cmd.Parameters.Add("@School_Name", OdbcType.VarChar, 50).Value = schoolName;
                cmd.Parameters.Add("@Address", OdbcType.VarChar, 50).Value = address;
                cmd.Parameters.Add("@Bio", OdbcType.VarChar, 1000).Value = bio;
                cmd.Parameters.Add("@Showcase", OdbcType.Char, 1).Value = showcase;

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

                UniLogin(username, password);
            }

        }

        public bool StuLogin(string username, string password)
        {

           string query = "SELECT * FROM students WHERE Username = @Username AND Password = @Password";
            
           using(OdbcConnection cn = new OdbcConnection(connection))
            {
                using (OdbcCommand cmd = new OdbcCommand(query, cn)) { 
                cn.Open();

                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                OdbcDataReader rdr = cmd.ExecuteReader();

                    
                        while (rdr.Read())
                        {

                            Student.Current.username = rdr.GetString(1);
                            Student.Current.password = rdr.GetString(2);
                            Student.Current.email = rdr.GetString(3);
                            Student.Current.firstName = rdr.GetString(4);
                            Student.Current.lastName = rdr.GetString(5);
                            Student.Current.phone = rdr.GetString(7);
                            Student.Current.bio = rdr.GetString(8);
                            Student.Current.highSchool = rdr.GetString(9);
                            Student.Current.address = rdr.GetString(10);
                            Student.Current.gradYear = rdr.GetString(11);
                            Student.Current.GPA = rdr.GetString(12);
                            Student.Current.subscribed = char.Parse(rdr.GetString(14));
                            Student.Current.SMS = char.Parse(rdr.GetString(15));

                        }
                        cn.Close();
                    
                    if(Student.Current.username != null)
                        return true;

                    return false;
                }                      
            }
        }

        public bool UniLogin(string username, string password)
        {

            string query = "SELECT * FROM schools WHERE Username = @Username AND Password = @Password";

            using (OdbcConnection cn = new OdbcConnection(connection))
            {
                using (OdbcCommand cmd = new OdbcCommand(query, cn))
                {
                    cn.Open();
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    OdbcDataReader rdr = cmd.ExecuteReader();
                    
                        while (rdr.Read())
                        {
                            new University();

                            University.Current.username = rdr.GetString(1);
                            University.Current.password = rdr.GetString(2);
                            University.Current.email = rdr.GetString(3);
                            University.Current.schoolName = rdr.GetString(4);
                            University.Current.address = rdr.GetString(5);
                            University.Current.bio = rdr.GetString(6);
                            University.Current.showcase = char.Parse(rdr.GetString(9));
                        }
                        cn.Close();

                    if (University.Current.username != null)
                        return true;

                    return false;
                }
            }
        }



    }
}