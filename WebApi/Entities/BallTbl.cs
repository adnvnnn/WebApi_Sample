using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace WebApi.Entities
{
    public class BallTbl : SeedEntity
    {
        public BallTbl(string name)
        {
            Name = name;

        }

        [Required]
        [MaxLength(10)]
        public string Name { get; set; }


        public int FkModelId { get; set; }

        [ForeignKey("FkModelId")]
        public ModelTbl?  ModelTbl { get; set; }


        public int FkColorId { get; set; }

        [ForeignKey("FkColorId")]
        public ColorTbl? ColorTbl { get; set; }
    }
}
