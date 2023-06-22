namespace Application.v1.DTOs
{
    public class RatedTvShowDto
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int Rating { get; set; }
        public DateTime Date { get; set; }
    }
}