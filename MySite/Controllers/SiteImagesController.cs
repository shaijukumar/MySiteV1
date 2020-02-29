using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MySite.Models;

namespace MySite.Controllers
{
    public class SiteImagesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //GET: SiteImages/ImageList
        public JsonResult ImageList(int ContentDataId)
        {
            return Json(db.siteImg.Where( img => img.ContentDataId == ContentDataId).ToList(), JsonRequestBehavior.AllowGet);
        }

        // GET: SiteImages
        public ActionResult Index()
        {
            return View(db.siteImg.ToList());
        }

        // GET: GetJson
        [HttpGet]
        public JsonResult GetJson()
        {
            //return Json(db.siteImg);
            return new JsonResult() { Data = db.siteImg, JsonRequestBehavior = JsonRequestBehavior.AllowGet };


            // return View(db.siteImg.ToList());
        }


        [HttpPost]
        public ActionResult Index(FormCollection fc, HttpPostedFileBase file)
        {            
            int ContentDataId;
            if (!int.TryParse(fc["ContentDataId"], out ContentDataId))
            {
                ContentDataId = 1;
            }
           

            var fileName = Path.GetFileName(file.FileName);
            var ext = Path.GetExtension(file.FileName);
            var allowedExtensions = new[] {".Jpg", ".png", ".jpg", "jpeg" };
            if (allowedExtensions.Contains(ext)) //check what type of extension  
            {
                string name = Path.GetFileNameWithoutExtension(fileName); //getting file name without extension  
                string filePath = name + "_" + ContentDataId + ext; //appending the name with id  
                                                           // store the file inside ~/project folder(Img)  
                var path = Path.Combine(Server.MapPath("~/Img"), filePath);
                file.SaveAs(path);

                SiteImages siteImages = new SiteImages();
                siteImages.ContentDataId = ContentDataId;
                siteImages.Image_url = filePath;
                siteImages.Name = fc["Name"].ToString();

                //if (fileName)
                {
                    db.siteImg.Add(siteImages);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else
            {

            }

            


            

            

           

            //return View(siteImages);


            //getting only file name(ex-ganesh.jpg)  
            /*
            tbl_details tbl = new tbl_details();
            var allowedExtensions = new[] {
            ".Jpg", ".png", ".jpg", "jpeg"
        };
            tbl.Id = fc["Id"].ToString();
            tbl.Image_url = file.ToString(); //getting complete url  
            tbl.Name = fc["Name"].ToString();
            var fileName = Path.GetFileName(file.FileName); //getting only file name(ex-ganesh.jpg)  
            var ext = Path.GetExtension(file.FileName); //getting the extension(ex-.jpg)  
            if (allowedExtensions.Contains(ext)) //check what type of extension  
            {
                string name = Path.GetFileNameWithoutExtension(fileName); //getting file name without extension  
                string myfile = name + "_" + tbl.Id + ext; //appending the name with id  
                                                           // store the file inside ~/project folder(Img)  
                var path = Path.Combine(Server.MapPath("~/Img"), myfile);
                tbl.Image_url = path;
                obj.tbl_details.Add(tbl);
                obj.SaveChanges();
                file.SaveAs(path);
            }
            else
            {
                ViewBag.message = "Please choose only Image file";
            }
            */
            return View();
        }


        // GET: SiteImages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteImages siteImages = db.siteImg.Find(id);
            if (siteImages == null)
            {
                return HttpNotFound();
            }
            return View(siteImages);
        }

        // GET: SiteImages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SiteImages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SiteImagesId,ContentDataId,Image_url,Name")] SiteImages siteImages)
        {
            if (ModelState.IsValid)
            {
                db.siteImg.Add(siteImages);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(siteImages);
        }

        // GET: SiteImages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteImages siteImages = db.siteImg.Find(id);
            if (siteImages == null)
            {
                return HttpNotFound();
            }
            return View(siteImages);
        }

        // POST: SiteImages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SiteImagesId,ContentDataId,Image_url,Name")] SiteImages siteImages)
        {
            if (ModelState.IsValid)
            {
                db.Entry(siteImages).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(siteImages);
        }

        // GET: SiteImages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteImages siteImages = db.siteImg.Find(id);
            if (siteImages == null)
            {
                return HttpNotFound();
            }
            return View(siteImages);
        }

        // POST: SiteImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SiteImages siteImages = db.siteImg.Find(id);
            db.siteImg.Remove(siteImages);
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
