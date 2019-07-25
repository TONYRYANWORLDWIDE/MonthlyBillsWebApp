﻿using System;
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

        // GET: MonthlyBills

        //public ActionResult Index()
        //{
        //    BillsEntities entities = new BillsEntities();
        //    List<MonthlyBill> monthlyBills = entities.MonthlyBills.ToList();


        //    //Add a Dummy Row.
        //    monthlyBills.Insert(0, new MonthlyBill());
        //    return View(monthlyBills);
        //}
        public ActionResult Index()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            //if (claimsIdentity != null)
            //{
            // the principal identity is a claims identity.
            // now we need to find the NameIdentifier claim
            var userIdClaim = claimsIdentity.Claims
                .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

            if (userIdClaim != null)
            {
                userIdValue = userIdClaim.Value;
            }
            var monthlybills = from u in db.MonthlyBills
                               where u.UserID == userIdValue
                               orderby u.Bill
                               select u;

            //return View(monthlybills.ToList());
            return View(monthlybills);

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
                entities.SaveChanges();
            }

            //var monthlybills = from u in db.MonthlyBills
            //                   where u.UserID == userIdValue
            //                   orderby u.Bill
            //                   select u;

            //return View(monthlybills.ToList());

           return new EmptyResult();
          
        }
        [HttpPost]
        public ActionResult DeleteCustomer(int id)
        {
            using (BillsEntities entities = new BillsEntities())
            {
                MonthlyBill  mb = (from c in entities.MonthlyBills
                                     where c.id == id
                                     select c).FirstOrDefault();
                entities.MonthlyBills.Remove(mb);
                entities.SaveChanges();
            }

            var monthlybills = from u in db.MonthlyBills
                               where u.UserID == userIdValue
                               orderby u.Bill
                               select u;

            return View(monthlybills.ToList());

        }


        [HttpPost]
        // GET: MonthlyBills/Details/5
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

        // GET: MonthlyBills/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: MonthlyBills/Create
        // TO DO // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Bill,Cost,Date,BillAlias")] MonthlyBill monthlyBill)
        {
            if (ModelState.IsValid)
            {
                db.MonthlyBills.Add(monthlyBill);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(monthlyBill);
        }
        // GET: MonthlyBills/Edit/5
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
        // POST: MonthlyBills/Edit/5
        // TO DO // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Bill,Cost,Date,BillAlias")] MonthlyBill monthlyBill)
        {
            if (ModelState.IsValid)
            {
                db.Entry(monthlyBill).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(monthlyBill);
        }
        // GET: MonthlyBills/Delete/5
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
        // POST: MonthlyBills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MonthlyBill monthlyBill = db.MonthlyBills.Find(id);
            db.MonthlyBills.Remove(monthlyBill);
            db.SaveChanges();
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
