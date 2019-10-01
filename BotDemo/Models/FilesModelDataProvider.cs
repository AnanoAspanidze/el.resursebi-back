using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace BotDemo.Models
{
    public class FilesModelDataProvider
    {
        ResourcesDBEntities _db = new ResourcesDBEntities();


        public IEnumerable<Files> GetAllFiles()
        {
            return _db.Files;
        }

        public void UploadFiles(HttpPostedFileBase file)
        {
            //string path = Server.MapPath("~/Content/Upload/")
            var mapPath = HostingEnvironment.MapPath("~/Content/Files/");
            if (file != null)
            {
                file.SaveAs(mapPath + file.FileName);
                    _db.Files.Add(new Files()
                    {
                        Name = file.FileName,
                        Url = "/Content/Files/" + file.FileName,
                        StudentId = 1,
                    });
                _db.SaveChanges();
            }
        }


        public void DeleteFiles(Files file)
        {

            // var findImage = _db.images.FirstOrDefault(e => e.articlesId == article.Id);
            string fullPath = HostingEnvironment.MapPath(file.Url);
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }
            var deletablefiles = _db.Files.Where(e => e.Id == file.Id);
            _db.Files.RemoveRange(deletablefiles);

            _db.SaveChanges();
        }



    }
}