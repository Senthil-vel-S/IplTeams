using AutoMapper;
using IplTeams.API.Dto.Teams;
using IplTeams.API.Models;

namespace IplTeams.API.Common
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<team, CreateTeamDto>().ReverseMap();
            CreateMap<team, GetTeamDto>().ReverseMap();
            CreateMap<team, UpdateTeamDto>().ReverseMap();
        }
    }
}
