using Microsoft.EntityFrameworkCore;
using tut10.Application.DTOs;
using tut10.Application.Exceptions;
using tut10.Application.Repositories.Interfaces;
using tut10.Core.Database;

namespace tut10.Application.Repositories;

public class PatientRepository : IPatientRepository
{
    private readonly PharmacyDbContext _dbContext;
    
    public PatientRepository(PharmacyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> PatientExistsAsync(int patientId)
    {
        var patient = await _dbContext.Patients.FirstOrDefaultAsync(x => x.IdPatient == patientId);
        return patient is not null;
    }

    public async Task<GetPatientDto> GetPatientAsync(int patientId)
    {
        if (!await PatientExistsAsync(patientId))
            throw new PatientDoesNotExistException(patientId);

        var patient = await _dbContext.Patients
            .FirstOrDefaultAsync(p => p.IdPatient == patientId);

        if (patient == null)
            throw new PatientDoesNotExistException(patientId);

        var prescriptions = await _dbContext.Prescriptions
            .Where(p => p.IdPatient == patientId)
            .OrderBy(p => p.DueDate)
            .Select(p => new GetPrescriptionDto
            {
                IdPrescription = p.IdPrescription,
                Date = p.Date,
                DueDate = p.DueDate,
                Medicaments = _dbContext.PrescriptionMedicaments
                    .Where(pm => pm.IdPrescription == p.IdPrescription)
                    .Join(
                        _dbContext.Medicaments,
                        pm => pm.IdMedicament,
                        m => m.IdMedicament,
                        (pm, m) => new MedicamentDto
                        {
                            IdMedicament = m.IdMedicament,
                            Description = m.Description,
                            Dose = pm.Dose ?? 0
                        }
                    ).ToList(),
                Doctor = _dbContext.Doctors
                    .Where(d => d.IdDoctor == p.IdDoctor)
                    .Select(d => new DoctorDto
                    {
                        IdDoctor = d.IdDoctor,
                        FirstName = d.FirstName
                    }).FirstOrDefault()!
            }).ToListAsync();

        return new GetPatientDto
        {
            IdPatient = patient.IdPatient,
            FirstName = patient.FirstName,
            LastName = patient.LastName,
            Birthdate = patient.Birthdate,
            Prescriptions = prescriptions
        };
    }
}
