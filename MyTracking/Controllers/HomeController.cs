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
        public async Task<ActionResult> Rastrear(string txtTrackingNumber)
        {
            if (string.IsNullOrWhiteSpace(txtTrackingNumber))
            {
                return RedirectToAction("Index");
            }
            Arrive arrive = await db.Arrives.Where(v => v.Package.TrackingNo == txtTrackingNumber).FirstOrDefaultAsync();
            if (arrive == null)
            {
                ViewBag.txtTrackingNumberMsj = "No se encontro el paquete";
                return RedirectToAction("Index");
            }
            return View(arrive);
        }
    }
}