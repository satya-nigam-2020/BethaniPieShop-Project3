using BethanyPieShop2.Models;
using BethanyPieShop2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BethanyPieShop2.Controllers
{
    public class CartController : Controller
    {
        DbContextClass _context;
        List<ProductViewModel> cart;
        Address ad = new Address();
        // OrderDetail pl = new OrderDetail();


        public CartController()
        {
            _context = new DbContextClass();
            cart = new List<ProductViewModel>();

        }
        // GET: Cart
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult Buy(int id)
        {
            var singleProduct = _context.ProductDetails.SingleOrDefault(c => c.ProductId == id);


            if (Session["cart"] == null)
            {
                cart.Add(new ProductViewModel { ProductDetails = singleProduct, Quantity = 1 });
                Session["cart"] = cart;
            }
            else
            {
                List<ProductViewModel> cart = (List<ProductViewModel>)Session["cart"];
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {

                    cart.Add(new ProductViewModel { ProductDetails = singleProduct, Quantity = 1 });
                }
                Session["cart"] = cart;
            }
            return RedirectToAction("Index", cart);
        }

        //public ActionResult Order(ProductDetail p)
        //{
        //  //  orderDetail();
        //    return RedirectToAction("Address", cart);
        //}


        private int isExist(int id)
        {
            List<ProductViewModel> cart = (List<ProductViewModel>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].ProductDetails.ProductId.Equals(id))
                    return i;
            return -1;
        }


        public ActionResult Address()
        {
            return View();
        }

        public ActionResult Address2()
        {
        //    string single = (string)Session["FName"];
        //    var singleCustomer = _context.Addresses.Find(single);
            Address1();
            return View();
        }

        [HttpPost]
        public ActionResult Address1()
        {
            // Address ad = _context.Addresses.SingleOrDefault(c => c.UserId == Session["UserId"]);
            // ad.UserId = Session["UserId"];
            // ad.Register = 0;
            ad.UserId = Convert.ToInt32(Request.Form["UserId"]);
            ad.Country = (Request.Form["Country"]);
            ad.LName = (Request.Form["LName"]);
            ad.FName = (Request.Form["FName"]);
            ad.PhoneNo = (Request.Form["PhoneNo"]);
            ad.State = (Request.Form["State"]);
            ad.Zipcode = Convert.ToInt64(Request.Form["Zipcode"]);
            ad.Address1 = (Request.Form["Address1"]);
            ad.Address2 = (Request.Form["Address2"]);
            ad.City = (Request.Form["City"]);
            ad.EmailId = (Request.Form["EmailId"]);
            _context.Addresses.Add(ad);
            _context.SaveChanges();
            return View("Address");
            //return RedirectToAction("OrderDetail", cart);

        }
        [HttpPost]
        public ActionResult orderDetail(IEnumerable<BethanyPieShop2.Models.ProductDetail> pl)
        {


            if (Session["username"] == null)
            {
                return RedirectToAction("Register", "Users", new { area = "Admin" });
            }
            else
            {
                var pl1 = (List<BethanyPieShop2.ViewModel.ProductViewModel>)Session["cart"];
                // _context.OrderDetails.AddRange(pl);                     // Data Binding
                //_context.Set<ProductDetail>().AddOrUpdate(product);
                //    _context.SaveChanges();
                return RedirectToAction("Address", cart);
            }
        }

        public ActionResult ConfirmOrder()
        {
            return View();
        }

    }
}