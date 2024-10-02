using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ARS.Models;
using System.Data.Entity;

namespace ARS.Controllers
{

    public class AdminController : Controller
    {
        ContextCS c = new ContextCS();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Adminlogin()
        {
            if (Session["u"] != null)
            {

                return RedirectToAction("Dashboard");
            }
            else
            {
                return View();
            }


        }
        [HttpPost]
        public ActionResult AdminLogin(AdminLogin l)
        {

            var x = c.AdminLogins.Where(a => a.AdminName == l.AdminName && a.Password == l.Password).FirstOrDefault();
            if (x != null)
            {
                Session["u"] = l.AdminName;
                return RedirectToAction("Dashboard");

            }
            else
            {
                ViewBag.m = "Wrong User id or Password";
            }

            return View();

        }
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult Login()
        {
            ViewBag.msg = "";
            return View();
        }
        //[HttpPost]
        //public Action Login(UserAccount User)
        //{
        //    using (ContextCS db = new ContextCS())
        //    {
        //        var usr = db.UserAccounts.Where(u => u.Username == User.Username && u.Password == User.Password).ToList();
        //        if (usr.Count > 0)
        //        {
        //            foreach (var item in usr)
        //            {
        //                Session["UserID"] = item.UserID.ToString();
        //                Session["UserName"] = item.Username.ToString();

        //            }
        //            return RedirectToAction("Index", "FlightBook");


        //        }
        //        else
        //        {
        //            ViewBag.msg = "Invalid Username or Password !!";
        //        }
        //    }
        //}


    }
}