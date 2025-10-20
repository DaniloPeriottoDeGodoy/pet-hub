using FluentResults;
using MediatR;
using PetHub.Domain.Enums;

namespace PetHub.AppService.UseCases.Pet.Create
{
    public record CreatePetCommand(string Name, Species Specie) : IRequest<Result>;
}
