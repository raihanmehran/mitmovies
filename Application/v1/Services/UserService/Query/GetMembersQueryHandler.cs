using Application.v1.DTOs;
using Application.v1.Interfaces;
using MediatR;

namespace Application.v1.Services.UserService.Query
{
    public class GetMembersQueryHandler : IRequestHandler<GetMembersQuery, ResponseMessage>
    {
        private readonly IUserRepository _userRepository;
        public GetMembersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<ResponseMessage> Handle(GetMembersQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetMembersAsync();
        }
    }
}