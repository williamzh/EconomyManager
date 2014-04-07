using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EconomyManager.Api.Domain;
using EconomyManager.Api.Models;

namespace EconomyManager.Api.Controllers
{
	public class ExpensesController : ApiController
	{
		private readonly IProfileService _profileService;

		public ExpensesController(IProfileService profileService)
		{
			_profileService = profileService;
		}

		// GET api/expenses
		public Response<IEnumerable<Expense>> Get()
		{
			var userId = 1;	// TODO: get user from AUTH header

			var profile = _profileService.GetProfile(userId);
			
			return new Response<IEnumerable<Expense>>
			{
				StartDate = profile.Created,
				EndDate = DateTime.Today.Date,
				Data = profile.Expenses
			};
		}

		// GET api/expenses/2014-04-01
		public Response<IEnumerable<Expense>> Get(DateTime startDate)
		{
			var userId = 1;	// TODO: get user from AUTH header

			var profile = _profileService.GetProfile(userId);

			return new Response<IEnumerable<Expense>>
			{
				StartDate = startDate,
				EndDate = DateTime.Today.Date,
				Data = profile.Expenses.Where(e => e.Recurrency == RecurrencyType.Fixed || e.Date.Month == startDate.Month)
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
	}
}