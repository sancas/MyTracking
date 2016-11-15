using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyTracking.Models;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Net;

namespace MyTracking.Controllers
{
    public class HomeController : Controller
    {
        private Tracking db = new Tracking();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Rastrear(string txtTrackingNumber)
        {
            if (string.IsNullOrWhiteSpace(txtTrackingNumber))
            {
                return RedirectToAction("Index");
            }
            if (db.Packages.Where(v => v.TrackingNo == txtTrackingNumber).FirstOrDefault() == null)
            {
                return RedirectToAction("Index");
            }
            IQueryable<Arrive> arrive = db.Arrives.Where(v => v.Package.TrackingNo == txtTrackingNumber).OrderByDescending(v => v.Date);
            string json = "[";
            int x = arrive.Count() - 1;
            foreach (Arrive miArrive in arrive)
            {
                if (json != "[")
                    json += ",";
                else if (ViewBag.GeoLat == null)
                {
                    ViewBag.GeoLat = miArrive.Location.Latitude;
                    ViewBag.GeoLong = miArrive.Location.Longitude;
                    ViewBag.Placename = arrive.Count().ToString() + ". Actualmente en: " + miArrive.Name + " Fecha que llego: " + miArrive.Date.ToShortDateString();
                    continue;
                }
                json += "{'Id':"+miArrive.Id+", 'PlaceName': '"+ x.ToString() + ". "+miArrive.Name+" Fecha que llego: "+miArrive.Date.ToShortDateString()+"','GeoLong': "+miArrive.Location.Latitude.ToString()+", 'GeoLat': "+miArrive.Location.Longitude.ToString()+"}";
                x--;
            }
            json += "]";
            ViewBag.DestGeoLat = db.Packages.Where(v => v.TrackingNo == txtTrackingNumber).FirstOrDefault().Destination.Latitude;
            ViewBag.DestGeoLong = db.Packages.Where(v => v.TrackingNo == txtTrackingNumber).FirstOrDefault().Destination.Longitude;
            ViewBag.Data = json;
            return View(arrive);
        }
    }
}