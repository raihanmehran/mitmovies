namespace Domain.v1.Entities
{
    public class WatchLater
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int TvShowId { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public int AppUserId { get; set; }
        public AppUser User { get; set; }
    }
}