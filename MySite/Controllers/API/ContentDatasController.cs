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
    public class ContentDatasController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/ContentDatas
        public IQueryable<ContentData> Getcd()
        {
            return db.cd;
        }

        // GET: api/ContentDatas/5
        [ResponseType(typeof(ContentData))]
        public IHttpActionResult GetContentData(int id)
        {
            ContentData contentData = db.cd.Find(id);
            if (contentData == null)
            {
                return NotFound();
            }

            return Ok(contentData);
        }

        // PUT: api/ContentDatas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutContentData(int id, ContentData contentData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contentData.ContentDataId)
            {
                return BadRequest();
            }

            db.Entry(contentData).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContentDataExists(id))
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

        // POST: api/ContentDatas
        [ResponseType(typeof(ContentData))]
        public IHttpActionResult PostContentData(ContentData contentData)
        {
            if (!ModelState.IsValid)
            {
               // return BadRequest(ModelState);
            }

            db.cd.Add(contentData);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = contentData.ContentDataId }, contentData);
        }

        // DELETE: api/ContentDatas/5
        [ResponseType(typeof(ContentData))]
        public IHttpActionResult DeleteContentData(int id)
        {
            ContentData contentData = db.cd.Find(id);
            if (contentData == null)
            {
                return NotFound();
            }

            db.cd.Remove(contentData);
            db.SaveChanges();

            return Ok(contentData);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContentDataExists(int id)
        {
            return db.cd.Count(e => e.ContentDataId == id) > 0;
        }
    }
}