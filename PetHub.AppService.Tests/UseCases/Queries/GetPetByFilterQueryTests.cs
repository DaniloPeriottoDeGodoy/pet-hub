using FluentResults;
using Moq;
using NUnit.Framework;
using PetHub.AppService.DTOs;
using PetHub.AppService.UseCases.Pet.Queries;
using PetHub.Domain.Entities;
using PetHub.Domain.Enums;
using PetHub.Domain.Interfaces;

namespace PetHub.AppService.Tests.UseCases.Queries
{
    [TestFixture]
    public class GetPetByFilterQueryTests
    {
        private GetPetByFilterQueryHandler _handler;
        private Mock<IPetRepository> _petRepository;

        [SetUp]
        public void Setup()
        {
            _petRepository = new Mock<IPetRepository>();

            _handler = new GetPetByFilterQueryHandler(_petRepository.Object);
        }

        [Test]
        public async Task Should_Get_Pet_Filtering_By_Name()
        {
            // Arrange            
            var nameForSearch = "Buddy";

            var filter = new FilterPetDTO(nameForSearch, Species.Undefined, Status.All);
            var query = new GetPetByFilterQuery(filter);

            var listOfPetsFound = new List<Pet>
            {
                new Pet("Buddy", Species.Dog) { Id = Guid.NewGuid() }
            };

            _petRepository
                .Setup(x => x.GetByFilterAsync(nameForSearch, It.IsAny<Species>(), It.IsAny<Status>()))
                .ReturnsAsync(Result.Ok(listOfPetsFound));

            // Act
            Result<List<Pet>> result = await _handler.Handle(query);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.IsSuccess, Is.True);

            _petRepository.Verify
            (
                x => x.GetByFilterAsync(It.IsAny<string>(), It.IsAny<Species>(), It.IsAny<Status>()), Times.Once()
            );
        }

        [Test]
        public async Task Should_Get_Pet_Filtering_By_Specie()
        {
            // Arrange            
            var specieSearch = Species.Dog;
            var filter = new FilterPetDTO(null, specieSearch, Status.All);

            var query = new GetPetByFilterQuery(filter);

            var listOfPetsFound = new List<Pet>
            {
                new Pet("Buddy", Species.Dog) { Id = Guid.NewGuid() },
                new Pet("Puppy", Species.Dog) { Id = Guid.NewGuid() },
                new Pet("Bilu", Species.Dog) { Id = Guid.NewGuid() }
            };

            _petRepository
                .Setup(x => x.GetByFilterAsync(null, It.IsAny<Species>(), It.IsAny<Status>()))
                .ReturnsAsync(Result.Ok(listOfPetsFound));

            // Act
            Result<List<Pet>> result = await _handler.Handle(query);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.IsSuccess, Is.True);

            _petRepository.Verify
            (
                x => x.GetByFilterAsync(It.IsAny<string>(), It.IsAny<Species>(), It.IsAny<Status>()), Times.Once()
            );
        }

        [Test]
        public async Task Should_Get_Pet_Filtering_By_Status()
        {
            // Arrange            
            var statusSearch = Status.Available;
            var filter = new FilterPetDTO(null, Species.Undefined, statusSearch);
            
            var query = new GetPetByFilterQuery(filter);

            var listOfPetsFound = new List<Pet>
            {
                new Pet("Buddy", Species.Dog) { Id = Guid.NewGuid(), Status = Status.Available },
                new Pet("Puppy", Species.Dog) { Id = Guid.NewGuid(), Status = Status.Available },
                new Pet("Bilu", Species.Dog) { Id = Guid.NewGuid(), Status = Status.Available},
                new Pet("Meoow", Species.Cat) { Id = Guid.NewGuid(), Status = Status.Available }
            };

            _petRepository
                .Setup(x => x.GetByFilterAsync(null, It.IsAny<Species>(), It.IsAny<Status>()))
                .ReturnsAsync(Result.Ok(listOfPetsFound));

            // Act
            Result<List<Pet>> result = await _handler.Handle(query);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.IsSuccess, Is.True);

            _petRepository.Verify
            (
                x => x.GetByFilterAsync(It.IsAny<string>(), It.IsAny<Species>(), It.IsAny<Status>()), Times.Once()
            );
        }
    }
}
