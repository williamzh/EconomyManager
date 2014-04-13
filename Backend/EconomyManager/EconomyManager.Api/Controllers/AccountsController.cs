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
	public class AccountsController : ApiController
	{
		private readonly IProfileService _profileService;
		private readonly ITokenService _tokenService;

		public AccountsController(IProfileService profileService, ITokenService tokenService)
		{
			_profileService = profileService;
			_tokenService = tokenService;
		}

		// POST api/login
		[Route("api/login")]
		[AllowAnonymous]
		public Response<Token> Login([FromBody]Login login)
		{
			var isUserAuthenticated = (login.UserName == "william" && login.Password == "test1234");
			return new Response<Token>
			{
				Status = isUserAuthenticated ? ResponseStatus.Ok : ResponseStatus.Failed,
				Data = isUserAuthenticated ? _tokenService.Create(login.UserName) : null
			};
		}

		// GET api/accounts
		public IEnumerable<User> Get()
		{
			return new [] { new User { FirstName = "William", Lastname = "Zhang" } };
		}

		// GET api/<controller>/5
		public User Get(int id)
		{
			return new User { FirstName = "William", Lastname = "Zhang" };
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