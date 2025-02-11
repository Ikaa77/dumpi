using MoviaCatalogiAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace MoviaCatalogiAPI.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required, MinLength(2), MaxLength(150)]
        public string? Title { get; set; }

        [Required]
        public string? Genre { get; set; }

        [Required]
        public int ReleaseYear { get; set; }

        [Required, MinLength(15), MaxLength(150)]
        public string? Country { get; set; }

        [Required, MinLength(250)]
        public string? Description { get; set; }
    }
}
