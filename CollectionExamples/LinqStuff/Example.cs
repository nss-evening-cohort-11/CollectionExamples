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
            var animals = new List<string> {"Dog", "Cat", "Elephant", "Goat"};

            Console.WriteLine(string.Join(",",animals));

            var realAnimals = animals.Select(animal => new Animal {Name = animal, Color = "Brown" });

            var jsonAnimals = JsonSerializer.Serialize(realAnimals, new JsonSerializerOptions {WriteIndented = true});

            Console.WriteLine(jsonAnimals);
        }
    }
}
