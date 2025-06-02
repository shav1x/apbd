using tut10.Application.DTOs;
using tut10.Application.Exceptions;
using tut10.Application.Repositories.Interfaces;
using tut10.Application.Services.Interfaces;

namespace tut10.Application.Services;

public class PrescriptionService(IPrescriptionRepository prescriptionRepository) : IPrescriptionService
{
    public async Task<bool> CreatePrescriptionAsync(PrescriptionDto prescriptionDto, int doctorId)
    {
        if (!await prescriptionRepository.PatientExistsAsync(prescriptionDto.IdPatient))
            throw new PatientDoesNotExistException(prescriptionDto.IdPatient);
        
        return await prescriptionRepository.CreatePrescriptionAsync(prescriptionDto, doctorId);
    }
    
}