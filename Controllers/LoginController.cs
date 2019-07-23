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
        public ActionResult Authorize(MonthlyBillsWebApp.Models.UserOG userModel)
        {
            using (BillsEntities db = new BillsEntities())
            {
                var userDetails = db.UserOGs.Where(x => x.UserName == userModel.UserName && x.Password == userModel.Password).FirstOrDefault();
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
        //public ActionResult LogOut()
        //{ 
        //    int userId = (int)Session["userID"];
        //    Session.Abandon();
        //    return RedirectToAction("Index", "Login");
        //}
        [HttpGet]
        public ActionResult AddOrEdit(int UseID = 0)
        {
            UserOG userModel = new UserOG();
            return View(userModel);
        }
        [HttpPost]
        public ActionResult AddOrEdit(UserOG usermodel)
        {
            using (BillsEntities db2 = new BillsEntities())
            {
                if(db2.UserOGs.Any(x => x.UserName == usermodel.UserName))
                {
                    ViewBag.DuplicateMessage = "Username already exists. Please try again.";
                    return View("AddOrEdit", usermodel);
                }
                db2.UserOGs.Add(usermodel);
                db2.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registration Successful";
            //return View("AddOrEdit", new UserOG());
            return RedirectToAction("Index", "Login");

        }
    }
}