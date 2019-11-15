using System;
using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MonthlyBillsWebApp.Models;
using System.Dynamic;
using System.Security.Claims;
using System.Data.Entity.Infrastructure;
//using Expando;

namespace MonthlyBillsWebApp.Controllers
{
    [RequireHttps]
    public class MonthlyBillsController : Controller
    {
        private BillsEntities db = new BillsEntities();
        public string userIdValue { get; private set; }
       // public int id { get; private set; }
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
            var monthlybills = from u in db.MonthlyBills
                               where u.UserID == userIdValue
                               orderby u.Bill
                               select u;
            return View(monthlybills.ToList());
            //return View(monthlybills);
        }
        [HttpPost]
        public System.Web.Mvc.JsonResult InsertMonthlyBills(MonthlyBill monthlyBill)
        {
            using (BillsEntities entities = new BillsEntities())
            {
                entities.MonthlyBills.Add(monthlyBill);
                entities.SaveChanges();
            }
            return Json(monthlyBill);
        }
        [HttpPost]
        public ActionResult UpdateMonthlyBills(MonthlyBill monthlyBill)
        {
            using (BillsEntities entities = new BillsEntities())
            {
                MonthlyBill updatedBills = (from c in entities.MonthlyBills
                                            where c.id == monthlyBill.id
                                            select c).FirstOrDefault();
                updatedBills.Bill = monthlyBill.Bill;
                updatedBills.Date = monthlyBill.Date;
                updatedBills.Cost = monthlyBill.Cost;
                updatedBills.Paid_ = monthlyBill.Paid_;
                entities.SaveChanges();
            }
            //return View(monthlyBill);
            return RedirectToAction("Index");
        }
        
        [HttpPost]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonthlyBill monthlyBill = db.MonthlyBills.Find(id);
            if (monthlyBill == null)
            {
                return HttpNotFound();
            }
            return View(monthlyBill);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Bill,Cost,Date,BillAlias")] MonthlyBill monthlyBill)
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
            if (ModelState.IsValid)
            {
                monthlyBill.UserID = userIdValue;
                db.MonthlyBills.Add(monthlyBill);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(monthlyBill);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonthlyBill monthlyBill = db.MonthlyBills.Find(id);
            if (monthlyBill == null)
            {
                return HttpNotFound();
            }           
            return View(monthlyBill);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Bill,Cost,Date,BillAlias,Paid_")] MonthlyBill monthlyBill)
        {
            if (ModelState.IsValid)
            {
                db.Entry(monthlyBill).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(monthlyBill);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonthlyBill monthlyBill = db.MonthlyBills.Find(id);
            if (monthlyBill == null)
            {
                return HttpNotFound();
            }
            return View(monthlyBill);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            using (BillsEntities entities = new BillsEntities())
            {
                MonthlyBill mb = (from c in entities.MonthlyBills
                                  where c.id == id
                                  select c).FirstOrDefault();
                entities.MonthlyBills.Remove(mb);
                entities.SaveChanges();
            }

            return RedirectToAction("Index");
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
