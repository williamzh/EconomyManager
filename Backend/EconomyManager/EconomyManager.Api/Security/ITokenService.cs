using EconomyManager.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EconomyManager.Api.Security
{
	public interface ITokenService
	{
		Token Create(string userName);
		bool Validate(string token);
		User GetUser(string token);
	}
}