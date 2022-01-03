using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
	public class ShippingDetailManager : IShippingDetailService
	{
		private IShippingDetailDal _shipping;
		ICartService _cartService;

		public ShippingDetailManager(IShippingDetailDal shipping,ICartService cartService)
		{
			_shipping = shipping;
			_cartService = cartService;
		}

		public void Pay(ShippingDetail shippingDetail)
		{
			_shipping.Add(shippingDetail);
			_cartService.DeleteByMemberId(shippingDetail.MemberId);
		}
	}
}
