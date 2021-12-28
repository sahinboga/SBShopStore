using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
	public class CartManager : ICartService
	{
		ICartDal cartDal;

		public CartManager(ICartDal cartDal)
		{
			this.cartDal = cartDal;
		}

		public void CartAdd(Cart cart)
		{
			var memberCart=cartDal.GetAll(x => x.MemberId == cart.MemberId && x.ProductId==cart.ProductId).FirstOrDefault();
			if (memberCart != null)
			{
				memberCart.Quantity += cart.Quantity;
				cartDal.Update(memberCart);
			}
			else
			{
				cartDal.Add(cart);
			}
		}

		public void DeleteCart(Cart cart)
		{
			cartDal.Delete(cart);
		}

		public Cart GetById(int id)
		{
			throw new NotImplementedException();
		}

		public List<Cart> GetMemberById(int memberId)
		{
			return cartDal.GetAll(x=>x.MemberId==memberId);
		}

		public Cart GetProductById(int id)
		{
			return cartDal.GetById(x=>x.ProductId==id);
		}

		public void UpdateCart(Cart cart)
		{
			throw new NotImplementedException();
		}
	}
}
