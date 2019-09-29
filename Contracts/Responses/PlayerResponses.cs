using Football.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.API.Contracts.Responses
{
	public class PlayerResponse
	{
		public string Name { get; set; }
		public int Number { get; set; }
	}
	public class PlayerDetailResponse
	{
		public int PlayerId { get; set; }
		public string Name { get; set; }
		public int Number { get; set; }
		public int Age { get; set; }
		public int Height { get; set; }
	}

}
