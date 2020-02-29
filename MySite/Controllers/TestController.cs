using MySite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MySite.Controllers
{
    public class TestController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Test
        public ActionResult Index()
        {            
            ViewBag.ImageList = new SelectList(db.siteImg.ToList(), "SiteImagesId", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Submit(FormCollection collection)
        {
            ViewBag.Username = collection["UserName"];
            return View();
        }
    }
}