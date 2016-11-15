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
    public class PackagesController : Controller
    {
        private Tracking db = new Tracking();

        // GET: Packages
        public async Task<ActionResult> Index()
        {
            return View(await db.Packages.ToListAsync());
        }

        // GET: Packages/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Package package = await db.Packages.FindAsync(id);
            if (package == null)
            {
                return HttpNotFound();
            }
            return View(package);
        }

        // GET: Packages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Packages/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,TrackingNo,Weight,InTransit,Owner,Destination")] Package package)
        {
            if (ModelState.IsValid)
            {
                db.Packages.Add(package);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(package);
        }

        // GET: Packages/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Package package = await db.Packages.FindAsync(id);
            if (package == null)
            {
                return HttpNotFound();
            }
            return View(package);
        }

        // POST: Packages/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,TrackingNo,Weight,InTransit,Owner,Destination")] Package package)
        {
            if (ModelState.IsValid)
            {
                db.Entry(package).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(package);
        }

        // GET: Packages/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Package package = await db.Packages.FindAsync(id);
            if (package == null)
            {
                return HttpNotFound();
            }
            return View(package);
        }

        // POST: Packages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Package package = await db.Packages.FindAsync(id);
            db.Packages.Remove(package);
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
