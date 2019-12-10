using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MonthlyBillsWebApp.Models;

namespace MonthlyBillsWebApp.Controllers
{
    public class UpcomingBills_AlterController : Controller
    {
        private BillsEntities db = new BillsEntities();
        public async Task<ActionResult> Index()
        {
            return View(await db.UpcomingBills_Alter.ToListAsync());
        }
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,TheDate,DayOfWeek,Name,Amount,Type,UserID")] UpcomingBills_Alter upcomingBills_Alter)
        {
            if (ModelState.IsValid)
            {
                db.UpcomingBills_Alter.Add(upcomingBills_Alter);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(upcomingBills_Alter);
        }
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UpcomingBills_Alter upcomingBills_Alter = await db.UpcomingBills_Alter.FindAsync(id);
            if (upcomingBills_Alter == null)
            {
                return HttpNotFound();
            }
            return View(upcomingBills_Alter);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,TheDate,DayOfWeek,Name,Amount,Type,UserID")] UpcomingBills_Alter upcomingBills_Alter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(upcomingBills_Alter).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(upcomingBills_Alter);
        }
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UpcomingBills_Alter upcomingBills_Alter = await db.UpcomingBills_Alter.FindAsync(id);
            if (upcomingBills_Alter == null)
            {
                return HttpNotFound();
            }
            return View(upcomingBills_Alter);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            UpcomingBills_Alter upcomingBills_Alter = await db.UpcomingBills_Alter.FindAsync(id);
            db.UpcomingBills_Alter.Remove(upcomingBills_Alter);
            await db.SaveChangesAsync();
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
