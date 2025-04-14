using Animals.Api.Models;

namespace Animals.Api.Data;

public static class VisitsRepository
{
    public static readonly List<Visit> Visits =
    [
        new Visit
        {
            id = 1,
            date = new DateTime(2023, 10, 1),
            animalId = 1,
            description = "Routine health checkup",
            price = 150.00m
        },
        new Visit
        {
            id = 2,
            date = new DateTime(2023, 9, 15),
            animalId = 2,
            description = "Treatment for injured paw",
            price = 250.00m
        },
        new Visit
        {
            id = 3,
            date = new DateTime(2023, 11, 5),
            animalId = 3,
            description = "Vaccination update",
            price = 120.00m
        },
        new Visit
        {
            id = 4,
            date = new DateTime(2023, 8, 20),
            animalId = 4,
            description = "Diagnosed for unusual molting behavior",
            price = 100.00m
        },
        new Visit
        {
            id = 5,
            date = new DateTime(2023, 7, 30),
            animalId = 5,
            description = "Dental checkup for tooth decay",
            price = 300.00m
        },
        new Visit
        {
            id = 6,
            date = new DateTime(2023, 9, 10),
            animalId = 14,
            description = "Treatment for scale infection",
            price = 80.00m
        },
        new Visit
        {
            id = 7,
            date = new DateTime(2023, 10, 25),
            animalId = 12,
            description = "Preparation for upcoming breeding season",
            price = 200.00m
        },
        new Visit
        {
            id = 8,
            date = new DateTime(2023, 12, 15),
            animalId = 18,
            description = "Routine blood work and dietary review",
            price = 180.00m
        },
        new Visit
        {
            id = 9,
            date = new DateTime(2023, 6, 10),
            animalId = 6,
            description = "Emergency treatment for underwater injury",
            price = 500.00m
        },
        new Visit
        {
            id = 10,
            date = new DateTime(2023, 7, 5),
            animalId = 11,
            description = "Checkup for ear infection",
            price = 60.00m
        }
    ];
}
