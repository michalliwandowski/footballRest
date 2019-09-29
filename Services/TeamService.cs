using System.Collections.Generic;
using System.Threading.Tasks;
using Football.API.Domain.Models;
using Football.API.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Football.API.Domain.Services
{
	public class TeamService : ITeamService
	{
		private readonly AppDbContext _appDbContext;
		public TeamService(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}

		public async Task<List<Team>> GetTeamsAsync()
		{
			return await _appDbContext.Teams
				.ToListAsync();
		}

		public async Task<Team> GetSingleTeamAsync(int TeamId)
		{
			return await _appDbContext.Teams
				.Include(x => x.Players)
				.SingleOrDefaultAsync(x => x.TeamId == TeamId);
		}
	}
}
