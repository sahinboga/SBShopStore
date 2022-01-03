using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.Repositories;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
	public class EfCartDal : GenericRepository<Cart>, ICartDal
	{
		public void DeleteByMemberId(int id)
		{
			
			using (var context=new ShopContext())
			{
				var result=context.Carts.RemoveRange(context.Carts.Where(x => x.MemberId == id).ToList());
				context.SaveChanges();
			}
		}
	}
}
