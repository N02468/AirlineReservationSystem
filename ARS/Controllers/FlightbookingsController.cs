using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ARS.Models;

namespace ARS.Controllers
{
    public class FlightbookingsController : Controller
    {
        private ContextCS db = new ContextCS();

        // GET: Flightbookings
        public ActionResult Index()
        {
        
         
            //return View(db.Flightbookings.ToList());
            return View();
        }
 
        // GET: Flightbookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flightbooking flightbooking = db.Flightbookings.Find(id);
            if (flightbooking == null)
            {
                return HttpNotFound();
            }
            return View(flightbooking);
        }

        // GET: Flightbookings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Flightbookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Bid,bCusName,bCusAddress,bCusEmail,bCusSeat,bCusPhoneNum,bCusCnic,ResID")] Flightbooking flightbooking)
        {
            if (ModelState.IsValid)
            {
                db.Flightbookings.Add(flightbooking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(flightbooking);
        }

        // GET: Flightbookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flightbooking flightbooking = db.Flightbookings.Find(id);
            if (flightbooking == null)
            {
                return HttpNotFound();
            }
            return View(flightbooking);
        }

        // POST: Flightbookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Bid,bCusName,bCusAddress,bCusEmail,bCusSeat,bCusPhoneNum,bCusCnic,ResID")] Flightbooking flightbooking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(flightbooking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(flightbooking);
        }

        // GET: Flightbookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flightbooking flightbooking = db.Flightbookings.Find(id);
            if (flightbooking == null)
            {
                return HttpNotFound();
            }
            return View(flightbooking);
        }

        // POST: Flightbookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Flightbooking flightbooking = db.Flightbookings.Find(id);
            db.Flightbookings.Remove(flightbooking);
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
