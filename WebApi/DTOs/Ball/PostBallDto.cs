using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Entities;

namespace WebApi.DTOs.Ball
{
    public class PostBallDto
    {
        [Required]
        public string Name { get; set; }

        public int FkModelId { get; set; }

        public int FkColorId { get; set; }
    }
}
