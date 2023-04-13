using DuAn.IServices;
using DuAn.Models;
using DuAn.Services;
using Microsoft.AspNetCore.Mvc;

namespace DuAn.Controllers
{
    public class BillController : Controller
    {
        private readonly IBillServices BillServices;// Interface
        private readonly IBillDetailsServices BillDetailsServices;// Interface
        public BillController()
        {
            BillServices=new BillServices();
            BillDetailsServices=new BillDetailsServices();  
        }
        public IActionResult Index()
        {
            return View();
        }

        //show Bill
        public ActionResult ShowAllBill()
        {

            List<Bill> bills = BillServices.GetAllBills();
            return View(bills); // Truyền trực tiếp 1 Obj Model duy nhất sang View

        }


        //show Bill
        public ActionResult ShowAllBillDetails()
        {

            List<BillDetails> billdetails = BillDetailsServices.GetAllBillDetailss();
            return View(billdetails); // Truyền trực tiếp 1 Obj Model duy nhất sang View

        }




        //them sua xoa


        public IActionResult CreateBill() // Hiển thị form
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateBill(Bill p)
        {
            if (BillServices.CreateBill(p))
            {
                return RedirectToAction("ShowAllBill");
            }
            else return BadRequest();
        }

        public IActionResult DetailBills(Guid id)
        {
            var bills = BillServices.GetBillById(id);
            return View(bills);
        }
        public IActionResult DeleteBill(Guid id)
        {
            if (BillServices.DeleteBill(id))
            {
                return RedirectToAction("ShowAllBill");
            }
            else return BadRequest();
        }
        [HttpGet]

        public IActionResult EditBill(Guid id)
        {
            var bills = BillServices.GetBillById(id);
            return View(bills);
        }
        public IActionResult EditBill(Bill p)
        {
            if (BillServices.UpdateBill(p))
            {
                return RedirectToAction("ShowAllBill");
            }
            else return BadRequest();
        }


    }
}
