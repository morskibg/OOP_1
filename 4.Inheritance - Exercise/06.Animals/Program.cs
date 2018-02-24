using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _06.Animals
{
    class Program
    {
        static void CreateAnimal(string animalData, string animalType, List<Animal> animals)
        {
            Animal currAnimal = null;
            string[] tokens = animalData.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim())
                .ToArray();
            if (animalType.ToLower() == "dog")
            {
                currAnimal = new Dog(tokens[0], tokens[1], tokens[2]);
            }
            else if (animalType.ToLower() == "cat")
            {
                currAnimal = new Cat(tokens[0], tokens[1], tokens[2]);
            }
            else if (animalType.ToLower() == "frog")
            {
                currAnimal = new Frog(tokens[0], tokens[1], tokens[2]);
            }
            if (currAnimal != null)
            {
                animals.Add(currAnimal);
            }
        }
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Beast!")
                {
                    break;
                }
                if (!input.Contains(" "))
                {
                    try
                    {
                        CreateAnimal(Console.ReadLine(), input, animals);
                    }
                    catch (ArgumentException ae)
                    {
                        Console.WriteLine(ae.Message);
                    }
                }
                
            }
            foreach (var animal in animals)
            {
                Console.WriteLine(animal.GetType().Name);
                Console.WriteLine($"{animal.Name} {animal.Age} {animal.Gendre}");
                animal.ProduceSound();
            }
        }
        
    }
}
