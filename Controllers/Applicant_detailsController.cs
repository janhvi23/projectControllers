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
    public class Applicant_detailsController : ApiController
    {
        private PrjGladEntities db = new PrjGladEntities();

        // GET: api/Applicant_details
        public IQueryable<Applicant_details> GetApplicant_details()
        {
            return db.Applicant_details;
        }

        // GET: api/Applicant_details/5
        [ResponseType(typeof(Applicant_details))]
        public IHttpActionResult GetApplicant_details(long id)
        {
            Applicant_details applicant_details = db.Applicant_details.Find(id);
            if (applicant_details == null)
            {
                return NotFound();
            }

            return Ok(applicant_details);
        }

        // PUT: api/Applicant_details/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutApplicant_details(long id, Applicant_details applicant_details)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != applicant_details.Applicant_Id)
            {
                return BadRequest();
            }

            db.Entry(applicant_details).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Applicant_detailsExists(id))
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

        // POST: api/Applicant_details
        [ResponseType(typeof(Applicant_details))]
        public IHttpActionResult PostApplicant_details(Applicant_details applicant_details)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Applicant_details.Add(applicant_details);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = applicant_details.Applicant_Id }, applicant_details);
        }

        // DELETE: api/Applicant_details/5
        [ResponseType(typeof(Applicant_details))]
        public IHttpActionResult DeleteApplicant_details(long id)
        {
            Applicant_details applicant_details = db.Applicant_details.Find(id);
            if (applicant_details == null)
            {
                return NotFound();
            }

            db.Applicant_details.Remove(applicant_details);
            db.SaveChanges();

            return Ok(applicant_details);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Applicant_detailsExists(long id)
        {
            return db.Applicant_details.Count(e => e.Applicant_Id == id) > 0;
        }
    }
}