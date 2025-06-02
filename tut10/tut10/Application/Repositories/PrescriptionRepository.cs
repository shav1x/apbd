using Microsoft.EntityFrameworkCore;
using tut10.Application.DTOs;
using tut10.Application.Exceptions;
using tut10.Application.Repositories.Interfaces;
using tut10.Core.Data;
using tut10.Core.Database;

namespace tut10.Application.Repositories;

public class PrescriptionRepository : IPrescriptionRepository
{
    
    private readonly PharmacyDbContext _dbContext;
    
    public PrescriptionRepository(PharmacyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> PatientExistsAsync(int patientId)
    {
        var patient = await _dbContext.Patients.FirstOrDefaultAsync(x => x.IdPatient == patientId);
        return patient is not null;
    }

    public async Task<Patient> AddPatientAsync(PatientDto patientDto)
    {
        var newPatient = new Patient
        {
            FirstName = patientDto.FirstName,
            LastName = patientDto.LastName,
            Birthdate = patientDto.Birthdate
        };

        _dbContext.Patients.Add(newPatient);
        await _dbContext.SaveChangesAsync();

        return newPatient;
    }

    public async Task<bool> MedicationsExistAsync(int medicationId)
    {
        var medications = await _dbContext.Medicaments.FirstOrDefaultAsync(x => x.IdMedicament == medicationId);
        return medications is not null;
    }

    public async Task<bool> CreatePrescriptionAsync(PrescriptionDto prescriptionDto, int doctorId)
    {
        if (prescriptionDto.DueDate < prescriptionDto.Date)
        {
            throw new DateException();
        }
        
        if (prescriptionDto.Medicaments.Count > 10)
        {
            throw new TooMuchMedicationsException();
        }
        
        foreach (var medicament in prescriptionDto.Medicaments)
        {
            if (!await MedicationsExistAsync(medicament.IdMedicament))
            {
                throw new MedicationDoesNotExistException();
            }
        }
        
        Patient patient = await _dbContext.Patients
            .FirstOrDefaultAsync(p => p.IdPatient == prescriptionDto.IdPatient);

        if (patient is null)
        {
            patient = await AddPatientAsync(new PatientDto
            {
                FirstName = prescriptionDto.FirstName,
                LastName = prescriptionDto.LastName,
                Birthdate = prescriptionDto.Birthdate
            });
            _dbContext.Patients.Add(patient);
        }
        
        var newPrescription = new Prescription
        {
            Date = prescriptionDto.Date,
            DueDate = prescriptionDto.DueDate,
            IdPatient = patient.IdPatient,
            IdDoctor = doctorId
        };

        _dbContext.Prescriptions.Add(newPrescription);
        await _dbContext.SaveChangesAsync();
        
        foreach (var medicamentDto in prescriptionDto.Medicaments)
        {
            var prescriptionMedicament = new PrescriptionMedicament
            {
                IdPrescription = newPrescription.IdPrescription,
                IdMedicament = medicamentDto.IdMedicament,
                Dose = medicamentDto.Dose,
                Details = medicamentDto.Description
            };

            _dbContext.PrescriptionMedicaments.Add(prescriptionMedicament);
        }

        await _dbContext.SaveChangesAsync();
        return true;
    }
}
