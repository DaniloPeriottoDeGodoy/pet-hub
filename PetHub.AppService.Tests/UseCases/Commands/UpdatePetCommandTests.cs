using FluentResults;
using Moq;
using NUnit.Framework;
using PetHub.AppService.UseCases.Pet.Commands;
using PetHub.AppService.UseCases.Pet.Create;
using PetHub.Domain.Entities;
using PetHub.Domain.Enums;
using PetHub.Domain.Interfaces;

namespace PetHub.AppService.Tests.UseCases.Commands
{
    [TestFixture]
    public class UpdatePetCommandTests
    {
        private UpdatePetHandler _handler;
        private Mock<IPetRepository> _petRepository;

        [SetUp]
        public void Setup()
        {
            _petRepository = new Mock<IPetRepository>();

            _handler = new UpdatePetHandler(_petRepository.Object);
        }

        [Test]
        public async Task Should_Update_Pet_Successfully()
        {
            // Arrange
            var name = "Pretinha mudou de nome";
            var id = Guid.NewGuid();

            var command = new UpdatePetCommand(id, name, Species.Dog, Status.Available);

            var petFound = new Pet("Pretinha", Species.Dog)
            {
                Status = Status.Available
            };

            _petRepository
                .Setup(x => x.GetByIdAsync(id))
                .ReturnsAsync(Result.Ok(petFound));

            // Act
            var result = await _handler.Handle(command, default);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.IsSuccess, Is.True);

            _petRepository.Verify
            (
                x => x.UpdateAsync(It.Is<Pet>(p => p.Name == command.Name)), Times.Once()
            );
        }

        [Test]
        public async Task When_Updating_Should_Obtain_Pet_By_Id()
        {
            // Arrange
            var name = "Pretinha mudou de nome";
            var id = Guid.NewGuid();

            var command = new UpdatePetCommand(id, name, Species.Dog, Status.Available);

            var petFound = new Pet("Pretinha", Species.Dog)
            {
                Status = Status.Available
            };

            _petRepository
                .Setup(x => x.GetByIdAsync(id))
                .ReturnsAsync(Result.Ok(petFound));

            // Act
            var result = await _handler.Handle(command, default);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.IsSuccess, Is.True);

            _petRepository.Verify
            (
                x => x.GetByIdAsync(It.IsAny<Guid>()), Times.Once
            );
        }
    }
}
