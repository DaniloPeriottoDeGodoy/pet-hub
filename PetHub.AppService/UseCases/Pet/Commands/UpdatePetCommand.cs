using FluentResults;
using MediatR;
using PetHub.Domain.Enums;

namespace PetHub.AppService.UseCases.Pet.Commands
{
    public class UpdatePetCommand : IRequest<Result>
    {
        public UpdatePetCommand(Guid id, string name, Species specie)
        {
            Id = id;
            Name = name;
            Specie = specie;
        }

        public Guid Id { get; }
        public string Name { get; }
        public Species Specie { get; }
    }
}
