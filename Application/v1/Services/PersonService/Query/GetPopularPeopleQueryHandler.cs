using Application.v1.DTOs;
using Application.v1.Interfaces;
using MediatR;

namespace Application.v1.Services.PersonService.Query
{
    public class GetPopularPeopleQueryHandler : IRequestHandler<GetPopularPeopleQuery, ResponseMessage>
    {
        private readonly IPersonRepository _personsRepository;
        public GetPopularPeopleQueryHandler(IPersonRepository personsRepository)
        {
            _personsRepository = personsRepository;
        }
        public async Task<ResponseMessage> Handle(GetPopularPeopleQuery request, CancellationToken cancellationToken)
        {
            return await _personsRepository.GetPopularPeople();
        }
    }
}