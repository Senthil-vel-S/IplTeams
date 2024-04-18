using System.ComponentModel.DataAnnotations;

namespace IplTeams.API.Dto.Teams
{
    public class UpdateTeamDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [MaxLength(10)]
        public string ShortName { get; set; }
        [Required]
        [MaxLength(5)]
        public string Trophies { get; set; }
    }
}
