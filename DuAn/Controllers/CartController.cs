using DuAn.IServices;
using DuAn.Models;
using DuAn.Services;
using Microsoft.AspNetCore.Mvc;

namespace DuAn.Controllers
{
    public class CartController : Controller
    {
   
        private readonly ICartServices CartServices;// Interface
    
        public CartController() {
          
            CartServices =new CartServices();
           

        }
        public IActionResult Index()
        {
            return View();
        }


        #region << SHOWBANG >>
        //show Cart
        public ActionResult ShowAllCart()
        {

            List<Cart> carts = CartServices.GetAllCarts();
            return View(carts); // Truyền trực tiếp 1 Obj Model duy nhất sang View

        }



        #endregion


















        //them sua xoa
        #region  << TSX >>

        public IActionResult CreateCart() // Hiển thị form
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCart(Cart p)
        {
            if (CartServices.CreateCart(p))
            {
                return RedirectToAction("ShowAllCart");
            }
            else return BadRequest();
        }

        public IActionResult DetailCarts(Guid id)
        {
            var carts = CartServices.GetCartById(id);
            return View(carts);
        }
        public IActionResult DeleteCart(Guid id)
        {
            if (CartServices.DeleteCart(id))
            {
                return RedirectToAction("ShowAllCart");
            }
            else return BadRequest();
        }
        [HttpGet]

        public IActionResult EditCart(Guid id)
        {
            var carts = CartServices.GetCartById(id);
            return View(carts);
        }
        public IActionResult EditCart(Cart p)
        {
            if (CartServices.UpdateCart(p))
            {
                return RedirectToAction("ShowAllCart");
            }
            else return BadRequest();
        }



        #endregion
    }
}
