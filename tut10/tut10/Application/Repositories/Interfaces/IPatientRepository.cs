using tut10.Application.DTOs;

namespace tut10.Application.Repositories.Interfaces;

public interface IPatientRepository
{
    Task<bool> PatientExistsAsync(int patientId);
    Task<GetPatientDto> GetPatientAsync(int patientId);
}