using Moq;
using NUnit.Framework;
using PetHub.AppService.UseCases;
using PetHub.AppService.UseCases.Pet;
using PetHub.Domain.Entities;
using PetHub.Domain.Interfaces;

namespace PetHub.AppService.Tests.UseCases
{
    [TestFixture]
    public class CreatePetTests
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
            var command = new CreatePetCommand(name);

            // Act
            Domain.Entities.Pet result = await _handler.Handle(command, default);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Name, Is.EqualTo(name));
            Assert.That(result.Id, Is.Not.EqualTo(Guid.Empty));

            _petRepository.Verify
            (
                x => x.AddAsync(It.Is<Pet>(p => p.Name == command.Name)), Times.Once()
            );
        }
    }
}
