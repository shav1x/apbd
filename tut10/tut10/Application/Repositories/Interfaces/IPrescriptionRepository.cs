using tut10.Application.DTOs;
using tut10.Core.Data;

namespace tut10.Application.Repositories.Interfaces;

public interface IPrescriptionRepository
{
        Task<bool> PatientExistsAsync(int patientId);
        Task<Patient> AddPatientAsync(PatientDto patientDto);
        Task<bool> MedicationsExistAsync(int medicationId);
        Task<bool> CreatePrescriptionAsync(PrescriptionDto prescriptionDto, int doctorId);
}
