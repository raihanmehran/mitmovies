using Application.v1.DTOs;

namespace Application.v1.Interfaces
{
    public interface IPersonRepository
    {
        Task<ResponseMessage> GetPopularPeople();
        Task<ResponseMessage> GetPersonById(int personId);
    }
}