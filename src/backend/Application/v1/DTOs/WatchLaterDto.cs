namespace Application.v1.DTOs
{
    public class WatchLaterDto
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int TvShowId { get; set; }
        public DateTime Date { get; set; }
    }
}