namespace WebApi.DTOs.Ball
{
    public class PatchBallDto
    {
        public string Name { get; set; } = string.Empty;

        public int FkModelId { get; set; }

        public int FkColorId { get; set; }
    }
}
