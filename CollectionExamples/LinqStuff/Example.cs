using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.Json;

namespace CollectionExamples.LinqStuff
{
    class Example
    {
        public void Run()
        {
            var animals = new List<string> { "Dog", "Cat", "Elephant", "Goat" };

            Console.WriteLine(string.Join(",", animals));

            //selects are like map, they are for transformation
            var realAnimals = animals.Select(animal => new Animal { Name = animal, Color = "Brown" });

            var jsonAnimals = JsonSerializer.Serialize(realAnimals, new JsonSerializerOptions { WriteIndented = true });

            Console.WriteLine(jsonAnimals);

            //where is like filter
            var filteredAnimals = realAnimals.Where(animal => animal.Name.Contains('a'));

            //because most linq method returns a collection, they are able to be chained
            var chainedResults = animals
                .Select(animal => new Animal { Name = animal, Color = "Brown" })
                .Where(animal => animal.Name.Contains('a'));


            var anyAnimalsWithAZ = animals.Any(animal => animal.Contains('z'));

            //return the first item that matches.  if no matches, you'll get an exception
            var firstAnimalWithA = realAnimals.First(animal => animal.Name.Contains('a'));

            //returns the first item that matches, or the default value of the collection type if no match
            var firstAnimalWithAZ = realAnimals.FirstOrDefault(animal => animal.Name.Contains('z'));

            var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 3, 6, 4, 5, 11, 67 };

            var biggestNumber = numbers.Max();

            var lengthOfTheLongestName = realAnimals.Max(animal => animal.Name.Length);

            var uniqueNumbers = numbers.Distinct().ToList();

            var orderedNumbers = numbers.OrderBy(number => number).ToList();

            var orderedAnimals = realAnimals.OrderBy(animal => animal.Name).ToList();

            var animalsToGroup = new List<Animal>
            {
                new Animal {Name = "steve", Color = "blue", Type = "bird"},
                new Animal {Name = "john", Color = "yellow", Type = "bird"},
                new Animal {Name = "sally", Color = "red", Type = "bird"},
                new Animal {Name = "jim", Color = "brown", Type = "monkey"},
                new Animal {Name = "nancy", Color = "white", Type = "monkey"},
                new Animal {Name = "brett", Color = "brown", Type = "kangaroo"}
            };


            var groupedAnimals = animalsToGroup.GroupBy(animal => animal.Type);

            foreach (var group in groupedAnimals)
            {
                Console.WriteLine($"Animal type is {group.Key}");

                foreach (var animal in group)
                {
                    Console.WriteLine($"{animal.Name} is {animal.Color}.");
                }

            }


        }
    }
}
