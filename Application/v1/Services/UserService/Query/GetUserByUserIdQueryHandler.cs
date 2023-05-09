using Application.v1.DTOs;
using Application.v1.Interfaces;
using MediatR;

namespace Application.v1.Services.UserService.Query
{
    public class GetUserByUserIdQueryHandler : IRequestHandler<GetUserByUserIdQuery, ResponseMessage>
    {
        private readonly IUserRepository _userRepository;
        public GetUserByUserIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<ResponseMessage> Handle(GetUserByUserIdQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetUserByUserIdAsync(userId: request.UserId);
        }
    }
}