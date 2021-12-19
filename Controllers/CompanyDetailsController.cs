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
    public class CompanyDetailsController : Controller
    {
        private readonly ChainStoreDbContext _context;

        public CompanyDetailsController(ChainStoreDbContext context)
        {
            _context = context;
        }

        // GET: CompanyDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.companyDetails.ToListAsync());
        }

        // GET: CompanyDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyDetail = await _context.companyDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (companyDetail == null)
            {
                return NotFound();
            }

            return View(companyDetail);
        }

        // GET: CompanyDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CompanyDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CompanyName,CompanyEmail,CompanyLogo,Address,Message")] CompanyDetail companyDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(companyDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(companyDetail);
        }

        // GET: CompanyDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyDetail = await _context.companyDetails.FindAsync(id);
            if (companyDetail == null)
            {
                return NotFound();
            }
            return View(companyDetail);
        }

        // POST: CompanyDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CompanyName,CompanyEmail,CompanyLogo,Address,Message")] CompanyDetail companyDetail)
        {
            if (id != companyDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(companyDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyDetailExists(companyDetail.Id))
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
            return View(companyDetail);
        }

        // GET: CompanyDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyDetail = await _context.companyDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (companyDetail == null)
            {
                return NotFound();
            }

            return View(companyDetail);
        }

        // POST: CompanyDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var companyDetail = await _context.companyDetails.FindAsync(id);
            _context.companyDetails.Remove(companyDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyDetailExists(int id)
        {
            return _context.companyDetails.Any(e => e.Id == id);
        }
    }
}
