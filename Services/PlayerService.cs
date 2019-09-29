using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Football.API.Domain.Models;
using Football.API.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Football.API.Services
{
	public class PlayerService : IPlayerService
	{
		private readonly AppDbContext _appDbContext;
		public PlayerService(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}
		public async Task<List<Player>> GetPlayersAsync()
		{
			return await _appDbContext.Players
				.Include(x => x.Team).ToListAsync() ;
		}

		public async Task<Player> GetSinglePlayerAsync(int PlayerId)
		{
			return await _appDbContext.Players
				.SingleOrDefaultAsync(x => x.PlayerId == PlayerId);
		}

		public async Task<bool> CreatePlayerAsync(Player player)
		{
			await _appDbContext.Players.AddAsync(new Player
				{ Name = player.Name, Number = player.Number, Age = player.Age, Height = player.Height, TeamId = player.TeamId });
			var created = await _appDbContext.SaveChangesAsync();
			
			return created > 0;
		}

		public async Task<bool> RemovePlayerAsync(int PlayerId)
		{
			var player = await GetSinglePlayerAsync(PlayerId);
			if (player == null)
				return false;

			_appDbContext.Players.Remove(player);
			var removed = await _appDbContext.SaveChangesAsync();
			return removed > 0;
		}

		public async Task<bool> UpdatePlayerAsync(Player playerToUpdate)
		{
			_appDbContext.Players.Update(playerToUpdate);
			var updated = await _appDbContext.SaveChangesAsync();
			return updated > 0;
		}
	}
}
