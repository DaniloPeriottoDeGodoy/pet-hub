
using FluentResults;

namespace PetHub.AppService.UseCases.Pet.Get
{
    public class GetPetByIdQueryHandler
    {
        public async Task<Result<Domain.Entities.Pet>> Handle(GetPetByIdQuery query)
        {
            throw new NotImplementedException();
        }
    }
}