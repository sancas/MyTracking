using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyTracking.Models;

namespace MyTracking.Controllers
{
    public class ArrivesController : Controller
    {
        private Tracking db = new Tracking();

        // GET: Arrives
        public async Task<ActionResult> Index()
        {
            var arrives = db.Arrives.Include(a => a.Package);
            return View(await arrives.ToListAsync());
        }

        // GET: Arrives/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arrive arrive = await db.Arrives.FindAsync(id);
            if (arrive == null)
            {
                return HttpNotFound();
            }
            return View(arrive);
        }

        // GET: Arrives/Create
        public ActionResult Create()
        {
            ViewBag.IdPackage = new SelectList(db.Packages, "Id", "TrackingNo");
            return View();
        }

        // POST: Arrives/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Date,Location,IdPackage")] Arrive arrive)
        {
            if (ModelState.IsValid)
            {
                db.Arrives.Add(arrive);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdPackage = new SelectList(db.Packages, "Id", "TrackingNo", arrive.IdPackage);
            return View(arrive);
        }

        // GET: Arrives/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arrive arrive = await db.Arrives.FindAsync(id);
            if (arrive == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPackage = new SelectList(db.Packages, "Id", "TrackingNo", arrive.IdPackage);
            return View(arrive);
        }

        // POST: Arrives/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Date,Location,IdPackage")] Arrive arrive)
        {
            if (ModelState.IsValid)
            {
                db.Entry(arrive).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdPackage = new SelectList(db.Packages, "Id", "TrackingNo", arrive.IdPackage);
            return View(arrive);
        }

        // GET: Arrives/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arrive arrive = await db.Arrives.FindAsync(id);
            if (arrive == null)
            {
                return HttpNotFound();
            }
            return View(arrive);
        }

        // POST: Arrives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Arrive arrive = await db.Arrives.FindAsync(id);
            db.Arrives.Remove(arrive);
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
