using FluentResults;
using MediatR;
using PetHub.Domain.Interfaces;

namespace PetHub.AppService.UseCases.Pet.Commands
{
    public class UpdatePetHandler : IRequestHandler<UpdatePetCommand, Result>
    {
        private readonly IPetRepository _petRepository;
        public UpdatePetHandler(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public async Task<Result> Handle(UpdatePetCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}