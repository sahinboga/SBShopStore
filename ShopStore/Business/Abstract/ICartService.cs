using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface ICartService
	{
		List<Cart> GetMemberById(int id);
		Cart GetProductById(int id);
		void CartAdd(Cart cart);
		Cart GetById(int id);
		void DeleteCart(Cart carty);
		void UpdateCart(Cart cart);
	}
}
