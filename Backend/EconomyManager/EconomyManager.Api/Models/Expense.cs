using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EconomyManager.Api.Models
{
	public enum ExpenseCategory
	{
		FixedCost,		// Direct debit, etc
		Entertainment,	// Movies, going out, etc
		Food,			// Lunch, dinner, groceries etc
		Travel,			// Trips, gas money, etc
		Shopping,		// Clothes, gadgets, games, etc
		Lifestyle,		// Training, furnishing, etc
		Other			// Miscellaneous
	}

	public class Expense : MonetaryItem
	{
		[JsonConverter(typeof(StringEnumConverter))]
		public ExpenseCategory Category { get; set; }
	}
}