using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class ProductImage
	{
		public int ProductImageId { get; set; }

		public int ProductId { get; set; }
		public virtual Product Product { get; set; }

		public int ImageId { get; set; }
		public virtual Image Image { get; set; }
	}
}
