using Microsoft.EntityFrameworkCore;
using tut9.Core.Models;

namespace tut9.Application;

public partial class TripContext : DbContext
{
    private readonly string? _connectionString;

    public TripContext() { }

    public TripContext(IConfiguration configuration, DbContextOptions<TripContext> options) : base(options)
    {
        _connectionString = configuration.GetConnectionString("Default") ??
                            throw new ArgumentNullException(nameof(configuration), "Connection string is not set");
    }
    
    public virtual DbSet<Country> Countries { get; set; }
    public virtual DbSet<Trip> Trips { get; set; }
    public virtual DbSet<Client> Clients { get; set; }
    public virtual DbSet<CountryTrip> CountryTrips { get; set; }
    public virtual DbSet<ClientTrip> ClientTrips { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.IdCountry).HasName("Country_pk");;
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(120);
            entity.ToTable("Country");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.IdClient).HasName("Client_pk");;
            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(120);
            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(120);
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(120);
            entity.Property(e => e.Telephone)
                .IsRequired()
                .HasMaxLength(120);
            entity.Property(e => e.Pesel)
                .IsRequired()
                .HasMaxLength(120);
            entity.ToTable("Client");
        });

        modelBuilder.Entity<Trip>(entity =>
        {
            entity.HasKey(e => e.IdTrip).HasName("Trip_pk");;
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(120);
            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(220);
            entity.Property(e => e.DateFrom).HasColumnType("datetime");
            entity.Property(e => e.DateTo).HasColumnType("datetime");
            entity.Property(e => e.MaxPeople).HasColumnType("int");
            entity.ToTable("Trip");
        });
        
        modelBuilder.Entity<CountryTrip>(entity =>
        {
            entity.HasKey(e => new { e.IdCountry, e.IdTrip }).HasName("Country_Trip_pk");
            entity.HasOne(e => e.IdCountryNavigation)
                .WithMany()
                .HasForeignKey(e => e.IdCountry)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Country_Trip_Country");
            entity.HasOne(e => e.IdTripNavigation)
                .WithMany()
                .HasForeignKey(e => e.IdTrip)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Country_Trip_Trip");
            entity.ToTable("Country_Trip");
        });

        modelBuilder.Entity<ClientTrip>(entity =>
        {
            entity.HasKey(e => new { e.IdClient, e.IdTrip }).HasName("Client_Trip_pk");
            entity.HasOne(e => e.IdClientNavigation)
                .WithMany()
                .HasForeignKey(e => e.IdClient)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Table_5_Country");
            entity.HasOne(e => e.IdTripNavigation)
                .WithMany()
                .HasForeignKey(e => e.IdTrip)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Table_5_Trip");
            entity.ToTable("Client_Trip");
        });
        OnModelCreatingPartial(modelBuilder);
    }
    
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    
}
