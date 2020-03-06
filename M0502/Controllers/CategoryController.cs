using M0502.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace M0502.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }


        public FileStreamResult GetImage(int id) {

            var Context = new Models.NORTHWNDEntities();

            int OffSet = 78;
            var bytes = Context.Categories.Where(c=> c.CategoryID == id).Select(c=>c.Picture).FirstOrDefault();

            return File(
                        new MemoryStream(
                                            bytes,OffSet,bytes.Length-OffSet)
                       ,"image/jpeg");
                

        }



        public ActionResult UploadPhoto()
        {
            var Category = new Models.Category();

            return View(Category);
        }

        [HttpPost]
        public ActionResult UploadPhoto2(Category newCategory, HttpPostedFileBase file)
        {
            ActionResult Result = View(newCategory);
            /**Aqui deberia de estar la logica para validar y guardar en la base de datos*/
            /*Aqui deberia estar la logica para recuperar el archivo*/
            if(file!=null && file.ContentLength > 0)
            {
                Result = File(file.InputStream, file.ContentType);
             
            }
            return Result;

        }


        [HttpPost]
        public ActionResult UploadPhoto(Category newCategory)
        {
            ActionResult Result = View(newCategory);
            /**Aqui deberia de estar la logica para validar y guardar en la base de datos*/
            /*Aqui deberia estar la logica para recuperar el archivo*/
            if (Request.Files.Count > 0 != null && Request.Files[0].ContentLength > 0)
            {
                Result = File(Request.Files[0].InputStream, Request.Files[0].ContentType);

            }
            return Result;

        }

    }
    }
