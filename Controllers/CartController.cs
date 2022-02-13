using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChainStoreSystem.Controllers
{
    public class CartController : Controller
    {
        [HttpPost]
        public IActionResult GetModel(int id)
        {
            return View();
        }
    }
}
