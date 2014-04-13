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
	[Authorize]
	[EnableCors(origins: "http://localhost:8000", headers: "*", methods: "*")]
	public class IncomesController : ApiController
	{
		private readonly IProfileService _profileService;

		public IncomesController(IProfileService profileService)
		{
			_profileService = profileService;
		}

		// GET api/incomes
		public Response<IEnumerable<Income>> Get()
		{
			var userId = 1;	// TODO: get user from AUTH header

			var profile = _profileService.GetProfile(userId);

			return new Response<IEnumerable<Income>>
			{
				Data = profile.Incomes
			};
		}

		// GET api/<controller>/5
		public string Get(int id)
		{
			return "value";
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