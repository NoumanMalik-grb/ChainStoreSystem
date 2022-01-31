using ChainStoreSystem.Data;
using ChainStoreSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChainStoreSystem.Controllers
{
    public class CartController : Controller
    {
        private readonly ChainStoreDbContext _context;

        public CartController(ChainStoreDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult AddToCart(Product CartProduct)
        {

            return View();
        }
    }
}
