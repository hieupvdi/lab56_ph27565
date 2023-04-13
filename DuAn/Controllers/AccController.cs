using DuAn.IServices;
using DuAn.Models;
using DuAn.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace DuAn.Controllers
{
    public class AccController : Controller
    {
        private readonly IUserServices userServices;// Interface
        public readonly IRoleServices roleServices;
        public AccController()
        {
            userServices = new UserServices();
            roleServices = new RoleServices();
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DangKy(User p)
        {
            //DuAn.Models.ShopDbContext db = new DuAn.Models.ShopDbContext();

            //var user = db.Users.FirstOrDefault(p => p.Username == Username);
          

            var check = userServices.GetUserByName(p.Username);
            if (check == null)
            {

                userServices.CreateUser(p);
            }
            else
            {
                ViewBag.error = "Username đã đăng ký";
                return View();
            }
             return BadRequest();



        }
            
    
    }
}
