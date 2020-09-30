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
    public class Employment_detailsController : ApiController
    {
        private PrjGladEntities db = new PrjGladEntities();

        // GET: api/Employment_details
        public IQueryable<Employment_details> GetEmployment_details()
        {
            return db.Employment_details;
        }

        // GET: api/Employment_details/5
        [ResponseType(typeof(Employment_details))]
        public IHttpActionResult GetEmployment_details(string id)
        {
            Employment_details employment_details = db.Employment_details.Find(id);
            if (employment_details == null)
            {
                return NotFound();
            }

            return Ok(employment_details);
        }

        // PUT: api/Employment_details/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmployment_details(string id, Employment_details employment_details)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employment_details.email)
            {
                return BadRequest();
            }

            db.Entry(employment_details).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Employment_detailsExists(id))
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

        // POST: api/Employment_details
        [ResponseType(typeof(Employment_details))]
        public IHttpActionResult PostEmployment_details(Employment_details employment_details)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Employment_details.Add(employment_details);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Employment_detailsExists(employment_details.email))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = employment_details.email }, employment_details);
        }

        // DELETE: api/Employment_details/5
        [ResponseType(typeof(Employment_details))]
        public IHttpActionResult DeleteEmployment_details(string id)
        {
            Employment_details employment_details = db.Employment_details.Find(id);
            if (employment_details == null)
            {
                return NotFound();
            }

            db.Employment_details.Remove(employment_details);
            db.SaveChanges();

            return Ok(employment_details);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Employment_detailsExists(string id)
        {
            return db.Employment_details.Count(e => e.email == id) > 0;
        }
    }
}