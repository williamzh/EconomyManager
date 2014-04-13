using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EconomyManager.Api.Security
{
	public class Token
	{
		public string Value { get; set; }
		public DateTime Expires { get; set; }
	}
}