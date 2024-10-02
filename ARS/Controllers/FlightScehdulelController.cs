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
    public class FlightScehdulelController : Controller
    {
        private ContextCS db = new ContextCS();

        // GET: FlightScehdulel
        public ActionResult Index()
        {
            var ticketReserve_tbl = db.TicketReserve_tbl.Include(t => t.Plane_tbls);
            return View(ticketReserve_tbl.ToList());
        }

        // GET: FlightScehdulel/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketReserve_tbl ticketReserve_tbl = db.TicketReserve_tbl.Find(id);
            if (ticketReserve_tbl == null)
            {
                return HttpNotFound();
            }
            return View(ticketReserve_tbl);
        }

        // GET: FlightScehdulel/Create
        public ActionResult Create()
        {
            ViewBag.PlaneId = new SelectList(db.PlaneInfo, "Planeid", "Aplane");
            return View();
        }

        // POST: FlightScehdulel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ResID,Resfrom,Resto,ResDepDate,ResTime,PlaneId,Planeseat,ResTicketPrice,ResPlaneType")] TicketReserve_tbl ticketReserve_tbl)
        {
            if (ModelState.IsValid)
            {
                db.TicketReserve_tbl.Add(ticketReserve_tbl);
                db.SaveChanges();
                return ViewBag.m = "Record Saved";
            }

            ViewBag.PlaneId = new SelectList(db.PlaneInfo, "Planeid", "Aplane", ticketReserve_tbl.PlaneId);
            return View(ticketReserve_tbl);
        }

        // GET: FlightScehdulel/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketReserve_tbl ticketReserve_tbl = db.TicketReserve_tbl.Find(id);
            if (ticketReserve_tbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlaneId = new SelectList(db.PlaneInfo, "Planeid", "Aplane", ticketReserve_tbl.PlaneId);
            return View(ticketReserve_tbl);
        }

        // POST: FlightScehdulel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ResID,Resfrom,Resto,ResDepDate,ResTime,PlaneId,Planeseat,ResTicketPrice,ResPlaneType")] TicketReserve_tbl ticketReserve_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticketReserve_tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PlaneId = new SelectList(db.PlaneInfo, "Planeid", "Aplane", ticketReserve_tbl.PlaneId);
            return View(ticketReserve_tbl);
        }

        // GET: FlightScehdulel/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketReserve_tbl ticketReserve_tbl = db.TicketReserve_tbl.Find(id);
            if (ticketReserve_tbl == null)
            {
                return HttpNotFound();
            }
            return View(ticketReserve_tbl);
        }

        // POST: FlightScehdulel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TicketReserve_tbl ticketReserve_tbl = db.TicketReserve_tbl.Find(id);
            db.TicketReserve_tbl.Remove(ticketReserve_tbl);
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
