using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class ColorTbl : SeedEntity
    {
        public ColorTbl(string color)
        {
            Color = color;
        }

        [Required]
        [MaxLength(10)]
        public string Color { get; set; }

        public ICollection<BallTbl>? BallTbls { get; set; } 

    }
}
