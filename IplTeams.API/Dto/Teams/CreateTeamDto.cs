using System.ComponentModel.DataAnnotations;

namespace IplTeams.API.Dto.Teams
{
    public class CreateTeamDto
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Trophies { get; set; }
    }
}
