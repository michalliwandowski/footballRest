using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Football.API.Contracts;
using Football.API.Contracts.Responses;
using Football.API.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Football.API.Controllers
{
    [Route("")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
		private readonly ITeamService _teamService;
		private readonly IMapper _mapper;
		public TeamsController(ITeamService teamService, IMapper mapper)
		{
			_teamService = teamService;
			_mapper = mapper;
		}

		// GET: api/Teams
		[HttpGet(ApiRoutes.Teams.GetAll)]
		public async Task<IActionResult> GetAll()
        {
			var teams = await _teamService.GetTeamsAsync();
			return Ok(_mapper.Map<List<TeamResponse>>(teams));
        }

        // GET: api/Teams/5
        [HttpGet(ApiRoutes.Teams.Get)]
        public async Task<IActionResult> Get(int teamId)
        {
			var team = await _teamService.GetSingleTeamAsync(teamId);
			return Ok(_mapper.Map<TeamDetailResponse>(team));
		}
       
    }
}
