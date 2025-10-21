using FluentResults;
using PetHub.Domain.Entities;

namespace PetHub.Domain.Interfaces
{
    public interface IPetRepository
    {
        Task<Result> AddAsync(Pet newPet);
        Task<Result<List<Pet>>> GetByFilterAsync(string nameForSearch);
        Task<Result<Pet>> GetByIdAsync(Guid id);
    }
}
