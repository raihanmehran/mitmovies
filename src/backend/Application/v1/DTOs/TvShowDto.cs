using TMDbLib.Objects.TvShows;

namespace Application.v1.DTOs
{
    public class TvShowDto
    {
        public int Id { get; set; }
        public DateTime? FirstAirDate { get; set; }
        public DateTime? LastAirDate { get; set; }
        public bool InProduction { get; set; }
        public string Name { get; set; }
        public int NumberOfEpisodes { get; set; }
        public int NumberOfSeasons { get; set; }
        public string OriginalName { get; set; }
        public string OriginalLanguage { get; set; }
        public string Overview { get; set; }
        public string PosterPath { get; set; }
        public float VoteAverage { get; set; }
        public int VoteCount { get; set; }
        public double Popularity { get; set; }
        public int UserRating { get; set; }
    }


}