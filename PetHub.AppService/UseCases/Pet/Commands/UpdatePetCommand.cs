using FluentResults;
using MediatR;
using PetHub.Domain.Enums;

namespace PetHub.AppService.UseCases.Pet.Commands
{
    public class UpdatePetCommand : IRequest<Result>
    {
        public UpdatePetCommand(Guid id, string name, Species specie, Status status)
        {
            Id = id;
            Name = name;
            Specie = specie;
            Status = status;
        }

        public Guid Id { get; }
        public string Name { get; }
        public Species Specie { get; }
        public Status Status { get; }
    }
}
