using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Football.API.Domain.Models;
using AutoMapper;
using Football.API.Contracts;
using Football.API.Services;
using Football.API.Contracts.Responses;
using Football.API.Contracts.Requests;

namespace Football.API.Controllers
{
    [Route("")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
		private readonly IPlayerService _playerService;
		private readonly IMapper _mapper;
		public PlayersController(IPlayerService playerService, IMapper mapper)
        {
			_playerService = playerService;
			_mapper = mapper;
		}


		// GET: api/Players
		[HttpGet(ApiRoutes.Players.GetAll)]
		public async Task<IActionResult> GetAll()
		{
			var players = await _playerService.GetPlayersAsync();
			return Ok(_mapper.Map<List<PlayerResponse>>(players));
		}

		// GET: api/Players/5
		[HttpGet(ApiRoutes.Players.Get)]
		public async Task<IActionResult> Get(int playerId)
		{
			var player = await _playerService.GetSinglePlayerAsync(playerId);
			return Ok(_mapper.Map<PlayerDetailResponse>(player));
		}

		// POST: api/Players
		[HttpPost(ApiRoutes.Players.Create)]
		public async Task<IActionResult> Create([FromBody] CreatePlayerRequest request)
		{
			var newPlayer = new Player
			{
				Name = request.Name,
				Age = request.Age,
				Height = request.Height,
				Number = request.Number,
				TeamId = request.TeamId
			};
			var created = await _playerService.CreatePlayerAsync(newPlayer);
			if (!created)
			{
				return BadRequest(new { error = "Unable to create tag" });
			}
			
			return Ok(_mapper.Map<PlayerDetailResponse>(newPlayer));
		}

		// DELETE: api/Players/5
		[HttpDelete(ApiRoutes.Players.Delete)]
		public async Task<IActionResult> Delete(int playerId)
		{			
			var created = await _playerService.RemovePlayerAsync(playerId);
			if (!created)
			{
				return BadRequest(new { error = "Unable to remove player" });
			}

			return Ok("Player with Id " + playerId + " removed.");
		}

		// PUT: api/Players/5
		[HttpPut(ApiRoutes.Players.Update)]
		public async Task<IActionResult> Update([FromRoute]int playerId, [FromBody] UpdatePlayerRequest request)
		{
			var player = await _playerService.GetSinglePlayerAsync(playerId);
			if (request.Age > 0)
				player.Age = request.Age;
			if (request.Number > 0)
				player.Number = request.Number;
			if (request.Height > 0)
				player.Height = request.Height;
			if (request.Name != null)
				player.Name = request.Name;


			var updated = await _playerService.UpdatePlayerAsync(player);
			if (updated)
				return Ok(_mapper.Map<PlayerResponse>(player));

			return NotFound();
		}

		// PUT: api/PlayersAddToTeam
		[HttpPut(ApiRoutes.Players.AddToTeam)]
		public async Task<IActionResult> AddToTeam([FromBody] AddPlayerToTeamRequest request)
		{
			var player = await _playerService.GetSinglePlayerAsync(request.PlayerId);
			if (request.TeamId > 1)
				player.TeamId = request.TeamId;

			var updated = await _playerService.UpdatePlayerAsync(player);
			if (updated)
				return Ok(_mapper.Map<PlayerDetailResponse>(player));

			return NotFound("Player with id " + request.TeamId + " not found.");
		}

		// PUT: api/PlayersRemoveFromTeam/5
		[HttpPut(ApiRoutes.Players.RemoveFromTeam)]
		public async Task<IActionResult> RemoveFromTeam([FromRoute]int playerId)
		{
			var player = await _playerService.GetSinglePlayerAsync(playerId);
			player.TeamId = 1;

			var updated = await _playerService.UpdatePlayerAsync(player);
			if (updated)
				return Ok(_mapper.Map<PlayerDetailResponse>(player));

			return NotFound();
		}
	}
}
