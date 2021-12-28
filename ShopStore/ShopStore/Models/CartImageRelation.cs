using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopStore.Models
{
	public class CartImageRelation
	{
		public IEnumerable<Cart> Cart { get; set; }
		public IEnumerable<ProductImage> ProductImages { get; set; }
	}
}