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
	[RoutePrefix("api/meta")]
	public class MetaController : ApiController
	{
		// GET api/meta/period
		[Route("period")]
		public Response<Period> Get()
		{
			return new Response<Period>
			{
				Data = PeriodService.CurrentPeriod
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