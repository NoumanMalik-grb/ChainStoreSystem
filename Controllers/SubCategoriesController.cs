using ChainStoreSystem.Data;
using ChainStoreSystem.Models;
using ChainStoreSystem.ViewModel.DropDownViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ChainStoreSystem.Controllers
{
    public class SubCategoriesController : Controller
    {
        private readonly ChainStoreDbContext _context;

        public SubCategoriesController(ChainStoreDbContext context)
        {
            _context = context;
        }

        // GET: SubCategories
        public IActionResult Index()
        {
            var result = (from s in _context.Sub_Categorie
                          join
c in _context.categories on s.Category_Fid equals c.Id
                          select new SubCategory()
                          {
                              SubCategoryName = s.SubCategoryName,
                              Category = c,
                              Category_Fid = s.Category_Fid,
                              SubCategoryStatus = s.SubCategoryStatus,
                              Id = s.Id
                          }).AsAsyncEnumerable();
            return View(result);
        }
        // GET: SubCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subCategory = await _context.Sub_Categorie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subCategory == null)
            {
                return NotFound();
            }

            return View(subCategory);
        }
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> items = _context.categories.
            Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.CategoryName });
            ViewBag.category = items;

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(int? id, CategoryDropDownViewModel model)
        {
            var subCategory = new SubCategory
            {
                Category_Fid = model.CategoryId,
                SubCategoryName = model.SubCategoryName,
                SubCategoryStatus = model.SubCategoryStatus
            };
            _context.Sub_Categorie.Add(subCategory);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        // GET: SubCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subCategory = await _context.Sub_Categorie.FindAsync(id);
            var categroyDt = new CategoryDropDownViewModel()
            {
                CategoryId = subCategory.Id,
                SubCategoryName = subCategory.SubCategoryName,
                SubCategoryStatus = subCategory.SubCategoryStatus
            };
            if (subCategory == null)
            {
                return NotFound();
            }
            IEnumerable<SelectListItem> SubCatitem = _context.categories.
               Select(c => new SelectListItem
               { Value = c.Id.ToString(), Text = c.CategoryName });
            ViewBag.Category = SubCatitem;
            return View(categroyDt);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CategoryDropDownViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var CategoryDt = await _context.Sub_Categorie.FindAsync(model.Id);
                CategoryDt.Category_Fid = model.CategoryId;
                CategoryDt.SubCategoryName = model.SubCategoryName;
                CategoryDt.SubCategoryStatus = model.SubCategoryStatus;
                _context.Update(CategoryDt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subCategory = await _context.Sub_Categorie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subCategory == null)
            {
                return NotFound();
            }

            return View(subCategory);
        }
        [HttpPost]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subCategory = await _context.Sub_Categorie.FindAsync(id);
            _context.Sub_Categorie.Remove(subCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool SubCategoryExists(int id)
        {
            return _context.Sub_Categorie.Any(e => e.Id == id);
        }
    }
}
