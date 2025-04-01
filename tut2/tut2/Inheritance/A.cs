namespace tut2;

public class A : IMyInterface {
    //Property
    public int Number { get; set; } // <-- Automatically generates getter and setter of the int variable

    public A(int number) {
        Number = number;
    }

    public virtual void SendMessage(string message) // Virtual method
    {
        //throw new NotImplementedException(); // <-- If we don't want to implement some methods
        
        Console.WriteLine("A: " + message);
        
    }

    public override string ToString() { // <-- Overridden method ToString()
        return @"A: " + Number;
    }
}