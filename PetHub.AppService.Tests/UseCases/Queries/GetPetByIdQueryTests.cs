using FluentResults;
using Moq;
using NUnit.Framework;
using PetHub.AppService.UseCases.Pet.Get;
using PetHub.Domain.Entities;
using PetHub.Domain.Enums;
using PetHub.Domain.Interfaces;

namespace PetHub.AppService.Tests.UseCases.Queries
{
    [TestFixture]
    public class GetPetByIdQueryTests
    {
        private GetPetByIdQueryHandler _handler;
        private Mock<IPetRepository> _petRepository;

        [SetUp]
        public void Setup()
        {
            _petRepository = new Mock<IPetRepository>();

            _handler = new GetPetByIdQueryHandler(_petRepository.Object);
        }

        [Test]
        public async Task Should_Get_Pet_By_Id()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            var query = new GetPetByIdQuery(id);

            var petFound = new Pet("Buddy", Species.Dog) { Id = id };
            _petRepository
                .Setup(x => x.GetByIdAsync(id))
                .ReturnsAsync(Result.Ok(petFound));

            // Act
            Result<Pet> result = await _handler.Handle(query);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.IsSuccess, Is.True);

            _petRepository.Verify
            (
                x => x.GetByIdAsync(id), Times.Once()
            );
        }

        [Test]
        public async Task Should_Return_Error_When_Pet_Not_Found()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            var query = new GetPetByIdQuery(id);

            Pet petNotFound = null;
            _petRepository
                .Setup(x => x.GetByIdAsync(id))
                .ReturnsAsync(Result.Fail<Pet>("Pet not found"));

            // Act
            Result<Pet> result = await _handler.Handle(query);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.Errors.Select(e => e.Message), Does.Contain("Pet not found"));
            

            _petRepository.Verify
            (
                x => x.GetByIdAsync(id), Times.Once()
            );
        }
    }
}
