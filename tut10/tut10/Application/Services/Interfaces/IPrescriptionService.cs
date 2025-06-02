using tut10.Application.DTOs;

namespace tut10.Application.Services.Interfaces;

public interface IPrescriptionService
{
    Task<bool> CreatePrescriptionAsync(PrescriptionDto prescriptionDto, int doctorId);
}