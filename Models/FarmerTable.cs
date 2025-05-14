using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;

//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<*THE*START*OF*FILE*<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<//

namespace ST10381071_PROG7311_3A_POE.Models
{
    public class FarmerTable
    {
        // Connection string for connecting to the SQLite database
        public static string con_string = "Data Source=C:\\Users\\mathe\\OneDrive\\Desktop\\VARSITY\\BCA3 YEAR 3\\SEMESTER 1\\PROG7311 3A\\DB BROSWER\\POE2Database.db";

        // SQLiteConnection objct. for managing the database connection
        public static SqliteConnection con = new SqliteConnection(con_string);


        // properties for storing the user information
        public int UserID { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }


        // Method for inserting user data into the database
        public int insert_Farmer(FarmerTable model)
        {
            string sql = "INSERT INTO FarmerTable (UserName, UserSurname, UserEmail, UserPassword) VALUES (@Name, @Surname, @Email, @Password)";

            // Create SQLiteCommand object with SQLite query and SQLiteConnection
            using (SqliteCommand cmd = new SqliteCommand(sql, con))
            {
                // Adding parameters to the SQLite query
                cmd.Parameters.AddWithValue("@Name", model.Name);
                cmd.Parameters.AddWithValue("@Surname", model.Surname);
                cmd.Parameters.AddWithValue("@Email", model.Email);
                cmd.Parameters.AddWithValue("@Password", model.Password);

                // Open the database connection and verify if it's successful
                try
                {
                    // Check if connection is open, if not, open it
                    if (con.State != System.Data.ConnectionState.Open)
                    {
                        con.Open();
                        Console.WriteLine("Database connection opened successfully.");
                    }

                    // Execute the query and get the number of rows affected
                    int resultAffected = cmd.ExecuteNonQuery();

                    // Return the number of rows affected
                    return resultAffected;
                }
                catch (Exception ex)
                {
                    // Log the exception if the connection or query fails
                    Console.WriteLine($"Error: {ex.Message}");
                    return 0;
                }
                finally
                {
                    // Ensure the connection is closed
                    if (con.State == System.Data.ConnectionState.Open)
                    {
                        con.Close();
                        Console.WriteLine("Database connection closed.");
                    }
                }
            }
        }

        public int update_FarmerDetails(FarmerTable model)
        {
            string sql = "UPDATE FarmerTable SET UserName = @Name, UserSurname = @Surname, UserEmail = @Email, UserPassword = @Password WHERE UserID = @UserID";

            // create SQLiteCommand object with SQLite query and SQLiteConnection
            using SqliteCommand cmd = new SqliteCommand(sql, con);

            // adding parameters to the SQLite query
            cmd.Parameters.AddWithValue("@UserID", model.UserID);
            cmd.Parameters.AddWithValue("@Name", model.Name);
            cmd.Parameters.AddWithValue("@Surname", model.Surname);
            cmd.Parameters.AddWithValue("@Email", model.Email);
            cmd.Parameters.AddWithValue("@Password", model.Password);

            // open the database connection
            con.Open();

            // executing the SQLite query + getting the number of rows affected 
            int resultAffected = cmd.ExecuteNonQuery();

            // close the database connection
            con.Close();

            // returns the number of rows affected by the query
            return resultAffected;
        }

        // method to show a single lecturers - details
        public FarmerTable get_FarmerDetails(int userId)
        {
            string sql = "SELECT * FROM FarmerTable WHERE UserID = @UserID";

            // create SQLiteCommand object with SQLite query and SQLConnection
            using SqliteCommand cmd = new SqliteCommand(sql, con);

            // adding parameters to the SQLite query
            cmd.Parameters.AddWithValue("@UserID", userId);

            // open the database connection
            con.Open();

            using SqliteDataReader reader = cmd.ExecuteReader();

            FarmerTable farmer = null;

            if (reader.Read())
            {
                farmer = new FarmerTable
                {
                    UserID = Convert.ToInt32(reader["UserID"]),
                    Name = reader["UserName"].ToString(),
                    Surname = reader["UserSurname"].ToString(),
                    Email = reader["UserEmail"].ToString(),
                    Password = reader["UserPassword"].ToString(),
                };
            }

            con.Close();
            return farmer;
        }

        // method to delete a farmer
        public int delete_Farmer(int userId)
        {
            string sql = "DELETE FROM FarmerTable WHERE UserID = @UserID";

            // create SQLiteCommand object with SQLite query and SQLiteConnection
            using SqliteCommand cmd = new SqliteCommand(sql, con);

            // adding parameters to the SQLite query
            cmd.Parameters.AddWithValue("@UserID", userId);

            // open the database connection
            con.Open();

            int resultAffected = cmd.ExecuteNonQuery();

            con.Close();

            return resultAffected;
        }

        // method to show all the farmers - details
        public List<FarmerTable> get_AllFarmers()
        {
            string sql = "SELECT * FROM FarmerTable";

            // create SQLiteCommand object with SQLite query and SQLiteConnection
            using SqliteCommand cmd = new SqliteCommand(sql, con);

            // open the database connection
            con.Open();

            using SqliteDataReader reader = cmd.ExecuteReader();

            List<FarmerTable> farmers = new List<FarmerTable>();

            while (reader.Read())
            {
                farmers.Add(new FarmerTable
                {
                    UserID = Convert.ToInt32(reader["UserID"]),
                    Name = reader["UserName"].ToString(),
                    Surname = reader["UserSurname"].ToString(),
                    Email = reader["UserEmail"].ToString(),
                    Password = reader["UserPassword"].ToString(),
                });
            }

            con.Close();
            return farmers;
        }
    }
}

//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<//