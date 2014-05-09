using EconomyManager.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconomyManager.Api.Domain
{
	public interface IProfileService
	{
		void CreateProfile(string username, string password, IEnumerable<Income> incomes);
		Profile GetProfile(int userId);
		void UpdateProfile(int userId, IEnumerable<Income> incomes, IEnumerable<Expense> expenses);
		void RemoveProfile(int userId);
	}
}
