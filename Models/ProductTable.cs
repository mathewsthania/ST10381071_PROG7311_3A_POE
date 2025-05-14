using System;
using System.Data;
using Microsoft.Data.Sqlite;
using ST10381071_PROG7311_3A_POE.Models;

//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<*THE*START*OF*FILE*<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<//

namespace ST10381071_PROG7311_3A_POE.Models
{
    public class ProductTable
    {
        // Use the same connection string as your FarmerTable or read from appsettings.json
        public static string con_string = "Data Source=C:\\Users\\mathe\\OneDrive\\Desktop\\VARSITY\\BCA3 YEAR 3\\SEMESTER 1\\PROG7311 3A\\DB BROSWER\\POE2Database.db";

        public static SqliteConnection con = new SqliteConnection(con_string);

        // Method for inserting a new product
        public int Insert_Product(Product model)
        {
            string sql = "INSERT INTO Product (Name, Category, ProductionDate, Price, FarmerUserID) VALUES (@Name, @Category, @ProductionDate, @Price, @FarmerUserID)";

            using (SqliteCommand cmd = new SqliteCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@Name", model.Name);
                cmd.Parameters.AddWithValue("@Category", model.Category);
                cmd.Parameters.AddWithValue("@ProductionDate", model.ProductionDate);
                cmd.Parameters.AddWithValue("@Price", model.Price);
                cmd.Parameters.AddWithValue("@FarmerUserID", model.FarmerUserID);

                try
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                        Console.WriteLine("Database connection opened successfully.");
                    }
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error inserting product: {ex.Message}");
                    return 0;
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                        Console.WriteLine("Database connection closed.");
                    }
                }
            }
        }

        public List<Product> GetProductsByFarmer(int farmerUserId, string category = null, string startDate = null, string endDate = null)
        {
            List<Product> products = new List<Product>();

            var sql = "SELECT * FROM Product WHERE FarmerUserID = @FarmerUserID";
            if (!string.IsNullOrEmpty(category))
                sql += " AND Category = @Category";
            if (!string.IsNullOrEmpty(startDate))
                sql += " AND ProductionDate >= @StartDate";
            if (!string.IsNullOrEmpty(endDate))
                sql += " AND ProductionDate <= @EndDate";

            using (SqliteCommand cmd = new SqliteCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@FarmerUserID", farmerUserId);
                if (!string.IsNullOrEmpty(category))
                    cmd.Parameters.AddWithValue("@Category", category);
                if (!string.IsNullOrEmpty(startDate))
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                if (!string.IsNullOrEmpty(endDate))
                    cmd.Parameters.AddWithValue("@EndDate", endDate);

                try
                {
                    if (con.State != System.Data.ConnectionState.Open)
                        con.Open();

                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            products.Add(new Product
                            {
                                ProductID = Convert.ToInt32(reader["ProductID"]),
                                Name = reader["Name"].ToString(),
                                Category = reader["Category"].ToString(),
                                ProductionDate = reader["ProductionDate"].ToString(),
                                Price = Convert.ToDouble(reader["Price"]),
                                FarmerUserID = Convert.ToInt32(reader["FarmerUserID"])
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error fetching products: " + ex.Message);
                }
                finally
                {
                    if (con.State == System.Data.ConnectionState.Open)
                        con.Close();
                }
            }

            return products;
        }
    }
}

//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<*THE*END*OF*FILE*<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<//

