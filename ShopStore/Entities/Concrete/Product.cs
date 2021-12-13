using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class Product
	{
		[Key]
		public int ProductId { get; set; }

		[StringLength(20)]
		public string ProductName { get; set; }
		public int ProductPrice { get; set; }
		public int Quantity { get; set; }
		public bool IsActive { get; set; }
		public bool IsDelete { get; set; }
		public bool IsFeatured { get; set; }

		[StringLength(500)]
		public string Description { get; set; }

		public int CategoryId { get; set; }
		public virtual Category Category { get; set; }

		public ICollection<Cart> Carts { get; set; }
		public ICollection<ProductImage> ProductImages { get; set; }
	}
}
