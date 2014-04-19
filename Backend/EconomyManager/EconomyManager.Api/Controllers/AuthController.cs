using EconomyManager.Api.Models;
using EconomyManager.Api.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EconomyManager.Api.Controllers
{
	[EnableCors(origins: "http://localhost:8000", headers: "*", methods: "*")]
	public class AuthController : ApiController
	{
		private readonly ITokenService _tokenService;

		public AuthController(ITokenService tokenService)
		{
			_tokenService = tokenService;
		}

		// POST api/auth
		public Response<Token> Post([FromBody]Login login)
		{
			var isUserAuthenticated = (login.UserName == "william" && login.Password == "test1234");
			return new Response<Token>
			{
				Status = isUserAuthenticated ? ResponseStatus.Ok : ResponseStatus.Failed,
				Data = isUserAuthenticated ? _tokenService.Create(login.UserName) : null
			};
		}

		// DELETE api/auth/<token>
		[Authorize]
		public void Delete(string token)
		{
			// Delete token?
		}
	}
}
