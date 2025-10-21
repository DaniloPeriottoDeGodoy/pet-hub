using PetHub.AppService.DTOs;

namespace PetHub.AppService.UseCases.Pet.Queries
{
    public record class GetPetByFilterQuery(FilterPetDTO filter);
}
