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
        public  IActionResult ProfitAndLoss(FilterModel filter)
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
            //var malik = _context.orders.Where(x => x.Order_Type == "sale").Include(x => x.OrderDetails).ToList();
            //var orders = _context.orders.ToList<Order>();
            //var OdDetail = _context.orderDetails.ToList<OrderDetail>();
            var result = (from o in _context.orders 
                          let ode = _context.orderDetails.Where (x=> x.Id == o.Id).ToList()
                          where o.Order_Type == "sale"
                          select new OrderViewModel
                          {
                             Id = o.Id,
                             OrderDetails = ode,
                            Order_Name=o.Order_Name
                          }).ToList();
            return View(result);
        }
        [HttpGet]
        //Damaged Product 
        public IActionResult DamagedProduct(FilterDamagedProduct filterDamaged)
        {
            if (filterDamaged.DateFrom == null)
            {
                ViewBag.DateFrom = System.DateTime.Today.ToString("s");
                filterDamaged.DateFrom = System.DateTime.Now;
            }

            if (filterDamaged.DateTo == null)
            {
                ViewBag.DateTo = System.DateTime.Today.ToString("s");
                filterDamaged.DateTo = System.DateTime.Now;
            }
            else
            {
                ViewBag.DateTo = Convert.ToDateTime(filterDamaged.DateTo).ToString("s");
            }
            //for getlis area
            ViewBag.GetArea = _context.areas.Select(x => new SelectListItem
            { Value = x.Id.ToString(), Text = x.Name });
            // for Getlist Product
            ViewBag.GetProduct = _context.products.Select(g => new SelectListItem
            { Value = g.Id.ToString(), Text = g.ProductName });
            var malik = (from d in _context.damagedProducts
                         join p in _context.products on d.Product_Fid equals p.Id
                         join a in _context.areas on d.Area_FId equals a.Id
                         select new DamagedProduct()
                         {
                             Products=p,
                             Areas=a,
                             Product_Fid=d.Product_Fid,
                             Area_FId=d.Area_FId,
                             Id=d.Id,
                             Name=d.Name,
                             Type=d.Type,
                             Date_Time=d.Date_Time
                         }).AsAsyncEnumerable();


            return View(malik);
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
            var result = (from pro in _context.products
                          let prod = _context.orderDetails.Where(k => k.Product_FId == pro.Id &&k.Orders.Order_DateTime<=filter.DateTo).ToList()
                          select new ProductViewModel()
                          {
                            ProductViewId=pro.Id,
                            ProductName=pro.ProductName,
                            Product_Picture=pro.Product_Picture,
                            Product_Discription_Max=pro.Product_Discription_Max,
                            Product_Sale_Price=pro.Product_Sale_Price,
                            Product_Purchase_Price=pro.Product_Purchase_Price,
                            Product_Status=pro.Product_Status,
                             Product_Quantity=pro.Product_Quantity,
                            ProOrderDetails=prod
                          }
                        ).ToList();
            return View(result);
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
        }
    }
}
