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

        public List<Product> GetProductsByFarmer(int farmerId, string category, string startDate, string endDate)
        {
            List<Product> products = new List<Product>();
            using (var con = new SqliteConnection(con_string))
            {
                con.Open();
                string sql = "SELECT * FROM Product WHERE FarmerUserID = @FarmerUserID";

                if (!string.IsNullOrEmpty(category))
                {
                    sql += " AND Category LIKE @Category";
                }

                if (!string.IsNullOrEmpty(startDate))
                {
                    sql += " AND ProductionDate >= @StartDate";
                }

                if (!string.IsNullOrEmpty(endDate))
                {
                    sql += " AND ProductionDate <= @EndDate";
                }

                using (var cmd = new SqliteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@FarmerUserID", farmerId);

                    if (!string.IsNullOrEmpty(category))
                        cmd.Parameters.AddWithValue("@Category", $"%{category}%");

                    if (!string.IsNullOrEmpty(startDate))
                        cmd.Parameters.AddWithValue("@StartDate", startDate);

                    if (!string.IsNullOrEmpty(endDate))
                        cmd.Parameters.AddWithValue("@EndDate", endDate);

                    using (var reader = cmd.ExecuteReader())
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
            }
            return products;
        }

        public Product GetProductById(int id)
        {
            using (var con = new SqliteConnection(con_string))
            {
                con.Open();
                string sql = "SELECT * FROM Product WHERE ProductID = @ProductID";

                using (var cmd = new SqliteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@ProductID", id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Product
                            {
                                ProductID = Convert.ToInt32(reader["ProductID"]),
                                Name = reader["Name"].ToString(),
                                Category = reader["Category"].ToString(),
                                ProductionDate = reader["ProductionDate"].ToString(),
                                Price = Convert.ToDouble(reader["Price"]),
                                FarmerUserID = Convert.ToInt32(reader["FarmerUserID"])
                            };
                        }
                    }
                }
            }
            return null;
        }

        public int UpdateProduct(Product product)
        {
            using (var con = new SqliteConnection(con_string))
            {
                con.Open(); 

                string sql = "UPDATE Product SET Name = @Name, Category = @Category, ProductionDate = @ProductionDate, Price = @Price WHERE ProductID = @ProductID";

                using (var cmd = new SqliteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Name", product.Name);
                    cmd.Parameters.AddWithValue("@Category", product.Category);
                    cmd.Parameters.AddWithValue("@ProductionDate", product.ProductionDate);
                    cmd.Parameters.AddWithValue("@Price", product.Price);
                    cmd.Parameters.AddWithValue("@ProductID", product.ProductID);

                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public int DeleteProduct(int id)
        {
            using (var con = new SqliteConnection(con_string))
            {
                con.Open();
                string sql = "DELETE FROM Product WHERE ProductID = @ProductID";

                using (var cmd = new SqliteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@ProductID", id);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<*THE*END*OF*FILE*<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<//

