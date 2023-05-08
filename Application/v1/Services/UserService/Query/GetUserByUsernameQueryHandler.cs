using Application.v1.DTOs;
using Application.v1.Interfaces;
using MediatR;

namespace Application.v1.Services.UserService.Query
{
    public class GetUserByUsernameQueryHandler : IRequestHandler<GetUserByUsernameQuery, ResponseMessage>
    {
        private readonly IUserRepository _userRepository;
        public GetUserByUsernameQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<ResponseMessage> Handle(GetUserByUsernameQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetUserByUsernameAsync(username: request.Username);
        }
    }
}