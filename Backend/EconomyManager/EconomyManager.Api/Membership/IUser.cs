using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconomyManager.Api.Membership
{
	interface IUser
	{
		int Id { get; set; }
		DateTime Created { get; set; }
	}
}
