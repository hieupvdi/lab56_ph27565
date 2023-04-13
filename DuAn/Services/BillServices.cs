using DuAn.IServices;
using DuAn.Models;

namespace DuAn.Services
{
    public class BillServices : IBillServices
    {
        ShopDbContext Context;
        public BillServices()
        {
            Context = new ShopDbContext();

        }
        public bool CreateBill(Bill p)
        {
            try
            {
                //THEEM 1 DOOI TUONG VAOF DB
                Context.Bills.Add(p);
                Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;

            }
        }

        public bool DeleteBill(Guid id)
        {
            try
            {
                //Find(id) chi  dung duoc khi id laf khoa chinh
                dynamic Bill = Context.Bills.Find(id);//dynamic khiieu du lu naof cung nhan var thi k
                Context.Bills.Remove(Bill);
                Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;

            }
        }

        public List<Bill> GetAllBills()
        {
            return Context.Bills.ToList();
            //laays data chi loi code hoac loi ket noi sql  throw new NotImplementedException();
        }

        public Bill GetBillById(Guid id)
        {
            return Context.Bills.FirstOrDefault(p => p.Id == id);
            //return Context.Product.SingleOrDefault(p => p.Id == id);
        }

        public List<Bill> GetBillByName(string name)
        {
            //return Context.Product.Where(p => p.Name.Contains(name)).ToList();
            throw new NotImplementedException();
        }

        public bool UpdateBill(Bill p)
        {
            try
            {

                var Bill = Context.Bills.Find(p.Id);
                Bill.Status = p.Status;
                //cos the them thuoc tinh
                Context.Bills.Update(Bill);
                Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;

            }
        }
    }
}
