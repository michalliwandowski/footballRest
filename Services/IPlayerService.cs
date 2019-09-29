using Football.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.API.Services
{
	public interface IPlayerService
	{

		Task<List<Player>> GetPlayersAsync();
		Task<Player> GetSinglePlayerAsync(int PlayerId);
		Task<bool> UpdatePlayerAsync(Player player);
		Task<bool> CreatePlayerAsync(Player Player);
		Task<bool> RemovePlayerAsync(int PlayerId);

	}
}
