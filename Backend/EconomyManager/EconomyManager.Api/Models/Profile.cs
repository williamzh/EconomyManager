using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EconomyManager.Api.Models
{
	public class Profile
	{
		public int UserId { get; set; }
		public DateTime Created { get; set; }
		public IEnumerable<Income> Incomes { get; set; }
		public IEnumerable<Expense> Expenses { get; set; }
	}
}