using BethanyPieShop2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BethanyPieShop2.Controllers
{
    public class AccountController : Controller
    {
        DbContextClass _context;

        public AccountController()
        {
            _context = new DbContextClass();
        }
        // GET: Account
        public ActionResult Index()
        {
            return View();

        }
        public ActionResult YourOrder()
        {
            return View();
        }

        //public ActionResult CartItems()
        //{
        //    return View();
        //}

        public ActionResult AccountDetails()
        {
            int single = (int)Session["UserId"];
            var singleCustomer = _context.Registers.Find(single);
            //return View(singleCustomer);
            return View(singleCustomer);
        }
    }
}