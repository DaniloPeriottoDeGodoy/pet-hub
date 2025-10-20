using NUnit.Framework;
using PetHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHub.Domain.Tests.Entities
{
    [TestFixture]
    public class PetTests
    {
        private Pet _pet;

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Pet_Should_Have_Name()
        {
            // Arrange and Act
            _pet = new Pet(null);

            // Assert
            Assert.That(_pet.IsInvalid, Is.True);
            Assert.That(_pet.Errors.Contains("Pet name is invalid"), Is.True);
        }
    }
}
