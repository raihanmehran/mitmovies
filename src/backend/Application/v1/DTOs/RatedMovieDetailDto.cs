using TMDbLib.Objects.Movies;

namespace Application.v1.DTOs
{
    public class RatedMovieDetailDto
    {
        public int Rating { get; set; }
        public Movie Movie { get; set; }
    }
}