using Football.API.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Football.API.Domain.Services
{
	public interface ITeamService
	{
        Task<List<Team>> GetTeamsAsync();
		Task<Team> GetSingleTeamAsync(int TeamId);
	}
}

