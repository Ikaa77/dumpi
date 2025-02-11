using System.ComponentModel.DataAnnotations;

namespace MoviaCatalogiAPI.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int UserId { get; set; }

        [Required, Range(1, 5)]
        public byte Stars {  get; set; }

        [Required, MinLength(150), MaxLength(250)]
        public string? RateText { get; set; }
    }
}
