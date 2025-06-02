namespace tut10.Application.Exceptions;

public class PatientDoesNotExistException(int patientId) : Exception($"Patient with id {patientId} does not exist");