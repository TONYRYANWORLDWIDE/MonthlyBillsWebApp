﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MonthlyBillsWebApp.Models;
using System.Security.Claims;

namespace MonthlyBillsWebApp.Controllers
{
    public class WeeklyBillsController : Controller
    {
        private BillsEntities db = new BillsEntities();

        // GET: WeeklyBills
        public string userIdValue { get; private set; }
        public ActionResult Index()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            string ip = Request.UserHostAddress;

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
            var weeklybills = from u in db.WeeklyBills
                               where u.UserID == userIdValue
                               orderby u.Bill
                               select u;

            
            return View(weeklybills.ToList());
        }

        [HttpPost]
        public ActionResult UpdateWeeklyBills(WeeklyBill weeklyBill)
        {
            using (BillsEntities entities = new BillsEntities())
            {
                WeeklyBill updatedBills = (from c in entities.WeeklyBills
                                            where c.id == weeklyBill.id
                                            select c).FirstOrDefault();
                updatedBills.Bill = weeklyBill.Bill;
                updatedBills.Cost = weeklyBill.Cost;
                updatedBills.DayOfWeek = weeklyBill.DayOfWeek;
                entities.SaveChanges();
            }
            return new EmptyResult();
        }


        // GET: WeeklyBills/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WeeklyBills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Bill,Cost,id,DayOfWeek,UserID")] WeeklyBill weeklyBill)
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
                weeklyBill.UserID = userIdValue;

                db.WeeklyBills.Add(weeklyBill);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            return View(weeklyBill);
        }       

        // GET: WeeklyBills/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    WeeklyBill weeklyBill = db.WeeklyBills.Find(id);
        //    if (weeklyBill == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(weeklyBill);
        //}

        //[HttpPost]
        //, ActionName("Delete")
        //[ValidateAntiForgeryToken]
        public ActionResult Deletejq(int? id)
        {
            using (BillsEntities entities = new BillsEntities())
            {

                WeeklyBill weeklyBill = db.WeeklyBills.Find(id);
                db.WeeklyBills.Remove(weeklyBill);
                db.SaveChanges();        
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
