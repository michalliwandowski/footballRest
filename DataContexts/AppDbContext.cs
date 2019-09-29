using Football.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.API.Persistance.Contexts
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		public DbSet<Team> Teams { get; set; }
		public DbSet<Player> Players { get; set; }

		
		protected override void OnModelCreating(ModelBuilder builder)
		{
			//I usually use annotations in model class but I wanted to try different approach 
			base.OnModelCreating(builder);
			builder.Entity<Team>().ToTable("Teams");
			builder.Entity<Team>().HasKey(p => p.TeamId);
			builder.Entity<Team>().Property(p => p.TeamId).ValueGeneratedOnAdd();
			builder.Entity<Team>().HasMany(p => p.Players).WithOne(p => p.Team).HasForeignKey(p => p.TeamId);
			
			builder.Entity<Team>().HasData
			(
				new Team { TeamId = 1, Name = "NoTeamPlayers"							},
				new Team { TeamId = 2, Name = "Ajax", Country = "Netherlands"			},
				new Team { TeamId = 3, Name = "Manchester City", Country = "England"	}
			);

			builder.Entity<Player>().ToTable("Players");
			builder.Entity<Player>().HasKey(p => p.PlayerId);
			builder.Entity<Player>().Property(p => p.PlayerId).ValueGeneratedOnAdd();
			builder.Entity<Player>().Property(p => p.TeamId);

			builder.Entity<Player>().HasData
			(
			    new Player { PlayerId = 1, Name = "Andre Onana", Number = 24, Age = 23, Height = 190, TeamId = 2	},
			    new Player { PlayerId = 2, Name = "Daley Blind", Number = 17, Age = 29, Height = 180, TeamId = 2	},
			    new Player { PlayerId = 3, Name = "Edson Alvarez", Number = 4, Age = 21, Height = 187, TeamId = 2 },
			    new Player { PlayerId = 4, Name = "Lisandro Martínez", Number = 21, Age = 21, Height = 178, TeamId = 2 },
				new Player { PlayerId = 5, Name = "Perr Schuurs", Number = 2, Age = 19, Height = 191, TeamId = 2 },
				new Player { PlayerId = 6, Name = "Nicolas Tagliafico", Number = 31, Age = 27, Height = 172, TeamId = 2 },
				new Player { PlayerId = 7, Name = "Noussair Mazraoui", Number = 12, Age = 21, Height = 183, TeamId = 2 },
				new Player { PlayerId = 8, Name = "Joel Veltman", Number = 3, Age = 27, Height = 184, TeamId = 2 },
				new Player { PlayerId = 9, Name = "Carel Eiting", Number = 8, Age = 21, Height = 179, TeamId = 2 },
				new Player { PlayerId = 10, Name = "Razvan Marin", Number = 18, Age = 23, Height = 178, TeamId = 2 },
				new Player { PlayerId = 11, Name = "Ryan Gravenberch", Number = 29, Age = 17, Height = 190, TeamId = 2 },
				new Player { PlayerId = 12, Name = "Ederson", Number = 31, Age = 26, Height = 188, TeamId = 3 },
				new Player { PlayerId = 13, Name = "Aymeric Laporte", Number = 14, Age = 25, Height = 191, TeamId = 3 },
				new Player { PlayerId = 14, Name = "Benjamin Mendy", Number = 22, Age = 25, Height = 185, TeamId = 3 },
				new Player { PlayerId = 15, Name = "Joao Cancelo", Number = 27, Age = 25, Height = 182, TeamId = 3 },
				new Player { PlayerId = 16, Name = "Rodri", Number = 16, Age = 23, Height = 191, TeamId = 3 },
				new Player { PlayerId = 17, Name = "Raheem Sterling", Number = 7, Age = 24, Height = 170, TeamId = 3 }
			);
		}
	}
}
