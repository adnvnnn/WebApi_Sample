using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class ModelTbl :SeedEntity
    {
        public ModelTbl(string model)
        {
            Model = model;
        }

        [Required]
        [MaxLength(10)]
        public string Model { get; set; }

        public ICollection<BallTbl> BallTbls { get; set; }

    }
}
