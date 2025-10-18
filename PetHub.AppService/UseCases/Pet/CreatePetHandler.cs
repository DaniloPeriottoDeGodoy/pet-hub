using MediatR;
using PetHub.Domain.Interfaces;

namespace PetHub.AppService.UseCases.Pet
{
    public class CreatePetHandler : IRequestHandler<CreatePetCommand, Domain.Entities.Pet>
    {
        private readonly IPetRepository _petRepository;

        public CreatePetHandler(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public async Task<Domain.Entities.Pet> Handle(CreatePetCommand request, CancellationToken cancellationToken)
        {
            var newPet = new Domain.Entities.Pet
            {
                Name = request.Name,
            };

            await _petRepository.AddAsync(newPet);

            return newPet;
        }
    }
}
