using EntityLayer.Models;
using ShootingService.Controllers;
using System.Collections.Generic;
using Xunit;

namespace ShootingServiceTests
{
    public class BrassesControllerTests : AbstractControllerTest
    {
        [Fact]
        public void GetBrasses_Succeeds()
        {
            // Arrange
            var controller = new BrassesController(context);

            // Act
            var response = controller.GetBrass();
            var value = response.Result.Value;

            // Assert
            Assert.IsType<List<Brass>>(value);
        }

        [Fact]
        public void GetBrassById_Succeeds()
        {
            // Arrange
            var controller = new BrassesController(context);
            var id = 1;

            // Act
            var response = controller.GetBrass(id);
            var value = response.Result.Value;

            // Assert
            Assert.IsType<Brass>(value);
        }

        [Fact]
        public void PutBrass_Succeeds()
        {
            // Arrange
            var controller = new BrassesController(context);
            var id = 1;
            var entity = controller.GetBrass(id).Result.Value;

            // Act
            ((Brass)entity).Name = "test";
            var response = controller.PutBrass(entity.Id, (Brass)entity);
            var value = response.Result;
            Assert.IsType<Microsoft.AspNetCore.Mvc.NoContentResult>(value);
            var updatedEntity = controller.GetBrass(id).Result.Value;

            // Assert
            Assert.IsType<Brass>(updatedEntity);
            Assert.Equal("test", ((Brass)updatedEntity).Name);
        }

        [Fact]
        public void PostBrass_Succeeds()
        {
            // Arrange
            var controller = new BrassesController(context);
            var id = 2;
            var entity = new Brass { Id = id };

            // Act
            var response = controller.PostBrass(entity);
            var value = ((Microsoft.AspNetCore.Mvc.CreatedAtActionResult)response.Result.Result).Value;

            // Assert
            Assert.IsType<Brass>(value);
            Assert.Equal(id, ((Brass)value).Id);
        }
    }
}
