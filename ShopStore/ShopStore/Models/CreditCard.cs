using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopStore.Models
{
	public class CreditCard
	{
		public string CardName { get; set; }
		public string CardNumber { get; set; }
		public string Month { get; set; }
		public string Year { get; set; } 
		public int CVV { get; set; }
	}
}