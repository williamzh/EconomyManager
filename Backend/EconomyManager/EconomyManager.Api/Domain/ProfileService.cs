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
			return new Profile
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
						Recurrency = RecurrencyType.Dynamic,
						Date = new DateTime(0001, 1, 25)	// TODO: calculate
					}
				},
				Expenses = new []
				{
					new Expense
					{
						Id = 1,
						Category = ExpenseCategory.FixedCost,
						Amount = 250,
						Description = "Bredbandsbolaget",
						Date = new DateTime(0001, 1, 28),
						Recurrency = RecurrencyType.Fixed
					},
					new Expense
					{
						Id = 2,
						Category = ExpenseCategory.FixedCost,
						Amount = 1273,
						Description = "Underhållsstöd",
						Date = new DateTime(0001, 1, 28),
						Recurrency = RecurrencyType.Fixed
					},
					new Expense
					{
						Id = 1,
						Category = ExpenseCategory.FixedCost,
						Amount = 3095,
						Description = "Hyra",
						Date = new DateTime(0001, 1, 28),
						Recurrency = RecurrencyType.Fixed
					},
					new Expense
					{
						Id = 1,
						Category = ExpenseCategory.FixedCost,
						Amount = 284,
						Description = "Parkering",
						Date = new DateTime(0001, 1, 28),
						Recurrency = RecurrencyType.Fixed
					},
					new Expense
					{
						Id = 1,
						Category = ExpenseCategory.Food,
						Amount = 488.65m,
						Description = "Ica Kvantum",
						Date = new DateTime(2014, 4, 7),
					},
				}
			};
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