namespace WebAPI.Models.DTO
{
    public class UpdateRegionRequestDto
    {
        public required string Code { get; set; }
        public required string Name { get; set; }
        public string? RegionImageURL { get; set; }
    }
}