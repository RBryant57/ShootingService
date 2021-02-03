using EntityLayer.Contexts;
using EntityLayer.Interfaces;
using EntityLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace ShootingServiceTests
{
    public abstract class AbstractControllerTest
    {
        protected readonly ShootingContext context;

        public AbstractControllerTest()
        {
            var options = new DbContextOptionsBuilder<ShootingContext>()
                .UseInMemoryDatabase("ShootingContext", new InMemoryDatabaseRoot())
                .Options;

            context = new ShootingContext(options);

            IEntity entity = new Brass { Id = 1 };
            context.Set<Brass>().Add((Brass)entity);
            entity = new Bullet { Id = 1 };
            context.Set<Bullet>().Add((Bullet)entity);
            entity = new BulletType { Id = 1 };
            context.Set<BulletType>().Add((BulletType)entity);
            entity = new Caliber { Id = 1 };
            context.Set<Caliber>().Add((Caliber)entity);
            entity = new CartridgeLoad { Id = 1 };
            context.Set<CartridgeLoad>().Add((CartridgeLoad)entity);
            entity = new Cartridge { Id = 1 };
            context.Set<Cartridge>().Add((Cartridge)entity);
            entity = new Gun { Id = 1 };
            context.Set<Gun>().Add((Gun)entity);
            entity = new Manufacturer { Id = 1 };
            context.Set<Manufacturer>().Add((Manufacturer)entity);
            entity = new Material { Id = 1 };
            context.Set<Material>().Add((Material)entity);
            entity = new Powder { Id = 1 };
            context.Set<Powder>().Add((Powder)entity);
            entity = new PowderShape { Id = 1 };
            context.Set<PowderShape>().Add((PowderShape)entity);
            entity = new PowderType { Id = 1 };
            context.Set<PowderType>().Add((PowderType)entity);
            entity = new Primer { Id = 1 };
            context.Set<Primer>().Add((Primer)entity);
            entity = new PrimerType { Id = 1 };
            context.Set<PrimerType>().Add((PrimerType)entity);
            entity = new ShootingLocation { Id = 1 };
            context.Set<ShootingLocation>().Add((ShootingLocation)entity);
            entity = new ShootingSession { Id = 1 };
            context.Set<ShootingSession>().Add((ShootingSession)entity);
            entity = new Unit { Id = 1 };
            context.Set<Unit>().Add((Unit)entity);
            entity = new UnitType { Id = 1 };
            context.Set<UnitType>().Add((UnitType)entity);

            context.SaveChanges();
        }
    }
}
