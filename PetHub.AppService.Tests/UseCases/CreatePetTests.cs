using NUnit.Framework;
using PetHub.AppService.UseCases;
using PetHub.AppService.UseCases.Pet;

namespace PetHub.AppService.Tests.UseCases
{
    [TestFixture]
    public class CreatePetTests
    {
        private CreatePetHandler _handler;

        [SetUp]
        public void Setup()
        {        
            _handler = new CreatePetHandler();
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
        }
    }    
}
