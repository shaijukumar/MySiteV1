using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using MySite.Models;

namespace MySite.Controllers.API
{
    public class SiteConfigsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        


       

        // GET: api/SiteConfigs
        public IQueryable<SiteConfig> Getconfig()
        {
            return db.config;
        }

        // GET: api/SiteConfigs/5
        [ResponseType(typeof(SiteConfig))]
        public IHttpActionResult GetSiteConfig(int id)
        {
            SiteConfig siteConfig = db.config.Find(id);
            if (siteConfig == null)
            {
                return NotFound();
            }

            return Ok(siteConfig);
        }

        // PUT: api/SiteConfigs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSiteConfig(int id, SiteConfig siteConfig)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != siteConfig.SiteConfigID)
            {
                return BadRequest();
            }

            db.Entry(siteConfig).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SiteConfigExists(id))
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

        // POST: api/SiteConfigs
        [ResponseType(typeof(SiteConfig))]
        public IHttpActionResult PostSiteConfig(SiteConfig siteConfig)
        {
            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
            }

            db.config.Add(siteConfig);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = siteConfig.SiteConfigID }, siteConfig);
        }

        // DELETE: api/SiteConfigs/5
        [ResponseType(typeof(SiteConfig))]
        public IHttpActionResult DeleteSiteConfig(int id)
        {
            SiteConfig siteConfig = db.config.Find(id);
            if (siteConfig == null)
            {
                return NotFound();
            }

            db.config.Remove(siteConfig);
            db.SaveChanges();

            return Ok(siteConfig);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SiteConfigExists(int id)
        {
            return db.config.Count(e => e.SiteConfigID == id) > 0;
        }
    }
}