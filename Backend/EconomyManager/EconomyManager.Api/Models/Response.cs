using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EconomyManager.Api.Models
{
	public enum ResponseStatus
	{
		Ok,
		Failed
	}

	public class Response<T>
	{
		[JsonConverter(typeof(StringEnumConverter))]
		public ResponseStatus Status { get; set; }
		public ErrorInfo Error { get; set; }
		public T Data { get; set; }	
	}
}