using Football.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.API.Contracts.Responses
{
	public class TeamResponse
	{
		public string Name { get; set; }
		public string Country { get; set; }
	}

	public class TeamDetailResponse
	{
		public string Name { get; set; }
		public string Country { get; set; }
		public IEnumerable<PlayerResponse> Players { get; set; }
	}
}
