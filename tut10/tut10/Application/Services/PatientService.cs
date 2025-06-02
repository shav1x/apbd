using tut10.Application.DTOs;
using tut10.Application.Repositories.Interfaces;
using tut10.Application.Services.Interfaces;

namespace tut10.Application.Services;

public class PatientService(IPatientRepository patientRepository) : IPatientService
{
    public async Task<GetPatientDto> GetPatientAsync(int patientId)
    {
        return await patientRepository.GetPatientAsync(patientId);
    }
}