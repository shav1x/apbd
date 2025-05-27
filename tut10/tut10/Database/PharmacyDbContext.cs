using Microsoft.EntityFrameworkCore;
using tut10.Data;

namespace tut10.Database;

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
    }
}
