using BethanyPieShop2.Models;
using BethanyPieShop2.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BethanyPieShop2.Controllers
{
    public class ProductDetailsController : Controller
    {
        // GET: ProductDetails
        DbContextClass _context;
        ProductDetail productObj;
        //ProDetailsAndCatagory productObj1 = new ProDetailsAndCatagory();
        //ProductDetail productObj = new ProductDetail();
        public ProductDetailsController()
        {
            _context = new DbContextClass();
          productObj  = new ProductDetail();

        }
        public ActionResult Index()
        {

            var allPies = _context.ProductDetails.Where(p => p.CatagoryId==1)
                .OrderBy(p => p.ProductName);
            return View(allPies);

        }
        public ActionResult ApplePie(int id)
        {
            var CatPie = _context.ProductDetails.Include(c => c.Catagory).Where(p => p.CatagoryId == id);

            return View(CatPie);
        }
        public ActionResult PumpkinPie()
        {
            return View();
        }
        public ActionResult RhubarbPie()
        {
            return View();
        }



        //// GET: ProductDetails
        //public ActionResult Index()
        //{
        //    var products = _context.ProductDetails.ToList();
        //    return View(products);
        //}

        //public ActionResult Details(int id)
        //{
        //    var singleProduct = _context.ProductDetails.SingleOrDefault(k => k.ProductId == id);
        //    if (singleProduct == null)
        //        return HttpNotFound();
        //    return View(singleProduct);
        //}

        //public ActionResult Update(int? id)
        //{
        //    var updateProduct = _context.ProductDetails.SingleOrDefault(c => c.ProductId == id);
        //    if (updateProduct == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    var up = new ProDetailsAndCatagory
        //    {
        //        ProductDetail = updateProduct,
        //        Catagories = _context.Categories.ToList()
        //    };
        //    return View("Create", up);
        //}

        public ActionResult Create()
        {
            var newCatagory = _context.Categories.ToList();
            var viewModel = new ProDetailsAndCatagory
            {
                Catagories = newCatagory
                //ProductDetail = new ProductDetail()
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(ProDetailsAndCatagory product)
        {

            //productObj.ProductName = Request.Form["ProductName"];
            //productObj.ShortDescription = Request.Form["ShortDescription"];
            //productObj.Price = Convert.ToInt32( Request.Form["Price"]);
            //productObj.LongDescription = Request.Form["LongDescription"];
            //productObj.ImagePath = Request.Form["ImagePath"];
            //productObj.CatagoryId  = Convert.ToInt32(Request.Form["CatagoryId"]);


            productObj.ProductName = product.ProductDetail.ProductName;
            productObj.ShortDescription = product.ProductDetail.ShortDescription;
            productObj.LongDescription = product.ProductDetail.LongDescription;
            productObj.Price = product.ProductDetail.Price;
            productObj.CatagoryId = product.ProductDetail.CatagoryId;
            productObj.ImagePath = product.ProductDetail.ImagePath;
            
            _context.ProductDetails.Add(productObj);                      // Data Binding

            _context.SaveChanges();
           
            return RedirectToAction("Index", "ProductDetails");
        }

        //public ActionResult Delete(int? id)
        //{
        //    var selectProduct = _context.ProductDetails.SingleOrDefault(c => c.ProductId == id);
        //    if (selectProduct == null)
        //        return HttpNotFound();
        //    _context.ProductDetails.Remove(selectProduct);
        //    _context.SaveChanges();
        //    return RedirectToAction("Index", "ProductDetails");
        //}
    }
}