namespace Domain.v1.Entities
{
    public class RatedTvShow
    {
        public int Id { get; set; }
        public int TvShowId { get; set; }
        public int Rating { get; set; }
        public int AppUserId { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public AppUser User { get; set; }
    }
}