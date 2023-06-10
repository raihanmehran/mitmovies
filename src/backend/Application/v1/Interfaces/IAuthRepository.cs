using Application.v1.DTOs;

namespace Application.v1.Interfaces
{
    public interface IAuthRepository
    {
        Task<ResponseMessage> AuthenticateUser(AuthDto authDto);
    }
}