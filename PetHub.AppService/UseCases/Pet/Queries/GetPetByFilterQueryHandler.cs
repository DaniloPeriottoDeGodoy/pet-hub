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
            var result = await _petRepository.GetByFilterAsync(query.filter.Name, query.filter.Specie, query.filter.Status);

            return Result.Ok(result.Value);
        }
    }
}
