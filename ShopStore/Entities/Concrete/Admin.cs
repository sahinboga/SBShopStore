using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class Admin
	{
		[Key]
		public int AdminId { get; set; }
		[StringLength(50)]
		public string Email { get; set; }
		[StringLength(20)]
		public string Password { get; set; }
		[StringLength(1)]
		public string Role { get; set; }
	}
}
