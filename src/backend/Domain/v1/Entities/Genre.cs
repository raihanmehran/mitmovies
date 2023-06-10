namespace Domain.v1.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<UserGenre> UserGenres { get; set; }
    }
}