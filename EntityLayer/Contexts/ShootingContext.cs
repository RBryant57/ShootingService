using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

using EntityLayer.Models;

namespace EntityLayer.Contexts
{
    public partial class ShootingContext : DbContext
    {
        public ShootingContext()
        {
        }

        public ShootingContext(DbContextOptions<ShootingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brass> Brass { get; set; }
        public virtual DbSet<BrassCost> BrassCost { get; set; }
        public virtual DbSet<BrassQuantity> BrassQuantity { get; set; }
        public virtual DbSet<BrassView> BrassView { get; set; }
        public virtual DbSet<Bullet> Bullet { get; set; }
        public virtual DbSet<BulletCost> BulletCost { get; set; }
        public virtual DbSet<BulletQuantity> BulletQuantity { get; set; }
        public virtual DbSet<BulletType> BulletType { get; set; }
        public virtual DbSet<BulletView> BulletView { get; set; }
        public virtual DbSet<Caliber> Caliber { get; set; }
        public virtual DbSet<CaliberCalibers> CaliberCalibers { get; set; }
        public virtual DbSet<CaliberView> CaliberView { get; set; }
        public virtual DbSet<Cartridge> Cartridge { get; set; }
        public virtual DbSet<CartridgeCost> CartridgeCost { get; set; }
        public virtual DbSet<CartridgeLoad> CartridgeLoad { get; set; }
        public virtual DbSet<CartridgeLoadView> CartridgeLoadView { get; set; }
        public virtual DbSet<CartridgeQuantity> CartridgeQuantity { get; set; }
        public virtual DbSet<CartridgeView> CartridgeView { get; set; }
        public virtual DbSet<Gun> Gun { get; set; }
        public virtual DbSet<GunImages> GunImages { get; set; }
        public virtual DbSet<GunType> GunType { get; set; }
        public virtual DbSet<GunView> GunView { get; set; }
        public virtual DbSet<GunsCalibers> GunsCalibers { get; set; }
        public virtual DbSet<GunsCalibersView> GunsCalibersView { get; set; }
        public virtual DbSet<InventoryType> InventoryType { get; set; }
        public virtual DbSet<Manufacturer> Manufacturer { get; set; }
        public virtual DbSet<Material> Material { get; set; }
        public virtual DbSet<Powder> Powder { get; set; }
        public virtual DbSet<PowderCost> PowderCost { get; set; }
        public virtual DbSet<PowderQuantity> PowderQuantity { get; set; }
        public virtual DbSet<PowderShape> PowderShape { get; set; }
        public virtual DbSet<PowderType> PowderType { get; set; }
        public virtual DbSet<PowderView> PowderView { get; set; }
        public virtual DbSet<Primer> Primer { get; set; }
        public virtual DbSet<PrimerCost> PrimerCost { get; set; }
        public virtual DbSet<PrimerQuantity> PrimerQuantity { get; set; }
        public virtual DbSet<PrimerType> PrimerType { get; set; }
        public virtual DbSet<PrimerView> PrimerView { get; set; }
        public virtual DbSet<ShootingLocation> ShootingLocation { get; set; }
        public virtual DbSet<ShootingLocationView> ShootingLocationView { get; set; }
        public virtual DbSet<ShootingSession> ShootingSession { get; set; }
        public virtual DbSet<ShootingSessionView> ShootingSessionView { get; set; }
        public virtual DbSet<Unit> Unit { get; set; }
        public virtual DbSet<UnitType> UnitType { get; set; }
        public virtual DbSet<UnitView> UnitView { get; set; }

        /*         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                {
                    if (!optionsBuilder.IsConfigured)
                    {
        #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                        optionsBuilder.UseSqlServer("Server=.\\Development;Database=Shooting;Trusted_Connection=True;");
                    }
                } */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brass>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("(N'Standard')");

                entity.Property(e => e.Notes).HasColumnType("ntext");

                entity.HasOne(d => d.Caliber)
                    .WithMany(p => p.Brass)
                    .HasForeignKey(d => d.CaliberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Brass_Caliber");

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.Brass)
                    .HasForeignKey(d => d.ManufacturerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Brass_Manufacturer");

                entity.HasOne(d => d.Material)
                    .WithMany(p => p.Brass)
                    .HasForeignKey(d => d.MaterialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Brass_Material");
            });

            modelBuilder.Entity<BrassCost>(entity =>
            {
                entity.Property(e => e.Cost).HasColumnType("money");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Notes).HasColumnType("ntext");

                entity.HasOne(d => d.Brass)
                    .WithMany(p => p.BrassCost)
                    .HasForeignKey(d => d.BrassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BrassCost_Brass");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.BrassCost)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BrassCost_Unit");
            });

            modelBuilder.Entity<BrassQuantity>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Notes).HasColumnType("ntext");

                entity.HasOne(d => d.Brass)
                    .WithMany(p => p.BrassQuantity)
                    .HasForeignKey(d => d.BrassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BrassQuantity_Brass");

                entity.HasOne(d => d.InventoryType)
                    .WithMany(p => p.BrassQuantity)
                    .HasForeignKey(d => d.InventoryTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BrassQuantity_InventoryType");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.BrassQuantity)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BrassQuantity_Unit");
            });

            modelBuilder.Entity<BrassView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("BrassView");

                entity.Property(e => e.BrassFullName).HasMaxLength(139);

                entity.Property(e => e.BrassName)
                    .IsRequired()
                    .HasMaxLength(101);

                entity.Property(e => e.CaliberViewBrassLength).HasColumnType("decimal(7, 3)");

                entity.Property(e => e.CaliberViewBrassLengthUnitViewAbbreviation)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CaliberViewBrassLengthUnitViewName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CaliberViewBrassLengthUnitViewNotes).HasColumnType("ntext");

                entity.Property(e => e.CaliberViewBrassLengthUnitViewPlural)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CaliberViewBrassLengthUnitViewUnitTypeName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CaliberViewBrassLengthUnitViewUnitTypeNotes).HasColumnType("ntext");

                entity.Property(e => e.CaliberViewDiameter).HasColumnType("decimal(7, 3)");

                entity.Property(e => e.CaliberViewDiameterUnitViewAbbreviation)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CaliberViewDiameterUnitViewName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CaliberViewDiameterUnitViewNotes).HasColumnType("ntext");

                entity.Property(e => e.CaliberViewDiameterUnitViewPlural)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CaliberViewDiameterUnitViewUnitTypeName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CaliberViewDiameterUnitViewUnitTypeNotes).HasColumnType("ntext");

                entity.Property(e => e.CaliberViewName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CaliberViewNotes).HasColumnType("ntext");

                entity.Property(e => e.CaliberViewPrimerTypeAbbreviation)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CaliberViewPrimerTypeName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CaliberViewPrimerTypeNotes).HasColumnType("ntext");

                entity.Property(e => e.ManufacturerAddress)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ManufacturerCity)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ManufacturerName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ManufacturerNotes).HasColumnType("ntext");

                entity.Property(e => e.ManufacturerShortName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ManufacturerState)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsFixedLength();

                entity.Property(e => e.ManufacturerUrl)
                    .IsRequired()
                    .HasColumnName("ManufacturerURL")
                    .HasMaxLength(250);

                entity.Property(e => e.ManufacturerZip)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.MaterialName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MaterialNotes).HasColumnType("ntext");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Notes).HasColumnType("ntext");

                entity.Property(e => e.ParentBrassFullName).HasMaxLength(139);
            });

            modelBuilder.Entity<Bullet>(entity =>
            {
                entity.HasIndex(e => new { e.Name, e.Diameter, e.ManufacturerId, e.Mass, e.MaterialId, e.Length, e.BulletTypeId })
                    .HasName("UNQ_Bullet")
                    .IsUnique();

                entity.Property(e => e.BallisticCoefficient).HasColumnType("decimal(7, 3)");

                entity.Property(e => e.Diameter).HasColumnType("decimal(7, 3)");

                entity.Property(e => e.Length).HasColumnType("decimal(7, 3)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Notes).HasColumnType("ntext");

                entity.Property(e => e.SectionalDensity).HasColumnType("decimal(7, 3)");

                entity.HasOne(d => d.BulletType)
                    .WithMany(p => p.Bullet)
                    .HasForeignKey(d => d.BulletTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bullet_BulletType");

                entity.HasOne(d => d.DiameterUnit)
                    .WithMany(p => p.BulletDiameterUnit)
                    .HasForeignKey(d => d.DiameterUnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bullet_UnitDiameter");

                entity.HasOne(d => d.LengthUnit)
                    .WithMany(p => p.BulletLengthUnit)
                    .HasForeignKey(d => d.LengthUnitId)
                    .HasConstraintName("FK_Bullet_UnitLength");

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.Bullet)
                    .HasForeignKey(d => d.ManufacturerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bullet_Manufacturer");

                entity.HasOne(d => d.MassUnit)
                    .WithMany(p => p.BulletMassUnit)
                    .HasForeignKey(d => d.MassUnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bullet_UnitMass");

                entity.HasOne(d => d.Material)
                    .WithMany(p => p.Bullet)
                    .HasForeignKey(d => d.MaterialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bullet_Material");
            });

            modelBuilder.Entity<BulletCost>(entity =>
            {
                entity.Property(e => e.Cost).HasColumnType("money");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Notes).HasColumnType("ntext");

                entity.HasOne(d => d.Bullet)
                    .WithMany(p => p.BulletCost)
                    .HasForeignKey(d => d.BulletId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BulletCost_Bullet");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.BulletCost)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BulletCost_Unit");
            });

            modelBuilder.Entity<BulletQuantity>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Notes).HasColumnType("ntext");

                entity.HasOne(d => d.Bullet)
                    .WithMany(p => p.BulletQuantity)
                    .HasForeignKey(d => d.BulletId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BulletQuantity_Bullet");

                entity.HasOne(d => d.InventoryType)
                    .WithMany(p => p.BulletQuantity)
                    .HasForeignKey(d => d.InventoryTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BulletQuantity_InventoryType");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.BulletQuantity)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BulletQuantity_Unit");
            });

            modelBuilder.Entity<BulletType>(entity =>
            {
                entity.HasIndex(e => new { e.Name, e.Abbreviation })
                    .HasName("UNQ_BulletTypeNameAbbreviation")
                    .IsUnique();

                entity.Property(e => e.Abbreviation)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Notes).HasColumnType("ntext");
            });

            modelBuilder.Entity<BulletView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("BulletView");

                entity.Property(e => e.BallisticCoefficient).HasColumnType("decimal(7, 3)");

                entity.Property(e => e.BulletFullName).HasMaxLength(234);

                entity.Property(e => e.BulletName).HasMaxLength(183);

                entity.Property(e => e.BulletTypeAbbreviation)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.BulletTypeName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.BulletTypeNotes).HasColumnType("ntext");

                entity.Property(e => e.CaliberViewName).HasMaxLength(50);

                entity.Property(e => e.Diameter).HasColumnType("decimal(7, 3)");

                entity.Property(e => e.DiameterUnitViewAbbreviation).HasMaxLength(50);

                entity.Property(e => e.DiameterUnitViewName).HasMaxLength(50);

                entity.Property(e => e.DiameterUnitViewNotes).HasColumnType("ntext");

                entity.Property(e => e.DiameterUnitViewPlural).HasMaxLength(50);

                entity.Property(e => e.DiameterUnitViewUnitTypeName).HasMaxLength(50);

                entity.Property(e => e.DiameterUnitViewUnitTypeNotes).HasColumnType("ntext");

                entity.Property(e => e.Length).HasColumnType("decimal(7, 3)");

                entity.Property(e => e.LengthUnitViewAbbreviation).HasMaxLength(50);

                entity.Property(e => e.LengthUnitViewName).HasMaxLength(50);

                entity.Property(e => e.LengthUnitViewNotes).HasColumnType("ntext");

                entity.Property(e => e.LengthUnitViewPlural).HasMaxLength(50);

                entity.Property(e => e.LengthUnitViewUnitTypeName).HasMaxLength(50);

                entity.Property(e => e.LengthUnitViewUnitTypeNotes).HasColumnType("ntext");

                entity.Property(e => e.ManufacturerAddress).HasMaxLength(50);

                entity.Property(e => e.ManufacturerCity).HasMaxLength(50);

                entity.Property(e => e.ManufacturerName).HasMaxLength(100);

                entity.Property(e => e.ManufacturerNotes).HasColumnType("ntext");

                entity.Property(e => e.ManufacturerShortName).HasMaxLength(50);

                entity.Property(e => e.ManufacturerState)
                    .HasMaxLength(2)
                    .IsFixedLength();

                entity.Property(e => e.ManufacturerUrl)
                    .HasColumnName("ManufacturerURL")
                    .HasMaxLength(250);

                entity.Property(e => e.ManufacturerZip)
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.MassUnitViewAbbreviation).HasMaxLength(50);

                entity.Property(e => e.MassUnitViewName).HasMaxLength(50);

                entity.Property(e => e.MassUnitViewNotes).HasColumnType("ntext");

                entity.Property(e => e.MassUnitViewPlural).HasMaxLength(50);

                entity.Property(e => e.MassUnitViewUnitTypeName).HasMaxLength(50);

                entity.Property(e => e.MassUnitViewUnitTypeNotes).HasColumnType("ntext");

                entity.Property(e => e.MaterialName).HasMaxLength(50);

                entity.Property(e => e.MaterialNotes).HasColumnType("ntext");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Notes).HasColumnType("ntext");

                entity.Property(e => e.SectionalDensity).HasColumnType("decimal(7, 3)");
            });

            modelBuilder.Entity<Caliber>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UNQ_CaliberName")
                    .IsUnique();

                entity.Property(e => e.BrassLength).HasColumnType("decimal(7, 3)");

                entity.Property(e => e.Col)
                    .HasColumnName("COL")
                    .HasColumnType("decimal(7, 3)")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ColunitId)
                    .HasColumnName("COLUnitId")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Diameter).HasColumnType("decimal(7, 3)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Notes).HasColumnType("ntext");

                entity.HasOne(d => d.BrassLengthUnit)
                    .WithMany(p => p.CaliberBrassLengthUnit)
                    .HasForeignKey(d => d.BrassLengthUnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Caliber_BrassLengthUnit");

                entity.HasOne(d => d.Colunit)
                    .WithMany(p => p.CaliberColunit)
                    .HasForeignKey(d => d.ColunitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Caliber_COLUnit");

                entity.HasOne(d => d.DiameterUnit)
                    .WithMany(p => p.CaliberDiameterUnit)
                    .HasForeignKey(d => d.DiameterUnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Caliber_DiameterUnit");

                entity.HasOne(d => d.PrimerType)
                    .WithMany(p => p.Caliber)
                    .HasForeignKey(d => d.PrimerTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Caliber_PrimerType");
            });

            modelBuilder.Entity<CaliberCalibers>(entity =>
            {
                entity.Property(e => e.Notes).HasColumnType("text");

                entity.HasOne(d => d.PrimaryCaliber)
                    .WithMany(p => p.CaliberCalibersPrimaryCaliber)
                    .HasForeignKey(d => d.PrimaryCaliberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CaliberCalibers_PrimaryCaliber");

                entity.HasOne(d => d.SecondaryCaliber)
                    .WithMany(p => p.CaliberCalibersSecondaryCaliber)
                    .HasForeignKey(d => d.SecondaryCaliberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CaliberCalibers_SecondaryCaliber");
            });

            modelBuilder.Entity<CaliberView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("CaliberView");

                entity.Property(e => e.BrassLength).HasColumnType("decimal(7, 3)");

                entity.Property(e => e.BrassLengthUnitViewAbbreviation)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.BrassLengthUnitViewName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.BrassLengthUnitViewNotes).HasColumnType("ntext");

                entity.Property(e => e.BrassLengthUnitViewPlural)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.BrassLengthUnitViewUnitTypeName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.BrassLengthUnitViewUnitTypeNotes).HasColumnType("ntext");

                entity.Property(e => e.Diameter).HasColumnType("decimal(7, 3)");

                entity.Property(e => e.DiameterUnitViewAbbreviation)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DiameterUnitViewName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DiameterUnitViewNotes).HasColumnType("ntext");

                entity.Property(e => e.DiameterUnitViewPlural)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DiameterUnitViewUnitTypeName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DiameterUnitViewUnitTypeNotes).HasColumnType("ntext");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Notes).HasColumnType("ntext");

                entity.Property(e => e.PrimerTypeAbbreviation)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PrimerTypeName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PrimerTypeNotes).HasColumnType("ntext");
            });

            modelBuilder.Entity<Cartridge>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("(N'Standard')");

                entity.Property(e => e.Notes).HasColumnType("ntext");

                entity.HasOne(d => d.Brass)
                    .WithMany(p => p.Cartridge)
                    .HasForeignKey(d => d.BrassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cartridge_Brass");

                entity.HasOne(d => d.CartridgeLoad)
                    .WithMany(p => p.Cartridge)
                    .HasForeignKey(d => d.CartridgeLoadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cartridge_CartridgeLoad");

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.Cartridge)
                    .HasForeignKey(d => d.ManufacturerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cartridge_Manufacturer");

                entity.HasOne(d => d.Primer)
                    .WithMany(p => p.Cartridge)
                    .HasForeignKey(d => d.PrimerId)
                    .HasConstraintName("FK_Cartridge_Primer");
            });

            modelBuilder.Entity<CartridgeCost>(entity =>
            {
                entity.Property(e => e.Cost).HasColumnType("money");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Notes).HasColumnType("ntext");

                entity.HasOne(d => d.Cartridge)
                    .WithMany(p => p.CartridgeCost)
                    .HasForeignKey(d => d.CartridgeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CartridgeCost_Cartridge");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.CartridgeCost)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CartridgeCost_Unit");
            });

            modelBuilder.Entity<CartridgeLoad>(entity =>
            {
                entity.Property(e => e.Col)
                    .HasColumnName("COL")
                    .HasColumnType("decimal(4, 3)");

                entity.Property(e => e.ColunitId).HasColumnName("COLUnitId");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Notes).HasColumnType("ntext");

                entity.Property(e => e.PowderWeight).HasColumnType("decimal(4, 1)");

                entity.HasOne(d => d.Bullet)
                    .WithMany(p => p.CartridgeLoad)
                    .HasForeignKey(d => d.BulletId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CartridgeLoad_Bullet");

                entity.HasOne(d => d.Caliber)
                    .WithMany(p => p.CartridgeLoad)
                    .HasForeignKey(d => d.CaliberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CartridgeLoad_Caliber");

                entity.HasOne(d => d.Colunit)
                    .WithMany(p => p.CartridgeLoadColunit)
                    .HasForeignKey(d => d.ColunitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CartridgeLoad_COLUnit");

                entity.HasOne(d => d.Powder)
                    .WithMany(p => p.CartridgeLoad)
                    .HasForeignKey(d => d.PowderId)
                    .HasConstraintName("FK_CartridgeLoad_Powder");

                entity.HasOne(d => d.PowderWeightUnit)
                    .WithMany(p => p.CartridgeLoadPowderWeightUnit)
                    .HasForeignKey(d => d.PowderWeightUnitId)
                    .HasConstraintName("FK_CartridgeLoad_PowderWeightUnit");

                entity.HasOne(d => d.PressureUnit)
                    .WithMany(p => p.CartridgeLoadPressureUnit)
                    .HasForeignKey(d => d.PressureUnitId)
                    .HasConstraintName("FK_CartridgeLoad_PressureUnit");

                entity.HasOne(d => d.VelocityUnit)
                    .WithMany(p => p.CartridgeLoadVelocityUnit)
                    .HasForeignKey(d => d.VelocityUnitId)
                    .HasConstraintName("FK_CartridgeLoad_VelocityUnit");
            });

            modelBuilder.Entity<CartridgeLoadView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("CartridgeLoadView");

                entity.Property(e => e.BulletViewBallisticCoefficient).HasColumnType("decimal(7, 3)");

                entity.Property(e => e.BulletViewBulletFullName).HasMaxLength(234);

                entity.Property(e => e.BulletViewBulletName).HasMaxLength(183);

                entity.Property(e => e.BulletViewBulletTypeAbbreviation).HasMaxLength(50);

                entity.Property(e => e.BulletViewBulletTypeName).HasMaxLength(50);

                entity.Property(e => e.BulletViewBulletTypeNotes).HasColumnType("ntext");

                entity.Property(e => e.BulletViewDiameter).HasColumnType("decimal(7, 3)");

                entity.Property(e => e.BulletViewDiameterUnitViewAbbreviation).HasMaxLength(50);

                entity.Property(e => e.BulletViewDiameterUnitViewName).HasMaxLength(50);

                entity.Property(e => e.BulletViewDiameterUnitViewNotes).HasColumnType("ntext");

                entity.Property(e => e.BulletViewDiameterUnitViewPlural).HasMaxLength(50);

                entity.Property(e => e.BulletViewDiameterUnitViewUnitTypeName).HasMaxLength(50);

                entity.Property(e => e.BulletViewDiameterUnitViewUnitTypeNotes).HasColumnType("ntext");

                entity.Property(e => e.BulletViewLength).HasColumnType("decimal(7, 3)");

                entity.Property(e => e.BulletViewLengthUnitViewAbbreviation).HasMaxLength(50);

                entity.Property(e => e.BulletViewLengthUnitViewName).HasMaxLength(50);

                entity.Property(e => e.BulletViewLengthUnitViewNotes).HasColumnType("ntext");

                entity.Property(e => e.BulletViewLengthUnitViewPlural).HasMaxLength(50);

                entity.Property(e => e.BulletViewLengthUnitViewUnitTypeName).HasMaxLength(50);

                entity.Property(e => e.BulletViewLengthUnitViewUnitTypeNotes).HasColumnType("ntext");

                entity.Property(e => e.BulletViewManufacturerAddress).HasMaxLength(50);

                entity.Property(e => e.BulletViewManufacturerCity).HasMaxLength(50);

                entity.Property(e => e.BulletViewManufacturerName).HasMaxLength(100);

                entity.Property(e => e.BulletViewManufacturerNotes).HasColumnType("ntext");

                entity.Property(e => e.BulletViewManufacturerState)
                    .HasMaxLength(2)
                    .IsFixedLength();

                entity.Property(e => e.BulletViewManufacturerUrl)
                    .HasColumnName("BulletViewManufacturerURL")
                    .HasMaxLength(250);

                entity.Property(e => e.BulletViewManufacturerZip)
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.BulletViewMassUnitViewAbbreviation).HasMaxLength(50);

                entity.Property(e => e.BulletViewMassUnitViewName).HasMaxLength(50);

                entity.Property(e => e.BulletViewMassUnitViewNotes).HasColumnType("ntext");

                entity.Property(e => e.BulletViewMassUnitViewPlural).HasMaxLength(50);

                entity.Property(e => e.BulletViewMassUnitViewUnitTypeName).HasMaxLength(50);

                entity.Property(e => e.BulletViewMassUnitViewUnitTypeNotes).HasColumnType("ntext");

                entity.Property(e => e.BulletViewMaterialName).HasMaxLength(50);

                entity.Property(e => e.BulletViewMaterialNotes).HasColumnType("ntext");

                entity.Property(e => e.BulletViewName).HasMaxLength(100);

                entity.Property(e => e.BulletViewNotes).HasColumnType("ntext");

                entity.Property(e => e.BulletViewSectionalDensity).HasColumnType("decimal(7, 3)");

                entity.Property(e => e.CaliberViewBrassLength).HasColumnType("decimal(7, 3)");

                entity.Property(e => e.CaliberViewBrassLengthUnitViewAbbreviation).HasMaxLength(50);

                entity.Property(e => e.CaliberViewBrassLengthUnitViewName).HasMaxLength(50);

                entity.Property(e => e.CaliberViewBrassLengthUnitViewNotes).HasColumnType("ntext");

                entity.Property(e => e.CaliberViewBrassLengthUnitViewPlural).HasMaxLength(50);

                entity.Property(e => e.CaliberViewBrassLengthUnitViewTypeName).HasMaxLength(50);

                entity.Property(e => e.CaliberViewBrassLengthUnitViewTypeNotes).HasColumnType("ntext");

                entity.Property(e => e.CaliberViewDiameter).HasColumnType("decimal(7, 3)");

                entity.Property(e => e.CaliberViewDiameterUnitViewAbbreviation).HasMaxLength(50);

                entity.Property(e => e.CaliberViewDiameterUnitViewName).HasMaxLength(50);

                entity.Property(e => e.CaliberViewDiameterUnitViewNotes).HasColumnType("ntext");

                entity.Property(e => e.CaliberViewDiameterUnitViewPlural).HasMaxLength(50);

                entity.Property(e => e.CaliberViewDiameterUnitViewUnitTypeName).HasMaxLength(50);

                entity.Property(e => e.CaliberViewDiameterUnitViewUnitTypeNotes).HasColumnType("ntext");

                entity.Property(e => e.CaliberViewName).HasMaxLength(50);

                entity.Property(e => e.CaliberViewNotes).HasColumnType("ntext");

                entity.Property(e => e.CaliberViewPrimerTypeAbbreviation).HasMaxLength(50);

                entity.Property(e => e.CaliberViewPrimerTypeName).HasMaxLength(50);

                entity.Property(e => e.CaliberViewPrimerTypeNotes).HasColumnType("ntext");

                entity.Property(e => e.CartridgeLoadName).HasMaxLength(316);

                entity.Property(e => e.Col)
                    .HasColumnName("COL")
                    .HasColumnType("decimal(4, 3)");

                entity.Property(e => e.ColunitId).HasColumnName("COLUnitId");

                entity.Property(e => e.ColunitViewAbbreviation)
                    .HasColumnName("COLUnitViewAbbreviation")
                    .HasMaxLength(50);

                entity.Property(e => e.ColunitViewName)
                    .HasColumnName("COLUnitViewName")
                    .HasMaxLength(50);

                entity.Property(e => e.ColunitViewNotes)
                    .HasColumnName("COLUnitViewNotes")
                    .HasColumnType("ntext");

                entity.Property(e => e.ColunitViewPlural)
                    .HasColumnName("COLUnitViewPlural")
                    .HasMaxLength(50);

                entity.Property(e => e.ColunitViewUnitTypeId).HasColumnName("COLUnitViewUnitTypeId");

                entity.Property(e => e.ColunitViewUnitTypeName)
                    .HasColumnName("COLUnitViewUnitTypeName")
                    .HasMaxLength(50);

                entity.Property(e => e.ColunitViewUnitTypeNotes)
                    .HasColumnName("COLUnitViewUnitTypeNotes")
                    .HasColumnType("ntext");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Notes).HasColumnType("ntext");

                entity.Property(e => e.PowderViewManufacturerAddress).HasMaxLength(50);

                entity.Property(e => e.PowderViewManufacturerCity).HasMaxLength(50);

                entity.Property(e => e.PowderViewManufacturerName).HasMaxLength(100);

                entity.Property(e => e.PowderViewManufacturerNotes).HasColumnType("ntext");

                entity.Property(e => e.PowderViewManufacturerState)
                    .HasMaxLength(2)
                    .IsFixedLength();

                entity.Property(e => e.PowderViewManufacturerUrl)
                    .HasColumnName("PowderViewManufacturerURL")
                    .HasMaxLength(250);

                entity.Property(e => e.PowderViewManufacturerZip)
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.PowderViewName).HasMaxLength(50);

                entity.Property(e => e.PowderViewNotes).HasColumnType("ntext");

                entity.Property(e => e.PowderViewPowderName).HasMaxLength(151);

                entity.Property(e => e.PowderViewPowderShapeName)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.PowderViewPowderShapeNotes).HasColumnType("ntext");

                entity.Property(e => e.PowderViewPowderTypeName).HasMaxLength(50);

                entity.Property(e => e.PowderViewPowderTypeNotes).HasColumnType("ntext");

                entity.Property(e => e.PowderWeight).HasColumnType("decimal(4, 1)");

                entity.Property(e => e.PowderWeightUnitViewAbbreviation).HasMaxLength(50);

                entity.Property(e => e.PowderWeightUnitViewName).HasMaxLength(50);

                entity.Property(e => e.PowderWeightUnitViewNotes).HasColumnType("ntext");

                entity.Property(e => e.PowderWeightUnitViewPlural).HasMaxLength(50);

                entity.Property(e => e.PowderWeightUnitViewUnitTypeName).HasMaxLength(50);

                entity.Property(e => e.PowderWeightUnitViewUnitTypeNotes).HasColumnType("ntext");

                entity.Property(e => e.PressureUnitViewAbbreviation).HasMaxLength(50);

                entity.Property(e => e.PressureUnitViewName).HasMaxLength(50);

                entity.Property(e => e.PressureUnitViewNotes).HasColumnType("ntext");

                entity.Property(e => e.PressureUnitViewPlural).HasMaxLength(50);

                entity.Property(e => e.PressureUnitViewUnitTypeName).HasMaxLength(50);

                entity.Property(e => e.PressureUnitViewUnitTypeNotes).HasColumnType("ntext");

                entity.Property(e => e.VelocityUnitViewAbbreviation).HasMaxLength(50);

                entity.Property(e => e.VelocityUnitViewName).HasMaxLength(50);

                entity.Property(e => e.VelocityUnitViewNotes).HasColumnType("ntext");

                entity.Property(e => e.VelocityUnitViewPlural).HasMaxLength(50);

                entity.Property(e => e.VelocityUnitViewUnitTypeName).HasMaxLength(50);

                entity.Property(e => e.VelocityUnitViewUnitTypeNotes).HasColumnType("ntext");
            });

            modelBuilder.Entity<CartridgeQuantity>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Notes).HasColumnType("ntext");

                entity.HasOne(d => d.Cartridge)
                    .WithMany(p => p.CartridgeQuantity)
                    .HasForeignKey(d => d.CartridgeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CartridgeQuantity_Cartridge");

                entity.HasOne(d => d.InventoryType)
                    .WithMany(p => p.CartridgeQuantity)
                    .HasForeignKey(d => d.InventoryTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CartridgeQuantity_InventoryType");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.CartridgeQuantity)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CartridgeQuantity_Unit");
            });

            modelBuilder.Entity<CartridgeView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("CartridgeView");

                entity.Property(e => e.BrassViewBrassFullName).HasMaxLength(139);

                entity.Property(e => e.BrassViewBrassName).HasMaxLength(101);

                entity.Property(e => e.BrassViewManufacturerAddress).HasMaxLength(50);

                entity.Property(e => e.BrassViewManufacturerCity).HasMaxLength(50);

                entity.Property(e => e.BrassViewManufacturerName).HasMaxLength(100);

                entity.Property(e => e.BrassViewManufacturerNotes).HasColumnType("ntext");

                entity.Property(e => e.BrassViewManufacturerState)
                    .HasMaxLength(2)
                    .IsFixedLength();

                entity.Property(e => e.BrassViewManufacturerUrl)
                    .HasColumnName("BrassViewManufacturerURL")
                    .HasMaxLength(250);

                entity.Property(e => e.BrassViewManufacturerZip)
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.BrassViewMaterialName).HasMaxLength(50);

                entity.Property(e => e.BrassViewMaterialNotes).HasColumnType("ntext");

                entity.Property(e => e.BrassViewName).HasMaxLength(100);

                entity.Property(e => e.BrassViewNotes).HasColumnType("ntext");

                entity.Property(e => e.BrassViewParentBrassFullName).HasMaxLength(139);

                entity.Property(e => e.CartridgeLoadViewBulletViewBallisticCoefficient).HasColumnType("decimal(7, 3)");

                entity.Property(e => e.CartridgeLoadViewBulletViewBulletFullName).HasMaxLength(234);

                entity.Property(e => e.CartridgeLoadViewBulletViewBulletName).HasMaxLength(183);

                entity.Property(e => e.CartridgeLoadViewBulletViewBulletTypeAbbreviation).HasMaxLength(50);

                entity.Property(e => e.CartridgeLoadViewBulletViewBulletTypeName).HasMaxLength(50);

                entity.Property(e => e.CartridgeLoadViewBulletViewBulletTypeNotes).HasColumnType("ntext");

                entity.Property(e => e.CartridgeLoadViewBulletViewDiameter).HasColumnType("decimal(7, 3)");

                entity.Property(e => e.CartridgeLoadViewBulletViewDiameterUnitViewAbbreviation).HasMaxLength(50);

                entity.Property(e => e.CartridgeLoadViewBulletViewDiameterUnitViewName).HasMaxLength(50);

                entity.Property(e => e.CartridgeLoadViewBulletViewDiameterUnitViewNotes).HasColumnType("ntext");

                entity.Property(e => e.CartridgeLoadViewBulletViewDiameterUnitViewPlural).HasMaxLength(50);

                entity.Property(e => e.CartridgeLoadViewBulletViewDiameterUnitViewUnitTypeName).HasMaxLength(50);

                entity.Property(e => e.CartridgeLoadViewBulletViewDiameterUnitViewUnitTypeNotes).HasColumnType("ntext");

                entity.Property(e => e.CartridgeLoadViewBulletViewLength).HasColumnType("decimal(7, 3)");

                entity.Property(e => e.CartridgeLoadViewBulletViewLengthUnitViewAbbreviation).HasMaxLength(50);

                entity.Property(e => e.CartridgeLoadViewBulletViewLengthUnitViewName).HasMaxLength(50);

                entity.Property(e => e.CartridgeLoadViewBulletViewLengthUnitViewNotes).HasColumnType("ntext");

                entity.Property(e => e.CartridgeLoadViewBulletViewLengthUnitViewPlural).HasMaxLength(50);

                entity.Property(e => e.CartridgeLoadViewBulletViewLengthUnitViewUnitTypeName).HasMaxLength(50);

                entity.Property(e => e.CartridgeLoadViewBulletViewLengthUnitViewUnitTypeNotes).HasColumnType("ntext");

                entity.Property(e => e.CartridgeLoadViewBulletViewManufacturerAddress).HasMaxLength(50);

                entity.Property(e => e.CartridgeLoadViewBulletViewManufacturerCity).HasMaxLength(50);

                entity.Property(e => e.CartridgeLoadViewBulletViewManufacturerName).HasMaxLength(100);

                entity.Property(e => e.CartridgeLoadViewBulletViewManufacturerNotes).HasColumnType("ntext");

                entity.Property(e => e.CartridgeLoadViewBulletViewManufacturerState)
                    .HasMaxLength(2)
                    .IsFixedLength();

                entity.Property(e => e.CartridgeLoadViewBulletViewManufacturerUrl)
                    .HasColumnName("CartridgeLoadViewBulletViewManufacturerURL")
                    .HasMaxLength(250);

                entity.Property(e => e.CartridgeLoadViewBulletViewManufacturerZip)
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.CartridgeLoadViewBulletViewMassUnitViewAbbreviation).HasMaxLength(50);

                entity.Property(e => e.CartridgeLoadViewBulletViewMassUnitViewName).HasMaxLength(50);

                entity.Property(e => e.CartridgeLoadViewBulletViewMassUnitViewNotes).HasColumnType("ntext");

                entity.Property(e => e.CartridgeLoadViewBulletViewMassUnitViewPlural).HasMaxLength(50);

                entity.Property(e => e.CartridgeLoadViewBulletViewMassUnitViewUnitTypeName).HasMaxLength(50);

                entity.Property(e => e.CartridgeLoadViewBulletViewMassUnitViewUnitTypeNotes).HasColumnType("ntext");

                entity.Property(e => e.CartridgeLoadViewBulletViewMaterialName).HasMaxLength(50);

                entity.Property(e => e.CartridgeLoadViewBulletViewMaterialNotes).HasColumnType("ntext");

                entity.Property(e => e.CartridgeLoadViewBulletViewName).HasMaxLength(100);

                entity.Property(e => e.CartridgeLoadViewBulletViewNotes).HasColumnType("ntext");

                entity.Property(e => e.CartridgeLoadViewBulletViewSectionalDensity).HasColumnType("decimal(7, 3)");

                entity.Property(e => e.CartridgeLoadViewCaliberViewBrassLength).HasColumnType("decimal(7, 3)");

                entity.Property(e => e.CartridgeLoadViewCaliberViewBrassLengthUnitViewAbbreviation).HasMaxLength(50);

                entity.Property(e => e.CartridgeLoadViewCaliberViewBrassLengthUnitViewName).HasMaxLength(50);

                entity.Property(e => e.CartridgeLoadViewCaliberViewBrassLengthUnitViewNotes).HasColumnType("ntext");

                entity.Property(e => e.CartridgeLoadViewCaliberViewBrassLengthUnitViewPlural).HasMaxLength(50);

                entity.Property(e => e.CartridgeLoadViewCaliberViewBrassLengthUnitViewTypeName).HasMaxLength(50);

                entity.Property(e => e.CartridgeLoadViewCaliberViewBrassLengthUnitViewTypeNotes).HasColumnType("ntext");

                entity.Property(e => e.CartridgeLoadViewCaliberViewDiameter).HasColumnType("decimal(7, 3)");

                entity.Property(e => e.CartridgeLoadViewCaliberViewDiameterUnitViewAbbreviation).HasMaxLength(50);

                entity.Property(e => e.CartridgeLoadViewCaliberViewDiameterUnitViewName).HasMaxLength(50);

                entity.Property(e => e.CartridgeLoadViewCaliberViewDiameterUnitViewNotes).HasColumnType("ntext");

                entity.Property(e => e.CartridgeLoadViewCaliberViewDiameterUnitViewPlural).HasMaxLength(50);

                entity.Property(e => e.CartridgeLoadViewCaliberViewDiameterUnitViewUnitTypeName).HasMaxLength(50);

                entity.Property(e => e.CartridgeLoadViewCaliberViewDiameterUnitViewUnitTypeNotes).HasColumnType("ntext");

                entity.Property(e => e.CartridgeLoadViewCaliberViewName).HasMaxLength(50);

                entity.Property(e => e.CartridgeLoadViewCaliberViewNotes).HasColumnType("ntext");

                entity.Property(e => e.CartridgeLoadViewCaliberViewPrimerTypeAbbreviation).HasMaxLength(50);

                entity.Property(e => e.CartridgeLoadViewCaliberViewPrimerTypeName).HasMaxLength(50);

                entity.Property(e => e.CartridgeLoadViewCaliberViewPrimerTypeNotes).HasColumnType("ntext");

                entity.Property(e => e.CartridgeLoadViewCartridgeLoadName).HasMaxLength(316);

                entity.Property(e => e.CartridgeLoadViewCol)
                    .HasColumnName("CartridgeLoadViewCOL")
                    .HasColumnType("decimal(4, 3)");

                entity.Property(e => e.CartridgeLoadViewColunitId).HasColumnName("CartridgeLoadViewCOLUnitId");

                entity.Property(e => e.CartridgeLoadViewColunitViewAbbreviation)
                    .HasColumnName("CartridgeLoadViewCOLUnitViewAbbreviation")
                    .HasMaxLength(50);

                entity.Property(e => e.CartridgeLoadViewColunitViewName)
                    .HasColumnName("CartridgeLoadViewCOLUnitViewName")
                    .HasMaxLength(50);

                entity.Property(e => e.CartridgeLoadViewColunitViewNotes)
                    .HasColumnName("CartridgeLoadViewCOLUnitViewNotes")
                    .HasColumnType("ntext");

                entity.Property(e => e.CartridgeLoadViewColunitViewPlural)
                    .HasColumnName("CartridgeLoadViewCOLUnitViewPlural")
                    .HasMaxLength(50);

                entity.Property(e => e.CartridgeLoadViewColunitViewUnitTypeId).HasColumnName("CartridgeLoadViewCOLUnitViewUnitTypeId");

                entity.Property(e => e.CartridgeLoadViewColunitViewUnitTypeName)
                    .HasColumnName("CartridgeLoadViewCOLUnitViewUnitTypeName")
                    .HasMaxLength(50);

                entity.Property(e => e.CartridgeLoadViewColunitViewUnitTypeNotes)
                    .HasColumnName("CartridgeLoadViewCOLUnitViewUnitTypeNotes")
                    .HasColumnType("ntext");

                entity.Property(e => e.CartridgeLoadViewName).HasMaxLength(100);

                entity.Property(e => e.CartridgeLoadViewNotes).HasColumnType("ntext");

                entity.Property(e => e.CartridgeLoadViewPowderViewManufacturerAddress).HasMaxLength(50);

                entity.Property(e => e.CartridgeLoadViewPowderViewManufacturerCity).HasMaxLength(50);

                entity.Property(e => e.CartridgeLoadViewPowderViewManufacturerName).HasMaxLength(100);

                entity.Property(e => e.CartridgeLoadViewPowderViewManufacturerNotes).HasColumnType("ntext");

                entity.Property(e => e.CartridgeLoadViewPowderViewManufacturerState)
                    .HasMaxLength(2)
                    .IsFixedLength();

                entity.Property(e => e.CartridgeLoadViewPowderViewManufacturerUrl)
                    .HasColumnName("CartridgeLoadViewPowderViewManufacturerURL")
                    .HasMaxLength(250);

                entity.Property(e => e.CartridgeLoadViewPowderViewManufacturerZip)
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.CartridgeLoadViewPowderViewName).HasMaxLength(50);

                entity.Property(e => e.CartridgeLoadViewPowderViewNotes).HasColumnType("ntext");

                entity.Property(e => e.CartridgeLoadViewPowderViewPowderName).HasMaxLength(151);

                entity.Property(e => e.CartridgeLoadViewPowderViewPowderShapeName)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.CartridgeLoadViewPowderViewPowderShapeNotes).HasColumnType("ntext");

                entity.Property(e => e.CartridgeLoadViewPowderViewPowderTypeName).HasMaxLength(50);

                entity.Property(e => e.CartridgeLoadViewPowderViewPowderTypeNotes).HasColumnType("ntext");

                entity.Property(e => e.CartridgeLoadViewPowderWeight).HasColumnType("decimal(4, 1)");

                entity.Property(e => e.CartridgeLoadViewPowderWeightUnitViewAbbreviation).HasMaxLength(50);

                entity.Property(e => e.CartridgeLoadViewPowderWeightUnitViewName).HasMaxLength(50);

                entity.Property(e => e.CartridgeLoadViewPowderWeightUnitViewNotes).HasColumnType("ntext");

                entity.Property(e => e.CartridgeLoadViewPowderWeightUnitViewPlural).HasMaxLength(50);

                entity.Property(e => e.CartridgeLoadViewPowderWeightUnitViewUnitTypeName).HasMaxLength(50);

                entity.Property(e => e.CartridgeLoadViewPowderWeightUnitViewUnitTypeNotes).HasColumnType("ntext");

                entity.Property(e => e.CartridgeLoadViewPressureUnitViewAbbreviation).HasMaxLength(50);

                entity.Property(e => e.CartridgeLoadViewPressureUnitViewName).HasMaxLength(50);

                entity.Property(e => e.CartridgeLoadViewPressureUnitViewNotes).HasColumnType("ntext");

                entity.Property(e => e.CartridgeLoadViewPressureUnitViewPlural).HasMaxLength(50);

                entity.Property(e => e.CartridgeLoadViewPressureUnitViewUnitTypeName).HasMaxLength(50);

                entity.Property(e => e.CartridgeLoadViewPressureUnitViewUnitTypeNotes).HasColumnType("ntext");

                entity.Property(e => e.CartridgeLoadViewVelocityUnitViewAbbreviation).HasMaxLength(50);

                entity.Property(e => e.CartridgeLoadViewVelocityUnitViewName).HasMaxLength(50);

                entity.Property(e => e.CartridgeLoadViewVelocityUnitViewNotes).HasColumnType("ntext");

                entity.Property(e => e.CartridgeLoadViewVelocityUnitViewPlural).HasMaxLength(50);

                entity.Property(e => e.CartridgeLoadViewVelocityUnitViewUnitTypeName).HasMaxLength(50);

                entity.Property(e => e.CartridgeLoadViewVelocityUnitViewUnitTypeNotes).HasColumnType("ntext");

                entity.Property(e => e.CartridgeName).HasMaxLength(421);

                entity.Property(e => e.ManufacturerAddress).HasMaxLength(50);

                entity.Property(e => e.ManufacturerCity).HasMaxLength(50);

                entity.Property(e => e.ManufacturerName).HasMaxLength(100);

                entity.Property(e => e.ManufacturerNotes).HasColumnType("ntext");

                entity.Property(e => e.ManufacturerShortName).HasMaxLength(50);

                entity.Property(e => e.ManufacturerState)
                    .HasMaxLength(2)
                    .IsFixedLength();

                entity.Property(e => e.ManufacturerUrl)
                    .HasColumnName("ManufacturerURL")
                    .HasMaxLength(250);

                entity.Property(e => e.ManufacturerZip)
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Notes).HasColumnType("ntext");

                entity.Property(e => e.PrimerViewFullName).HasMaxLength(202);

                entity.Property(e => e.PrimerViewManufacturerAddress).HasMaxLength(50);

                entity.Property(e => e.PrimerViewManufacturerCity).HasMaxLength(50);

                entity.Property(e => e.PrimerViewManufacturerName).HasMaxLength(100);

                entity.Property(e => e.PrimerViewManufacturerNotes).HasColumnType("ntext");

                entity.Property(e => e.PrimerViewManufacturerState)
                    .HasMaxLength(2)
                    .IsFixedLength();

                entity.Property(e => e.PrimerViewManufacturerUrl)
                    .HasColumnName("PrimerViewManufacturerURL")
                    .HasMaxLength(250);

                entity.Property(e => e.PrimerViewManufacturerZip)
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.PrimerViewName).HasMaxLength(100);

                entity.Property(e => e.PrimerViewNotes).HasColumnType("ntext");

                entity.Property(e => e.PrimerViewPrimerName).HasMaxLength(151);

                entity.Property(e => e.PrimerViewPrimerTypeAbbreviation).HasMaxLength(50);

                entity.Property(e => e.PrimerViewPrimerTypeName).HasMaxLength(50);

                entity.Property(e => e.PrimerViewPrimerTypeNotes).HasColumnType("ntext");
            });

            modelBuilder.Entity<Gun>(entity =>
            {
                entity.HasIndex(e => e.SerialNumber)
                    .HasName("UNQ_GunSerialNumber")
                    .IsUnique();

                entity.Property(e => e.AcquisitionDate).HasColumnType("date");

                entity.Property(e => e.BarrelLength).HasColumnType("decimal(3, 1)");

                entity.Property(e => e.Cost).HasColumnType("money");

                entity.Property(e => e.Details)
                    .IsRequired()
                    .HasColumnType("ntext");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Notes).HasColumnType("ntext");

                entity.Property(e => e.RetireDate).HasColumnType("date");

                entity.Property(e => e.SerialNumber)
                    .IsRequired()
                    .HasMaxLength(75);

                entity.HasOne(d => d.BarrelLengthUnit)
                    .WithMany(p => p.Gun)
                    .HasForeignKey(d => d.BarrelLengthUnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Gun_BarrelLengthUnit");

                entity.HasOne(d => d.Buyer)
                    .WithMany(p => p.GunBuyer)
                    .HasForeignKey(d => d.BuyerId)
                    .HasConstraintName("FK_Gun_Buyer");

                entity.HasOne(d => d.Caliber)
                    .WithMany(p => p.Gun)
                    .HasForeignKey(d => d.CaliberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Gun_Caliber");

                entity.HasOne(d => d.GunType)
                    .WithMany(p => p.Gun)
                    .HasForeignKey(d => d.GunTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Gun_GunType");

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.GunManufacturer)
                    .HasForeignKey(d => d.ManufacturerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Gun_Manufacturer");

                entity.HasOne(d => d.Seller)
                    .WithMany(p => p.GunSeller)
                    .HasForeignKey(d => d.SellerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Gun_Seller");
            });

            modelBuilder.Entity<GunImages>(entity =>
            {
                entity.Property(e => e.PictureLocation)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.Gun)
                    .WithMany(p => p.GunImages)
                    .HasForeignKey(d => d.GunId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GunImages_Gun");
            });

            modelBuilder.Entity<GunType>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UNQ_GunTypeName")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Notes).HasColumnType("ntext");
            });

            modelBuilder.Entity<GunView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("GunView");

                entity.Property(e => e.AcquisitionDate).HasColumnType("date");

                entity.Property(e => e.BarrelLength).HasColumnType("decimal(3, 1)");

                entity.Property(e => e.BuyerAddress).HasMaxLength(50);

                entity.Property(e => e.BuyerCity).HasMaxLength(50);

                entity.Property(e => e.BuyerName).HasMaxLength(100);

                entity.Property(e => e.BuyerNotes).HasColumnType("ntext");

                entity.Property(e => e.BuyerShortName).HasMaxLength(50);

                entity.Property(e => e.BuyerState)
                    .HasMaxLength(2)
                    .IsFixedLength();

                entity.Property(e => e.BuyerUrl)
                    .HasColumnName("BuyerURL")
                    .HasMaxLength(250);

                entity.Property(e => e.BuyerZip)
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.CaliberViewBrassLength).HasColumnType("decimal(7, 3)");

                entity.Property(e => e.CaliberViewBrassLengthUnitViewAbbreviation)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CaliberViewBrassLengthUnitViewName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CaliberViewBrassLengthUnitViewNotes).HasColumnType("ntext");

                entity.Property(e => e.CaliberViewBrassLengthUnitViewPlural)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CaliberViewBrassLengthUnitViewUnitTypeName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CaliberViewBrassLengthUnitViewUnitTypeNotes).HasColumnType("ntext");

                entity.Property(e => e.CaliberViewDiameter).HasColumnType("decimal(7, 3)");

                entity.Property(e => e.CaliberViewDiameterUnitViewAbbreviation)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CaliberViewDiameterUnitViewName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CaliberViewDiameterUnitViewNotes).HasColumnType("ntext");

                entity.Property(e => e.CaliberViewDiameterUnitViewPlural)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CaliberViewDiameterUnitViewUnitTypeName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CaliberViewDiameterUnitViewUnitTypeNotes).HasColumnType("ntext");

                entity.Property(e => e.CaliberViewName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CaliberViewNotes).HasColumnType("ntext");

                entity.Property(e => e.CaliberViewPrimerTypeAbbreviation)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CaliberViewPrimerTypeName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CaliberViewPrimerTypeNotes).HasColumnType("ntext");

                entity.Property(e => e.Cost).HasColumnType("money");

                entity.Property(e => e.Details)
                    .IsRequired()
                    .HasColumnType("ntext");

                entity.Property(e => e.GunName)
                    .IsRequired()
                    .HasMaxLength(152);

                entity.Property(e => e.GunTypeName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GunTypeNotes).HasColumnType("ntext");

                entity.Property(e => e.LengthUnitViewAbbreviation)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LengthUnitViewName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LengthUnitViewNotes).HasColumnType("ntext");

                entity.Property(e => e.LengthUnitViewPlural)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LengthUnitViewUnitTypeName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LengthUnitViewUnitTypeNotes).HasColumnType("ntext");

                entity.Property(e => e.ManufacturerAddress)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ManufacturerCity)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ManufacturerName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ManufacturerNotes).HasColumnType("ntext");

                entity.Property(e => e.ManufacturerShortName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ManufacturerState)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsFixedLength();

                entity.Property(e => e.ManufacturerUrl)
                    .IsRequired()
                    .HasColumnName("ManufacturerURL")
                    .HasMaxLength(250);

                entity.Property(e => e.ManufacturerZip)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Notes).HasColumnType("ntext");

                entity.Property(e => e.RetireDate).HasColumnType("date");

                entity.Property(e => e.SellerAddress)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SellerCity)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SellerName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.SellerNotes).HasColumnType("ntext");

                entity.Property(e => e.SellerShortName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SellerState)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsFixedLength();

                entity.Property(e => e.SellerUrl)
                    .IsRequired()
                    .HasColumnName("SellerURL")
                    .HasMaxLength(250);

                entity.Property(e => e.SellerZip)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.SerialNumber)
                    .IsRequired()
                    .HasMaxLength(75);
            });

            modelBuilder.Entity<GunsCalibers>(entity =>
            {
                entity.HasOne(d => d.Caliber)
                    .WithMany(p => p.GunsCalibers)
                    .HasForeignKey(d => d.CaliberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GunsCalibers_Caliber");

                entity.HasOne(d => d.Gun)
                    .WithMany(p => p.GunsCalibers)
                    .HasForeignKey(d => d.GunId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GunsCalibers_Gun");
            });

            modelBuilder.Entity<GunsCalibersView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("GunsCalibersView");

                entity.Property(e => e.CaliberName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GunName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<InventoryType>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Notes).HasColumnType("ntext");
            });

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.HasIndex(e => new { e.Name, e.Address })
                    .HasName("UNQ_ManufacturerNameAddress")
                    .IsUnique();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Notes).HasColumnType("ntext");

                entity.Property(e => e.ShortName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsFixedLength();

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("URL")
                    .HasMaxLength(250);

                entity.Property(e => e.Zip)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UNQ_MaterialName")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Notes).HasColumnType("ntext");
            });

            modelBuilder.Entity<Powder>(entity =>
            {
                entity.HasIndex(e => new { e.Name, e.ManufacturerId, e.PowderShapeId, e.PowderTypeId })
                    .HasName("UNQ_Powder")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Notes).HasColumnType("ntext");

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.Powder)
                    .HasForeignKey(d => d.ManufacturerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Powder_Manufacturer");

                entity.HasOne(d => d.PowderShape)
                    .WithMany(p => p.Powder)
                    .HasForeignKey(d => d.PowderShapeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Powder_PowderShape");

                entity.HasOne(d => d.PowderType)
                    .WithMany(p => p.Powder)
                    .HasForeignKey(d => d.PowderTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Powder_PowderType");
            });

            modelBuilder.Entity<PowderCost>(entity =>
            {
                entity.Property(e => e.Cost).HasColumnType("money");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Notes).HasColumnType("ntext");

                entity.HasOne(d => d.Powder)
                    .WithMany(p => p.PowderCost)
                    .HasForeignKey(d => d.PowderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PowderCost_Powder");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.PowderCost)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PowderCost_Unit");
            });

            modelBuilder.Entity<PowderQuantity>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Notes).HasColumnType("ntext");

                entity.HasOne(d => d.InventoryType)
                    .WithMany(p => p.PowderQuantity)
                    .HasForeignKey(d => d.InventoryTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PowderQuantity_InventoryType");

                entity.HasOne(d => d.Powder)
                    .WithMany(p => p.PowderQuantity)
                    .HasForeignKey(d => d.PowderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PowderQuantity_Powder");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.PowderQuantity)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PowderQuantity_Unit");
            });

            modelBuilder.Entity<PowderShape>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UNQ_PowderShapeName")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Notes).HasColumnType("ntext");
            });

            modelBuilder.Entity<PowderType>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UNQ_PowderTypeName")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Notes).HasColumnType("ntext");
            });

            modelBuilder.Entity<PowderView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("PowderView");

                entity.Property(e => e.ManufacturerAddress)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ManufacturerCity)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ManufacturerName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ManufacturerNotes).HasColumnType("ntext");

                entity.Property(e => e.ManufacturerShortName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ManufacturerState)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsFixedLength();

                entity.Property(e => e.ManufacturerUrl)
                    .IsRequired()
                    .HasColumnName("ManufacturerURL")
                    .HasMaxLength(250);

                entity.Property(e => e.ManufacturerZip)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Notes).HasColumnType("ntext");

                entity.Property(e => e.PowderName)
                    .IsRequired()
                    .HasMaxLength(151);

                entity.Property(e => e.PowderShapeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.PowderShapeNotes).HasColumnType("ntext");

                entity.Property(e => e.PowderTypeName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PowderTypeNotes).HasColumnType("ntext");
            });

            modelBuilder.Entity<Primer>(entity =>
            {
                entity.HasIndex(e => new { e.ManufacturerId, e.Name, e.PrimerTypeId })
                    .HasName("UNQ_Primer")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Notes).HasColumnType("ntext");

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.Primer)
                    .HasForeignKey(d => d.ManufacturerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Primer_Manufacturer");

                entity.HasOne(d => d.PrimerType)
                    .WithMany(p => p.Primer)
                    .HasForeignKey(d => d.PrimerTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Primer_PrimerType");
            });

            modelBuilder.Entity<PrimerCost>(entity =>
            {
                entity.Property(e => e.Cost).HasColumnType("money");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Notes).HasColumnType("ntext");

                entity.HasOne(d => d.Primer)
                    .WithMany(p => p.PrimerCost)
                    .HasForeignKey(d => d.PrimerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PrimerCost_Primer");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.PrimerCost)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PrimerCost_Unit");
            });

            modelBuilder.Entity<PrimerQuantity>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Notes).HasColumnType("ntext");

                entity.HasOne(d => d.InventoryType)
                    .WithMany(p => p.PrimerQuantity)
                    .HasForeignKey(d => d.InventoryTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PrimerQuantity_InventoryType");

                entity.HasOne(d => d.Primer)
                    .WithMany(p => p.PrimerQuantity)
                    .HasForeignKey(d => d.PrimerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PrimerQuantity_Primer");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.PrimerQuantity)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PrimerQuantity_Unit");
            });

            modelBuilder.Entity<PrimerType>(entity =>
            {
                entity.HasIndex(e => new { e.Abbreviation, e.Name })
                    .HasName("UNQ_PrimerTypeNameAbbreviation")
                    .IsUnique();

                entity.Property(e => e.Abbreviation)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Notes).HasColumnType("ntext");
            });

            modelBuilder.Entity<PrimerView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("PrimerView");

                entity.Property(e => e.ManufacturerAddress)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ManufacturerCity)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ManufacturerName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ManufacturerNotes).HasColumnType("ntext");

                entity.Property(e => e.ManufacturerShortName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ManufacturerState)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsFixedLength();

                entity.Property(e => e.ManufacturerUrl)
                    .IsRequired()
                    .HasColumnName("ManufacturerURL")
                    .HasMaxLength(250);

                entity.Property(e => e.ManufacturerZip)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Notes).HasColumnType("ntext");

                entity.Property(e => e.PrimerFullName)
                    .IsRequired()
                    .HasMaxLength(202);

                entity.Property(e => e.PrimerName)
                    .IsRequired()
                    .HasMaxLength(151);

                entity.Property(e => e.PrimerTypeAbbreviation)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PrimerTypeName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PrimerTypeNotes).HasColumnType("ntext");
            });

            modelBuilder.Entity<ShootingLocation>(entity =>
            {
                entity.HasIndex(e => new { e.Name, e.State })
                    .HasName("UNQ_ShootingLocationNameState")
                    .IsUnique();

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasColumnType("xml");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Notes).HasColumnType("ntext");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsFixedLength();
            });

            modelBuilder.Entity<ShootingLocationView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ShootingLocationView");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasColumnType("xml");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Notes).HasColumnType("ntext");

                entity.Property(e => e.ShootingLocationName)
                    .IsRequired()
                    .HasMaxLength(54);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsFixedLength();
            });

            modelBuilder.Entity<ShootingSession>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Notes).HasColumnType("ntext");

                entity.HasOne(d => d.Cartridge)
                    .WithMany(p => p.ShootingSession)
                    .HasForeignKey(d => d.CartridgeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShootingSession_Cartridge");

                entity.HasOne(d => d.Gun)
                    .WithMany(p => p.ShootingSession)
                    .HasForeignKey(d => d.GunId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShootingSession_Gun");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.ShootingSession)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShootingSession_ShootingLocation");
            });

            modelBuilder.Entity<ShootingSessionView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ShootingSessionView");

                entity.Property(e => e.CartridgeViewBrassViewBrassFullName).HasMaxLength(139);

                entity.Property(e => e.CartridgeViewBrassViewBrassName).HasMaxLength(101);

                entity.Property(e => e.CartridgeViewBrassViewManufacturerAddress).HasMaxLength(50);

                entity.Property(e => e.CartridgeViewBrassViewManufacturerCity).HasMaxLength(50);

                entity.Property(e => e.CartridgeViewBrassViewManufacturerName).HasMaxLength(100);

                entity.Property(e => e.CartridgeViewBrassViewManufacturerNotes).HasColumnType("ntext");

                entity.Property(e => e.CartridgeViewBrassViewManufacturerState)
                    .HasMaxLength(2)
                    .IsFixedLength();

                entity.Property(e => e.CartridgeViewBrassViewManufacturerUrl)
                    .HasColumnName("CartridgeViewBrassViewManufacturerURL")
                    .HasMaxLength(250);

                entity.Property(e => e.CartridgeViewBrassViewManufacturerZip)
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.CartridgeViewBrassViewMaterialName).HasMaxLength(50);

                entity.Property(e => e.CartridgeViewBrassViewMaterialNotes).HasColumnType("ntext");

                entity.Property(e => e.CartridgeViewBrassViewName).HasMaxLength(100);

                entity.Property(e => e.CartridgeViewBrassViewNotes).HasColumnType("ntext");

                entity.Property(e => e.CartridgeViewBrassViewParentBrassFullName).HasMaxLength(139);

                entity.Property(e => e.CartridgeViewCartridgeLoadViewBulletViewBallisticCoefficient).HasColumnType("decimal(7, 3)");

                entity.Property(e => e.CartridgeViewCartridgeLoadViewBulletViewBulletFullName).HasMaxLength(234);

                entity.Property(e => e.CartridgeViewCartridgeLoadViewBulletViewBulletName).HasMaxLength(183);

                entity.Property(e => e.CartridgeViewCartridgeLoadViewBulletViewBulletTypeAbbreviation).HasMaxLength(50);

                entity.Property(e => e.CartridgeViewCartridgeLoadViewBulletViewBulletTypeName).HasMaxLength(50);

                entity.Property(e => e.CartridgeViewCartridgeLoadViewBulletViewBulletTypeNotes).HasColumnType("ntext");

                entity.Property(e => e.CartridgeViewCartridgeLoadViewBulletViewDiameter).HasColumnType("decimal(7, 3)");

                entity.Property(e => e.CartridgeViewCartridgeLoadViewBulletViewDiameterUnitViewAbbreviation).HasMaxLength(50);

                entity.Property(e => e.CartridgeViewCartridgeLoadViewBulletViewDiameterUnitViewName).HasMaxLength(50);

                entity.Property(e => e.CartridgeViewCartridgeLoadViewBulletViewDiameterUnitViewNotes).HasColumnType("ntext");

                entity.Property(e => e.CartridgeViewCartridgeLoadViewBulletViewDiameterUnitViewPlural).HasMaxLength(50);

                entity.Property(e => e.CartridgeViewCartridgeLoadViewBulletViewDiameterUnitViewUnitTypeName).HasMaxLength(50);

                entity.Property(e => e.CartridgeViewCartridgeLoadViewBulletViewDiameterUnitViewUnitTypeNotes).HasColumnType("ntext");

                entity.Property(e => e.CartridgeViewCartridgeLoadViewBulletViewLength).HasColumnType("decimal(7, 3)");

                entity.Property(e => e.CartridgeViewCartridgeLoadViewBulletViewLengthUnitViewAbbreviation).HasMaxLength(50);

                entity.Property(e => e.CartridgeViewCartridgeLoadViewBulletViewLengthUnitViewName).HasMaxLength(50);

                entity.Property(e => e.CartridgeViewCartridgeLoadViewBulletViewLengthUnitViewNotes).HasColumnType("ntext");

                entity.Property(e => e.CartridgeViewCartridgeLoadViewBulletViewLengthUnitViewPlural).HasMaxLength(50);

                entity.Property(e => e.CartridgeViewCartridgeLoadViewBulletViewLengthUnitViewUnitTypeName).HasMaxLength(50);

                entity.Property(e => e.CartridgeViewCartridgeLoadViewBulletViewLengthUnitViewUnitTypeNotes).HasColumnType("ntext");

                entity.Property(e => e.CartridgeViewCartridgeLoadViewBulletViewManufacturerAddress).HasMaxLength(50);

                entity.Property(e => e.CartridgeViewCartridgeLoadViewBulletViewManufacturerCity).HasMaxLength(50);

                entity.Property(e => e.CartridgeViewCartridgeLoadViewBulletViewManufacturerName).HasMaxLength(100);

                entity.Property(e => e.CartridgeViewCartridgeLoadViewBulletViewManufacturerNotes).HasColumnType("ntext");

                entity.Property(e => e.CartridgeViewCartridgeLoadViewBulletViewManufacturerState)
                    .HasMaxLength(2)
                    .IsFixedLength();

                entity.Property(e => e.CartridgeViewCartridgeLoadViewBulletViewManufacturerUrl)
                    .HasColumnName("CartridgeViewCartridgeLoadViewBulletViewManufacturerURL")
                    .HasMaxLength(250);

                entity.Property(e => e.CartridgeViewCartridgeLoadViewBulletViewManufacturerZip)
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.CartridgeViewCartridgeLoadViewBulletViewMassUnitViewAbbreviation).HasMaxLength(50);

                entity.Property(e => e.CartridgeViewCartridgeLoadViewBulletViewMassUnitViewName).HasMaxLength(50);

                entity.Property(e => e.CartridgeViewCartridgeLoadViewBulletViewMassUnitViewNotes).HasColumnType("ntext");

                entity.Property(e => e.CartridgeViewCartridgeLoadViewBulletViewMassUnitViewPlural).HasMaxLength(50);

                entity.Property(e => e.CartridgeViewCartridgeLoadViewBulletViewMassUnitViewUnitTypeName).HasMaxLength(50);

                entity.Property(e => e.CartridgeViewCartridgeLoadViewBulletViewMassUnitViewUnitTypeNotes).HasColumnType("ntext");

                entity.Property(e => e.CartridgeViewCartridgeLoadViewBulletViewMaterialName).HasMaxLength(50);

                entity.Property(e => e.CartridgeViewCartridgeLoadViewBulletViewMaterialNotes).HasColumnType("ntext");

                entity.Property(e => e.CartridgeViewCartridgeLoadViewBulletViewName).HasMaxLength(100);

                entity.Property(e => e.CartridgeViewCartridgeLoadViewBulletViewNotes).HasColumnType("ntext");

                entity.Property(e => e.CartridgeViewCartridgeLoadViewBulletViewSectionalDensity).HasColumnType("decimal(7, 3)");

                entity.Property(e => e.CartridgeViewCartridgeLoadViewCartridgeLoadName).HasMaxLength(316);

                entity.Property(e => e.CartridgeViewCartridgeLoadViewCol)
                    .HasColumnName("CartridgeViewCartridgeLoadViewCOL")
                    .HasColumnType("decimal(4, 3)");

                entity.Property(e => e.CartridgeViewCartridgeLoadViewColunitId).HasColumnName("CartridgeViewCartridgeLoadViewCOLUnitId");

                entity.Property(e => e.CartridgeViewCartridgeLoadViewColunitViewAbbreviation)
                    .HasColumnName("CartridgeViewCartridgeLoadViewCOLUnitViewAbbreviation")
                    .HasMaxLength(50);

                entity.Property(e => e.CartridgeViewCartridgeLoadViewColunitViewName)
                    .HasColumnName("CartridgeViewCartridgeLoadViewCOLUnitViewName")
                    .HasMaxLength(50);

                entity.Property(e => e.CartridgeViewCartridgeLoadViewColunitViewNotes)
                    .HasColumnName("CartridgeViewCartridgeLoadViewCOLUnitViewNotes")
                    .HasColumnType("ntext");

                entity.Property(e => e.CartridgeViewCartridgeLoadViewColunitViewPlural)
                    .HasColumnName("CartridgeViewCartridgeLoadViewCOLUnitViewPlural")
                    .HasMaxLength(50);

                entity.Property(e => e.CartridgeViewCartridgeLoadViewColunitViewUnitTypeId).HasColumnName("CartridgeViewCartridgeLoadViewCOLUnitViewUnitTypeId");

                entity.Property(e => e.CartridgeViewCartridgeLoadViewColunitViewUnitTypeName)
                    .HasColumnName("CartridgeViewCartridgeLoadViewCOLUnitViewUnitTypeName")
                    .HasMaxLength(50);

                entity.Property(e => e.CartridgeViewCartridgeLoadViewColunitViewUnitTypeNotes)
                    .HasColumnName("CartridgeViewCartridgeLoadViewCOLUnitViewUnitTypeNotes")
                    .HasColumnType("ntext");

                entity.Property(e => e.CartridgeViewCartridgeLoadViewName).HasMaxLength(100);

                entity.Property(e => e.CartridgeViewCartridgeLoadViewNotes).HasColumnType("ntext");

                entity.Property(e => e.CartridgeViewCartridgeLoadViewPowderViewManufacturerAddress).HasMaxLength(50);

                entity.Property(e => e.CartridgeViewCartridgeLoadViewPowderViewManufacturerCity).HasMaxLength(50);

                entity.Property(e => e.CartridgeViewCartridgeLoadViewPowderViewManufacturerName).HasMaxLength(100);

                entity.Property(e => e.CartridgeViewCartridgeLoadViewPowderViewManufacturerNotes).HasColumnType("ntext");

                entity.Property(e => e.CartridgeViewCartridgeLoadViewPowderViewManufacturerState)
                    .HasMaxLength(2)
                    .IsFixedLength();

                entity.Property(e => e.CartridgeViewCartridgeLoadViewPowderViewManufacturerUrl)
                    .HasColumnName("CartridgeViewCartridgeLoadViewPowderViewManufacturerURL")
                    .HasMaxLength(250);

                entity.Property(e => e.CartridgeViewCartridgeLoadViewPowderViewManufacturerZip)
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.CartridgeViewCartridgeLoadViewPowderViewName).HasMaxLength(50);

                entity.Property(e => e.CartridgeViewCartridgeLoadViewPowderViewNotes).HasColumnType("ntext");

                entity.Property(e => e.CartridgeViewCartridgeLoadViewPowderViewPowderName).HasMaxLength(151);

                entity.Property(e => e.CartridgeViewCartridgeLoadViewPowderViewPowderShapeName)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.CartridgeViewCartridgeLoadViewPowderViewPowderShapeNotes).HasColumnType("ntext");

                entity.Property(e => e.CartridgeViewCartridgeLoadViewPowderViewPowderTypeName).HasMaxLength(50);

                entity.Property(e => e.CartridgeViewCartridgeLoadViewPowderViewPowderTypeNotes).HasColumnType("ntext");

                entity.Property(e => e.CartridgeViewCartridgeLoadViewPowderWeight).HasColumnType("decimal(4, 1)");

                entity.Property(e => e.CartridgeViewCartridgeLoadViewPowderWeightUnitViewAbbreviation).HasMaxLength(50);

                entity.Property(e => e.CartridgeViewCartridgeLoadViewPowderWeightUnitViewName).HasMaxLength(50);

                entity.Property(e => e.CartridgeViewCartridgeLoadViewPowderWeightUnitViewNotes).HasColumnType("ntext");

                entity.Property(e => e.CartridgeViewCartridgeLoadViewPowderWeightUnitViewPlural).HasMaxLength(50);

                entity.Property(e => e.CartridgeViewCartridgeLoadViewPowderWeightUnitViewUnitTypeName).HasMaxLength(50);

                entity.Property(e => e.CartridgeViewCartridgeLoadViewPowderWeightUnitViewUnitTypeNotes).HasColumnType("ntext");

                entity.Property(e => e.CartridgeViewCartridgeLoadViewPressureUnitViewAbbreviation).HasMaxLength(50);

                entity.Property(e => e.CartridgeViewCartridgeLoadViewPressureUnitViewName).HasMaxLength(50);

                entity.Property(e => e.CartridgeViewCartridgeLoadViewPressureUnitViewNotes).HasColumnType("ntext");

                entity.Property(e => e.CartridgeViewCartridgeLoadViewPressureUnitViewPlural).HasMaxLength(50);

                entity.Property(e => e.CartridgeViewCartridgeLoadViewPressureUnitViewUnitTypeName).HasMaxLength(50);

                entity.Property(e => e.CartridgeViewCartridgeLoadViewPressureUnitViewUnitTypeNotes).HasColumnType("ntext");

                entity.Property(e => e.CartridgeViewCartridgeLoadViewVelocityUnitViewAbbreviation).HasMaxLength(50);

                entity.Property(e => e.CartridgeViewCartridgeLoadViewVelocityUnitViewName).HasMaxLength(50);

                entity.Property(e => e.CartridgeViewCartridgeLoadViewVelocityUnitViewNotes).HasColumnType("ntext");

                entity.Property(e => e.CartridgeViewCartridgeLoadViewVelocityUnitViewPlural).HasMaxLength(50);

                entity.Property(e => e.CartridgeViewCartridgeLoadViewVelocityUnitViewUnitTypeName).HasMaxLength(50);

                entity.Property(e => e.CartridgeViewCartridgeLoadViewVelocityUnitViewUnitTypeNotes).HasColumnType("ntext");

                entity.Property(e => e.CartridgeViewCartridgeName).HasMaxLength(421);

                entity.Property(e => e.CartridgeViewManufacturerAddress).HasMaxLength(50);

                entity.Property(e => e.CartridgeViewManufacturerCity).HasMaxLength(50);

                entity.Property(e => e.CartridgeViewManufacturerName).HasMaxLength(100);

                entity.Property(e => e.CartridgeViewManufacturerNotes).HasColumnType("ntext");

                entity.Property(e => e.CartridgeViewManufacturerShortName).HasMaxLength(50);

                entity.Property(e => e.CartridgeViewManufacturerState)
                    .HasMaxLength(2)
                    .IsFixedLength();

                entity.Property(e => e.CartridgeViewManufacturerUrl)
                    .HasColumnName("CartridgeViewManufacturerURL")
                    .HasMaxLength(250);

                entity.Property(e => e.CartridgeViewManufacturerZip)
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.CartridgeViewName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CartridgeViewNotes).HasColumnType("ntext");

                entity.Property(e => e.CartridgeViewPrimerViewFullName).HasMaxLength(202);

                entity.Property(e => e.CartridgeViewPrimerViewManufacturerAddress).HasMaxLength(50);

                entity.Property(e => e.CartridgeViewPrimerViewManufacturerCity).HasMaxLength(50);

                entity.Property(e => e.CartridgeViewPrimerViewManufacturerName).HasMaxLength(100);

                entity.Property(e => e.CartridgeViewPrimerViewManufacturerNotes).HasColumnType("ntext");

                entity.Property(e => e.CartridgeViewPrimerViewManufacturerState)
                    .HasMaxLength(2)
                    .IsFixedLength();

                entity.Property(e => e.CartridgeViewPrimerViewManufacturerUrl)
                    .HasColumnName("CartridgeViewPrimerViewManufacturerURL")
                    .HasMaxLength(250);

                entity.Property(e => e.CartridgeViewPrimerViewManufacturerZip)
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.CartridgeViewPrimerViewName).HasMaxLength(100);

                entity.Property(e => e.CartridgeViewPrimerViewNotes).HasColumnType("ntext");

                entity.Property(e => e.CartridgeViewPrimerViewPrimerName).HasMaxLength(151);

                entity.Property(e => e.CartridgeViewPrimerViewPrimerTypeAbbreviation).HasMaxLength(50);

                entity.Property(e => e.CartridgeViewPrimerViewPrimerTypeName).HasMaxLength(50);

                entity.Property(e => e.CartridgeViewPrimerViewPrimerTypeNotes).HasColumnType("ntext");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.GunViewAcquisitionDate).HasColumnType("date");

                entity.Property(e => e.GunViewBarrelLength).HasColumnType("decimal(3, 1)");

                entity.Property(e => e.GunViewBuyerAddress).HasMaxLength(50);

                entity.Property(e => e.GunViewBuyerCity).HasMaxLength(50);

                entity.Property(e => e.GunViewBuyerName).HasMaxLength(100);

                entity.Property(e => e.GunViewBuyerNotes).HasColumnType("ntext");

                entity.Property(e => e.GunViewBuyerShortName).HasMaxLength(50);

                entity.Property(e => e.GunViewBuyerState)
                    .HasMaxLength(2)
                    .IsFixedLength();

                entity.Property(e => e.GunViewBuyerUrl)
                    .HasColumnName("GunViewBuyerURL")
                    .HasMaxLength(250);

                entity.Property(e => e.GunViewBuyerZip)
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.GunViewCaliberViewBrassLength).HasColumnType("decimal(7, 3)");

                entity.Property(e => e.GunViewCaliberViewBrassLengthUnitViewAbbreviation)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GunViewCaliberViewBrassLengthUnitViewName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GunViewCaliberViewBrassLengthUnitViewNotes).HasColumnType("ntext");

                entity.Property(e => e.GunViewCaliberViewBrassLengthUnitViewPlural)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GunViewCaliberViewBrassLengthUnitViewUnitTypeName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GunViewCaliberViewBrassLengthUnitViewUnitTypeNotes).HasColumnType("ntext");

                entity.Property(e => e.GunViewCaliberViewDiameter).HasColumnType("decimal(7, 3)");

                entity.Property(e => e.GunViewCaliberViewDiameterUnitViewAbbreviation)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GunViewCaliberViewDiameterUnitViewName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GunViewCaliberViewDiameterUnitViewNotes).HasColumnType("ntext");

                entity.Property(e => e.GunViewCaliberViewDiameterUnitViewPlural)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GunViewCaliberViewDiameterUnitViewUnitTypeName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GunViewCaliberViewDiameterUnitViewUnitTypeNotes).HasColumnType("ntext");

                entity.Property(e => e.GunViewCaliberViewName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GunViewCaliberViewNotes).HasColumnType("ntext");

                entity.Property(e => e.GunViewCaliberViewPrimerTypeAbbreviation)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GunViewCaliberViewPrimerTypeName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GunViewCaliberViewPrimerTypeNotes).HasColumnType("ntext");

                entity.Property(e => e.GunViewCost).HasColumnType("money");

                entity.Property(e => e.GunViewDetails)
                    .IsRequired()
                    .HasColumnType("ntext");

                entity.Property(e => e.GunViewGunName)
                    .IsRequired()
                    .HasMaxLength(152);

                entity.Property(e => e.GunViewGunTypeName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GunViewGunTypeNotes).HasColumnType("ntext");

                entity.Property(e => e.GunViewLengthUnitViewAbbrevation)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GunViewLengthUnitViewName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GunViewLengthUnitViewNotes).HasColumnType("ntext");

                entity.Property(e => e.GunViewLengthUnitViewPlural)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GunViewLengthUnitViewUnitTypeName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GunViewLengthUnitViewUnitTypeNotes).HasColumnType("ntext");

                entity.Property(e => e.GunViewManufacturerAddress)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GunViewManufacturerCity)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GunViewManufacturerName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.GunViewManufacturerNotes).HasColumnType("ntext");

                entity.Property(e => e.GunViewManufacturerShortName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GunViewManufacturerState)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsFixedLength();

                entity.Property(e => e.GunViewManufacturerUrl)
                    .IsRequired()
                    .HasColumnName("GunViewManufacturerURL")
                    .HasMaxLength(250);

                entity.Property(e => e.GunViewManufacturerZip)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.GunViewName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GunViewNotes).HasColumnType("ntext");

                entity.Property(e => e.GunViewRetireDate).HasColumnType("date");

                entity.Property(e => e.GunViewSellerAddress)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GunViewSellerCity)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GunViewSellerName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.GunViewSellerNotes).HasColumnType("ntext");

                entity.Property(e => e.GunViewSellerShortName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GunViewSellerState)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsFixedLength();

                entity.Property(e => e.GunViewSellerUrl)
                    .IsRequired()
                    .HasColumnName("GunViewSellerURL")
                    .HasMaxLength(250);

                entity.Property(e => e.GunViewSellerZip)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.GunViewSerialNumber)
                    .IsRequired()
                    .HasMaxLength(75);

                entity.Property(e => e.Notes).HasColumnType("ntext");

                entity.Property(e => e.ShootingLocationViewLocation)
                    .IsRequired()
                    .HasColumnType("xml");

                entity.Property(e => e.ShootingLocationViewName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ShootingLocationViewNotes).HasColumnType("ntext");

                entity.Property(e => e.ShootingLocationViewShootingLocationName)
                    .IsRequired()
                    .HasMaxLength(54);

                entity.Property(e => e.ShootingLocationViewState)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.HasIndex(e => new { e.Name, e.UnitTypeId })
                    .HasName("UNQ_UnitNameUnitType")
                    .IsUnique();

                entity.Property(e => e.Abbreviation)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Notes).HasColumnType("ntext");

                entity.Property(e => e.Plural)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.UnitType)
                    .WithMany(p => p.Unit)
                    .HasForeignKey(d => d.UnitTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Unit_UnitType");
            });

            modelBuilder.Entity<UnitType>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UNQ_UnitTypeName")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Notes).HasColumnType("ntext");
            });

            modelBuilder.Entity<UnitView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("UnitView");

                entity.Property(e => e.Abbreviation)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Notes).HasColumnType("ntext");

                entity.Property(e => e.Plural)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UnitTypeName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UnitTypeNotes).HasColumnType("ntext");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
