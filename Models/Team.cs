using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Football.API.Domain.Models
{
	[Table("Players")]
	public class Team
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int TeamId { get; set; }
		public string Name { get; set; }
		public string Country { get; set; }
		public virtual List<Player> Players { get; set; } = new List<Player>();
	}
}
