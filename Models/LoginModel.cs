using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;

//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<*THE*START*OF*FILE*<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<//

namespace ST10381071_PROG7311_3A_POE.Models
{
    public class LoginModel
    {
        // creating connection string - to connect to sqlite database
        public static string con_string = "Data Source=C:\\Users\\mathe\\OneDrive\\Desktop\\VARSITY\\BCA3 YEAR 3\\SEMESTER 1\\PROG7311 3A\\DB BROSWER\\POE2Database.db";

        // creating method to select farmer - by name,email and password
        public int SelectFarmer(string Name, string Email, string Password)
        {
            // Default UserID value if user is not found in database
            int UserID = -1;

            using (SqliteConnection con = new SqliteConnection(con_string))
            {
                // defining the sql query to select the UserID from the FarmerTable 
                string sql = "SELECT UserID FROM FarmerTable WHERE UserName = @Name AND UserEmail = @Email AND UserPassword = @Password";
                SqliteCommand cmd = new SqliteCommand(sql, con);

                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Password", Password);


                try
                {
                    con.Open(); // opening the connection for the database

                    object result = cmd.ExecuteScalar(); // execuing the SQLite query and get the returning result

                    // if statmenet - to check if the result is not null and not DBnull
                    if (result != null && result != DBNull.Value)
                    {
                        // converting the result to an integer and setting it as the UserID
                        UserID = Convert.ToInt32(result);
                    }
                }

                catch (Exception ex)
                {
                    throw ex;
                }

            }
            return UserID;
        }

        // creating method to select employee - by name,email and password
        public int SelectEmployee(string Name, string Email, string Password)
        {
            // Default UserID value if user is not found in database
            int UserID = -1;

            using (SqliteConnection con = new SqliteConnection(con_string))
            {
                // defining the sqlite query to select the UserID from the UserTable 
                string sql = "SELECT UserID FROM EmployeeTable WHERE UserName = @Name AND UserEmail = @Email AND UserPassword = @Password";
                SqliteCommand cmd = new SqliteCommand(sql, con);

                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Password", Password);


                try
                {
                    con.Open(); // opening the connection for the database

                    object result = cmd.ExecuteScalar(); // execuing the SQLite query and get the returning result

                    // if statmenet - to check if the result is not null and not DBnull
                    if (result != null && result != DBNull.Value)
                    {
                        // converting the result to an integer and setting it as the UserID
                        UserID = Convert.ToInt32(result);
                    }
                }

                catch (Exception ex)
                {
                    throw ex;
                }

            }
            return UserID;
        }
    }
}

//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<*THE*END*OF*FILE*<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<//