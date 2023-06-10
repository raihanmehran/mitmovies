using Application.v1.DTOs;
using Application.v1.Interfaces;
using MediatR;

namespace Application.v1.Services.AccountService.Query
{
    public class GetUsersWithRoleQueryHandler : IRequestHandler<GetUsersWithRoleQuery, ResponseMessage>
    {
        private readonly IAccountRepository _accountRepository;
        public GetUsersWithRoleQueryHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<ResponseMessage> Handle(GetUsersWithRoleQuery request, CancellationToken cancellationToken)
        {
            return await _accountRepository.GetUsersWithRoleAsync();
        }
    }
}