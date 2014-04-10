using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EconomyManager.Api.Models
{
	public class Invoice : MonetaryItem
	{
		public bool IsPaid { get; set; }
		public string Recipient { get; set; }
	}
}