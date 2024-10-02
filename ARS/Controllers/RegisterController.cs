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
    public class RegisterController : Controller
    {
        private ContextCS db = new ContextCS();

        // GET: Register
        public ActionResult Index()
        {
            return View(db.AdminLogins.ToList());
        }

        // GET: Register/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminLogin adminLogin = db.AdminLogins.Find(id);
            if (adminLogin == null)
            {
                return HttpNotFound();
            }
            return View(adminLogin);
        }

        // GET: Register/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Register/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdminId,AdminName,Password")] AdminLogin adminLogin)
        {
            if (ModelState.IsValid)
            {
                db.AdminLogins.Add(adminLogin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adminLogin);
        }

        // GET: Register/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminLogin adminLogin = db.AdminLogins.Find(id);
            if (adminLogin == null)
            {
                return HttpNotFound();
            }
            return View(adminLogin);
        }

        // POST: Register/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AdminId,AdminName,Password")] AdminLogin adminLogin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adminLogin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adminLogin);
        }

        // GET: Register/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminLogin adminLogin = db.AdminLogins.Find(id);
            if (adminLogin == null)
            {
                return HttpNotFound();
            }
            return View(adminLogin);
        }

        // POST: Register/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdminLogin adminLogin = db.AdminLogins.Find(id);
            db.AdminLogins.Remove(adminLogin);
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
