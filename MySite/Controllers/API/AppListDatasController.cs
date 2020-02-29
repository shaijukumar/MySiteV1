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
    public class AppListDatasController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/AppListDatas
        public IQueryable<AppListData> GetAppListDatas()
        {
            return db.AppListDatas;
        }

        // GET: api/AppListDatas/SubList/5
        [HttpGet]
        [ResponseType(typeof(AppListData))]
        public IHttpActionResult SubList(int id)
        {
            AppListData appListData = db.AppListDatas.Find(id);
            if (appListData == null)
            {
                return NotFound();
            }

            appListData.FieldValue = "Abcd";

            return Ok(appListData);
        }


        // GET: api/AppListDatas/5
        [ResponseType(typeof(AppListData))]
        public IHttpActionResult GetAppListData(int id)
        {
            AppListData appListData = db.AppListDatas.Find(id);
            if (appListData == null)
            {
                return NotFound();
            }

            return Ok(appListData);
        }

        // PUT: api/AppListDatas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAppListData(int id, AppListData appListData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != appListData.AppListDataID)
            {
                return BadRequest();
            }

            db.Entry(appListData).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppListDataExists(id))
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

        // POST: api/AppListDatas
        [ResponseType(typeof(AppListData))]
        public IHttpActionResult PostAppListData(AppListData appListData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AppListDatas.Add(appListData);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = appListData.AppListDataID }, appListData);
        }

        // DELETE: api/AppListDatas/5
        [ResponseType(typeof(AppListData))]
        public IHttpActionResult DeleteAppListData(int id)
        {
            AppListData appListData = db.AppListDatas.Find(id);
            if (appListData == null)
            {
                return NotFound();
            }

            db.AppListDatas.Remove(appListData);
            db.SaveChanges();

            return Ok(appListData);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AppListDataExists(int id)
        {
            return db.AppListDatas.Count(e => e.AppListDataID == id) > 0;
        }
    }
}