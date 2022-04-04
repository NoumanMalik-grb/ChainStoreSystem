using ChainStoreSystem.Data;
using ChainStoreSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;

namespace ChainStoreSystem.Controllers
{
    public class StoreReportController : Controller
    {
        private readonly ChainStoreDbContext _context;

        public StoreReportController(ChainStoreDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        //action for sale invoice
        public IActionResult SaleInvoice()
        {
            return View();
        }
        [HttpGet]
        //profit&loss
        public IActionResult ProfitAndLoss()
        {
            return View();
        }
        [HttpGet]
        //Damaged Product
        public IActionResult DamagedProduct()
        {
            return View();
        }
        [HttpGet]
        //Damaged Product
        public IActionResult StockReport()
        {
            return View();
        }
        [HttpGet]
        //Damaged Product
        public IActionResult HighselingArea()
        {
            return View();
        }
        //Damaged Product
        public IActionResult LowselingArea()
        {
            return View();
        }
        //Damaged Product
        public IActionResult StoreRecordReports()
        {
            return View();
        }
        //total sale

        public IActionResult TotalSale(FilterModel salerep)
        {
            if (salerep.DateFrom == null)
            {
                ViewBag.DateFrom = System.DateTime.Today.ToString("s");
                salerep.DateFrom = System.DateTime.Now;
            }
            else
            {
                ViewBag.DateFrom = Convert.ToDateTime(salerep.DateFrom).ToString("s");
            }
            if (salerep.DateTo == null)
            {
                ViewBag.DateTo = System.DateTime.Today.ToString("s");
                salerep.DateTo = System.DateTime.Now;
            }
            else
            {
                ViewBag.DateTo = Convert.ToDateTime(salerep.DateTo).ToString("s");
            }

            ViewBag.Category = _context.categories.Select
                (k => new SelectListItem { Value = k.Id.ToString(), Text = k.CategoryName });

            ViewBag.Product = _context.products.Select
            (x => new SelectListItem { Value = x.Id.ToString(), Text = x.ProductName });


            var malik = _context.orders.Where(x => x.Order_Type == "sale" & x.Order_DateTime >= salerep.DateFrom &
            x.Order_DateTime <= salerep.DateTo).OrderByDescending(x => x.Id).ToList();
            return View(malik);
        }


    }
}
