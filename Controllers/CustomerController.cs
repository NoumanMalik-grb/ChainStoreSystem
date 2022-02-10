using ChainStoreSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChainStoreSystem.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ChainStoreDbContext _context;

        public CustomerController(ChainStoreDbContext chainStore)
        {
            _context = chainStore;
        }
        public async Task<IActionResult> Index()
        {
            var pro = await _context.products.ToListAsync();
            return View(pro);
        }
        [HttpPost]
        public IActionResult cus(int id)
        {

            return View(nameof(Index));
        }
    }
}
