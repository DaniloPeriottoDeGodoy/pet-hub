using FluentResults;
using MediatR;
using PetHub.Domain.Interfaces;

namespace PetHub.AppService.UseCases.Pet
{
    public class CreatePetHandler : IRequestHandler<CreatePetCommand, Result>
    {
        private readonly IPetRepository _petRepository;

        public CreatePetHandler(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public async Task<Result> Handle(CreatePetCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var pet = new Domain.Entities.Pet(request.Name, request.Specie);

                if (pet.IsInvalid)
                    return Result.Fail(pet.Errors);

                await _petRepository.AddAsync(pet);

                return Result.Ok();
            }
            catch (Exception e)
            {
                return Result.Fail(e.Message);
            }
        }
    }
}
