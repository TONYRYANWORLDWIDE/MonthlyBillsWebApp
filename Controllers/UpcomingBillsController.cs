﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MonthlyBillsWebApp.Models;
using PagedList;

namespace MonthlyBillsWebApp.Controllers
{
    public class UpcomingBillsController : Controller
    {
        private BillsEntities db = new BillsEntities();

        // GET: UpcomingBills
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
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
            var upcomingbills = from u in db.UpcomingBills
                                select u;
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
                    //upcomingbills = upcomingbills.OrderBy(s => s.Type);
                    //break;
                    upcomingbills = upcomingbills.OrderBy(s => s.TheDate);
                    break;
            }

            int pageSize = (upcomingbills.Count() / 6) + 1;
            int pageNumber = (page ?? 1);
            return View(upcomingbills.ToPagedList(pageNumber, pageSize));
            //return View(upcomingbills.ToList());
        }

        // GET: UpcomingBills/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UpcomingBill upcomingBill = db.UpcomingBills.Find(id);
            if (upcomingBill == null)
            {
                return HttpNotFound();
            }
            return View(upcomingBill);
        }

        // GET: UpcomingBills/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UpcomingBills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,TheDate,DayOfWeek,Name,Amount,Type,RunningTotal")] UpcomingBill upcomingBill)
        {
            if (ModelState.IsValid)
            {
                db.UpcomingBills.Add(upcomingBill);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(upcomingBill);
        }

        // GET: UpcomingBills/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UpcomingBill upcomingBill = db.UpcomingBills.Find(id);
            if (upcomingBill == null)
            {
                return HttpNotFound();
            }
            return View(upcomingBill);
        }

        // POST: UpcomingBills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,TheDate,DayOfWeek,Name,Amount,Type,RunningTotal")] UpcomingBill upcomingBill)
        {
            if (ModelState.IsValid)
            {
                db.Entry(upcomingBill).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(upcomingBill);
        }

        // GET: UpcomingBills/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UpcomingBill upcomingBill = db.UpcomingBills.Find(id);
            if (upcomingBill == null)
            {
                return HttpNotFound();
            }
            return View(upcomingBill);
        }

        // POST: UpcomingBills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UpcomingBill upcomingBill = db.UpcomingBills.Find(id);
            db.UpcomingBills.Remove(upcomingBill);
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
