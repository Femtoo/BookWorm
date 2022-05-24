using BookWormWeb.Data;
using BookWormWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookWormWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDatabaseContext _db;

        public CategoryController(ApplicationDatabaseContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;
            return View(objCategoryList);
        }

        //get
        public IActionResult Create()
        {
            
            return View();
        }
        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name","The DisplayOrder cannot exactly match the Name");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
