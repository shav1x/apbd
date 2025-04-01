namespace tut2;

public class B : A { // <-- B extends A

    public int MyProperty { get; set; }

    public B (int number, int myProperty) : base(number) {
        MyProperty = myProperty;
    }
    
    public override void SendMessage(string message) // Method, which overrides the method from the parent class
    {
        Console.WriteLine("B: " + message);
    }
    
}
