namespace Application.v1.Interfaces
{
    public interface IMoviesRepository
    {
        Task GetMovie(int movieId);
    }
}