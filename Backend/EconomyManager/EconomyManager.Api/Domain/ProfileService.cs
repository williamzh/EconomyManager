using EconomyManager.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EconomyManager.Api.Domain
{
	public class ProfileService : IProfileService
	{
		public void CreateProfile(string username, IEnumerable<Income> incomes)
		{

		}

		public Profile GetProfile(int userId)
		{
			var profile = new Profile
			{
				UserId = 1,
				Created = new DateTime(2014, 3, 1),
				Incomes = new []
				{
					new Income 
					{ 
						Id = 1,
						Category = IncomeCategory.Salary,
						Amount = 27000,
						IsRecurrent = true,
						Date = new DateTime(0001, 1, 25)
					}
				},
				Invoices = new []
				{
					new Invoice
					{
						Id = 2,
						Amount = 250,
						Description = "Bredbandsbolaget",
						Date = new DateTime(0001, 1, 28),
						IsRecurrent = true
					},
					new Invoice
					{
						Id = 3,
						Amount = 1273,
						Description = "Underhållsstöd",
						Date = new DateTime(0001, 1, 28),
						IsRecurrent = true
					},
					new Invoice
					{
						Id = 4,
						Amount = 3095,
						Description = "Hyra",
						Date = new DateTime(0001, 1, 28),
						IsRecurrent = true
					}
				},
				Expenses = new []
				{
					new Expense
					{
						Id = 5,
						Category = ExpenseCategory.Entertainment,
						Amount = 200,
						Description = "Movies",
						Date = new DateTime(2014, 3, 24)
					},
					new Expense
					{
						Id = 6,
						Category = ExpenseCategory.Food,
						Amount = 488.65m,
						Description = "Ica Kvantum",
						Date = new DateTime(2014, 4, 7)
					},
					new Expense
					{
						Id = 6,
						Category = ExpenseCategory.Food,
						Amount = 95,
						Description = "Lunch",
						Date = new DateTime(2014, 4, 7)
					},
					new Expense
					{
						Id = 7,
						Category = ExpenseCategory.Shopping,
						Amount = 3600,
						Description = "Kläder (Jack & Jones)",
						Date = new DateTime(2014, 3, 28)
					},
					new Expense
					{
						Id = 8,
						Category = ExpenseCategory.Food,
						Amount = 230,
						Description = "Middag",
						Date = new DateTime(2014, 4, 9)
					},
				}
			};

			var currentDate = DateTime.Today.Date;

			foreach (var exp in profile.Expenses)
			{
				if (exp.IsRecurrent)
				{
					exp.Date = new DateTime(currentDate.Year, currentDate.Month, exp.Date.Day);
				}
			}

			foreach (var inc in profile.Incomes)
			{
				if (inc.IsRecurrent)
				{
					var date = inc.Date;
					if (inc.Category == IncomeCategory.Salary)
					{
						inc.Date = PeriodService.CalculateNextPayDay();
					}
					else
					{
						inc.Date = new DateTime(currentDate.Year, currentDate.Month, inc.Date.Day);
					}
				}
			}

			return profile;
		}

		public void UpdateProfile(int userId, IEnumerable<Income> incomes, IEnumerable<Expense> expenses)
		{
			throw new NotImplementedException();
		}

		public void RemoveProfile(int userId)
		{
			throw new NotImplementedException();
		}
	}
}