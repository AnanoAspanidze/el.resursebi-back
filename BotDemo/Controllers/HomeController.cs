using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BotDemo.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult AddImages()
        {
            return View();
        }
        
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult AddImages(HttpPostedFileBase files)
        {
            return View();
        }

        public ActionResult Gallery()
        {
            return View();
        }
    }
}