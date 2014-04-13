using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;

namespace EconomyManager.Api.Security
{
	public class BasicAuthModule : IHttpModule
	{
		private const string Realm = "StandardRealm";

		public ITokenService TokenService { get; set; }

		public void Init(HttpApplication context)
		{
			ObjectFactory.BuildUp(this);
			context.AuthenticateRequest += OnApplicationAuthenticateRequest;
			context.EndRequest += OnApplicationEndRequest;
		}

		public void Dispose() { }

		private void OnApplicationAuthenticateRequest(object sender, EventArgs e)
		{
			var authHeader = HttpContext.Current.Request.Headers["Bearer"];
			if (authHeader != null)
			{
				//var authHeaderVal = AuthenticationHeaderValue.Parse(authHeader);

				//if (authHeaderVal.Scheme.Equals("basic", StringComparison.OrdinalIgnoreCase) &&	authHeaderVal.Parameter != null)
				//{
				AuthenticateUser(authHeader);
				//}
			}
		}

		// If the request was unauthorized, add the WWW-Authenticate header to the response.
		private void OnApplicationEndRequest(object sender, EventArgs e)
		{
			var response = HttpContext.Current.Response;
			if (response.StatusCode == 401)
			{
				response.Headers.Add("WWW-Authenticate", string.Format("Basic realm=\"{0}\"", Realm));
			}
		}

		private bool AuthenticateUser(string token)
		{
			bool validated = false;
			try
			{
				//var encoding = Encoding.GetEncoding("iso-8859-1");
				//var token = encoding.GetString(Convert.FromBase64String(credentials));

				//int separator = credentials.IndexOf(':');
				//string name = credentials.Substring(0, separator);
				//string password = credentials.Substring(separator + 1);

				var user = TokenService.GetUser(token);
				if (user != null)
				{
					var identity = new GenericIdentity(user.UserName);

					var principal = new GenericPrincipal(identity, null);
					Thread.CurrentPrincipal = principal;
					if (HttpContext.Current != null)
					{
						HttpContext.Current.User = principal;
					}
				}
			}
			catch (FormatException)
			{
				// Credentials were not formatted correctly.
				validated = false;

			}
			return validated;
		}
	}
}