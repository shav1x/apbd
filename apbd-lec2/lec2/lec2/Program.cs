using lec2.Models;

public class CanBeAnyName {
    
    
    
    public static void Main(string[] args)
    {
        int age = 10;
        double d = 121.2;
        bool isRaining = true;
        
        string sentence = "John Smith";

        int[] numbers = new int[10];
        numbers[3] = 12;
        
        //Classes

        Students s = new Students();
        s.SetFName("Alex"); // fname = "Alex"
        double gpa = s.CalculateGPA();
        
        
        Students2 s2 = new Students2();
        s2.LName = "John"; // The same (fname = "John")
        
        //Dictionary

        Dictionary<string, int> dict = new Dictionary<string, int>
        {
            ["Alice"] = 10, // [key] = val
            ["Bob"] = 20
        }; // Dictionary (the same as HashSet in java)
        
        
        //Boxing/unboxing
        int? name = null;
        Nullable<int> name2 = null; // The same as "int?"
        
        
        
    }
    
}


public class EmptyClass {
    //Nothing in here
}