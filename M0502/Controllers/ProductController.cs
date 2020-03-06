using M0502.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace M0502.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Display(int id)
        {
            var Context = new Models.NORTHWNDEntities();

            Product Producto = Context.Products.FirstOrDefault(p => p.ProductID == id);

            return View(Producto);
        }



        public ActionResult Create()
        {
            var Product = new Models.Product();
            return View(Product);
        }

        [HttpPost]
        public ActionResult Create(Product newProduct)
        {
            ActionResult Result = View(newProduct);

            if (ModelState.IsValid)
            {
                using (var Contex = new Models.NORTHWNDEntities())
                {
                    Contex.Products.Add(newProduct);
                    Contex.SaveChanges();
                    Result = RedirectToAction("Display", new { id = newProduct.ProductID });
                    
                }
            }
            else
            {

            }
            return Result;
        }

    }
}