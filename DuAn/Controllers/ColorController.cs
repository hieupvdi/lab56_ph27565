using DuAn.IServices;
using DuAn.Models;
using DuAn.Services;
using Microsoft.AspNetCore.Mvc;

namespace DuAn.Controllers
{
    public class ColorController : Controller
    {
        private readonly IColorServices colorServices;// Interface
        public ColorController()
        {
            colorServices = new ColorServices();
        }
        public IActionResult Index()
        {
            return View();
        }
        //show màu
        public ActionResult ShowAllColor()
        {

            List<Color> colors = colorServices.GetAllColors();
            return View(colors); // Truyền trực tiếp 1 Obj Model duy nhất sang View

        }

        //thêm sửa xóa Color


        public IActionResult CreateColor() // Hiển thị form
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateColor(Color p)
        {
            if (colorServices.CreateColor(p))
            {
                return RedirectToAction("ShowAllColor");
            }
            else return BadRequest();
        }

        public IActionResult DetailColors(Guid id)
        {
            var colors = colorServices.GetColorById(id);
            return View(colors);
        }
        public IActionResult DeleteColor(Guid id)
        {
            if (colorServices.DeleteColor(id))
            {
                return RedirectToAction("ShowAllColor");
            }
            else return BadRequest();
        }
        [HttpGet]
        public IActionResult EditColor(Guid id)
        {
            var colors = colorServices.GetColorById(id);
            return View(colors);
        }
        public IActionResult EditColor(Color p)
        {
            if (colorServices.UpdateColor(p))
            {
                return RedirectToAction("ShowAllColor");
            }
            else return BadRequest();
        }



    }
}
