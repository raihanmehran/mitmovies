namespace Domain.v1.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public bool Adult { get; set; }
        public decimal Budget { get; set; }
        public string Homepage { get; set; }
        public int ImdbId { get; set; }
        public string OriginalLanguage { get; set; }
        public string OriginalTitle { get; set; }
        public string Overview { get; set; }
        public decimal Populariy { get; set; }
        public MovieCollection BelongsToCollection { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public ICollection<ProductionCompany> ProductionCompanies { get; set; }
        public ICollection<ProductionCountry> ProductionCountries { get; set; }
        public ICollection<SpokenLanguage> SpokenLanguages { get; set; }
    }
}