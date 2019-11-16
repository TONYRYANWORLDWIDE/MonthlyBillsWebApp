using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using MonthlyBillsWebApp.Models;
using PagedList;

namespace MonthlyBillsWebApp.Controllers
{
    public class UpcomingBillsController : Controller
    {
        private BillsEntities db = new BillsEntities();
        public string userIdValue { get; private set; }

        // GET: UpcomingBills
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
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
            using (var context = new BillsEntities())
            {
                context.sp_DateOfEachBill();
            }
             ViewBag.CurrentSort = sortOrder;
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            var upcomingbills = from up in db.UpcomingBills
                                where up.UserID == userIdValue
                                select up;
            if (!String.IsNullOrEmpty(searchString))
            {
                upcomingbills = upcomingbills.Where(s => s.Name.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "Date":
                    upcomingbills = upcomingbills.OrderBy(s => s.TheDate);
                    break;
                default:
                    upcomingbills = upcomingbills.OrderBy(s => s.TheDate);
                    break;
            }
            int pageSize = 20;              

            int pageNumber = (page ?? 1);
            return View(upcomingbills.ToPagedList(pageNumber, pageSize));
        }

       
       
       
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
