using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MonthlyBillsWebApp.Models;

namespace MonthlyBillsWebApp.Controllers
{
    public class WeeklyBillsController : Controller
    {
        private BillsEntities db = new BillsEntities();

        // GET: WeeklyBills
        public ActionResult Index()
        {
            return View(db.WeeklyBills.ToList());
        }

        // GET: WeeklyBills/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeeklyBill weeklyBill = db.WeeklyBills.Find(id);
            if (weeklyBill == null)
            {
                return HttpNotFound();
            }
            return View(weeklyBill);
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
        public ActionResult Create([Bind(Include = "Bill,Cost,id")] WeeklyBill weeklyBill)
        {
            if (ModelState.IsValid)
            {
                db.WeeklyBills.Add(weeklyBill);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(weeklyBill);
        }

        // GET: WeeklyBills/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeeklyBill weeklyBill = db.WeeklyBills.Find(id);
            if (weeklyBill == null)
            {
                return HttpNotFound();
            }
            return View(weeklyBill);
        }

        // POST: WeeklyBills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Bill,Cost,id")] WeeklyBill weeklyBill)
        {
            if (ModelState.IsValid)
            {
                db.Entry(weeklyBill).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(weeklyBill);
        }

        // GET: WeeklyBills/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeeklyBill weeklyBill = db.WeeklyBills.Find(id);
            if (weeklyBill == null)
            {
                return HttpNotFound();
            }
            return View(weeklyBill);
        }

        // POST: WeeklyBills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WeeklyBill weeklyBill = db.WeeklyBills.Find(id);
            db.WeeklyBills.Remove(weeklyBill);
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
