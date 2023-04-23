namespace Domain.v1.Entities
{
    public class UserRating
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public double Rating { get; set; }
        public DateTime date { get; set; } = DateTime.UtcNow;
    }
}