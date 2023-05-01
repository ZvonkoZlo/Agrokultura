using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Agrokultura.Models;

public partial class AgroContext : DbContext
{
    public AgroContext()
    {
    }

    public AgroContext(DbContextOptions<AgroContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Chore> Chores { get; set; }

    public virtual DbSet<ChorePerson> ChorePeople { get; set; }

    public virtual DbSet<ChoreStatus> ChoreStatuses { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Contract> Contracts { get; set; }

    public virtual DbSet<ContractPlot> ContractPlots { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<GoodsType> GoodsTypes { get; set; }

    public virtual DbSet<Ground> Grounds { get; set; }

    public virtual DbSet<IncomeAndExpense> IncomeAndExpenses { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderStatus> OrderStatuses { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Plant> Plants { get; set; }

    public virtual DbSet<PlantType> PlantTypes { get; set; }

    public virtual DbSet<Plot> Plots { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Terrain> Terrains { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=agro;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Chore>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__chore__3213E83F1CB3BDDD");

            entity.ToTable("chore");

            entity.Property(e => e.Id)
               .ValueGeneratedOnAdd()
              .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(5000)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<ChorePerson>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__chore_pe__3213E83F7148C5FF");

            entity.ToTable("chore_person");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
              .HasColumnName("id");
            entity.Property(e => e.ChoreId).HasColumnName("chore_id");
            entity.Property(e => e.Description)
                .HasMaxLength(5000)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.OrderStatusId).HasColumnName("order_status_id");
            entity.Property(e => e.PersonId).HasColumnName("person_id");

            entity.HasOne(d => d.Chore).WithMany(p => p.ChorePeople)
                .HasForeignKey(d => d.ChoreId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__chore_per__chore__5812160E");

            entity.HasOne(d => d.OrderStatus).WithMany(p => p.ChorePeople)
                .HasForeignKey(d => d.OrderStatusId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__chore_per__order__59063A47");

            entity.HasOne(d => d.Person).WithMany(p => p.ChorePeople)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__chore_per__perso__59FA5E80");
        });

        modelBuilder.Entity<ChoreStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__chore_st__3213E83FAD3F0B0E");

            entity.ToTable("chore_status");

            entity.Property(e => e.Id)
               .ValueGeneratedOnAdd()
              .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__city__3213E83F0FBAFC12");

            entity.ToTable("city");

            entity.Property(e => e.Id)
             .ValueGeneratedOnAdd()
              .HasColumnName("id");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.PostalCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("postal_code");

            entity.HasOne(d => d.Country).WithMany(p => p.Cities)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__city__country_id__5AEE82B9");
        });

        modelBuilder.Entity<Contract>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__contract__3213E83F65AEF21C");

            entity.ToTable("contract");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
              .HasColumnName("id");
            entity.Property(e => e.BeneficiaryId).HasColumnName("beneficiary_id");
            entity.Property(e => e.DateOfConclusion)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("date_of_conclusion");
            entity.Property(e => e.DateOfExpiration)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("date_of_expiration");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.ProviderId).HasColumnName("provider_id");

            entity.HasOne(d => d.Beneficiary).WithMany(p => p.ContractBeneficiaries)
                .HasForeignKey(d => d.BeneficiaryId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__contract__benefi__5BE2A6F2");

            entity.HasOne(d => d.Provider).WithMany(p => p.ContractProviders)
                .HasForeignKey(d => d.ProviderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__contract__provid__5CD6CB2B");
        });

        modelBuilder.Entity<ContractPlot>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__contract__3213E83F21D8BA34");

            entity.ToTable("contract_plot");

            entity.Property(e => e.Id)
               .ValueGeneratedOnAdd()
              .HasColumnName("id");
            entity.Property(e => e.ContractId).HasColumnName("contract_id");
            entity.Property(e => e.PlotId).HasColumnName("plot_id");

            entity.HasOne(d => d.Contract).WithMany(p => p.ContractPlots)
                .HasForeignKey(d => d.ContractId)
                .HasConstraintName("FK__contract___contr__5DCAEF64");

            entity.HasOne(d => d.Plot).WithMany(p => p.ContractPlots)
                .HasForeignKey(d => d.PlotId)
                .HasConstraintName("FK__contract___plot___5EBF139D");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__country__3213E83FE9403171");

            entity.ToTable("country");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
              .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<GoodsType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__goods_ty__3213E83FCF7F9773");

            entity.ToTable("goods_type");

            entity.Property(e => e.Id)
             .ValueGeneratedOnAdd()
              .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Ground>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ground__3213E83FFFF90794");

            entity.ToTable("ground");

            entity.Property(e => e.Id)
               .ValueGeneratedOnAdd()
              .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(5000)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<IncomeAndExpense>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__income_a__3213E83F01D52852");

            entity.ToTable("income_and_expenses");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
              .HasColumnName("id");
            entity.Property(e => e.AmountOfGoods).HasColumnName("amount_of_goods");
            entity.Property(e => e.AmountOfPlants).HasColumnName("amount_of_plants");
            entity.Property(e => e.DateOfPlanting)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("date_of_planting");
            entity.Property(e => e.EndDateOfPlanting)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("end_date_of_planting");
            entity.Property(e => e.PlantId).HasColumnName("plant_id");
            entity.Property(e => e.PlotId).HasColumnName("plot_id");
            entity.Property(e => e.Price).HasColumnName("price");

            entity.HasOne(d => d.Plant).WithMany(p => p.IncomeAndExpenses)
                .HasForeignKey(d => d.PlantId)
                .HasConstraintName("FK__income_an__plant__5FB337D6");

            entity.HasOne(d => d.Plot).WithMany(p => p.IncomeAndExpenses)
                .HasForeignKey(d => d.PlotId)
                .HasConstraintName("FK__income_an__plot___60A75C0F");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__order__3213E83FEB6A7775");

            entity.ToTable("order");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
              .HasColumnName("id");
            entity.Property(e => e.AmountOfGoods).HasColumnName("amount_of_goods");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.OrderStatusId).HasColumnName("order_status_id");
            entity.Property(e => e.PlantId).HasColumnName("plant_id");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__order__customer___619B8048");

            entity.HasOne(d => d.OrderStatus).WithMany(p => p.Orders)
                .HasForeignKey(d => d.OrderStatusId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__order__order_sta__628FA481");

            entity.HasOne(d => d.Plant).WithMany(p => p.Orders)
                .HasForeignKey(d => d.PlantId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__order__plant_id__6383C8BA");
        });

        modelBuilder.Entity<OrderStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__order_st__3213E83F8D778D95");

            entity.ToTable("order_status");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
              .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__person__3213E83FC6A192CC");

            entity.ToTable("person");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
              .HasColumnName("id");
            entity.Property(e => e.Adress)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("adress");
            entity.Property(e => e.CityId).HasColumnName("city_id");
            entity.Property(e => e.Email)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("full_name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone_number");
            entity.Property(e => e.RoleId).HasColumnName("role_id");

            entity.HasOne(d => d.City).WithMany(p => p.People)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK__person__city_id__6477ECF3");

            entity.HasOne(d => d.Role).WithMany(p => p.People)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__person__role_id__656C112C")
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Plant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__plant__3213E83FA4C407E4");

            entity.ToTable("plant");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
              .HasColumnName("id");
            entity.Property(e => e.AmountOfGoods).HasColumnName("amount_of_goods");
            entity.Property(e => e.Description)
                .HasMaxLength(5000)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.GoodsTypeId).HasColumnName("goods_type_id");
            entity.Property(e => e.ManufacturerId).HasColumnName("manufacturer_id");
            entity.Property(e => e.Name)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.PlantTypeId).HasColumnName("plant_type_id");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.SubspeciesName)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("subspecies_name");

            entity.HasOne(d => d.GoodsType).WithMany(p => p.Plants)
                .HasForeignKey(d => d.GoodsTypeId)
                .HasConstraintName("FK__plant__goods_typ__66603565");

            entity.HasOne(d => d.Manufacturer).WithMany(p => p.Plants)
                .HasForeignKey(d => d.ManufacturerId)
                .HasConstraintName("FK__plant__manufactu__6754599E");

            entity.HasOne(d => d.PlantType).WithMany(p => p.Plants)
                .HasForeignKey(d => d.PlantTypeId)
                .HasConstraintName("FK__plant__plant_typ__68487DD7");
        });

        modelBuilder.Entity<PlantType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__plant_ty__3213E83FD20B8659");

            entity.ToTable("plant_type");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
              .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(5000)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Plot>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__plot__3213E83F0E997AF4");

            entity.ToTable("plot");

            entity.Property(e => e.Id)
             .ValueGeneratedOnAdd()
              .HasColumnName("id");
            entity.Property(e => e.Coordinates)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("coordinates");
            entity.Property(e => e.Corners)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("corners");
            entity.Property(e => e.GroundId).HasColumnName("ground_id");
            entity.Property(e => e.Longitudes)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("longitudes");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.OwnerId).HasColumnName("owner_id");
            entity.Property(e => e.TerrainId).HasColumnName("terrain_id");

            entity.HasOne(d => d.Ground).WithMany(p => p.Plots)
                .HasForeignKey(d => d.GroundId)
                .HasConstraintName("FK__plot__ground_id__693CA210");

            entity.HasOne(d => d.Owner).WithMany(p => p.Plots)
                .HasForeignKey(d => d.OwnerId)
                .HasConstraintName("FK__plot__owner_id__6A30C649");

            entity.HasOne(d => d.Terrain).WithMany(p => p.Plots)
                .HasForeignKey(d => d.TerrainId)
                .HasConstraintName("FK__plot__terrain_id__6B24EA82");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__role__3213E83FA722BBF2");

            entity.ToTable("role");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
              .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(5000)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Terrain>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__terrain__3213E83F7D46155D");

            entity.ToTable("terrain");

            entity.Property(e => e.Id)
               .ValueGeneratedOnAdd()
              .HasColumnName("id");
            entity.Property(e => e.GroundSlope).HasColumnName("ground_slope");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.SunPersence)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("sun_persence");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
