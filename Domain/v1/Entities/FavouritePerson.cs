namespace Domain.v1.Entities
{
    public class FavouritePerson
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int AppUserId { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public AppUser User { get; set; }
    }
}