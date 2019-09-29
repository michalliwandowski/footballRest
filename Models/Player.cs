using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Football.API.Domain.Models
{
	[Table("Players")]
	public class Player
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int PlayerId { get; set; }
		public string Name { get; set; }
		public int Number { get; set; }
		public int Age { get; set; }
		public int Height { get; set; }
		public int TeamId { get; set; }
		public Team Team { get; set; }
	}
}
