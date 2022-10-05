using BookWorm.DataAccess.Repository.IRepository;
using BookWorm.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookWormWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        public CompanyController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }
        //get
        public IActionResult Upsert(int? id)
        {
            Company company = new();
            if(id == null || id == 0)
            {
                return View(company);
            }
            else
            {
                company = _unitOfWork.CompanyRepository.GetFirstOrDefault(u => u.Id == id);
                return View(company);
            }
        }
        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Company obj)
        {
            if (ModelState.IsValid)
            {
                if(obj.Id == 0)
                {
                    _unitOfWork.CompanyRepository.Add(obj);
                }
                else
                {
                    _unitOfWork.CompanyRepository.Update(obj);
                }
                _unitOfWork.Save();
                TempData["success"] = "Product added succesfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var companyList = _unitOfWork.CompanyRepository.GetAll();
            return Json(new { data = companyList });
        }

        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.CompanyRepository.GetFirstOrDefault(u=>u.Id == id);
            if(obj == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _unitOfWork.CompanyRepository.Remove(obj);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Delete Successful" });
        }

        #endregion
    }
}
