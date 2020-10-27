dotnet new webapi -o ShootingService
dotnet add package Microsoft.EntityFrameworkCore.SqlServer

dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet tool install --global dotnet-aspnet-codegenerator

dotnet ef dbcontext scaffold "Server=.\Development;Database=Shooting;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models
dotnet aspnet-codegenerator controller -name BrassesController -async -api -m Brass -dc ShootingContext -outDir Controllers
dotnet aspnet-codegenerator controller -name BulletsController -async -api -m Bullet -dc ShootingContext -outDir Controllers
dotnet aspnet-codegenerator controller -name BulletTypesController -async -api -m BulletType -dc ShootingContext -outDir Controllers
dotnet aspnet-codegenerator controller -name CalibersController -async -api -m Caliber -dc ShootingContext -outDir Controllers
dotnet aspnet-codegenerator controller -name CartridgesController -async -api -m Cartridge -dc ShootingContext -outDir Controllers
dotnet aspnet-codegenerator controller -name CartridgeLoadsController -async -api -m CartridgeLoad -dc ShootingContext -outDir Controllers
dotnet aspnet-codegenerator controller -name GunsController -async -api -m Gun -dc ShootingContext -outDir Controllers
dotnet aspnet-codegenerator controller -name GunTypesController -async -api -m GunType -dc ShootingContext -outDir Controllers
dotnet aspnet-codegenerator controller -name ManufacturersController -async -api -m Manufacturer -dc ShootingContext -outDir Controllers
dotnet aspnet-codegenerator controller -name MaterialsController -async -api -m Material -dc ShootingContext -outDir Controllers
dotnet aspnet-codegenerator controller -name PowdersController -async -api -m Powder -dc ShootingContext -outDir Controllers
dotnet aspnet-codegenerator controller -name PowderShapesController -async -api -m PowderShape -dc ShootingContext -outDir Controllers
dotnet aspnet-codegenerator controller -name PowderTypesController -async -api -m PowderType -dc ShootingContext -outDir Controllers
dotnet aspnet-codegenerator controller -name PrimersController -async -api -m Primer -dc ShootingContext -outDir Controllers
dotnet aspnet-codegenerator controller -name PrimerTypesController -async -api -m PrimerType -dc ShootingContext -outDir Controllers
dotnet aspnet-codegenerator controller -name ShootingLocationsController -async -api -m ShootingLocation -dc ShootingContext -outDir Controllers
dotnet aspnet-codegenerator controller -name ShootingSessionsController -async -api -m ShootingSession -dc ShootingContext -outDir Controllers
dotnet aspnet-codegenerator controller -name UnitsController -async -api -m Unit -dc ShootingContext -outDir Controllers
dotnet aspnet-codegenerator controller -name UnitTypesController -async -api -m UnitType -dc ShootingContext -outDir Controllers

dotnet publish -o D:\Webs\YCDServices\ShootingService