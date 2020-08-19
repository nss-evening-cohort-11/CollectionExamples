using System;
using System.Collections.Generic;
using CollectionExamples.LinqStuff;

namespace CollectionExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            var example = new Example();
            example.Run();

            //Lists are a general purpose collection that is pretty good at everything
            var instructors = new List<string>();
            var students = new List<string>();
            var evening11 = new List<string>();

            var numbers = new List<int>();

            //adding a single item
            instructors.Add("Jameka");
            instructors.Add("Nathan");
            instructors.Add("Dylan");


            foreach (var instructor in instructors)
            {
                //this will blow up with an invalid operation exception, collections can't be modified while being iterated
                instructors.Add("asdf");
            }

            //items need to be of the right type
            numbers.Add(1);
            numbers.Add(3);
            numbers.Add(5);

            students.Add("Aaron");
            students.Add("John");
            students.Add("John");
            students.Add("Monique");

            //add multiple at once from an existing list
            evening11.AddRange(instructors);
            evening11.AddRange(students);

            foreach (var person in evening11)
            {
                Console.WriteLine($"{person} is in evening cohort 11.");
            }

            //is the item in the list?
            var steveIsInE11 = evening11.Contains("Steve");

            //ternary inside interpolated strings have to be in parentheses
            Console.WriteLine($"Steve is {(steveIsInE11 ? "" : "not ")}in e11.");

            //just the first match
            var matchingPerson = evening11.Find(person => person.StartsWith("J"));

            Console.WriteLine($"{matchingPerson} starts with 'J'");

            //in a list, the index is the key
            Console.WriteLine($"{students[1]} is the student at the index of 1.");


            //dictionaries have 2 generic type parameters
            var words = new Dictionary<string, string>();

            //dictionary entries are made of key value pairs, and both must be supplied to add anything
            words.Add("pedantic", "Like a pedant");
            words.Add("congratulate", "to be excited for; celebrate");
            words.Add("scrupulous", "diligent,thorough, extremely attentive to details");

            //keys must be unique, this won't work
            //words.Add("congratulate", "not a real thing");

            //validate uniqueness so you don't get an exception
            if (words.ContainsKey("congratulate"))
            {
                words["congratulate"] = "adsfasdf";
            }
            else
            {
                words.Add("congratulate", "asdfasdf");
            }

            //same as above, just some different syntax
            if (!words.TryAdd("congratulate", "adsfasdf"))
            {
                words["congratulate"] = "adsfasdf";
            }

            Console.WriteLine($"The fake definition of Congratulations is {words["congratulate"]}");

            //foreach (var entry in words)
            //{
            //    string word;
            //    string definition;

            //    entry.Deconstruct(out word,out definition);

            //    Console.WriteLine($"The fake definition of {entry.Key} is {entry.Value}");
            //}

            //setting an existing key to a new value
            words["congratulate"] = "stuff";

            foreach (var (word, definition) in words)
            {
                Console.WriteLine($"The fake definition of {word} is {definition}");
            }

            var wordsWithMultipleDefinitions = new Dictionary<string, List<string>>
            {
                {
                    "Scrupulous", 
                    new List<string> {"Diligent", "Thorough", "Extremely attentive to detail"}
                }
            };

            foreach (var (word, definitions) in wordsWithMultipleDefinitions)
            {
                Console.WriteLine($"{word} is defined as :");
                definitions.Add("poop");
                foreach (var definition in definitions)
                {
                    Console.WriteLine($"    {definition}");
                }
            }

            var queue = new Queue<string>();

            queue.Enqueue("this is first");
            queue.Enqueue("Second");
            queue.Enqueue("third");

            var queueCount = queue.Count;

            for (var i = 0; i < queueCount; i++)
            {
                Console.WriteLine(queue.Dequeue());
            }
        }
    }
}
