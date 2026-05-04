namespace WebAPI.Models.Domain
{
    public class Track
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public double LengthInKM { get; set; }
        public string? TrackImageURL { get; set; }
        public Guid DifficultyId { get; set; }
        public Guid RegionId { get; set; }
        public required Difficulty Difficulty { get; set; }
        public required Region Region { get; set; }
    }
}