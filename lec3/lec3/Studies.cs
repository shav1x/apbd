namespace lec3;

public class Studies
{
    public string Name { get; set; }
    public string Description { get; set; }

    public double CalculateStudentsAverage(Student student)
    {
        double sum = 0;
        foreach (var grade in student.Grades)
            sum += grade;
        return sum / student.Grades.Count;
    }
}
