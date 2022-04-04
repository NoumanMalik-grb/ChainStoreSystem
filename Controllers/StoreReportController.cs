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
        [HttpGet]
        public IActionResult TotalSale(FilterModel filter)
        {
            if (filter.DateFrom == null)
            {
                ViewBag.DateFrom = System.DateTime.Today.ToString("s");
                filter.DateFrom = System.DateTime.Today;
            }
            else
            {
                ViewBag.DateFrom = Convert.ToDateTime(filter.DateFrom).ToString("s");
            }
            if (filter.DateTo == null)
            {
                ViewBag.DateTo = System.DateTime.Now.ToString("s");
                filter.DateTo = System.DateTime.Now;
            }
            else
            {
                ViewBag.DateFrom = Convert.ToDateTime(filter.DateTo).ToString("s");
            }

            ViewBag.SubCategory = _context.Sub_Categorie.
                Select(n => new SelectListItem { Value = n.Id.ToString(), Text = n.SubCategoryName });
            if (filter.SubCategory == null)
            {
                ViewBag.Product = _context.products.Select(n => new SelectListItem
                { Value = n.Id.ToString(), Text = n.ProductName });
            }
            else
            {
                ViewBag.Product = _context.products.Where
                    (n => n.SubCategory_Fid == filter.SubCategory).
                    Select(n => new SelectListItem { Value = n.Id.ToString(), Text = n.ProductName });
            }
            var od = _context.orderDetails.Select(x => x.Order_FId).ToList();
            if (filter.SubCategory != null)
            {
                var p = _context.products.Where
                    (n => n.SubCategory_Fid == filter.SubCategory).
                    Select(n => n.Id).ToList();
                if (filter.Product != null)
                {
                    p = _context.products.Where(n => n.Id == filter.Product).
                        Select(n => n.Id).ToList();
                }
                od = _context.orderDetails.Where(x => p.Contains(x.Product_FId)).
                    Select(x => x.Order_FId).ToList();

            }
            //var o = _context.orders.Where
            //    (x => x.Order_Type == "sale" & x.Order_DateTime >= filter.DateFrom &
            //    x.Order_DateTime <= filter.DateTo & od.Contains(x.Id)).ToList();
            var o = _context.orders.Where(x => x.Order_Type == "sale").ToList();
            return View(o);
        }

    }
}
