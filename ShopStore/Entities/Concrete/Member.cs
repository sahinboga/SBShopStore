using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class Member
	{
		[Key]
		public int MemberId { get; set; }

		[StringLength(50)]
		public string FirstName { get; set; }

		[StringLength(50)]
		public string LastName { get; set; }

		[StringLength(50)]
		public string Email { get; set; }

		[StringLength(50)]
		public string Password { get; set; }

		[StringLength(50)]
		public string Phone { get; set; }

		[StringLength(100)]
		public string Adress { get; set; }

		public ICollection<Cart> Carts { get; set; }
		public ICollection<ShippingDetail> ShippingDetails { get; set; }
	}
}
