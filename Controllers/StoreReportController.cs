using ChainStoreSystem.Data;
using ChainStoreSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult SaleInvoice(int id, String sale)
        {
            ViewBag.Id = id;
            ViewBag.Sale = sale;
            return View();
        }

        //profit&loss
        public IActionResult ProfitAndLoss(FilterModel filter)
        {
            if (filter.DateFrom == null)
            {
                ViewBag.DateFrom = System.DateTime.Today.ToString("s");
                filter.DateFrom = System.DateTime.Now;
            }
            else
            {
                ViewBag.DateFrom = Convert.ToDateTime(filter.DateFrom).ToString("s");
            }
            if (filter.DateTo == null)
            {
                ViewBag.DateTo = System.DateTime.Today.ToString("s");
                filter.DateTo = System.DateTime.Now;
            }
            else
            {
                ViewBag.DateTo = Convert.ToDateTime(filter.DateTo).ToString("s");
            }


            ViewBag.SubCategory = _context.Sub_Categorie.
                Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.SubCategoryName });
            if (filter.SubCategory == null)
            {
                ViewBag.Product = _context.products.
                               Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.ProductName });
            }
            else
            {
                ViewBag.Product = _context.products.Where(x => x.SubCategory_Fid == filter.SubCategory)
                    .Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.ProductName });
            }
            var od = _context.orderDetails.Select(k => k.Order_FId).ToList();
            if (filter.SubCategory != null)
            {

                var pro = _context.products.Where(a => a.SubCategory_Fid == filter.SubCategory).Select
                    (a => a.Id).ToList();

                if (filter.Product != null)
                {
                    pro = _context.products.Where(x => x.Id == filter.Product).Select(x => x.Id).ToList();
                }
                od = _context.orderDetails.Where(n => pro.Contains(n.Product_FId)).Select(n => n.Order_FId).ToList();
            }
            //var malik = _context.orders.Where(n => n.Order_Type == "sale"
            //             & n.Order_DateTime >= filter.DateFrom & n.Order_DateTime <= filter.DateTo & od.Contains(n.Id)).OrderByDescending(n => n.Id).ToList();
            var malik = _context.orders.Include(s => s.Order_Detail).Where(s=>s.Order_Type=="sale");

            return View(malik);
        }
        [HttpGet]
        //Damaged Product    
        public IActionResult DamagedProduct()
        {
            return View();
        }

        public IActionResult StockReport(FilterModel filter)
        {
            if (filter.DateFrom == null)
            {
                ViewBag.DateFrom = System.DateTime.Today.ToString("s");
                filter.DateFrom = System.DateTime.Now;
            }

            if (filter.DateTo == null)
            {
                ViewBag.DateTo = System.DateTime.Today.ToString("s");
                filter.DateTo = System.DateTime.Now;
            }
            else
            {
                ViewBag.DateTo = Convert.ToDateTime(filter.DateTo).ToString("s");
            }

            ViewBag.SubCategory = _context.Sub_Categorie.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.SubCategoryName });
            if (filter.SubCategory == null)
            {
                ViewBag.Product = _context.products.Select(k => new SelectListItem { Value = k.Id.ToString(), Text = k.ProductName + "(" + k.Product_Discription_Max + ")" });
            }
            else
            {
                ViewBag.Product = _context.products.Where(x => x.SubCategory_Fid == filter.SubCategory).
                    Select(k => new SelectListItem { Value = k.Id.ToString(), Text = k.ProductName + "(" + k.Product_Discription_Max + ")" });
            }

            var p = _context.products.ToList();
            if (filter.SubCategory != null)
            {
                p = _context.products.Where(x => x.SubCategory_Fid == filter.SubCategory).ToList();
                if (filter.Product != null)
                {
                    p = _context.products.Where(x => x.Id == filter.Product).ToList();
                }
            }
            return View(p);
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

            ViewBag.SubCategory = _context.Sub_Categorie.Select
                (k => new SelectListItem { Value = k.Id.ToString(), Text = k.SubCategoryName });
            if (salerep.SubCategory == null)
            {
                ViewBag.Product = _context.products.Select(k => new SelectListItem
                { Value = k.Id.ToString(), Text = k.ProductName + "(" + k.Product_Discription_Max + ")" });
            }
            else
            {
                ViewBag.Product = _context.products.Where(m => m.SubCategory_Fid == salerep.SubCategory).
                    Select(m => new SelectListItem { Value = m.Id.ToString(), Text = m.ProductName + "(" + m.Product_Discription_Max + ")" });

            }
            var od = _context.orderDetails.Select(a => a.Order_FId).ToList();
            if (salerep.SubCategory != null)
            {
                var pro = _context.products.Where(a => a.SubCategory_Fid == salerep.SubCategory).Select
                    (a => a.Id).ToList();
                if (salerep.Product != null)
                {
                    pro = _context.products.Where(a => a.Id == salerep.Product).Select(a => a.Id).ToList();
                }
                od = _context.orderDetails.Where(n => pro.Contains(n.Product_FId)).
                    Select(n => n.Order_FId).ToList();
            }
            var malik = _context.orders.Where(x => x.Order_Type == "sale" & x.Order_DateTime >= salerep.DateFrom &
            x.Order_DateTime <= salerep.DateTo & od.Contains(x.Id)).OrderByDescending(x => x.Id).ToList();
            return View(malik);
>>>>>>>>> Temporary merge branch 2
        }
    }
}
