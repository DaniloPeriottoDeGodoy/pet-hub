
using FluentResults;
using PetHub.Domain.Interfaces;

namespace PetHub.AppService.UseCases.Pet.Get
{
    public class GetPetByIdQueryHandler(IPetRepository petRepository)
    {
        public async Task<Result<Domain.Entities.Pet>> Handle(GetPetByIdQuery query)
        {
            var pet = await petRepository.GetByIdAsync(query.PetId);

            if (pet is null)
            {
                return Result.Fail<Domain.Entities.Pet>("Pet not found");
            }

            return pet;
        }


    }
}