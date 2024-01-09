using WebApi.DTOs.Base;

namespace WebApi.DTOs.Ball
{
    public class PutBallDto : SeedPut
    {
        public string Name { get; set; } = string.Empty;

        public int FkModelId { get; set; }

        public int FkColorId { get; set; }
    }
}
