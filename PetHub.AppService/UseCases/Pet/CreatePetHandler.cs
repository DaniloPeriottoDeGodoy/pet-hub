using MediatR;

namespace PetHub.AppService.UseCases.Pet
{
    public class CreatePetHandler : IRequestHandler<CreatePetCommand, Domain.Entities.Pet>
    {
        public async Task<Domain.Entities.Pet> Handle(CreatePetCommand request, CancellationToken cancellationToken)
        {
            return new Domain.Entities.Pet();            
        }
    }
}
