using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KejaAsapAPI.Models;

namespace KejaAsapAPI.Controllers
{
    public class HousesControllerWithView : Controller
    {
        private KejaAsapEntities db = new KejaAsapEntities();

        // GET: HousesControllerWithView
        public async Task<ActionResult> Index()
        {
            var houses = db.Houses.Include(h => h.Amenity);
            return View(await houses.ToListAsync());
        }

        // GET: HousesControllerWithView/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            House house = await db.Houses.FindAsync(id);
            if (house == null)
            {
                return HttpNotFound();
            }
            return View(house);
        }

        // GET: HousesControllerWithView/Create
        public ActionResult Create()
        {
            ViewBag.AmenitiesId = new SelectList(db.Amenities, "Id", "Name");
            return View();
        }

        // POST: HousesControllerWithView/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Name,AmenitiesId,Description,BuildingId,Price,Size,Type,Floor")] House house)
        {
            if (ModelState.IsValid)
            {
                db.Houses.Add(house);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.AmenitiesId = new SelectList(db.Amenities, "Id", "Name", house.AmenitiesId);
            return View(house);
        }

        // GET: HousesControllerWithView/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            House house = await db.Houses.FindAsync(id);
            if (house == null)
            {
                return HttpNotFound();
            }
            ViewBag.AmenitiesId = new SelectList(db.Amenities, "Id", "Name", house.AmenitiesId);
            return View(house);
        }

        // POST: HousesControllerWithView/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name,AmenitiesId,Description,BuildingId,Price,Size,Type,Floor")] House house)
        {
            if (ModelState.IsValid)
            {
                db.Entry(house).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.AmenitiesId = new SelectList(db.Amenities, "Id", "Name", house.AmenitiesId);
            return View(house);
        }

        // GET: HousesControllerWithView/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            House house = await db.Houses.FindAsync(id);
            if (house == null)
            {
                return HttpNotFound();
            }
            return View(house);
        }

        // POST: HousesControllerWithView/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            House house = await db.Houses.FindAsync(id);
            db.Houses.Remove(house);
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
