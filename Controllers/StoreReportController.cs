using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChainStoreSystem.Controllers
{
    public class StoreReportController : Controller
    {
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
        public IActionResult TotalSale()
        {
            return View();
        }

    }
}
