using tut3.Containers;

namespace tut3;

public class Ship
{
    public Ship(string name, int speed, int maxContainerNum, int maxWeight, List<Container> containers)
    {
        Name = name;
        Speed = speed;
        MaxContainerNum = maxContainerNum;
        MaxWeight = maxWeight;
        Containers = containers;
    }

    public string Name { get; }
    public int Speed { get; set; }
    public int MaxContainerNum { get; }
    public int MaxWeight { get; }
    public List<Container> Containers { get; set; }
    
    public void AddContainer(Container container)
    {
        foreach (Container c in Containers)
        {
            if (container.SerialNumber == c.SerialNumber) throw new ArgumentException("Container already exists");
        }
        if (Containers.Count >= MaxContainerNum) throw new ArgumentException("Ship is full");
        Containers.Add(container);
    }

    public override string ToString()
    {
        return $"{Name} (speed={Speed}, maxContainerNum={MaxContainerNum}, maxWeight={MaxWeight})";
    }
}