using System.Diagnostics;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.RateLimiting;
using ST10381071_PROG7311_3A_POE.Models;

//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<*THE*START*OF*FILE*<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<//

namespace ST10381071_PROG7311_3A_POE.Controllers
{
    public class HomeController : Controller
    {
        FarmerTable farmTbl = new FarmerTable();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();

        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult Blog()
        {
            return View();

        }

        public IActionResult ContactUs()
        {
            return View();
        }

        public IActionResult ViewFarmerProducts(int farmerUserId, string category = null, string startDate = null, string endDate = null)
        {
            Console.WriteLine("Incoming farmerUserId: " + farmerUserId);

            ViewBag.FarmerUserId = farmerUserId;
            ViewData["Category"] = category;
            ViewData["StartDate"] = startDate;
            ViewData["EndDate"] = endDate;

            ProductTable productTable = new ProductTable();
            var products = productTable.GetProductsByFarmer(farmerUserId, category, startDate, endDate);

            Console.WriteLine("Products returned: " + products.Count);

            return View("~/Views/Home/ViewFarmerProducts.cshtml", products);
        }

        public IActionResult ManageFarmerDetails()
        {
            var farmers = farmTbl.get_AllFarmers();
            return View("~/Views/Home/ManageFarmerDetails.cshtml", farmers);
        }

        [HttpGet]
        public IActionResult AddProduct(int userId)
        {
            var model = new Product
            {
                FarmerUserID = userId 
            };

            return View(model); 
        }

        [HttpPost]
        public IActionResult AddProduct(Product model)
        {
            ProductTable productTable = new ProductTable();
            int result = productTable.Insert_Product(model);

            if (result > 0)
                return RedirectToAction("ManageFarmerProducts", new { userId = model.FarmerUserID });
            else
                return View("Error"); // Handle failed insert
        }

        public IActionResult ManageFarmerProducts(int userId)
        {
            ViewBag.FarmerUserId = userId;

            ProductTable productTable = new ProductTable();
            var products = productTable.GetProductsByFarmer(userId, null, null, null);

            return View(products);
        }

        public IActionResult EditProduct(int id)
        {
            ProductTable productTable = new ProductTable();
            var product = productTable.GetProductById(id);

            if (product == null)
                return NotFound();

            return View(product);
        }

        // POST: Edit Product
        [HttpPost]
        public IActionResult EditProduct(Product model)
        {
            if (ModelState.IsValid)
            {
                ProductTable productTable = new ProductTable();
                int result = productTable.UpdateProduct(model);

                if (result > 0)
                    return RedirectToAction("ManageFarmerProducts", new { userId = model.FarmerUserID });
            }

            return View(model); // Show validation errors
        }

        public IActionResult DeleteProduct(int id)
        {
            ProductTable productTable = new ProductTable();
            var product = productTable.GetProductById(id);

            if (product == null)
                return NotFound();

            int result = productTable.DeleteProduct(id);

            // Redirect back to the manage page with correct userId
            return RedirectToAction("ManageFarmerProducts", new { userId = product.FarmerUserID });
        }

        public IActionResult SignUp()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View("Login");
        }

        public IActionResult Logout()
        {
            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}


//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<*THE*END*OF*FILE*<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<//