using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Upload_RetrieveImageMVC_5.Models;

namespace Upload_RetrieveImageMVC_5.Controllers
{
    public class HomeController : Controller
    {
        StudentDBEntities db=new StudentDBEntities();
        // GET: Home
        public ActionResult Index()
        {
            var data=db.Student_tbl.ToList();
            return View(data);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student_tbl s)
        {
            string fileName = Path.GetFileNameWithoutExtension(s.ImageFile.FileName);
            string extension=Path.GetExtension(s.ImageFile.FileName);
            HttpPostedFileBase postedFile = s.ImageFile;
            int length = postedFile.ContentLength;

            if (extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".png")
            {
                if (length < 1000000)
                {
                    fileName = fileName + extension;
                    s.Image_Path = "~/Image/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                    s.ImageFile.SaveAs(fileName);
                    db.Student_tbl.Add(s);
                    int a = db.SaveChanges();
                    if (a > 0)
                    {
                        ViewBag.Message = "<script>alert('Record Inserted !!')</script>";
                        ModelState.Clear();
                    }
                    else
                    {
                        ViewBag.Message = "<script>alert('Record Not Inserted !!')</script>";
                    }
                }


                else
                {
                    ViewBag.SizeMessage = "<script>alert('Size Should be of 1MB !!')</script>";
                }
            }
            else
            {
                ViewBag.ExtensionMessage = "<script>alert('ImageFile is Not Supported !!')</script>";
            }
            return View();
        }
    }
}