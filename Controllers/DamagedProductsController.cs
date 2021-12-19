using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChainStoreSystem.Data;
using ChainStoreSystem.Models;

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
        public async Task<IActionResult> Index()
        {
            return View(await _context.damagedProducts.ToListAsync());
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
            return View();
        }

        // POST: DamagedProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Type,Date_Time,Area_Id,Product_Fid")] DamagedProduct damagedProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(damagedProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(damagedProduct);
        }

        // GET: DamagedProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var damagedProduct = await _context.damagedProducts.FindAsync(id);
            if (damagedProduct == null)
            {
                return NotFound();
            }
            return View(damagedProduct);
        }

        // POST: DamagedProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Type,Date_Time,Area_Id,Product_Fid")] DamagedProduct damagedProduct)
        {
            if (id != damagedProduct.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(damagedProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DamagedProductExists(damagedProduct.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(damagedProduct);
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
