using EconomyManager.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EconomyManager.Api.Security
{
	public class TokenService : ITokenService
	{
		private static IDictionary<string, TokenCacheInfo> _tokenCache;

		public TokenService()
		{
			_tokenCache = new Dictionary<string, TokenCacheInfo>();
		}

		public Token Create(string username)
		{
			var token = new Token { Value = Guid.NewGuid().ToString(), Expires = DateTime.Now.AddHours(1) };
			_tokenCache.Add(token.Value, new TokenCacheInfo
			{
				Token = token,
				User = new User { UserName = username }
			});
			return token;
		}

		public bool Validate(string tokenValue)
		{
			if (_tokenCache.ContainsKey(tokenValue))
			{
				var tokenInfo = _tokenCache[tokenValue];
				var isValid = (tokenInfo.Token != null) && (DateTime.Now < tokenInfo.Token.Expires);
				if (!isValid)
				{
					_tokenCache.Remove(tokenValue);
				}
				return isValid;
			}

			return false;
		}

		public User GetUser(string tokenValue)
		{
			if (Validate(tokenValue))
			{
				return _tokenCache[tokenValue].User;
			}

			return null;
		}
	}

	class TokenCacheInfo
	{
		public Token Token { get; set; }
		public User User { get; set; }
	}
}