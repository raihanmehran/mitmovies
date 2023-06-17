using Domain.v1.Entities;

namespace Application.v1.DTOs
{
    public class MemberDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public List<PhotoDto> Photos { get; set; }
        public ICollection<FavouriteMovieDto> FavouriteMovies { get; set; }
        public ICollection<FavouritePersonDto> FavouritePeople { get; set; }
        public ICollection<FavouriteTvShowDto> FavouriteTvShows { get; set; }
        public ICollection<WatchedMovieDto> WatchedMovies { get; set; }
        public ICollection<WatchedTvShowDto> WatchedTvShows { get; set; }
        public ICollection<UserGenreDto> UserGenres { get; set; }
        public ICollection<RatedMovieDto> RatedMovies { get; set; }
        public ICollection<WatchLaterDto> WatchLaters { get; set; }
    }
}