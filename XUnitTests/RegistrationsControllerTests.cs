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
        [Fact]
        public void GetRegistration_WithUnexistingItem_ReturnsNotFound()
        {
            // Arrange
            var repositoryStub = new Mock<IRegistrationsRepository>();
            repositoryStub.Setup(repo => repo.GetRegistration(It.IsAny<Guid>())).Returns((Registration)null);

            var controller = new RegistrationsController(repositoryStub.Object);
            // Act
            var result = controller.GetRegistration(Guid.NewGuid());

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);

        }
    }
}
