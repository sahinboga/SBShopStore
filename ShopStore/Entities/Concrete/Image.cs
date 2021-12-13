using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class Image
	{
		[Key]
		public int ImageId { get; set; }

		[StringLength(100)]
		public string ImageTitle { get; set; }

		[StringLength(1000)]
		public string ImagePath { get; set; }

		public ICollection<ProductImage> ProductImages { get; set; }
	}
}
