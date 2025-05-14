using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using ST10381071_PROG7311_3A_POE.Models;

//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<*THE*START*OF*FILE*<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<//

namespace ST10381071_PROG7311_3A_POE.Controllers
{
    public class ProductController : Controller
    {
        [HttpPost]
        public IActionResult AddProduct(Product model)
        {
            ProductTable productTable = new ProductTable();
            int result = productTable.Insert_Product(model);

            if (result > 0)
                return RedirectToAction("ProductList"); // Or wherever you want to redirect
            else
                return View("Error"); // Handle failed insert
        }

        public IActionResult ViewFarmerProducts(int farmerUserId)
        {
            ProductTable productTable = new ProductTable();
            List<Product> products = productTable.GetProductsByFarmer(farmerUserId);

            ViewBag.FarmerUserId = farmerUserId;

            return View(products); // This must not be null
        }

        public IActionResult ListFarmers()
        {
            // Fetch all farmers (you can use the FarmerTable model to get the farmers)
            List<Farmer> farmers = new List<Farmer>();

            // Fetch farmers from the database or use a method that retrieves farmers
            // For simplicity, let’s assume you have a method to fetch all farmers

            using (var conn = new SqliteConnection(ProductTable.con_string))
            {
                conn.Open();
                var cmd = new SqliteCommand("SELECT * FROM FarmerTable", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        farmers.Add(new Farmer
                        {
                            UserID = Convert.ToInt32(reader["UserID"]),
                            UserName = reader["UserName"].ToString(),
                            UserSurname = reader["UserSurname"].ToString()
                        });
                    }
                }
            }

            return View(farmers); // Return to a view that lists all farmers
        }
    }
}

//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<*THE*END*OF*FILE*<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<//