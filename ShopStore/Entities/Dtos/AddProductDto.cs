using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
	public class AddProductDto
	{
		public Product Products { get; set; }
		public string[] Images { get; set; }
	}
}
