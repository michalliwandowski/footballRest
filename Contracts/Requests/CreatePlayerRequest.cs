using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.API.Contracts.Requests
{
	public class CreatePlayerRequest
	{
		public string Name { get; set; }
		public int Number { get; set; }
		public int Age { get; set; }
		public int Height { get; set; }
		public int TeamId { get; set; }
	}
}
