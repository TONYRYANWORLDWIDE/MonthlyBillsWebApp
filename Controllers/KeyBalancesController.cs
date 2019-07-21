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
    public class KeyBalancesController : Controller
    {
        private BillsEntities db = new BillsEntities();

        // GET: KeyBalances
        public ActionResult Index()
        {
            return View(db.KeyBalances.ToList());
          

        }

        // GET: KeyBalances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KeyBalance keyBalance = db.KeyBalances.Find(id);
            if (keyBalance == null)
            {
                return HttpNotFound();
            }
            return View(keyBalance);
        }

        // GET: KeyBalances/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KeyBalances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,KeyBalance1,DateTime")] KeyBalance keyBalance)
        {
            if (ModelState.IsValid)
            {
                db.KeyBalances.Add(keyBalance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(keyBalance);
        }

        // GET: KeyBalances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KeyBalance keyBalance = db.KeyBalances.Find(id);
            if (keyBalance == null)
            {
                return HttpNotFound();
            }
            return View(keyBalance);
        }

        // POST: KeyBalances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,KeyBalance1,DateTime")] KeyBalance keyBalance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(keyBalance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(keyBalance);
        }

        // GET: KeyBalances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KeyBalance keyBalance = db.KeyBalances.Find(id);
            if (keyBalance == null)
            {
                return HttpNotFound();
            }
            return View(keyBalance);
        }

        // POST: KeyBalances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KeyBalance keyBalance = db.KeyBalances.Find(id);
            db.KeyBalances.Remove(keyBalance);
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
