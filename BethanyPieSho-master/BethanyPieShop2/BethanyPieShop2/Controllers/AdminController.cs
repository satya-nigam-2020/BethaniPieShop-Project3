using BethanyPieShop2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace BethanyPieShop2.Controllers
{
   
    public class AdminController : Controller
    {
        DbContextClass _context;
        public AdminController()
        {
            _context = new DbContextClass();
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserIndex()
        {
            var res = _context.Registers.ToList();

            return View(res);
        }

        public ActionResult OrderIndex()
        {
            var res1 = _context.OrderDetails.Include(c=>c.Register).ToList();
            return View(res1);
        }

        [HttpPost]
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var singleCustomer = _context.Registers.SingleOrDefault(c => c.UserId == id);
            _context.Registers.Remove(singleCustomer);
            _context.SaveChanges();
            return View();
        }
    }
}