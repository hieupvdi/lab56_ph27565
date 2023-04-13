using DuAn.IServices;
using DuAn.Models;
using DuAn.Services;
using Microsoft.AspNetCore.Mvc;

namespace DuAn.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductServices productServices;// Interface
     
       
      
        public ProductController()
        {
            productServices = new ProductServices(); // DI
     
          
        
        }
        public IActionResult Index()
        {
            return View();
        }


        //show sản phẩm
        public ActionResult ShowAllProduct()
        {

            List<Product> products = productServices.GetAllProducts();
            return View(products); // Truyền trực tiếp 1 Obj Model duy nhất sang View

        }
        public ActionResult ShowOld()
        {
            var products = SessionServices.GetObjFromSession(HttpContext.Session, "pro");
            return View(products);// Truyền sang view
        }

        //show CartDetails ảo
        public IActionResult ShowCart()
        {
            // Lấy dữ liệu từ Session để truyền vào View
            //Đoạn mã này dùng để lấy dữ liệu giỏ hàng từ session và truyền vào view để hiển thị các sản phẩm trong giỏ hàng

            var cartdetail = SessionCartServices.GetObjFromSession(HttpContext.Session, "CartDetails");
            return View(cartdetail);// Truyền sang view



        }










        //thêm sửa xóa Product
        public IActionResult CreateProduct() // Hiển thị form
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateProduct(Product p, IFormFile LinkAnh)
        {

            // Lưu file ảnh vào thư mục "wwwroot/images"
            if (LinkAnh != null && LinkAnh.Length > 0)
            {
                var fileName = Path.GetFileName(LinkAnh.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    LinkAnh.CopyTo(stream);
                }
                // Lưu đường dẫn đến ảnh vào đối tượng User
                p.LinkAnh = "/images/" + fileName;
            }

            if (productServices.CreateProduct(p))
            {
                return RedirectToAction("ShowAllProduct");
            }
            else return BadRequest();
        }

        public IActionResult DetailProducts(Guid id)
        {
            var Products = productServices.GetProductById(id);
            return View(Products);
        }
        public IActionResult DeleteProduct(Guid id)
        {
            if (productServices.DeleteProduct(id))
            {
                return RedirectToAction("ShowAllProduct");
            }
            else return BadRequest();
        }
        [HttpGet]
        public IActionResult EditProduct(Guid id)
        {

            var product = productServices.GetProductById(id);
            var products = SessionServices.GetObjFromSession(HttpContext.Session, "pro");
            var ex = products.FirstOrDefault(x => x.Id == id);
            if (products.Count == 0) // Trong trường hợp mà list rỗng
            {
                products.Add(product);
                SessionServices.SetObjToSession(HttpContext.Session, "pro", products);
            }
            else
            {
                if (ex!=null)
                {
                    return View(product);
                } 
                else
                {
                    products.Add(product);
                    SessionServices.SetObjToSession(HttpContext.Session, "pro", products);

                }
            }
            return View(product);

            //var Products = productServices.GetProductById(id);
            //return View(Products);

        }

        public IActionResult EditProduct(Product p, IFormFile LinkAnh)
        {

            if (LinkAnh != null && LinkAnh.Length > 0)
            {
                var fileName = Path.GetFileName(LinkAnh.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    LinkAnh.CopyTo(stream);
                }

                p.LinkAnh = "/images/" + fileName;
            }

            if (productServices.UpdateProduct(p))
            {
                return RedirectToAction("ShowAllProduct");
            }
            else
            {
                return BadRequest();
            }

        }


        //List<Product> message = Products;
        //string message = Products.Name;
        // Đưa dữ liệu vào phiên làm việc (Session)
        //HttpContext.Session.SetString("mitom2trung", message);
        // Đọc dữ liệu ra từ Session
        //var sessionData = HttpContext.Session.GetString("mitom2trung");
        //ViewData["data"] = sessionData;


        //var Products = productServices.GetProductById(p.Id);
        //if (p.Price < 1)
        //{
        //    ModelState.AddModelError("", "Giá phải lớn hơn 1");
        //    return View();
        //}
        //if (p.AvailableQuantity < 1)
        //{
        //    ModelState.AddModelError("", "Số Lượng phải lớn hơn 1");
        //    return View();
        //}



        [HttpPost]

        public IActionResult RollBack(Guid id,string action) // Sử dụng Session
        {
            if (action == "RollBack")
            {
                var ok = SessionServices.GetObjFromSession(HttpContext.Session, "pro").FirstOrDefault(p=>p.Id==id);
                if (productServices.UpdateProduct(ok))
                {
                    return RedirectToAction("ShowAllProduct");

                }else  return BadRequest();
               
            }
            else
            {
                var product = productServices.GetProductById(id);
                return RedirectToAction("UpdateProduct", product);
            }
        }




        public IActionResult AddToCart(Guid id)// Sử dụng Session
        {

            // B1: Dựa vào ID lấy ra sản phẩm
            var product = productServices.GetProductById(id);
      
            //B2: Lấy danh sách sản phẩm ra từ Session

            var cartdetails = SessionCartServices.GetObjFromSession(HttpContext.Session, "CartDetails");
            var newcartDetails = new CartDetails
            {

                IdSP = product.Id,
                Quantity = 1,
                Product=product,

            };


            if (cartdetails.Count == 0) // Trong trường hợp mà list rỗng
            {

                cartdetails.Add(newcartDetails);
                SessionCartServices.SetObjToSession(HttpContext.Session, "CartDetails", cartdetails);
              
            }
            else
            {
                if (SessionCartServices.CheckObjInList(id, cartdetails))
                {
                    //Tìm kiếm sản phẩm có trong giỏ hàng và cập nhật số lượng
                    foreach (var p in cartdetails)
                    {
                        if (p.IdSP == id)
                        {
                            p.Quantity++;
                            break;
                        }
                    }
                    SessionCartServices.SetObjToSession(HttpContext.Session, "CartDetails", cartdetails);

                    //return Content("Bình thường sẽ + số lượng nhưng tôi không thích thế");
                }
                else
                { // Nếu sp chưa tồn tại trong giỏ hàng thì thêm như
                  // bth
                    cartdetails.Add(newcartDetails);
                    SessionCartServices.SetObjToSession(HttpContext.Session, "CartDetails", cartdetails);


                }
            }
            


            // B3: Kiểm tra và thêm SP vào giỏ hàng
            return RedirectToAction("ShowCart");
        }


        //xóa sản phẩm khỏi giỏ hàng theo id
        public IActionResult RemoveCart(Guid id,int Quantity)
        {
            var product = productServices.GetProductById(id);


            var cartdetails = SessionCartServices.GetObjFromSession(HttpContext.Session, "CartDetails");
            var newcartDetails = new CartDetails
            {

                IdSP = product.Id,
                Quantity = Quantity,
                Product = product,

            };
            if (cartdetails.Count == 0) // Trong trường hợp mà list rỗng
            {

                return Content("không có sp xóa vào mắt");

            }
            else
            {

                cartdetails.Remove(newcartDetails);
                SessionCartServices.SetObjToSession(HttpContext.Session, "CartDetails", cartdetails);

            }

            return RedirectToRoute("ShowCart");


        }


    }
}
