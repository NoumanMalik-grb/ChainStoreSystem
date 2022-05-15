using ChainStoreSystem.Data;
using ChainStoreSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System.Linq;
namespace ChainStoreSystem.Controllers
{

    public class SalePerson : Controller
    {
        private readonly ChainStoreDbContext _context;

        public SalePerson(ChainStoreDbContext context)
        {
            _context = context;
        }
        public IActionResult SalepersonView(string sortorder, string currentFilter, string SearchStirng, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortorder;
            ViewData["NameSortParm"] = string.IsNullOrEmpty(sortorder) ? "Name_Dcen" : "";
            ViewData["DateSortParm"] = sortorder == "Date" ? "date_dec" : "Date";
            ViewData["CurrentFilter"] = SearchStirng;
            var CuOrder = from od in _context.orders select od;
            
            if (!string.IsNullOrEmpty(SearchStirng)) 
            {
                CuOrder = CuOrder.Where(k => k.Id.ToString().Contains(SearchStirng));
            }

            switch (sortorder)
            {
                case "Name_Dcen":
                    CuOrder = CuOrder.OrderByDescending(od => od.Order_Name);
                    break;
                case "Date":
                    CuOrder = CuOrder.OrderBy(od => od.Order_Delivery_Status);
                    break;
                case "date_dec":
                    CuOrder = CuOrder.OrderByDescending(od => od.Order_DateTime);
                    break;
                default:
                    CuOrder = CuOrder.OrderBy(od => od.Order_Name);
                    break;
            }
            //paging code
            int pageSize = 7;
            return View(PaginatedList<Order>.Create(CuOrder.AsNoTracking(), pageNumber ?? 1, pageSize));
        }
        //for searching
        public JsonResult Autocomplete(string prefix)
        {
            var searchorder = (from k in this._context.orders
                               where
                               k.Id.ToString().StartsWith(prefix)
                               select new
                               {
                                   label=k.Order_Delivery_Status,
                                   val=k.Id
                               }
                             ).ToList();
            return Json(searchorder);
        }
        //for download ExcelSheet file
        public IActionResult ExportToExcelSheet()
        {
            var SaleOrder = _context.orders.ToList();
            byte[] FileContexts;
            ExcelPackage ep = new ExcelPackage();
            ExcelWorksheet sheet = ep.Workbook.Worksheets.Add("SaleOrderInfo");
            sheet.Cells["A1"].Value = "OrderNo";
            sheet.Cells["B1"].Value = "Name";
            sheet.Cells["C1"].Value = "City";
            sheet.Cells["D1"].Value = "Type";
            sheet.Cells["E1"].Value = "Status";
            sheet.Cells["F1"].Value = "Delivery Status";
            sheet.Cells["G1"].Value = "Order Area";
            sheet.Cells["H1"].Value = "DateTime";
            int row = 2;
            foreach (var k in SaleOrder)
            {
                sheet.Cells[string.Format("A{0}", row)].Value = k.Id;
                sheet.Cells[string.Format("B{0}", row)].Value = k.Order_Name;
                sheet.Cells[string.Format("C{0}", row)].Value = k.Order_City;
                sheet.Cells[string.Format("D{0}", row)].Value = k.Order_Type;
                sheet.Cells[string.Format("E{0}", row)].Value = k.Order_Status;
                sheet.Cells[string.Format("F{0}", row)].Value = k.Order_Delivery_Status;
                sheet.Cells[string.Format("G{0}", row)].Value = k.Area;
                sheet.Cells[string.Format("H{0}", row)].Value = k.Order_DateTime;
                row++;
            }
            sheet.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            FileContexts = ep.GetAsByteArray();
            if (FileContexts == null || FileContexts.Length == 0)
            {
                return NotFound();
            }
            return File(
                fileContents: FileContexts,
                contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileDownloadName: "SaleOrder.xlsx"
                );
        }
        //for change order statsu
        public IActionResult Deliverorder(int ?id) 
        {
            Order k = _context.orders.Where(x => x.Id == id).FirstOrDefault();
            k.Order_Delivery_Status = "Deliver";
            _context.Entry(k).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("SalepersonView");
         }
        // for the cancel order
        public IActionResult CancelOrder(int ?id) 
        {
            Order s = _context.orders.Where(n => n.Id == id).FirstOrDefault();
            s.Order_Delivery_Status = "Cancel";
            _context.Entry(s).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("SalepersonView");
        }
    }
}
