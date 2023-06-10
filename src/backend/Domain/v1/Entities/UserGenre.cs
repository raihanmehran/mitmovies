namespace Domain.v1.Entities
{
    public class UserGenre
    {
        public int AppUserId { get; set; }
        public AppUser User { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}