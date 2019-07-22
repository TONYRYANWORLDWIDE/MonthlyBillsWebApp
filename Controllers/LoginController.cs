using MonthlyBillsWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MonthlyBillsWebApp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Authorize(MonthlyBillsWebApp.Models.User userModel)
        {
            using (BillsEntities db = new BillsEntities())
            {
                var userDetails = db.Users.Where(x => x.UserName == userModel.UserName && x.Password == userModel.Password).FirstOrDefault();
                if (userDetails == null)
                {
                    userModel.LoginErrorMessage = "Wrong Username or Password.";
                    return View("Index", userModel);
                }
                else
                {
                    Session["userID"] = userDetails.UseID;
                    Session["userName"] = userDetails.UserName;
                    return RedirectToAction("Index", "MonthlyBills");
                }            
            }
        }
        public ActionResult LogOut()
        { 
            int userId = (int)Session["userID"];
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
        public ActionResult AddOrEdit(int id = 0)
        {
            User userModel = new User();
            return View(userModel);
        }
    }
}