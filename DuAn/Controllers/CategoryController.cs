using DuAn.IServices;
using DuAn.Models;
using DuAn.Services;
using Microsoft.AspNetCore.Mvc;

namespace DuAn.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryServices categoryServices;// Interface
        public CategoryController()
        {
            categoryServices = new CategoryServices();
        }
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult ShowAllCategory()
        {
            List<Category> categorys = categoryServices.GetAllCategorys();
            return View(categorys);
        }




        //thêm sửa xóa Color
        public IActionResult CreateCategory() // Hiển thị form
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCategory(Category p)
        {
            if (categoryServices.CreateCategory(p))
            {
                return RedirectToAction("ShowAllCategory");
            }
            else return BadRequest();
        }

        public IActionResult DetailCategorys(Guid id)
        {
            var categorys = categoryServices.GetCategoryById(id);
            return View(categorys);
        }
        public IActionResult DeleteCategory(Guid id)
        {
            if (categoryServices.DeleteCategory(id))
            {
                return RedirectToAction("ShowAllCategory");
            }
            else return BadRequest();
        }
        [HttpGet]
        public IActionResult EditCategory(Guid id)
        {
            var categorys = categoryServices.GetCategoryById(id);
            return View(categorys);
        }
        public IActionResult EditCategory(Category p)
        {
            if (categoryServices.UpdateCategory(p))
            {
                return RedirectToAction("ShowAllCategory");
            }
            else return BadRequest();
        }

    }
}
