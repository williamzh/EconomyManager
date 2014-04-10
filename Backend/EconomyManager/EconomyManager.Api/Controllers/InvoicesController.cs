using EconomyManager.Api.Domain;
using EconomyManager.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EconomyManager.Api.Controllers
{
	[EnableCors(origins: "http://localhost:8000", headers: "*", methods: "*")]
	[RoutePrefix("api/invoices")]
	public class InvoicesController : ApiController
	{
		private readonly IProfileService _profileService;

		public InvoicesController(IProfileService profileService)
		{
			_profileService = profileService;
		}

		// GET api/invoices/2014/04
		[Route("{*date:datetime:regex(\\d{4}/\\d{2})?}")]
		public Response<IEnumerable<Invoice>> Get(DateTime? date = null)
		{
			var startDate = date.HasValue ? date.Value : DateTime.Today;

			var userId = 1;	// TODO: get user from AUTH header

			var profile = _profileService.GetProfile(userId);
			
			return new Response<IEnumerable<Invoice>>
			{
				Data = profile.Invoices
			};
		}

		// POST api/<controller>
		public void Post([FromBody]string value)
		{
		}

		// PUT api/<controller>/5
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE api/<controller>/5
		public void Delete(int id)
		{
		}
	}
}