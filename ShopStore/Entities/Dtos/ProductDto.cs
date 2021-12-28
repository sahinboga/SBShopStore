using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
	public class ProductDto
	{
		public Product Product { get; set; }
		public List<Image> Images { get; set; }
	}
}
