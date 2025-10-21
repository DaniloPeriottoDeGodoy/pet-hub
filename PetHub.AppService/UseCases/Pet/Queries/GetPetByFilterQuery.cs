using PetHub.Domain.Enums;

namespace PetHub.AppService.UseCases.Pet.Queries
{
    public record class GetPetByFilterQuery(string name, Species specie, Status status);
}
