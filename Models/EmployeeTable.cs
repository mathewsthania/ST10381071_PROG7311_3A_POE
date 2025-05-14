using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;

//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<*THE*START*OF*FILE*<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<//

namespace ST10381071_PROG7311_3A_POE.Models
{
    public class EmployeeTable

    {
        // Connection string for connecting to the SQLite database
        public static string con_string = "Data Source=Database/POE2Database.db";

        // SQLiteConnection objct. for managing the database connection
        public static SqliteConnection con = new SqliteConnection(con_string);


        // properties for storing the user information
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }


        // Method for inserting user data into the database
        public int insert_Employee(EmployeeTable model)
        {
            string sql = "INSERT INTO EmployeeTable (UserName, UserSurname, UserEmail, UserPassword) VALUES (@Name, @Surname, @Email, @Password)";

            // create SQLliteCommand object with SQLite query and SQLiteConnection
            using SqliteCommand cmd = new SqliteCommand(sql, con);

            // adding parameters to the SQL query
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
    }
}

//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<//
