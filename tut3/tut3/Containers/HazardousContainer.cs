using tut3.Exceptions;
using tut3.Interfaces;

namespace tut3.Containers;

public abstract class HazardousContainer : Container, IHazardNotifier
{
    protected HazardousContainer(double height, double depth, double tareWeight, double maxPayload, char containerType)
        : base(height, depth, tareWeight, maxPayload, containerType)
    {
        
    }

    public override void LoadCargo(double mass)
    {
        if (mass <= 0) throw new ArgumentException();

        if (!CanLoadCargo(mass))
        {
            NotifyHazard("Loading the cargo will cause overfill");
            throw new OverfillException("Cargo mass exceeds max payload");
        }
        
        CargoMass += mass;
    }
    
    public void NotifyHazard(string message)
    {
        Console.WriteLine($"Hazardous situation occured for a container {SerialNumber}" +
                          $"\nMessage: {message}");
    }
    
}
