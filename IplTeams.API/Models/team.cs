using System.ComponentModel.DataAnnotations;

namespace IplTeams.API.Models
{
    public class team
    {
        [Key]
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
