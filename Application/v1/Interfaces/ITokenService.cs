using Domain.v1.Entities;

namespace Application.v1.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(AppUser user);
    }
}