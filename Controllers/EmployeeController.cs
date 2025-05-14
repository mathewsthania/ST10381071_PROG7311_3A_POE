using Microsoft.AspNetCore.Mvc;
using ST10381071_PROG7311_3A_POE.Models;

//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<*THE*START*OF*FILE*<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<//

namespace ST10381071_PROG7311_3A_POE.Controllers
{
    public class EmployeeController : Controller
    {
        FarmerTable farmTbl = new FarmerTable();

        // method/ action to display all the farmers thats signed up with the system
        public ActionResult ManageFarmerDetails()
        {
            var farmers = farmTbl.get_AllFarmers();
            return View("~/Views/Home/ManageFarmerDetails.cshtml", farmers);
        }

        // method/ action to edit a farmers details, getting info by their ID
        public ActionResult EditFarmer(int id)
        {
            var farmer = farmTbl.get_FarmerDetails(id);
            if (farmer == null)
            {
                return NotFound();
            }

            return View("~/Views/Home/EditFarmer.cshtml", farmer);
        }

        // the action to handle the form submission to edit a farmer
        [HttpPost]
        public ActionResult EditFarmer(FarmerTable model)
        {
            if (ModelState.IsValid)
            {
                farmTbl.update_FarmerDetails(model);
                return RedirectToAction("ManageFarmerDetails");
            }
            return View(model);
        }

        // method/ action to delete a farmer by their id
        public ActionResult DeleteFarmer(int id)
        {
            farmTbl.delete_Farmer(id);
            return RedirectToAction("ManageFarmerDetails");
        }

        [HttpPost]
        public ActionResult AddNewFarmer(FarmerTable model)
        {
            if (ModelState.IsValid)
            {
                farmTbl.insert_Farmer(model);
                return RedirectToAction("ManageFarmerDetails");
            }

            return View(model);
        }
        public ActionResult AddNewFarmer()
        {
            return View("~/Views/Home/AddNewFarmer.cshtml");
        }
    }
}

//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<*THE*END*OF*FILE*<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<//