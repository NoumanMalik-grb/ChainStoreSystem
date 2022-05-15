using ChainStoreSystem.Data;
using ChainStoreSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChainStoreSystem.Controllers
{
    public class DataChart : Controller
    {
        private readonly ChainStoreDbContext _context;

        public DataChart(ChainStoreDbContext context)
        {
            _context = context;
        }
        // GET: /DataChart/
        public IActionResult LineChart() 
        {
            return View();
        }
       
        public JsonResult GetLineChart()
        {
            var orders = _context.orders.ToList();
            var orderDetails = _context.orderDetails.ToList();
            var products = _context.products.ToList();
            var result = (from od in orderDetails
                          join o in orders on od.Order_FId equals o.Id
                          join p in products on od.Product_FId equals p.Id
                          select new
                          {
                              o.Order_Year,
                              od.Quantity,
                              p.ProductName
                          }
                        ).Take(50);
            return Json(result);
        }
       
    }
}

