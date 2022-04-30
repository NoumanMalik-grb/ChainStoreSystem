using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChainStoreSystem.Controllers
{
    public class salechartController : Controller
    {
        public IActionResult Curentsale()
        {
            return View();
        }
    }
}
