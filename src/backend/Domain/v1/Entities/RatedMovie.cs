namespace Domain.v1.Entities
{
    public class RatedMovie
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int Rating { get; set; }
        public int AppUserId { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public AppUser User { get; set; }
    }
}