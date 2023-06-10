using Application.v1.DTOs;
using Application.v1.Interfaces;
using Domain.v1.Entities;
using MediatR;

namespace Application.v1.Services.UserService.Query
{
    public class GetUserByUserIdQueryHandler : IRequestHandler<GetUserByUserIdQuery, AppUser>
    {
        private readonly IUserRepository _userRepository;
        public GetUserByUserIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<AppUser> Handle(GetUserByUserIdQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetUserByUserIdAsync(userId: request.UserId);
        }
    }
}