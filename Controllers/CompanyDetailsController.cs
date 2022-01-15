using ChainStoreSystem.Data;
using ChainStoreSystem.Models;
using ChainStoreSystem.ViewModel.CompanyViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ChainStoreSystem.Controllers
{
    public class CompanyDetailsController : Controller
    {
        private readonly ChainStoreDbContext _context;
        private readonly IWebHostEnvironment _WebHostEnvironment;

        public CompanyDetailsController(ChainStoreDbContext context, IWebHostEnvironment HostEnvironment)
        {
            _context = context;
            _WebHostEnvironment = HostEnvironment;
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
            var companydt = new CompanyDetailViewModel()
            {
                Id = companyDetail.Id,
                CompanyName = companyDetail.CompanyName,
                CompanyEmail = companyDetail.CompanyEmail,
                Address = companyDetail.Address,
                Message = companyDetail.Message,
                ExistingImage = companyDetail.CompanyLogo

            };
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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CompanyDetailViewModel model)
        {
            if (ModelState.IsValid)
            {
                string UniqueFileName = UploadFile(model);
                var CompanyDet = new CompanyDetail
                {
                    CompanyName = model.CompanyName,
                    CompanyEmail = model.CompanyEmail,
                    Address = model.Address,
                    Message = model.Message,
                    CompanyLogo = UniqueFileName
                };
                _context.Add(CompanyDet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: CompanyDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyDetail = await _context.companyDetails.FindAsync(id);
            var CompanyDTView = new CompanyDetailViewModel()
            {
                Id = companyDetail.Id,
                CompanyName = companyDetail.CompanyName,
                CompanyEmail = companyDetail.CompanyEmail,
                Address = companyDetail.Address,
                Message = companyDetail.Message,
                ExistingImage = companyDetail.CompanyLogo
            };
            if (companyDetail == null)
            {
                return NotFound();
            }
            return View(CompanyDTView);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CompanyDetailViewModel model)
        {
            if (ModelState.IsValid)
            {
                var company = await _context.companyDetails.FindAsync(model.Id);
                company.CompanyName = model.CompanyName;
                company.CompanyEmail = model.CompanyEmail;
                company.Address = model.Address;
                company.Message = model.Address;

                if (model.CompanyLogo != null)
                {
                    if (model.ExistingImage != null)
                    {
                        string filepath = Path.Combine(_WebHostEnvironment.WebRootPath, "StoreImage", model.ExistingImage);
                        System.IO.File.Delete(filepath);
                    }
                    company.CompanyLogo = UploadFile(model);
                }
                _context.Update(company);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
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
            var companydt = new CompanyDetailViewModel()
            {
                Id = companyDetail.Id,
                CompanyName = companyDetail.CompanyName,
                CompanyEmail = companyDetail.CompanyEmail,
                Address = companyDetail.Address,
                Message = companyDetail.Message,
                ExistingImage = companyDetail.CompanyLogo
            };
            if (companyDetail == null)
            {
                return NotFound();
            }

            return View(companydt);
        }

        // POST: CompanyDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var companyDetail = await _context.companyDetails.FindAsync(id);
            var CurrentImage = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\StoreImage", companyDetail.CompanyLogo);

            _context.companyDetails.Remove(companyDetail);
            if (await _context.SaveChangesAsync() > 0)
            {
                if (System.IO.File.Exists(CurrentImage))
                {
                    System.IO.File.Delete(CurrentImage);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyDetailExists(int id)
        {
            return _context.companyDetails.Any(e => e.Id == id);
        }
        // working for upload image
        private string UploadFile(CompanyDetailViewModel model)
        {
            string UniqueFileName = null;
            if (model.CompanyLogo != null)
            {
                var UpLoadStoreImg = Path.Combine(_WebHostEnvironment.WebRootPath, "StoreImage");
                UniqueFileName = Guid.NewGuid().ToString() + "-" + model.CompanyLogo.FileName;
                string FilePath = Path.Combine(UpLoadStoreImg, UniqueFileName);
                using (var filestream = new FileStream(FilePath, FileMode.Create))
                {
                    model.CompanyLogo.CopyTo(filestream);
                }
            }
            return UniqueFileName;
        }
    }
}
