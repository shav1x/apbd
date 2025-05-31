namespace tut10.Core.Data;

public class Patient
{
    public int IdPatient { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public DateTime Birthdate { get; set; }
}
