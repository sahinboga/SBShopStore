using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopStore.Models
{
	public class ProductImageDetailRelation
	{
		public Product Product { get; set; }
		public IEnumerable<ProductImage> ProductImage { get; set; }
	}
}