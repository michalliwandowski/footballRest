using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.API.Contracts.Requests
{
	public class UpdatePlayerRequest
	{
		public string PlayerId { get; set; }
		public string Name { get; set; }
		public int Number { get; set; }
		public int Age { get; set; }
		public int Height { get; set; }
	}
}
