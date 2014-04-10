using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EconomyManager.Api.Domain;
using EconomyManager.Api.Models;
using System.Web.Http.Cors;

namespace EconomyManager.Api.Controllers
{
	[EnableCors(origins: "http://localhost:8000", headers: "*", methods: "*")]
	[RoutePrefix("api/expenses")]
	public class ExpensesController : ApiController
	{
		private readonly IProfileService _profileService;

		public ExpensesController(IProfileService profileService)
		{
			_profileService = profileService;
		}

		// GET api/expenses/2014/04
		[Route("{*date:datetime:regex(\\d{4}/\\d{2})?}")]
		public Response<IEnumerable<Expense>> GetExpenses(DateTime? date = null)
		{
			var startDate = date.HasValue ? date.Value : DateTime.Today;

			var userId = 1;	// TODO: get user from AUTH header

			var profile = _profileService.GetProfile(userId);

			return new Response<IEnumerable<Expense>>
			{
				Data = profile.Expenses.Where(e => e.IsRecurrent || e.Date.Month == startDate.Month)
			};
		}

		// GET api/expenses/history/2014/04
		[Route("history/{*date:datetime:regex(\\d{4}/\\d{2})?}")]
		public Response<IDictionary<DateTime, decimal>> GetHistory(DateTime? date = null)
		{
			var startDate = date.HasValue ? date.Value : DateTime.Today;

			var userId = 1;	// TODO: get user from AUTH header

			var profile = _profileService.GetProfile(userId);

			var currentExpenses = profile.Expenses.Where(e => e.IsRecurrent || e.Date.Month == startDate.Month);
			var expenseHistory = currentExpenses.GroupBy(e => e.Date.Day).OrderBy(g => g.Key);

			var history = new Dictionary<DateTime, decimal>();
			var currentPeriod = PeriodService.CurrentPeriod;

			var daysInMonth = DateTime.DaysInMonth(currentPeriod.StartDate.Year, currentPeriod.StartDate.Month);
			for (var d = 1; d <= daysInMonth; d++)
			{
				var day = new DateTime(currentPeriod.StartDate.Year, currentPeriod.StartDate.Month, d);

				var matchingDay = expenseHistory.FirstOrDefault(e => e.Key == d);
				var dailyAmount = (matchingDay != null) ? matchingDay.Sum(g => g.Amount) : 0;
				history.Add(day, dailyAmount);
			}
						
			return new Response<IDictionary<DateTime, decimal>>
			{
				Data = history
			};
		}

		// GET api/expenses/distribution/2014/04
		[Route("distribution/{*date:datetime:regex(\\d{4}/\\d{2})?}")]
		public Response<IDictionary<ExpenseCategory, double>> GetDistribution(DateTime? date = null)
		{
			var startDate = date.HasValue ? date.Value : DateTime.Today;

			var userId = 1;	// TODO: get user from AUTH header

			var profile = _profileService.GetProfile(userId);
			var currentExpenses = profile.Expenses.Where(e => e.IsRecurrent || e.Date.Month == startDate.Month);

			return new Response<IDictionary<ExpenseCategory, double>>
			{
				Data = CalculateExpenseDistribution(currentExpenses)
			};
		}

		// POST api/expenses
		public void Post([FromBody]Expense expense)
		{

		}

		// DELETE api/expenses/5
		public void Delete(int id)
		{

		}

		private IDictionary<ExpenseCategory, double> CalculateExpenseDistribution(IEnumerable<Expense> expenses)
		{
			var distribution = new Dictionary<ExpenseCategory, double>();
			double totalExpenses = expenses.Count();

			var expenseGroups = expenses.GroupBy(k => k.Category);
			
			foreach (var expGrp in expenseGroups)
			{
				var percentage = ((double)expGrp.Count() / totalExpenses) * 100;
				distribution.Add(expGrp.Key, Math.Round(percentage, 1));
			}

			return distribution;
		}
	}
}