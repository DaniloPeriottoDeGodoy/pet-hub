using MediatR;

namespace PetHub.AppService.UseCases
{
    public record CreatePetCommand(string Name) : IRequest<Domain.Entities.Pet>;
}
