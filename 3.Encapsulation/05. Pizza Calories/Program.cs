using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Pizza_Calories
{
    public class Dough
    {


        private string flourType;
        private string bakingTechique;
        private int weight;
        private double calories;

        public string FlourType
        {
            get { return this.flourType; }
            set
            {
                string temp = value.ToLower();
                if (temp != "white" && temp != "wholegrain")
                {
                    Console.WriteLine("Invalid type of dough.");
                    Environment.Exit(1);
                }
                this.flourType = value;
            }
        }
        public string BakingTechnique
        {
            get { return this.bakingTechique; }
            set
            {
                string temp = value.ToLower();
                if (temp != "crispy" && temp != "chewy" && temp != "homemade")
                {
                    Console.WriteLine("Invalid type of dough.");
                    Environment.Exit(1);
                }
                this.bakingTechique = value;
            }
        }

        public int Weight
        {
            get { return this.weight; }
            set
            {
                if (value < 0 || value > 200)
                {
                    Console.WriteLine("Dough weight should be in the range[1..200].");
                    Environment.Exit(1);
                }
                this.weight = value;
            }
        }

        public Dough(string flourType, string bakingTechique, int weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechique;
            this.Weight = weight;
        }

        public double PrintCalories()
        {
            double calories = 2 * this.weight * GetModifiers(this.flourType) * GetModifiers(this.bakingTechique);
            return calories;
        }

        private double GetModifiers(string mod)
        {
            switch (mod.ToLower())
            {
                case "white":
                    return 1.5;
                case "wholegrain":
                    return 1.0;
                case "chewy":
                    return 1.1;
                case "crispy":
                    return 0.9;
                case "homemade":
                    return 1.0;
            }
            return -1;
        }
    }

    public class Topping
    {
        private string type;
        private int weight;

        public string Type
        {
            get { return this.type; }
            set
            {
                string temp = value.ToLower();
                if (temp != "meat" && temp != "veggies" && temp != "cheese" && temp != "sauce")
                {
                    Console.WriteLine($"Cannot place {value} on top of your pizza.");
                    Environment.Exit(1);
                }
                this.type = value;
            }
        }

        public int Weight
        {
            get { return this.weight; }
            set
            {
                if (value < 1 || value > 50)
                {
                    Console.WriteLine($"{this.type} weight should be in the range [1..50].");
                    Environment.Exit(1);
                }
                this.weight = value;
            }
        }

        public Topping(string type, int weight)
        {
            this.Type = type;
            this.Weight = weight;
        }
        private double GetModifiers(string mod)
        {
            switch (mod.ToLower())
            {
                case "meat":
                    return 1.2;
                case "veggies":
                    return 0.8;
                case "cheese":
                    return 1.1;
                case "sauce":
                    return 0.9;
            }
            return -1;
        }
        public double PrintCalories()
        {
            double calories = 2 * this.weight * GetModifiers(this.type);
            return calories;
        }
    }

    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> topings;

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 15)
                {
                    Console.WriteLine("Pizza name should be between 1 and 15 symbols.");
                    Environment.Exit(1);
                }
                this.name = value;
            }
        }

        public Pizza(string name)
        {
            this.Name = name;
            this.dough = null;
            this.topings = new List<Topping>();
        }

        public void AddDough(string input)
        {
            string[] tokens = input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim())
                .ToArray();
            Dough newDough = new Dough(tokens[1], tokens[2], int.Parse(tokens[3]));
            this.dough = newDough;
        }

        public void AddTopping(string input)
        {
            if (this.topings.Count > 10)
            {
                Console.WriteLine($"Number of toppings should be in range [0..10].");
                Environment.Exit(1);
            }
            string[] tokens = input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim())
                .ToArray();
            Topping newTopping = new Topping(tokens[1], int.Parse(tokens[2]));
            this.topings.Add(newTopping);
        }

        public double GetCalc()
        {
            double toppingCalories = 0;
            foreach (var topping in topings)
            {
                toppingCalories += topping.PrintCalories();
            }
            double doughtCalories = this.dough.PrintCalories();
            return toppingCalories + doughtCalories;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Pizza newPizza = new Pizza(Console.ReadLine().Split().Last());

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "END")
                {
                    break;
                }
                if (char.ToLower(line[0]) == 'd')
                {
                    newPizza.AddDough(line);
                }
                else
                {
                    newPizza.AddTopping(line);
                }

            }
            Console.WriteLine($"{newPizza.Name} - {newPizza.GetCalc():f2} Calories. ");
        }
    }
}
