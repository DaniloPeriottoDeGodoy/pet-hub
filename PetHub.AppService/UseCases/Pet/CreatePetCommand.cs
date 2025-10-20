using FluentResults;
using MediatR;

namespace PetHub.AppService.UseCases
{
    public record CreatePetCommand(string Name) : IRequest<Result>;
}
