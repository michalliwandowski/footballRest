using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.API.Contracts.Requests
{
	public class AddPlayerToTeamRequest
	{
		public int PlayerId { get; set; }
		public int TeamId { get; set; }
	}
}
