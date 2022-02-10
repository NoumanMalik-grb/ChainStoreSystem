using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChainStoreSystem.Data;
using ChainStoreSystem.Models;
using ChainStoreSystem.ViewModel.DamagedProduct;

namespace ChainStoreSystem.Controllers
{
    public class DamagedProductsController : Controller
    {
        private readonly ChainStoreDbContext _context;

        public DamagedProductsController(ChainStoreDbContext context)
        {
            _context = context;
        }

        // GET: DamagedProducts
        public IActionResult Index()
        {
            var result = (from d in _context.damagedProducts
                          join a in _context.areas on d.Area_FId equals a.Id
                          join p in _context.products on d.Product_Fid equals p.Id
                          select new DamagedProduct()
                          {
                            Areas=a,
                            Products=p,
                            Area_FId=d.Area_FId,
                            Product_Fid=d.Product_Fid,
                            Id=d.Id,
                            Name=d.Name,
                            Type=d.Type,
                            Date_Time=d.Date_Time

                          }).AsAsyncEnumerable();
            return View(result);
        }

        // GET: DamagedProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var damagedProduct = await _context.damagedProducts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (damagedProduct == null)
            {
                return NotFound();
            }

            return View(damagedProduct);
        }

        // GET: DamagedProducts/Create
        public IActionResult Create()
        {
            //for area
            IEnumerable<SelectListItem> Aeaitem = _context.areas.
                Select(c => new SelectListItem
                { Value = c.Id.ToString(), Text = c.Name });
            ViewBag.Area = Aeaitem;
            //for product
            IEnumerable<SelectListItem> Proitem = _context.products.
                Select(p => new SelectListItem
                { Value = p.Id.ToString(), Text = p.ProductName });
            ViewBag.ProductItem = Proitem;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DamagedProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dmproduct = new DamagedProduct()
                {
                   Id=model.Id,
                   Name=model.Name,
                   Type=model.Type,
                   Date_Time=model.Date_Time,
                   Area_FId=model.AreaId,
                   Product_Fid=model.ProductId
                };
                _context.Add(dmproduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: DamagedProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var damagedProduct = await _context.damagedProducts.FindAsync(id);
            var Damagepro = new DamagedProductViewModel()
            {
                Id = damagedProduct.Id,
                Name = damagedProduct.Name,
                Type = damagedProduct.Type,
                Date_Time = damagedProduct.Date_Time,
                AreaId = damagedProduct.Area_FId,
                ProductId = damagedProduct.Product_Fid
            };
            if (damagedProduct == null)
            {
                return NotFound();
            }
            //for area
            IEnumerable<SelectListItem> Aeaitem = _context.areas.
                Select(c => new SelectListItem
                { Value = c.Id.ToString(), Text = c.Name });
            ViewBag.Area = Aeaitem;
            //for product
            IEnumerable<SelectListItem> Proitem = _context.products.
                Select(p => new SelectListItem
                { Value = p.Id.ToString(), Text = p.ProductName });
            ViewBag.ProductItem = Proitem;
            return View(Damagepro);
        }       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DamagedProductViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var DamagedDt = await _context.damagedProducts.FindAsync(model.Id);
                DamagedDt.Name = model.Name;
                DamagedDt.Type = model.Type;
                DamagedDt.Date_Time = model.Date_Time;
                DamagedDt.Area_FId = model.AreaId;
                DamagedDt.Product_Fid = model.ProductId;
                _context.Update(DamagedDt);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: DamagedProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var damagedProduct = await _context.damagedProducts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (damagedProduct == null)
            {
                return NotFound();
            }

            return View(damagedProduct);
        }

        // POST: DamagedProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var damagedProduct = await _context.damagedProducts.FindAsync(id);
            _context.damagedProducts.Remove(damagedProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DamagedProductExists(int id)
        {
            return _context.damagedProducts.Any(e => e.Id == id);
        }
    }
}
