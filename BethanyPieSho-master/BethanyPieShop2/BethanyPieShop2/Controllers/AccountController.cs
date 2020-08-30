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
       // DbContextClass _context;
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult YourOrder()
        {
            return View();
        }

        public ActionResult CartItems()
        {
            return View();
        }

        public ActionResult AccountDetails()
        {
            //var singleCustomer = _context.Addresses.SingleOrDefault(c => c.UserId == id);
            //return View(singleCustomer);
            return View();
        }
    }
}