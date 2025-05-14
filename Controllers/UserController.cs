using Microsoft.AspNetCore.Mvc;
using ST10381071_PROG7311_3A_POE.Models;

//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<*THE*START*OF*FILE*<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<//

namespace ST10381071_PROG7311_3A_POE.Controllers
{
    public class UserController : Controller
    {
        // instantiate UserTable object to interact with the database
        public FarmerTable farmTbl = new FarmerTable();
        public EmployeeTable employTbl = new EmployeeTable();

        // Action method to handle SignUp POST request
        [HttpPost]
        public ActionResult SignUp(string role, string name, string surname, string email, string password)
        {
            if (role == "Farmer")
            {
                var farmer = new FarmerTable
                {
                    Name = name,
                    Surname = surname,
                    Email = email,
                    Password = password
                };

                var result = farmTbl.insert_Farmer(farmer);
            }
            else if (role == "Employee")
            {
                var employee = new EmployeeTable
                {
                    Name = name,
                    Surname = surname,
                    Email = email,
                    Password = password
                };

                var result = employTbl.insert_Employee(employee);
            }
            // redirecting to Home/Index action after a successful SignUp
            return RedirectToAction("ManageFarmerDetails", "Home");
        }

        // Action Method to handle SignUp GET request
        [HttpGet]
        public ActionResult SignUp()
        {
            // return the SignUp view with the UserTable object
            return View();
        }
    }
}

//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<*THE*END*OF*FILE*<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<//
