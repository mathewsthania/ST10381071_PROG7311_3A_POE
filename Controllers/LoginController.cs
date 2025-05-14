using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using ST10381071_PROG7311_3A_POE.Models;

//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<*THE*START*OF*FILE*<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<//

namespace ST10381071_PROG7311_3A_POE.Controllers
{
    public class LoginController : Controller
    {
        // creating an instance of the Lecturer and ProgAcademic class, to access data - database
        public FarmerTable farmTbl = new FarmerTable();
        public EmployeeTable employTbl = new EmployeeTable();


        // Action method - handling the default index view
        public IActionResult Index()
        {
            return View();
        }

        // creating a LoginModel instance - for managing the login operations
        private readonly LoginModel login;

        // creating a constructor for the LoginController class
        public LoginController()
        {
            login = new LoginModel();
        }

        // Action method for handling POST requests for user privacy
        [HttpPost]
        public async Task<IActionResult> UserLogin(string name, string email, string password)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ViewBag.ErrorMessage = "Please fill in all the fields!";
                ViewBag.Name = name;
                ViewBag.Email = email;
                return View("~/Views/Home/Login.cshtml");
            }

            // checking for farmer
            int farmerID = login.SelectFarmer(name, email, password);

            // checking for the emplpoyee
            int employeeID = login.SelectEmployee(name, email, password);


            if (farmerID != -1)
            {
                HttpContext.Session.SetString("UserName", name);
                HttpContext.Session.SetString("UserRole", "Farmer");

                return RedirectToAction("AddProduct", "Home", new { UserID = farmerID });
            }

            else if (employeeID != -1)
            {

                HttpContext.Session.SetString("UserName", name);
                HttpContext.Session.SetString("UserRole", "Employee");

                return RedirectToAction("ManageFarmerDetails", "Home", new { UserID = employeeID });
            }


            else
            {
                ViewBag.ErrorMessage = "Name or Email or Password entered is incorrect, Please try again!";
                // User not found, handle accordingly (e.g., show error message)
                ViewBag.Name = name;
                ViewBag.Email = email;
                return View("~/Views/Home/Login.cshtml");
            }
        }

        [HttpGet]
        public IActionResult Login()
        {
            // Returns the login view page
            return View("~/Views/Home/Login.cshtml");
        }

    }
}

//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<*THE*END*OF*FILE*<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<//
