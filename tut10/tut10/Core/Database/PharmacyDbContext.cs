using Microsoft.EntityFrameworkCore;
using tut10.Core.Data;

namespace tut10.Core.Database;

public class PharmacyDbContext : DbContext
{
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
    
    public PharmacyDbContext(DbContextOptions<PharmacyDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Doctor>()
            .HasKey(x => x.IdDoctor);
        
        modelBuilder.Entity<Medicament>()
            .HasKey(x => x.IdMedicament);
        
        modelBuilder.Entity<Patient>()
            .HasKey(x => x.IdPatient);
        
        modelBuilder.Entity<Prescription>()
            .HasKey(x => x.IdPrescription);
        
        modelBuilder.Entity<Prescription>()
            .HasOne<Patient>()
            .WithMany()
            .HasForeignKey(x => x.IdPatient)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<Prescription>()
            .HasOne<Doctor>()
            .WithMany()
            .HasForeignKey(x => x.IdDoctor)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<PrescriptionMedicament>()
            .HasKey(x => new {x.IdMedicament, x.IdPrescription});
        
        modelBuilder.Entity<PrescriptionMedicament>()
            .HasOne<Medicament>()
            .WithMany()
            .HasForeignKey(x => x.IdMedicament)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<PrescriptionMedicament>()
            .HasOne<Prescription>()
            .WithMany()
            .HasForeignKey(x => x.IdPrescription)
            .OnDelete(DeleteBehavior.Cascade);
        
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Patient>().HasData(
            new Patient { IdPatient = 1, FirstName = "John", LastName = "Doe", Birthdate = new DateTime(1990, 5, 12) },
            new Patient { IdPatient = 2, FirstName = "Alice", LastName = "Smith", Birthdate = new DateTime(1985, 3, 28) }
        );
        
        modelBuilder.Entity<Doctor>().HasData(
            new Doctor { IdDoctor = 1, FirstName = "Gregory", LastName = "House", Email = "house@example.com" },
            new Doctor { IdDoctor = 2, FirstName = "Meredith", LastName = "Grey", Email = "grey@example.com" }
        );
        
        modelBuilder.Entity<Medicament>().HasData(
            new Medicament { IdMedicament = 1, Name = "Ibuprofen", Description = "Pain reliever", Type = "Tablet" },
            new Medicament { IdMedicament = 2, Name = "Amoxicillin", Description = "Antibiotic", Type = "Capsule" }
        );
        
        modelBuilder.Entity<Prescription>().HasData(
            new Prescription { IdPrescription = 1, Date = DateTime.Now, DueDate = DateTime.Now.AddDays(7), IdPatient = 1, IdDoctor = 1 },
            new Prescription { IdPrescription = 2, Date = DateTime.Now, DueDate = DateTime.Now.AddDays(10), IdPatient = 2, IdDoctor = 2 }
        );
        
        modelBuilder.Entity<PrescriptionMedicament>().HasData(
            new PrescriptionMedicament { IdPrescription = 1, IdMedicament = 1, Dose = 2, Details = "Take twice daily" },
            new PrescriptionMedicament { IdPrescription = 2, IdMedicament = 2, Dose = 1, Details = "Take once daily" }
        );
    }
}
