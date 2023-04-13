using DuAn.IServices;
using DuAn.Models;
using System.Xml.Linq;

namespace DuAn.Services
{
    public class CartDetailsServices : ICartDetailsServices
    {
        ShopDbContext Context;
        public CartDetailsServices()
        {
            Context = new ShopDbContext();

        }
        public bool CreateCartDetails(CartDetails p)
        {
            try
            {
                //THEEM 1 DOOI TUONG VAOF DB
                Context.CartDetailss.Add(p);
                Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;

            }
        }

        public bool DeleteCartDetails(Guid id)
        {
            try
            {
                //Find(id) chi  dung duoc khi id laf khoa chinh
                dynamic CartDetails = Context.CartDetailss.Find(id);//dynamic khiieu du lu naof cung nhan var thi k
                Context.CartDetailss.Remove(CartDetails);
                Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;

            }
        }

        public List<CartDetails> GetAllCartDetailss()
        {
            return Context.CartDetailss.ToList();
            //laays data chi loi code hoac loi ket noi sql 
        }

        public CartDetails GetCartDetailsById(Guid id)
        {
            return Context.CartDetailss.FirstOrDefault(p => p.Id == id);
            //return Context.Product.SingleOrDefault(p => p.Id == id);
        }

        public List<CartDetails> GetCartDetailsByName(string name)
        {
            throw new NotImplementedException();
            // return Context.Product.Where(p => p.Name.Contains(name)).ToList();
        }

        public bool UpdateCartDetails(CartDetails p)
        {
            try
            {

                var CartDetails = Context.CartDetailss.Find(p.Id);

                CartDetails.Quantity = p.Quantity;
                //cos the them thuoc tinh
                Context.CartDetailss.Update(CartDetails);
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
