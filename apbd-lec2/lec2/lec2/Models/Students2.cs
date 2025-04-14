using System.Reflection.Metadata;

namespace lec2.Models;

public class Students2 : IEmployee
{
    //property
    //prop+tabx2
    //auto-property -> full property

    private string _lname;

    public string LName // <-- it is a property (full)
    {
        get
        {
            return _lname;
        }
        set
        {
            if (value == null)
            {
                throw new ArgumentNullException();
            }
            _lname = value;
        }
    }

    public string FullName // <-- it is a property (full)
    {
        get
        {
            return LName + " " + LName;
        }
    }

    public void DisplayInfo()
    {
        Console.WriteLine("DisplayInfo");
    }
}

public interface IEmployee // All interfaces should start with I (convention)
{
    void DisplayInfo();
}
