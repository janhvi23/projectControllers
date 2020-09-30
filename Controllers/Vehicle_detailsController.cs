using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ProjectGladiator.Models;
using System.Web.Http.Cors;


namespace ProjectGladiator.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class Vehicle_detailsController : ApiController
    {
        private PrjGladEntities db = new PrjGladEntities();

        // GET: api/Vehicle_details
        public IQueryable<Vehicle_details> GetVehicle_details()
        {
            return db.Vehicle_details;
        }

        // GET: api/Vehicle_details/5
        [ResponseType(typeof(Vehicle_details))]
        public IHttpActionResult GetVehicle_details(long id)
        {
            Vehicle_details vehicle_details = db.Vehicle_details.Find(id);
            if (vehicle_details == null)
            {
                return NotFound();
            }

            return Ok(vehicle_details);
        }

        // PUT: api/Vehicle_details/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVehicle_details(long id, Vehicle_details vehicle_details)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vehicle_details.Car_ID)
            {
                return BadRequest();
            }

            db.Entry(vehicle_details).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Vehicle_detailsExists(id))
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

        // POST: api/Vehicle_details
        [ResponseType(typeof(Vehicle_details))]
        public IHttpActionResult PostVehicle_details(Vehicle_details vehicle_details)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Vehicle_details.Add(vehicle_details);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = vehicle_details.Car_ID }, vehicle_details);
        }

        // DELETE: api/Vehicle_details/5
        [ResponseType(typeof(Vehicle_details))]
        public IHttpActionResult DeleteVehicle_details(long id)
        {
            Vehicle_details vehicle_details = db.Vehicle_details.Find(id);
            if (vehicle_details == null)
            {
                return NotFound();
            }

            db.Vehicle_details.Remove(vehicle_details);
            db.SaveChanges();

            return Ok(vehicle_details);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Vehicle_detailsExists(long id)
        {
            return db.Vehicle_details.Count(e => e.Car_ID == id) > 0;
        }
    }
}