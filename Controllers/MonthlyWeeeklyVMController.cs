using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Security.Claims;
using MonthlyBillsWebApp.Models;
using MonthlyBillsWebApp.ViewModels;

using System.Dynamic;
using System.Data.Entity.Infrastructure;

namespace MonthlyBillsWebApp.Controllers
{
    public class MonthlyWeeeklyVMController : Controller
    {
        private BillsEntities db = new BillsEntities();
        public string userIdValue { get; private set; }

        public ActionResult Index()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;

            var userIdClaim = claimsIdentity.Claims
                .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            if (userIdClaim != null)
            {
                userIdValue = userIdClaim.Value;
            }
            else
            {
                userIdValue = "tempuser";
            }


            var monthlyBill = (from u in db.MonthlyBills
                               where u.UserID == userIdValue
                               orderby u.Date
                               select u).FirstOrDefault();

            var weeklyBill = (from v in db.WeeklyBills
                              where v.UserID == userIdValue
                              orderby v.Bill
                              select v).FirstOrDefault();


            ViewModelMonthlyWeekly viewModel = new ViewModelMonthlyWeekly { monthlyBills = monthlyBill, weeklyBills = weeklyBill }; ;

   
            //viewModel.monthlyBills = monthlyBills;
            //viewModel.weeklyBills = weeklyBills;


            return View(viewModel);
        }

        //public ActionResult MonthlyWeekly(ViewModelMonthlyWeekly mw)
        //{



          



        //}
        //private BillsEntities db = new BillsEntities();
        //public string userIdValue { get; private set; }
        //// GET: MonthlyWeeeklyVM
        //public ActionResult Index()
        //{
        //    var claimsIdentity = User.Identity as ClaimsIdentity;

        //    var userIdClaim = claimsIdentity.Claims
        //        .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
        //    if (userIdClaim != null)
        //    {
        //        userIdValue = userIdClaim.Value;
        //    }
        //    else
        //    {
        //        userIdValue = "tempuser";
        //    }
        //    //var monthlybills = from u in db.MonthlyBills
        //    //                   //where u.UserID == userIdValue
        //    //                   orderby u.Date
        //    //                   select u;

        //    //var weeklybills = from u in db.WeeklyBills
        //    //                  where u.UserID == userIdValue
        //    //                  orderby u.Bill
        //    //                  select u;

        //    var ViewModelMonthlyWeekly = new ViewModelMonthlyWeekly()
        //    {
        //        monthlyBills = monthlybills,
        //        weeklyBills = weeklybills
        //    };





    }
    
}