using EntityLayer.Models;
using ShootingService.Controllers;
using System.Collections.Generic;
using Xunit;

namespace ShootingServiceTests
{
    public class BulletsControllerTests : AbstractControllerTest
    {
        [Fact]
        public void GetBullets_Succeeds()
        {
            // Arrange
            var controller = new BulletsController(context);

            // Act
            var response = controller.GetBullet();
            var value = response.Result.Value;

            // Assert
            Assert.IsType<List<Bullet>>(value);
        }

        [Fact]
        public void GetBulletById_Succeeds()
        {
            // Arrange
            var controller = new BulletsController(context);
            var id = 1;

            // Act
            var response = controller.GetBullet(id);
            var value = response.Result.Value;

            // Assert
            Assert.IsType<Bullet>(value);
        }

        [Fact]
        public void PutBullet_Succeeds()
        {
            // Arrange
            var controller = new BulletsController(context);
            var id = 1;
            var entity = controller.GetBullet(id).Result.Value;

            // Act
            ((Bullet)entity).Name = "test";
            var response = controller.PutBullet(entity.Id, (Bullet)entity);
            var value = response.Result;
            Assert.IsType<Microsoft.AspNetCore.Mvc.NoContentResult>(value);
            var updatedEntity = controller.GetBullet(id).Result.Value;

            // Assert
            Assert.IsType<Bullet>(updatedEntity);
            Assert.Equal("test", ((Bullet)updatedEntity).Name);
        }

        [Fact]
        public void PostBullet_Succeeds()
        {
            // Arrange
            var controller = new BulletsController(context);
            var id = 2;
            var entity = new Bullet { Id = id };

            // Act
            var response = controller.PostBullet(entity);
            var value = ((Microsoft.AspNetCore.Mvc.CreatedAtActionResult)response.Result.Result).Value;

            // Assert
            Assert.IsType<Bullet>(value);
            Assert.Equal(id, ((Bullet)value).Id);
        }
    }
}
