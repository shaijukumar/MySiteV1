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
using MySite.Models;

namespace MySite.Controllers.API
{
    public class AppFieldsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/AppFields
        public IQueryable<AppField> GetAppFields()
        {
            return db.AppFields;
        }

        // GET: api/AppFields/SubList/5
        [HttpGet]
        [ResponseType(typeof(AppField))]
        public IHttpActionResult SubList(int id)
        {
            AppField appField = db.AppFields.Find(id);
            if (appField == null)
            {
                return NotFound();
            }

            return Ok(appField);
        }

        // GET: api/AppFields/5
        [ResponseType(typeof(AppField))]
        public IHttpActionResult GetAppField(int id)
        {
            AppField appField = db.AppFields.Find(id);
            if (appField == null)
            {
                return NotFound();
            }
            return Ok(appField);
        }

        // PUT: api/AppFields/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAppField(int id, AppField appField)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != appField.AppFieldID)
            {
                return BadRequest();
            }

            db.Entry(appField).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppFieldExists(id))
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

        // POST: api/AppFields
        [ResponseType(typeof(AppField))]
        public IHttpActionResult PostAppField(AppField appField)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AppFields.Add(appField);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = appField.AppFieldID }, appField);
        }

        // DELETE: api/AppFields/5
        [ResponseType(typeof(AppField))]
        public IHttpActionResult DeleteAppField(int id)
        {
            AppField appField = db.AppFields.Find(id);
            if (appField == null)
            {
                return NotFound();
            }

            db.AppFields.Remove(appField);
            db.SaveChanges();

            return Ok(appField);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AppFieldExists(int id)
        {
            return db.AppFields.Count(e => e.AppFieldID == id) > 0;
        }
    }
}