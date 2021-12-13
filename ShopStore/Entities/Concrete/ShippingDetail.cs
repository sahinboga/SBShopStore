using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class ShippingDetail
	{
		[Key]
		public int ShippingDetilId { get; set; }

		public int MemberId { get; set; }
		public virtual Member Member { get; set; }

		[StringLength(50)]
		public string CardNumber { get; set; }
		public int CVV { get; set; }
		public int Amount { get; set; }
	}
}
