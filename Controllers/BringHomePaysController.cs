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

namespace MonthlyBillsWebApp.Controllers
{
    public class BringHomePaysController : Controller
    {
        private BillsEntities db = new BillsEntities();
        public string userIdValue { get; private set; }
        // GET: BringHomePays
        public ActionResult Index()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            if (claimsIdentity != null)
            {
                // the principal identity is a claims identity.
                // now we need to find the NameIdentifier claim
                var userIdClaim = claimsIdentity.Claims
                    .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

                if (userIdClaim != null)
                {
                    userIdValue = userIdClaim.Value;
                }
            }
            var bringhome = from u in db.BringHomePays
                          where u.UserID == userIdValue
                          select u;

            return View(bringhome.ToList());
        }

        // GET: BringHomePays/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BringHomePay bringHomePay = db.BringHomePays.Find(id);
            if (bringHomePay == null)
            {
                return HttpNotFound();
            }
            return View(bringHomePay);
        }

        // GET: BringHomePays/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BringHomePays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Name,amount,DayOfWeek,Frequency,PickOnePayDate,UserID")] BringHomePay bringHomePay)
        {
            if (ModelState.IsValid)
            {
                db.BringHomePays.Add(bringHomePay);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bringHomePay);
        }

        // GET: BringHomePays/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BringHomePay bringHomePay = db.BringHomePays.Find(id);
            if (bringHomePay == null)
            {
                return HttpNotFound();
            }
            return View(bringHomePay);
        }

        // POST: BringHomePays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name,amount,DayOfWeek,Frequency,PickOnePayDate,UserID")] BringHomePay bringHomePay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bringHomePay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bringHomePay);
        }

        // GET: BringHomePays/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BringHomePay bringHomePay = db.BringHomePays.Find(id);
            if (bringHomePay == null)
            {
                return HttpNotFound();
            }
            return View(bringHomePay);
        }

        // POST: BringHomePays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BringHomePay bringHomePay = db.BringHomePays.Find(id);
            db.BringHomePays.Remove(bringHomePay);
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
