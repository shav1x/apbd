using tut3.Containers;
using tut3.Enums;

namespace tut3;

public class Program
{
    public static void Main(string[] args)
    {
        List<Container> containers = new List<Container>();
        Container gas1 = new GasContainer(4, 8, 100, 1300, 4);
        gas1.LoadCargo(560);
        containers.Add(gas1);
        Container liq1 = new LiquidContainer(5, 10, 200, 2000, true);
        liq1.LoadCargo(1000);
        containers.Add(liq1);
        Container ref1 = new RefrigeratedContainer(6, 12, 350, 2500, ProductType.Fish, 2);
        ref1.LoadCargo(2000);
        containers.Add(ref1);

        List<Ship> ships = new List<Ship>();
        Ship ship1 = new Ship("Black Pearl", 20, 5, 1000, new List<Container>());
        ships.Add(ship1);

        while (true)
        {
            Console.Write("\nList of container ships: ");
            foreach (Ship s in ships)
            {
                Console.WriteLine(s + ",");
            }

            Console.WriteLine("\nList of containers: ");
            var counter = 0;
            foreach (Container c in containers)
            {
                counter++;
                Console.WriteLine($"{counter}) {c},");
            }

            Console.WriteLine("\nPossible actions: \n");

            Console.WriteLine("- (as) Add a ship");
            Console.WriteLine("- (ac) Add a container");

            string action = Console.ReadLine();
            switch (action)
            {
                case "as":

                    Console.Write("Enter ship name: ");
                    string shipName = Console.ReadLine();
                    Console.Write("Enter ship speed: ");
                    int speed = int.Parse(Console.ReadLine());
                    Console.Write("Enter ship max container num: ");
                    int maxContainerNum = int.Parse(Console.ReadLine());
                    Console.Write("Enter ship max weight: ");
                    int maxWeight = int.Parse(Console.ReadLine());
                    Ship ship = new Ship(shipName, speed, maxContainerNum, maxWeight, new List<Container>());
                    ships.Add(ship);
                    break;
                case "ac":

                    Console.Write("Enter container height: ");
                    double height = double.Parse(Console.ReadLine());
                    Console.Write("Enter container depth: ");
                    double depth = double.Parse(Console.ReadLine());
                    Console.Write("Enter container tare weight: ");
                    double tareWeight = double.Parse(Console.ReadLine());
                    Console.Write("Enter container max payload: ");
                    double maxPayload = double.Parse(Console.ReadLine());
                    Console.Write("Enter container type (L, G or C): ");
                    char type = char.Parse(Console.ReadLine());
                    if (type is not ('L' or 'G' or 'C'))
                        throw new ArgumentException("Invalid container type");
                    Container c;
                    switch (type)
                    {
                        case 'L':
                            Console.Write("Is the container hazardous ('yes' or 'no')?: ");
                            string isHazardousStr = Console.ReadLine();
                            var isHazardous = isHazardousStr switch
                            {
                                "yes" => true,
                                "no" => false,
                                _ => throw new ArgumentException("Invalid input")
                            };
                            c = new LiquidContainer(height, depth, tareWeight, maxPayload, isHazardous);
                            break;
                        case 'G':
                            Console.Write("Enter the pressure: ");
                            double pressure = double.Parse(Console.ReadLine());
                            c = new GasContainer(height, depth, tareWeight, maxPayload, pressure);
                            break;
                        case 'C':
                            Console.WriteLine("Enter the product type (Ba, Co, M, Fi, I, F, Ce, S, Bu, E): ");
                            string productTypeStr = Console.ReadLine();
                            ProductType pt;
                            switch (productTypeStr)
                            {
                                case "Ba": pt = ProductType.Bananas; break;
                                case "Co": pt = ProductType.Chocolate; break;
                                case "M": pt = ProductType.Meat; break;
                                case "Fi": pt = ProductType.Fish; break;
                                case "I": pt = ProductType.IceCream; break;
                                case "F": pt = ProductType.FrozenPizza; break;
                                case "Ce": pt = ProductType.Cheese; break;
                                case "S": pt = ProductType.Sausages; break;
                                case "Bu": pt = ProductType.Butter; break;
                                case "E": pt = ProductType.Eggs; break;
                                default: throw new ArgumentException("Invalid product type");
                            }

                            Console.Write("Enter the maintained temperature: ");
                            double maintainedTemperature = double.Parse(Console.ReadLine());
                            c = new RefrigeratedContainer(height, depth, tareWeight, maxPayload, pt,
                                maintainedTemperature);
                            break;
                        default: throw new ArgumentException("Invalid container type");
                    }

                    ;
                    containers.Add(c);
                    break;
            }
        }
    }
}
