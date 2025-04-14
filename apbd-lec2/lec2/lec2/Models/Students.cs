namespace lec2.Models;

public class Students
{
    private string _fname; // use _ before private fields (to make it convenient)
    private string _lname;

    public double CalculateGPA()
    {
        return 0;
    }

    public string GetFName()
    {
        return _fname;
    }

    public void SetFName(string fname)
    {
        _fname = fname;
    }
    
}