namespace lec3;

public class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public ICollection<double> Grades { get; set; }
    
    public double CalculateAverage()
    {
        double sum = 0;
        foreach (var grade in Grades)
            sum += grade;
        return sum / Grades.Count;
    }
}
