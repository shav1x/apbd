using lec4;

namespace lec4_unit_tests_xUnit;

public class StudentUnitTests
{
    
    [Fact]
    public void CalculateAverageGrade_WithPositiveGrades_ReturnsCorrectAverageGrade()
    {
        //AAA (arrange, act, assert)
        
        //Arrange
        var grades = new List<double>();
        grades.Add(4);
        grades.Add(4);
        grades.Add(4);
        var st = new Student("John", "Doe", grades);
        
        //Act
        var average = st.CalculateAverage();
        
        //Assert
        Assert.Equal(4, average);
    }
    
    [Fact]
    public void Test2()
    {
        
    }
    
}
