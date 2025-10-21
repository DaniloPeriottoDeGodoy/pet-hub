using FluentResults;
using PetHub.Domain.Interfaces;

namespace PetHub.AppService.UseCases.Pet.Queries
{
    public class GetPetByFilterQueryHandler
    {
        public readonly IPetRepository _petRepository;

        public GetPetByFilterQueryHandler(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public async Task<Result<List<Domain.Entities.Pet>>> Handle(GetPetByFilterQuery query)
        {
            var result = await _petRepository.GetByFilterAsync(query.name, query.specie);

            return Result.Ok(result.Value);
        }
    }
}
