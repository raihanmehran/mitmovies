using Application.v1.DTOs;

namespace Application.v1.Interfaces
{
    public interface IGenresRepository
    {
        Task<bool> SaveAllAsync();
        Task<ResponseMessage> AddGenreAsync(GenreDto genreDto);
        Task<ResponseMessage> UpdateGenreAsync(GenreDto genreDto);
        Task<ResponseMessage> GetGenreByIdAsync(int genreId);
        Task<bool> IsGenreExistAsync(GenreDto genreDto);
    }
}