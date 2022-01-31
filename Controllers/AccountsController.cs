 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChainStoreSystem.Data;
using ChainStoreSystem.Models;
using ChainStoreSystem.ViewModel;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using ChainStoreSystem.ViewModel.AccountViewModel;

namespace ChainStoreSystem.Controllers
{
    public class AccountsController : Controller
    {
        private readonly ChainStoreDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AccountsController(ChainStoreDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        // GET: Accounts
        public async Task<IActionResult> Index()
        {
            return View(await _context.accounts.ToListAsync());
        }

        // GET: Accounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.accounts
                .FirstOrDefaultAsync(m => m.Id == id);
            var accountdt = new AccountDetailViewModel()
            {
                Id = account.Id,
                UserName = account.UserName,
                UserEmail = account.UserEmail,
                UserMobile = account.UserMobile,
                Address1 = account.Address1,
                Address2 = account.Address2,
                CNIC = account.CNIC,
                Date_Time = account.Date_Time,
                PassWord = account.PassWord,
                Type = account.PassWord,
                ExistingImage = account.User_Picture
            };

            if (account == null)
            {
                return NotFound();
            }

            return View(accountdt);
        }

        // GET: Accounts/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AccountDetailViewModel model)
        {
            string UniqueFileName = UploadFile(model);
            var account = new Account()
            {
                UserName = model.UserName,
                UserEmail = model.UserEmail,
                UserMobile = model.UserMobile,
                Address1 = model.Address1,
                Address2 = model.Address2,
                CNIC = model.CNIC,
                Date_Time = model.Date_Time,
                PassWord = model.PassWord,
                Type = model.Type,
                User_Picture = UniqueFileName
            };
            _context.Add(account);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Accounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.accounts.FindAsync(id);
            var accountDtView = new AccountDetailViewModel()
            {
                Id = account.Id,
                UserName = account.UserName,
                UserEmail = account.UserEmail,
                UserMobile = account.UserMobile,
                Address1 = account.Address1,
                Address2 = account.Address2,
                CNIC = account.CNIC,
                Date_Time = account.Date_Time,
                PassWord = account.PassWord,
                Type = account.Type,
                ExistingImage = account.User_Picture
            };
            if (account == null)
            {
                return NotFound();
            }
            return View(accountDtView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AccountDetailViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var accountDt = await _context.accounts.FindAsync(model.Id);

                accountDt.UserName = model.UserName;
                accountDt.UserEmail = model.UserEmail;
                accountDt.Address1 = model.Address1;
                accountDt.Address2 = model.Address2;
                accountDt.CNIC = model.CNIC;
                accountDt.Date_Time = model.Date_Time;
                accountDt.PassWord = model.PassWord;
                accountDt.Type = model.Type;
                if (model.User_Picture != null)
                {
                    if (model.ExistingImage != null)
                    {
                        string filepath = Path.Combine(_webHostEnvironment.WebRootPath, "StoreImage", model.ExistingImage);
                        System.IO.File.Delete(filepath);
                    }
                    accountDt.User_Picture = UploadFile(model);
                }
                _context.Update(accountDt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Accounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.accounts
                .FirstOrDefaultAsync(m => m.Id == id);

            var accountdt = new AccountDetailViewModel()
            {
                Id = account.Id,
                UserName = account.UserName,
                UserEmail = account.UserEmail,
                UserMobile = account.UserMobile,
                Address1 = account.Address1,
                Address2 = account.Address2,
                CNIC = account.CNIC,
                Date_Time = account.Date_Time,
                PassWord = account.PassWord,
                Type = account.PassWord,
                ExistingImage = account.User_Picture
            };
            if (account == null)
            {
                return NotFound();
            }

            return View(accountdt);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var account = await _context.accounts.FindAsync(id);
            var CurrentImage = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\StoreImage", account.User_Picture);
            _context.accounts.Remove(account);
            if (await _context.SaveChangesAsync() > 0)
            {
                if (System.IO.File.Exists(CurrentImage))
                {
                    System.IO.File.Delete(CurrentImage);
                }
            }

            return RedirectToAction(nameof(Index));
        }

        private bool AccountExists(int id)
        {
            return _context.accounts.Any(e => e.Id == id);
        }
        //private funtion for upload image
        private string UploadFile(AccountDetailViewModel model)
        {
            string UniqueFileName = null;
            if (model.User_Picture != null)
            {
                var UploadImage = Path.Combine
               (_webHostEnvironment.WebRootPath, "StoreImage");
                UniqueFileName = Guid.NewGuid().ToString() 
                + "-" + model.User_Picture.FileName;
                string filePath = Path.Combine(UploadImage, UniqueFileName);
                using (var filestream = new FileStream(filePath, FileMode.Create))
                {
                    model.User_Picture.CopyTo(filestream);
                }
            }
            return UniqueFileName;
        }
    }
}
