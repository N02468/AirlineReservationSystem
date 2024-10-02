using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ARS.Models;

namespace ARS.Controllers
{
    public class FlightBookController : Controller
    {
        // GET: FlightBook
        ContextCS db = new ContextCS();
        public ActionResult Index()
        {
            ViewBag.dcity = db.TicketReserve_tbl.Select(l => l.Resfrom).Distinct().ToList();
            ViewBag.acity = db.TicketReserve_tbl.Select(l => l.Resto).Distinct().ToList();
            return View();

        }
        [HttpPost]
        public ActionResult Search(string cityto, string cityfrom, string date1)
        {
            var c = db.TicketReserve_tbl.Where(l => l.Resto.Equals(cityto) && l.Resfrom.Equals(cityfrom) && l.ResDepDate.Equals(cityfrom) && l.ResDepDate.Equals(date1));
            ViewBag.ss = c;
            return View();
        }
        public ActionResult Booking(string fid)
        {
            //int ids = int.Parse(fid);
            //var a = db.TicketReserve_tbl.Where(l => l.ResID == ids).SingleOrDefault();
            //ViewBag.name = a.ResID;
            //ViewBag.id = fid;

            return View();
         
        }
     
    }
}