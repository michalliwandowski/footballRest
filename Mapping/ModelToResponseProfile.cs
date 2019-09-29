using AutoMapper;
using Football.API.Contracts.Requests;
using Football.API.Contracts.Responses;
using Football.API.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace Supermarket.API.Mapping
{
	public class ModelToResponseProfile : Profile
	{
		public ModelToResponseProfile()
		{
			CreateMap<Player, PlayerResponse>();
			CreateMap<Player, PlayerDetailResponse>();
			CreateMap<Team, TeamResponse>();
			CreateMap<Team, TeamDetailResponse>()
				.ForMember(dest => dest.Players, opt =>
					opt.MapFrom(src => src.Players.Select(x => 
					new PlayerResponse { Name = x.Name, Number = x.Number })));

			CreateMap<Player, CreatePlayerRequest>();
			CreateMap<Player, AddPlayerToTeamRequest>(); 

		}
	}
}