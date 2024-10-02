﻿using System;
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
    public class AeroPlaneController : Controller
    {
        private ContextCS db = new ContextCS();

        // GET: AeroPlane
        public ActionResult Index()
        {
            if (Session["u"] != null)
            {

                
                return View(db.PlaneInfo.ToList());
            }
            else
            {
                return RedirectToAction("AdminLogin","Admin");
            }
            
        }

        // GET: AeroPlane/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AeroPlaneInfo aeroPlaneInfo = db.PlaneInfo.Find(id);
            if (aeroPlaneInfo == null)
            {
                return HttpNotFound();
            }
            return View(aeroPlaneInfo);
        }

        // GET: AeroPlane/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AeroPlane/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Planeid,Aplane,SeatingCapacity,Price")] AeroPlaneInfo AeroPlaneInfo)
        {
            if (ModelState.IsValid)
            {
                AeroPlaneInfo planeInfo = new AeroPlaneInfo();
                db.PlaneInfo.Add(AeroPlaneInfo);
                db.SaveChanges();
                
                ViewBag.m = "Record Saved";
                return View();
            }
            else
            {
                ViewBag.v = "wrong";
            }

            return View(AeroPlaneInfo);
        }

        // GET: AeroPlane/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AeroPlaneInfo aeroPlaneInfo = db.PlaneInfo.Find(id);
            if (aeroPlaneInfo == null)
            {
                return HttpNotFound();
            }
            return View(aeroPlaneInfo);
        }

        // POST: AeroPlane/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Planeid,Aplane,SeatingCapacity,Price")] AeroPlaneInfo aeroPlaneInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aeroPlaneInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aeroPlaneInfo);
        }

        // GET: AeroPlane/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AeroPlaneInfo aeroPlaneInfo = db.PlaneInfo.Find(id);
            if (aeroPlaneInfo == null)
            {
                return HttpNotFound();
            }
            return View(aeroPlaneInfo);
        }

        // POST: AeroPlane/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AeroPlaneInfo aeroPlaneInfo = db.PlaneInfo.Find(id);
            db.PlaneInfo.Remove(aeroPlaneInfo);
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
