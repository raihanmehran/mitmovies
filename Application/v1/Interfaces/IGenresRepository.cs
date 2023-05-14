using Application.v1.DTOs;

namespace Application.v1.Interfaces
{
    public interface IGenresRepository
    {
        Task<bool> SaveAllAsync();
        Task<ResponseMessage> AddGenre(GenreDto genreDto);
        Task<bool> IsGenreExist(GenreDto genreDto);
    }
}