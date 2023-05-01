using Application.v1.DTOs;
using Application.v1.Interfaces;
using MediatR;

namespace Application.v1.Services.PersonService.Query
{
    public class GetPersonByIdQueryHandler : IRequestHandler<GetPersonByIdQuery, ResponseMessage>
    {
        private readonly IPersonRepository _personRepository;
        public GetPersonByIdQueryHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public async Task<ResponseMessage> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {
            return await _personRepository.GetPersonById(personId: request.PersonId);
        }
    }
}