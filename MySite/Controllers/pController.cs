using MySite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MySite.Controllers
{
    public class pController : Controller
    {
        // GET: p
        public ActionResult Index(string title)
        {
            int contentDataId = -1;

            if (String.IsNullOrWhiteSpace(title))
            {
                title = "Home";
            }
            string PageFormat = string.Empty;

            using (var db = new ApplicationDbContext())
            {
                var configQry = db.config.Where(f => f.Key == "PageFormat");
                if (configQry.Any())
                {
                    PageFormat = configQry.FirstOrDefault().Value;

                    var cdQry = db.cd.Where(f => f.URLString == title );
                    if (cdQry.Any())
                    {
                        ContentData cd = cdQry.FirstOrDefault();
                        contentDataId = cd.ContentDataId;
                        PageFormat = PageFormat.Replace("##PageTitle##", cd.Title);
                        cd.Content = HttpUtility.HtmlDecode(cd.Content); 
                        PageFormat = PageFormat.Replace("##PageContent##", cd.Content);
                    }
                }

                string szRemoteAddr = Request.UserHostAddress;
                //Request.ServerVariables["X_FORWARDED_FOR"]
                //string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];  
                //ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]; 

                ContentView cv = new ContentView
                {
                    ContentDataId = contentDataId,
                    DateTime = DateTime.Now,
                    IP = Request.UserHostAddress
                };
                db.cv.Add(cv);
                db.SaveChanges();

            }


            return Content(PageFormat);            
        }
    }
}