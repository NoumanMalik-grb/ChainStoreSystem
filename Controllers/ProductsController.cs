using ChainStoreSystem.Data;
using ChainStoreSystem.Models;
using ChainStoreSystem.ViewModel.ProductViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ChainStoreSystem.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ChainStoreDbContext _context;
        private readonly IWebHostEnvironment _WebHostEnvironment;

        public ProductsController(ChainStoreDbContext context, IWebHostEnvironment HostEnvironment)
        {
            _context = context;
            _WebHostEnvironment = HostEnvironment;
        }

        // GET: Products
        public IActionResult Index()
        {
            var result = (from p in _context.products 
                          join s in _context.Sub_Categorie on p.SubCategory_Fid equals s.Id 
                          join a  in _context.areas on p.Area_FId equals a.Id
                          select new Product()
                          {
                           SubCategorys=s,
                           Areas=a,
                           SubCategory_Fid=p.SubCategory_Fid,
                           Area_FId=p.Area_FId,
                           ProductName=p.ProductName,
                           Product_Picture=p.Product_Picture,
                           Product_Discription_Max=p.Product_Discription_Max,
                           Product_Sale_Price=p.Product_Sale_Price,
                           Product_Purchase_Price=p.Product_Purchase_Price,
                           Product_Status=p.Product_Status,
                           Product_Discount=p.Product_Discount,
                           Product_Add_Date=p.Product_Add_Date,
                           Product_Exp_Date=p.Product_Exp_Date
                          }
                        ).ToList();

            return View(result);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.products
                .FirstOrDefaultAsync(m => m.Id == id);
            var productDt = new ProductImageViewModel()
            {
                Id = product.Id,
                ProductName = product.ProductName,
                ExistingImage = product.Product_Picture,
                Product_Discription_Max = product.Product_Discription_Max,
                Product_Discription_Min = product.Product_Discription_Min,
                Product_Sale_Price = product.Product_Sale_Price,
                Product_Purchase_Price = product.Product_Sale_Price,
                Product_Status = product.Product_Status,
                Product_Discount = product.Product_Discount,
                Product_Exp_Date = product.Product_Exp_Date,
                Product_Add_Date = product.Product_Add_Date,
                
            };
            if (product == null)
            {
                return NotFound();
            }

            return View(productDt);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> SubCatitem = _context.Sub_Categorie.Select(c => new SelectListItem 
            { Value = c.Id.ToString(), Text = c.SubCategoryName });
            ViewBag.SubCategory = SubCatitem;
            IEnumerable<SelectListItem> Aeaitem = _context.areas.Select(c => new SelectListItem
            {Value=c.Id.ToString(), Text=c.Name });
            ViewBag.Area = Aeaitem;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductImageViewModel model)
        {
            string UniqueFileName = UploadFile(model);
            var productDt = new Product()
            {
                ProductName = model.ProductName,
                Product_Picture = UniqueFileName,
                Product_Discription_Min = model.Product_Discription_Min,
                Product_Discription_Max = model.Product_Discription_Max,
                Product_Sale_Price = model.Product_Sale_Price,
                Product_Purchase_Price = model.Product_Purchase_Price,
                Product_Status = model.Product_Status,
                Product_Discount = model.Product_Discount,
                Product_Add_Date = model.Product_Add_Date,
                Product_Exp_Date = model.Product_Exp_Date,
                SubCategory_Fid=model.Sub_categoryId,
                Area_FId=model.AreaId
            };
            _context.Add(productDt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.products.FindAsync(id);
            var productDt = new ProductImageViewModel()
            {
                Id = product.Id,
                ProductName = product.ProductName,
                ExistingImage = product.Product_Picture,
                Product_Discription_Max = product.Product_Discription_Max,
                Product_Discription_Min = product.Product_Discription_Min,
                Product_Sale_Price = product.Product_Sale_Price,
                Product_Purchase_Price = product.Product_Purchase_Price,
                Product_Status = product.Product_Status,
                Product_Discount = product.Product_Discount,
                Product_Add_Date = product.Product_Add_Date,
                Product_Exp_Date = product.Product_Exp_Date,
                
            };
            if (product == null)
            {
                return NotFound();
            }
            return View(productDt);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductImageViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var productDt = await _context.products.FindAsync(model.Id);
                productDt.ProductName = model.ProductName;
                productDt.Product_Discription_Max = model.Product_Discription_Max;
                productDt.Product_Discription_Min = model.Product_Discription_Min;
                productDt.Product_Sale_Price = model.Product_Sale_Price;
                productDt.Product_Sale_Price = model.Product_Sale_Price;
                productDt.Product_Status = model.Product_Status;
                productDt.Product_Discount = model.Product_Discount;
                productDt.Product_Add_Date = model.Product_Add_Date;
                productDt.Product_Exp_Date = model.Product_Exp_Date;
             
                if (model.Product_Picture != null)
                {
                    if (model.ExistingImage != null)
                    {
                        string filepath = Path.Combine(_WebHostEnvironment.WebRootPath, "StoreImage", model.ExistingImage);
                        System.IO.File.Delete(filepath);
                    }
                    productDt.Product_Picture = UploadFile(model);
                }
                _context.Update(productDt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.products
                .FirstOrDefaultAsync(m => m.Id == id);
            var productDt = new ProductImageViewModel()
            {
                Id = product.Id,
                ProductName = product.ProductName,
                ExistingImage = product.Product_Picture,
                Product_Discription_Max = product.Product_Discription_Max,
                Product_Discription_Min = product.Product_Discription_Min,
                Product_Sale_Price = product.Product_Sale_Price,
                Product_Purchase_Price = product.Product_Purchase_Price,
                Product_Status = product.Product_Status,
                Product_Discount = product.Product_Discount,
                Product_Add_Date = product.Product_Add_Date,
                Product_Exp_Date = product.Product_Add_Date,
            };
            if (product == null)
            {
                return NotFound();
            }

            return View(productDt);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.products.FindAsync(id);
            _context.products.Remove(product);
            var CurrentImage = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\StoreImage", product.Product_Picture);
            if (await _context.SaveChangesAsync() > 0)
            {
                if (System.IO.File.Exists(CurrentImage))
                {
                    System.IO.File.Delete(CurrentImage);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.products.Any(e => e.Id == id);
        }

        //Upload Image Function
        private string UploadFile(ProductImageViewModel model)
        {
            string UniqueFileName = null;
            if (model.Product_Picture != null)
            {
                var UploadImage = Path.Combine(_WebHostEnvironment.WebRootPath, "StoreImage");
                UniqueFileName = Guid.NewGuid().ToString() + "-" + model.Product_Picture.FileName;
                string filepath = Path.Combine(UploadImage, UniqueFileName);
                using (var filestream = new FileStream(filepath, FileMode.Create))
                {
                    model.Product_Picture.CopyTo(filestream);
                }
            }
            return UniqueFileName;
        }

    }
}
