using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using KejaAsapAPI.Models;

namespace KejaAsapAPI.Controllers
{
    public class HousesController : ApiController
    {
        private KejaAsapEntities db = new KejaAsapEntities();

        // GET: api/Houses
        public IQueryable<House> GetHouses()
        {
            return db.Houses;
        }

        // GET: api/Houses/5
        [ResponseType(typeof(House))]
        public async Task<IHttpActionResult> GetHouse(long id)
        {
            House house = await db.Houses.FindAsync(id);
            if (house == null)
            {
                return NotFound();
            }

            return Ok(house);
        }

        // PUT: api/Houses/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutHouse(long id, House house)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != house.ID)
            {
                return BadRequest();
            }

            db.Entry(house).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HouseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Houses
        [ResponseType(typeof(House))]
        public async Task<IHttpActionResult> PostHouse(House house)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Houses.Add(house);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = house.ID }, house);
        }

        // DELETE: api/Houses/5
        [ResponseType(typeof(House))]
        public async Task<IHttpActionResult> DeleteHouse(long id)
        {
            House house = await db.Houses.FindAsync(id);
            if (house == null)
            {
                return NotFound();
            }

            db.Houses.Remove(house);
            await db.SaveChangesAsync();

            return Ok(house);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HouseExists(long id)
        {
            return db.Houses.Count(e => e.ID == id) > 0;
        }
    }
}