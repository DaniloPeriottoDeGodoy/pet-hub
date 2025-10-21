using FluentResults;
using PetHub.Domain.Entities;
using PetHub.Domain.Enums;

namespace PetHub.Domain.Interfaces
{
    public interface IPetRepository
    {
        Task<Result> AddAsync(Pet newPet);
        Task<Result<List<Pet>>> GetByFilterAsync(string nameForSearch, Species specie, Status status);
        Task<Result<Pet>> GetByIdAsync(Guid id);
    }
}
