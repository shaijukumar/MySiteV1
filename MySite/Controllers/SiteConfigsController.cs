using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MySite.Models;

namespace MySite.Controllers
{
    public class SiteConfigsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SiteConfigs
        public ActionResult Index()
        {
            return View(db.config.ToList());
        }

        // GET: SiteConfigs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteConfig siteConfig = db.config.Find(id);
            if (siteConfig == null)
            {
                return HttpNotFound();
            }
            return View(siteConfig);
        }

        // GET: SiteConfigs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SiteConfigs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SiteConfigID,Key,Value")] SiteConfig siteConfig)
        {
            if (ModelState.IsValid)
            {
                db.config.Add(siteConfig);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(siteConfig);
        }

        // GET: SiteConfigs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteConfig siteConfig = db.config.Find(id);
            if (siteConfig == null)
            {
                return HttpNotFound();
            }
            return View(siteConfig);
        }

        // POST: SiteConfigs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SiteConfigID,Key,Value")] SiteConfig siteConfig)
        {
            if (ModelState.IsValid)
            {
                db.Entry(siteConfig).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(siteConfig);
        }

        // GET: SiteConfigs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteConfig siteConfig = db.config.Find(id);
            if (siteConfig == null)
            {
                return HttpNotFound();
            }
            return View(siteConfig);
        }

        // POST: SiteConfigs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SiteConfig siteConfig = db.config.Find(id);
            db.config.Remove(siteConfig);
            db.SaveChanges();
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
