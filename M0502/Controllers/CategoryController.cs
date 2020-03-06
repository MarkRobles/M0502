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
        

        }
    }
