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
		public ICollection<Income> Incomes { get; set; }
		public ICollection<Expense> Expenses { get; set; }
		public ICollection<Invoice> Invoices { get; set; }
	}
}