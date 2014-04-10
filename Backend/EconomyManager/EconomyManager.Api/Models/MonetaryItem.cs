using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EconomyManager.Api.Models
{
	public abstract class MonetaryItem
	{
		public int Id { get; set; }
		public DateTime Date { get; set; }
		public bool IsRecurrent { get; set; }
		public decimal Amount { get; set; }
		public string Description { get; set; }
	}
}