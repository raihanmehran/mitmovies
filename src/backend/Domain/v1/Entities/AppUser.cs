using Microsoft.AspNetCore.Identity;

namespace Domain.v1.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime LastActive { get; set; } = DateTime.UtcNow;
        public bool IsAccountActive { get; set; } = true;
        public bool IsPremium { get; set; } = false;
        public ICollection<AppUserRole> UserRoles { get; set; }
        public List<Photo> Photos { get; set; } = new();
        public ICollection<FavouriteMovie> FavouriteMovies { get; set; }
        public ICollection<FavouriteTvShow> FavouriteTvShows { get; set; }
        public ICollection<FavouritePerson> FavouritePeople { get; set; }
        public ICollection<WatchedMovie> WatchedMovies { get; set; }
        public ICollection<WatchedTvShow> WatchedTvShows { get; set; }
        public ICollection<UserGenre> UserGenres { get; set; }
        public ICollection<RatedMovie> RatedMovies { get; set; }
        public ICollection<WatchLater> WatchLaters { get; set; }
    }
}