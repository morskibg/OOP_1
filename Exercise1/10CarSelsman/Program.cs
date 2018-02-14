using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10CarSelsman
{
    class Program
    {
        class Car
        {
            public string Model { get; set; }
            public Engine Engine { get; set; }
            public string Weight { get; set; }
            public string Color { get; set; }

            public Car(string model, Engine engine, string weight = "n/a", string color = "n/a")
            {
                this.Model = model;
                this.Engine = engine;
                this.Weight = weight;
                this.Color = color;
            }
        }

        class Engine
        {
            public string Model { get; set; }
            public string Power { get; set; }
            public string Displacement { get; set; }
            public string Efficiency { get; set; }

            public Engine(string model, string power, string displacement = "n/a", string efficiency = "n/a")
            {
                this.Model = model;
                this.Power = power;
                this.Displacement = displacement;
                this.Efficiency = efficiency;
            }
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                string[] s = Console.ReadLine().Split().ToArray();
                Engine currEngine = new Engine(s[0], s[1]);
                if (s.Length > 2)
                {
                    currEngine.Displacement = s[2];
                }
                if (s.Length == 4)
                {
                    currEngine.Efficiency = s[3];
                }
                engines.Add(currEngine);
            }
            int m = int.Parse(Console.ReadLine());
            for (int i = 0; i < m; i++)
            {
                string[] s = Console.ReadLine().Split().ToArray();
                Car currCar = new Car(s[0], engines.FirstOrDefault(x => x.Model == s[1]));
                if (s.Length > 2)
                {
                    currCar.Weight = s[2];
                }
                if (s.Length == 4)
                {
                    currCar.Color = s[3];
                }
                cars.Add(currCar);
            }
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model}:");
                Console.WriteLine($"  {car.Engine.Model}:");
                Console.WriteLine($"    Power: {car.Engine.Power}");
                Console.WriteLine($"    Displacement: {car.Engine.Displacement}");
                Console.WriteLine($"    Efficiency: {car.Engine.Efficiency}");
                Console.WriteLine($"  Weight: {car.Weight}");
                Console.WriteLine($"  Color: {car.Color}");
            }
            int t = 0;
        }
    }
}
