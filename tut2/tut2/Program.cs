//Data types

using tut2;

{
    int num = 41;
    float num2 = 10.5f;
    double num3 = 10.5;
    string name = "John";
    char firstLetter = name.ElementAt(0);
    bool isMale = true;

    var s = "Text"; // <-- Becomes string
    var i = 10; // <-- Becomes int

    int? nullable = null; // <-- Nullable something
    nullable = 23;

    Object? obj = null; // <-- by "?" we can say whether it can be null or not
}

//String
{
    int num = 10;
    string text = "Text: " + num + "."; // <-- Bad practice (concatenation)
    string text2 = $"Text: {num}"; // <-- Better practice (the compiler likes it)

    string path = "/Users/oleksiishavyrov/Desktop/PJATK/APBD/tut2/tut2/somefile.txt";
    string path2 = @"C:\Users\oleksiishavyrov\Desktop\PJATK\APBD\tut2\tut2\somefile.txt"; // <-- Better to add "@" before any path
}

//Arrays and collections
{
    int[] arr = new int[9];
    int[] arr2 = {1, 5, 2, 1, 6, 3};
    
    var list = new List<int>(); // We put "var" when initializing collections
    list.Add(2);
    
    var dict = new Dictionary<string, int>(); // <-- <(key, var)>
    dict.Add("(some key)", 2);
    
    var set = new HashSet<int>();
    set.Add(5);
    set.Add(1);
    set.Add(5); // <-- this will not be added
}

//Loops
{
    var list = new List<int> {1, 2, 3, 4, 5, 6};
    
    for (int i = 0; i < list.Count; i++) // Option 1
        Console.WriteLine(list[i]);

    foreach (var item in list) // Option 2
    {
        Console.WriteLine(item);
    }
}

//Classes and inheritance
{
    A a = new A(1);
    A ab = new B(2, 2); // <-- Will use the overridden method (written in the class "B")
    B b = new B(3, 3);
    
    a.SendMessage("text");
    ab.SendMessage("text");
    b.SendMessage("text\n");

    Console.WriteLine(a.ToString());
}
