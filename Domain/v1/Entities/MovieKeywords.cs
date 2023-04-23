namespace Domain.v1.Entities
{
    public class MovieKeywords
    {
        public int MovieId { get; set; }
        public List<Keyword> Keywords { get; set; }
    }
}