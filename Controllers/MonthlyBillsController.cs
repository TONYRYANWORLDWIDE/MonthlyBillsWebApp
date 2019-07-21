using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MonthlyBillsWebApp.Models;
using System.Dynamic;
//using Expando;

namespace MonthlyBillsWebApp.Controllers
{
    public class MonthlyBillsController : Controller
    {
        private BillsEntities db = new BillsEntities();
        // GET: MonthlyBills
        public ActionResult Index()
        {
            dynamic mymodel = new ExpandoObject();
            var monthlybills = from u in db.MonthlyBills
                               orderby u.Bill
                               select u;
            var KeyBalance = from k in db.KeyBalances
                             select k;
            mymodel.MonthlyBills = monthlybills.ToList();
            mymodel.KeyBalance = KeyBalance.ToList();
            return View(mymodel);
        }

        //public ActionResult IndexViewModel()
        //{
        //    ViewModel mymodel = new ViewModel(); //Need to create a class containing both models??
        //    var monthlybills = from u in db.MonthlyBills
        //                       orderby u.Bill
        //                       select u;
        //    var KeyBalance = from k in db.KeyBalances
        //                     select k;
        //    mymodel.MonthlyBills = monthlybills.ToList();
        //    mymodel.KeyBalance = KeyBalance.ToList();
        //    return View(mymodel);
        //}

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
                db.Entry(monthlyBill).State = EntityState.Modified;
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
