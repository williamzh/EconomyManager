using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EconomyManager.Api.Models
{
	public enum RecurrencyType
	{
		None,
		Fixed,
		Dynamic
	}

	public abstract class MonetaryItem
	{
		public int Id { get; set; }
		public DateTime Date { get; set; }
		public RecurrencyType Recurrency { get; set; }
		public decimal Amount { get; set; }
		public string Description { get; set; }
	}
}