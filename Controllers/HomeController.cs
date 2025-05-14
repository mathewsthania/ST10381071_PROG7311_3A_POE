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

        public IActionResult ViewFarmerProducts()
        {
            return View();
        }

        public IActionResult ManageFarmerDetails()
        {
            var farmers = farmTbl.get_AllFarmers();
            return View("~/Views/Home/ManageFarmerDetails.cshtml", farmers);
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