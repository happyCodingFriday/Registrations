using FluentAssertions;
using FluentAssertions.Extensions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Registrations.Controllers;
using Registrations.Entities;
using Registrations.Repositories;
using System;
using Xunit;

namespace UnitTests
{
    public class RegistrationsControllerTests
    {
        private readonly new Mock<IRegistrationsRepository> repositoryStub = new();

        private readonly Random rand = new();
        [Fact]
        public void GetRegistration_WithUnexistingRegistration_ReturnsNotFound()
        {
            // Arrange           
            repositoryStub.Setup(repo => repo.GetRegistration(It.IsAny<Guid>())).Returns((Registration)null);

            var controller = new RegistrationsController(repositoryStub.Object);

            // Act
            var result = controller.GetRegistration(Guid.NewGuid());

            // Assert
            result.Result.Should().BeOfType<NotFoundResult>();

        }

        [Fact]
        public void GetRegistration_WithExistingRegistration_ReturnsExpectedRegistration()
        {
            // Arrange           
            var expectedItem = CreateRandomRegistration();
            repositoryStub.Setup(repo => repo.GetRegistration(It.IsAny<Guid>())).Returns(expectedItem);

            var controller = new RegistrationsController(repositoryStub.Object);

            // Act           
            var result = controller.GetRegistration(Guid.NewGuid());

            // Assert
            result.Value.Should().BeEquivalentTo(
                expectedItem,
                options => options.ComparingByMembers<Registration>());
        }

        [Fact]
        public void GetRegistration_WithRegistrationToCreate_ReturnsCreatedRegistration()
        {
            // Arrange           
            var registrationToCreate = new Registration()
            {
                Locale = $"TestLocale{rand.Next(100)}",

                Person = new Person
                {
                    Address = new Address
                    {
                        AddressLine1 = $"TestAddress{rand.Next(100)}",

                        CountryIsoCode = $"TestCountryIsoCode{rand.Next(100)}"
                    },

                    Email = $"TestEmail{rand.Next(100)}@Test.com",

                    FirstName = $"TestFirstName{rand.Next(100)}",

                    LastName = $"TestFirstName{rand.Next(100)}",
                }
            };

            var controller = new RegistrationsController(repositoryStub.Object);

            // Act           
            var result = controller.CreateRegistration(registrationToCreate);

            // Assert
            var createdRegistration = (result.Result as CreatedAtActionResult).Value as Registration;

            // Ignoring RegistrationId and RegistrationDate validations at this place as those are currently auto-generated
            registrationToCreate.Locale.Should().BeEquivalentTo(createdRegistration.Locale);
            registrationToCreate.Person.Should().BeEquivalentTo(
                createdRegistration.Person,
                options => options.ComparingByMembers<Person>());

            createdRegistration.RegistrationId.Should().NotBeEmpty();
            createdRegistration.RegistrationDate.Should().BeCloseTo(DateTimeOffset.UtcNow, 1.Seconds());
            
        }

        private Registration CreateRandomRegistration()
        {
            return new()
            {
                RegistrationId = Guid.NewGuid(),

                Locale = $"TestLocale{rand.Next(100)}",

                RegistrationDate = DateTimeOffset.UtcNow
            };
        }
    }
}
