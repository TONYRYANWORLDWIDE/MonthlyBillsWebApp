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
    public class KeyBalancesController : Controller
    {
        private BillsEntities db = new BillsEntities();

        // GET: 
        public string userIdValue { get; private set; }

        public ActionResult Index()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            if (claimsIdentity != null)
            {
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
            }
            var balance = from u in db.KeyBalances
                              where u.UserID == userIdValue                              
                              select u;

            return View(balance.ToList());
        }
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,KeyBalance1,DateTime,UserID")] KeyBalance keyBalance)
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
                keyBalance.UserID = userIdValue;
                db.KeyBalances.Add(keyBalance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(keyBalance);
        }
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,KeyBalance1,DateTime")] KeyBalance keyBalance)
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
                keyBalance.UserID = userIdValue;
                db.Entry(keyBalance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(keyBalance);
        }
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
