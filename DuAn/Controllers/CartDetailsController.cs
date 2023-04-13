using DuAn.IServices;
using DuAn.Models;
using DuAn.Services;
using Microsoft.AspNetCore.Mvc;




namespace DuAn.Controllers
{
    public class CartDetailsController : Controller
    {
        private readonly IProductServices productServices;// Interface
        private readonly ICartDetailsServices cartDetailsServices;// Interface

        public IActionResult Index()
        {
            return View();
        }
        public CartDetailsController()
        {
            productServices=new ProductServices();
            cartDetailsServices = new CartDetailsServices();
        }
   



        //Add Sản phẩm vào giỏ hàng ảo

        //public IActionResult AddToCart(Guid id)// Sử dụng Session
        //{

        //    // B1: Dựa vào ID lấy ra sản phẩm
        //    var product = productServices.GetProductById(id);

        //    //B2: Lấy danh sách sản phẩm ra từ Session

        //    var cartdetails = SessionCartServices.GetObjFromSession(HttpContext.Session, "CartDetails");

        //    //var newcartDetails = new CartDetails
        //    //{
        //    //    Id = Guid.NewGuid(),
        //    //    UserId = null,
        //    //    IdSP = product.Id,
        //    //    Quantity = 1,
        //    //    Product = product
        //    //};
        //    if (cartdetails.Count == 0) // Trong trường hợp mà list rỗng
        //    {

        //        cartdetails.Add(product);
        //        SessionCartServices.SetObjToSession(HttpContext.Session, "CartDetails", cartdetails);
        //    }
        //    else
        //    {
        //        if (SessionCartServices.CheckObjInList(id, cartdetails))
        //        {
        //            // Tìm kiếm sản phẩm có trong giỏ hàng và cập nhật số lượng
        //            foreach (var p in cartdetails)
        //            {
        //                if (p.Id == id)
        //                {
        //                    p.Quantity++;
        //                    break;
        //                }
        //            }
        //            SessionCartServices.SetObjToSession(HttpContext.Session, "CartDetails", cartdetails);

        //            //return Content("Bình thường sẽ + số lượng nhưng tôi không thích thế");
        //        }
        //        else
        //        { // Nếu sp chưa tồn tại trong giỏ hàng thì thêm như
        //          // bth
        //            cartdetails.Add(product);
        //            SessionCartServices.SetObjToSession(HttpContext.Session, "CartDetails", cartdetails);
                    

        //        }
        //    }

        //    // B3: Kiểm tra và thêm SP vào giỏ hàng
        //    return RedirectToAction("ShowCart");
        //}






    }
}
