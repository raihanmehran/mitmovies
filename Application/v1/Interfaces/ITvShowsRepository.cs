using Application.v1.DTOs;

namespace Application.v1.Interfaces
{
    public interface ITvShowsRepository
    {
        Task<ResponseMessage> GetPopularTvShows();
    }
}