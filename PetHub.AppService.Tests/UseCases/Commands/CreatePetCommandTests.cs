using FluentResults;
using Moq;
using NUnit.Framework;
using PetHub.AppService.UseCases;
using PetHub.AppService.UseCases.Pet.Create;
using PetHub.Domain.Entities;
using PetHub.Domain.Enums;
using PetHub.Domain.Interfaces;

namespace PetHub.AppService.Tests.UseCases.Commands
{
    [TestFixture]
    public class CreatePetCommandTests
    {
        private CreatePetHandler _handler;
        private Mock<IPetRepository> _petRepository;

        [SetUp]
        public void Setup()
        {
            _petRepository = new Mock<IPetRepository>();

            _handler = new CreatePetHandler(_petRepository.Object);
        }

        [Test]
        public async Task Should_Create_Pet_Successfully()
        {
            // Arrange
            var name = "Pretinha";
            var command = new CreatePetCommand(name, Species.Dog);

            // Act
            var result = await _handler.Handle(command, default);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.IsSuccess, Is.True);            

            _petRepository.Verify
            (
                x => x.AddAsync(It.Is<Pet>(p => p.Name == command.Name)), Times.Once()
            );
        }

        [Test]
        public async Task When_Creating_Pet_Should_Return_Error_If_Pet_Name_Is_Invalid()
        {
            // Arrange
            string emptyName = string.Empty;
            var command = new CreatePetCommand(emptyName, Species.Dog);

            // Act            
            var result = await _handler.Handle(command, default);

            // Assert
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.Errors.Any(), Is.True);
            Assert.That(result.Errors.Select(e => e.Message), Does.Contain("Pet name is invalid"));

            _petRepository.Verify
            (
                x => x.AddAsync(It.IsAny<Pet>()), Times.Never()
            );
        }

        [Test]
        public async Task When_Creating_Pet_Should_Return_Error_If_Pet_Specie_Is_Invalid()
        {
            // Arrange
            var invalidSpecie = (Species)999;

            var command = new CreatePetCommand("Pretinha", invalidSpecie);

            // Act            
            var result = await _handler.Handle(command, default);

            // Assert
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.Errors.Any(), Is.True);
            Assert.That(result.Errors.Select(e => e.Message), Does.Contain("Pet specie is invalid"));

            _petRepository.Verify
            (
                x => x.AddAsync(It.IsAny<Pet>()), Times.Never()
            );
        }
    }
}
