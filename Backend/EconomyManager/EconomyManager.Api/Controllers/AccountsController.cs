using EconomyManager.Api.Domain;
using EconomyManager.Api.Models;
using EconomyManager.Api.Security;
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
	[RoutePrefix("api/accounts")]
	public class AccountsController : ApiController
	{
		private readonly IProfileService _profileService;
		private readonly ITokenService _tokenService;

		public AccountsController(IProfileService profileService, ITokenService tokenService)
		{
			_profileService = profileService;
			_tokenService = tokenService;
		}

		// GET api/accounts/<token>
		[Route("{token:guid}")]
		public Response<User> Get(string token)
		{
			var user = _tokenService.GetUser(token);
			// Temp
			user.FirstName = "William";
			user.LastName = "Zhang";
			// --

			return new Response<User>
			{
				Data = user
			};
		}

		// POST api/accounts
		public void Post([FromBody]User newUser)
		{
			//_profileService.CreateProfile();
		}

		// PUT api/accounts/5
		public void Put(int id, [FromBody]User user)
		{

		}

		// DELETE api/accounts/5
		public void Delete(int id)
		{

		}
	}
}