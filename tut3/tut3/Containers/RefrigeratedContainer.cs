using tut3.Enums;

namespace tut3.Containers;

public class RefrigeratedContainer : Container
{
    public RefrigeratedContainer(double height, double depth, double tareWeight, double maxPayload, ProductType productType, double maintainedTemperature)
        : base(height, depth, tareWeight, maxPayload, 'C')
    {
        if (TemperatureValidator.IsValid(productType, maintainedTemperature))
        {
            ProductType = productType;
            MaintainedTemperature = maintainedTemperature;
        }
        else
        {
            throw new ArgumentException("Maintained temperature is not valid for the product type");
        }
    }
    
    public double MaintainedTemperature { get; }
    public ProductType ProductType { get; }
}