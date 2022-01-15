using ChainStoreSystem.Data;
using ChainStoreSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChainStoreSystem.Controllers
{
    public class LogInController : Controller
    {
        private readonly ChainStoreDbContext _context;

        public LogInController(ChainStoreDbContext dbContext)
        {
            _context = dbContext;
        }
        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }
        //[HttpPost]
        //public IActionResult Login(Account accounts)
        //{
        //    var result=
        //    return View();
        //}
    }
}
