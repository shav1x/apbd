using Animals.Api.Models;

namespace Animals.Api.Data;

public static class AnimalsRepository
{
    public static readonly List<Animal> Animals =
    [
        new Animal { id = 1, name = "Elephant", category = "Mammal", weight = 5400.0m, furcolor = "Gray" },
        new Animal { id = 2, name = "Tiger", category = "Mammal", weight = 220.5m, furcolor = "Orange" },
        new Animal { id = 3, name = "Kangaroo", category = "Mammal", weight = 85.0m, furcolor = "Brown" },
        new Animal { id = 4, name = "Parrot", category = "Bird", weight = 1.0m, furcolor = "Green" },
        new Animal { id = 5, name = "Shark", category = "Fish", weight = 800.0m, furcolor = "Gray" },
        new Animal { id = 6, name = "Dolphin", category = "Mammal", weight = 635.0m, furcolor = "Gray" },
        new Animal { id = 7, name = "Polar Bear", category = "Mammal", weight = 450.0m, furcolor = "White" },
        new Animal { id = 8, name = "Penguin", category = "Bird", weight = 30.0m, furcolor = "Black and White" },
        new Animal { id = 9, name = "Crocodile", category = "Reptile", weight = 500.0m, furcolor = "Green" },
        new Animal { id = 10, name = "Frog", category = "Amphibian", weight = 0.5m, furcolor = "Green" },
        new Animal { id = 11, name = "Rabbit", category = "Mammal", weight = 2.5m, furcolor = "White" },
        new Animal { id = 12, name = "Horse", category = "Mammal", weight = 500.0m, furcolor = "Brown" },
        new Animal { id = 13, name = "Cow", category = "Mammal", weight = 700.0m, furcolor = "Black and White" },
        new Animal { id = 14, name = "Snake", category = "Reptile", weight = 8.0m, furcolor = "Brown" },
        new Animal { id = 15, name = "Eagle", category = "Bird", weight = 6.0m, furcolor = "Brown" },
        new Animal { id = 16, name = "Zebra", category = "Mammal", weight = 400.0m, furcolor = "Black and White" },
        new Animal { id = 17, name = "Chimpanzee", category = "Mammal", weight = 50.0m, furcolor = "Black" },
        new Animal { id = 18, name = "Giraffe", category = "Mammal", weight = 1200.0m, furcolor = "Yellow and Brown" },
        new Animal { id = 19, name = "Octopus", category = "Mollusk", weight = 15.0m, furcolor = "Pink" },
        new Animal { id = 20, name = "Lion", category = "Mammal", weight = 190.0m, furcolor = "Golden" }
    ];
}
