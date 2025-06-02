using tut10.Application.DTOs;

namespace tut10.Application.Services.Interfaces;

public interface IPatientService
{
    Task<GetPatientDto> GetPatientAsync(int patientId);
}