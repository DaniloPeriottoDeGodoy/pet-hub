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
            var getByIdResult = await _petRepository.GetByIdAsync(command.Id);

            var pet = getByIdResult.Value;

            pet.Name = command.Name;
            pet.Specie = command.Specie;
            pet.Status = command.Status;

            var result = await _petRepository.UpdateAsync(pet);

            return Result.Ok();
        }
    }
}