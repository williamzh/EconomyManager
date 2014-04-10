using EconomyManager.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EconomyManager.Api.Domain
{
	//public enum Month
	//{
	//	Jan = 1, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec
	//}

	public static class PeriodService
	{
		//public static Month CurrentMonth { get { return (Month)DateTime.Today.Month; } }

		public static Period CurrentPeriod
		{
			get
			{
				var currentYear = DateTime.Today.Year;
				var currentMonth = DateTime.Today.Month;

				var lastDayOfMonth = DateTime.DaysInMonth(currentYear, currentMonth);

				return new Period
				{
					StartDate = new DateTime(currentYear, currentMonth, 1),
					EndDate = new DateTime(currentYear, currentMonth, lastDayOfMonth)
				};
			}
		}

		public static DateTime CalculateNextPayDay()
		{
			var standardPayDay = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 25);

			// TODO: add handling for holidays
			if (standardPayDay.DayOfWeek == DayOfWeek.Saturday)
			{
				standardPayDay = standardPayDay.AddDays(-1);
			}
			else if (standardPayDay.DayOfWeek == DayOfWeek.Sunday)
			{
				standardPayDay = standardPayDay.AddDays(-2);
			}

			return standardPayDay;
		}
	}
}