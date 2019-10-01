using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BotDemo.Models;

namespace BotDemo.Controllers
{
    public class HomeController : Controller
    {
        FilesModelDataProvider FilesData = new FilesModelDataProvider();
        ResourcesDBEntities _db = new ResourcesDBEntities();

        public ActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult FilesPage()
        {
            return View();
        }

        //[ValidateAntiForgeryToken]
        //[HttpPost]
        //public ActionResult UploadFiles(HttpPostedFileBase files)
        //{
        //    return View();
        //}

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult UploadFiles()
        {
            string path = Server.MapPath("~/Content/Upload/");
            HttpFileCollectionBase files = Request.Files;
            for (int i = 0; i < files.Count; i++)
            {
                HttpPostedFileBase file = files[i];
                //file.SaveAs(path + file.FileName);
                FilesData.UploadFiles(file);
            }
            return Json(files.Count + " Files Uploaded!");
        }

        [HttpGet]
        public ActionResult Gallery()
        {
            var result = FilesData.GetAllFiles();
            return View(result);
        }

        
        [HttpPost]       
        //[ValidateAntiForgeryToken]
        public JsonResult DeleteFiles(/*int id,*/ int primary)
        {
            //var articleIds = _db.articles.FirstOrDefault(e => e.Id == id);
            var result = _db.Files.FirstOrDefault(/*x => x.Id == id &&*/x=> x.Id == primary);
            try
            {

                FilesData.DeleteFiles(result);
                //ViewBag.ImageDeleteConfirm="Image has been deleted";
            }
            catch
            {
                //return View(result);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            //return RedirectToAction("ArticlesList");
            return Json(new { success = true });
        }

    }
}