using Application.v1.DTOs;
using Application.v1.Interfaces;
using Domain.v1.Entities;
using MediatR;

namespace Application.v1.Services.UserService.Query
{
    public class GetUserByUsernameQueryHandler : IRequestHandler<GetUserByUsernameQuery, AppUser>
    {
        private readonly IUserRepository _userRepository;
        public GetUserByUsernameQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<AppUser> Handle(GetUserByUsernameQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetUserByUsernameAsync(username: request.Username);
        }
    }
}