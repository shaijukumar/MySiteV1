using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MySite.Models;

namespace MySite.Migrations
{
    public class ContentTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ContentTypes
        public ActionResult Index()
        {
            return View(db.ContentTypes.ToList());
        }

        // GET: ContentTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category contentTypes = db.ContentTypes.Find(id);
            if (contentTypes == null)
            {
                return HttpNotFound();
            }
            return View(contentTypes);
        }

        // GET: ContentTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContentTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContentTypesId,Title,ParentId")] Category contentTypes)
        {
            if (ModelState.IsValid)
            {
                db.ContentTypes.Add(contentTypes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contentTypes);
        }

        // GET: ContentTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category contentTypes = db.ContentTypes.Find(id);
            if (contentTypes == null)
            {
                return HttpNotFound();
            }
            return View(contentTypes);
        }

        // POST: ContentTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContentTypesId,Title,ParentId")] Category contentTypes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contentTypes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contentTypes);
        }

        // GET: ContentTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category contentTypes = db.ContentTypes.Find(id);
            if (contentTypes == null)
            {
                return HttpNotFound();
            }
            return View(contentTypes);
        }

        // POST: ContentTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category contentTypes = db.ContentTypes.Find(id);
            db.ContentTypes.Remove(contentTypes);
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
