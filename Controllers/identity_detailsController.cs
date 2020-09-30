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
    public class identity_detailsController : ApiController
    {
        private PrjGladEntities db = new PrjGladEntities();

        // GET: api/identity_details
        public IQueryable<identity_details> Getidentity_details()
        {
            return db.identity_details;
        }

        // GET: api/identity_details/5
        [ResponseType(typeof(identity_details))]
        public IHttpActionResult Getidentity_details(string id)
        {
            identity_details identity_details = db.identity_details.Find(id);
            if (identity_details == null)
            {
                return NotFound();
            }

            return Ok(identity_details);
        }

        // PUT: api/identity_details/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putidentity_details(string id, identity_details identity_details)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != identity_details.email)
            {
                return BadRequest();
            }

            db.Entry(identity_details).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!identity_detailsExists(id))
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

        // POST: api/identity_details
        [ResponseType(typeof(identity_details))]
        public IHttpActionResult Postidentity_details(identity_details identity_details)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.identity_details.Add(identity_details);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (identity_detailsExists(identity_details.email))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = identity_details.email }, identity_details);
        }

        // DELETE: api/identity_details/5
        [ResponseType(typeof(identity_details))]
        public IHttpActionResult Deleteidentity_details(string id)
        {
            identity_details identity_details = db.identity_details.Find(id);
            if (identity_details == null)
            {
                return NotFound();
            }

            db.identity_details.Remove(identity_details);
            db.SaveChanges();

            return Ok(identity_details);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool identity_detailsExists(string id)
        {
            return db.identity_details.Count(e => e.email == id) > 0;
        }
    }
}