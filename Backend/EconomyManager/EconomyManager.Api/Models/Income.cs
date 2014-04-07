using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EconomyManager.Api.Models
{
	public enum IncomeCategory
	{
		Salary,
		Other
	}

	public class Income : MonetaryItem
	{
		public IncomeCategory Category { get; set; }
	}
}