using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EconomyManager.Api.Models
{
	public class Period
	{
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public int Year { get; set; }
		public int Month { get; set; }
		public int Day { get; set; }
		public int Length { get; set; }
	}
}