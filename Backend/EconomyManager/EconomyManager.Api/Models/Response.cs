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
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public ResponseStatus Status { get; set; }
		public T Data { get; set; }
		public ErrorInfo Error { get; set; }
	}
}