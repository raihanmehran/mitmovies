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
    }
}