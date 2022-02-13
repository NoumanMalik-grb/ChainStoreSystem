﻿using ChainStoreSystem.Data;
using ChainStoreSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        [HttpPost]
        public IActionResult Login(Account a)
        {
            Account result = _context.accounts.Where(k => k.UserEmail == a.UserEmail && k.PassWord == a.PassWord).FirstOrDefault();
            if (result!= null)
            {
                if (result.Type== "student")
                {
                    HttpContext.Session.SetString("SessionStudent", JsonConvert.SerializeObject(result));
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                   ViewBag.message = "invalid user name or password";
                    return View();
                }
            }
            return View();
        }
    }
}
