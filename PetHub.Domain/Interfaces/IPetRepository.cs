using FluentResults;
using PetHub.Domain.Entities;

namespace PetHub.Domain.Interfaces
{
    public interface IPetRepository
    {
        Task<Result> AddAsync(Pet newPet);
    }
}
