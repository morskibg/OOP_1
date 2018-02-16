using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;

namespace P01_RawData
{
   
    class Car
    {
        public string model;

        public CarEngine engineObj { get; private set; }

        public CarCargo cargoObj { get; private set; }

        public CarTyres tyresObj { get; private set; }

        public Car(string model, string engine, string cargo, string tyres)

        {
            this.model = model;
            this.engineObj = new CarEngine(engine);
            this.cargoObj = new CarCargo(cargo);
            this.tyresObj = new CarTyres(tyres);
        }

        internal class CarEngine
        {
            public int EngineSpeed { get; private set; }
            public int EnginePower { get; private set; }

            public CarEngine(string carEngine)
            {
                string[] tokens = carEngine.Split().ToArray();
                EngineSpeed = int.Parse(tokens[0]);
                EnginePower = int.Parse(tokens[1]);
            }
        }
        internal class CarCargo
        {
            public int CargoWeight { get; set; }
            public string CargoType { get; set; }

            public CarCargo(string cargo)
            {
                string[] tokens = cargo.Split().ToArray();
                CargoWeight = int.Parse(tokens[0]);
                CargoType = tokens[1];
            }
        }
        internal class CarTyres
        {
            public KeyValuePair<double, int>[] tires;

            public CarTyres(string tyresString)
            {
                string[] tokens = tyresString.Split().ToArray(); 
                this.tires = new KeyValuePair<double, int>[] 
                    { KeyValuePair.Create(double.Parse(tokens[0]), int.Parse(tokens[1])),
                      KeyValuePair.Create(double.Parse(tokens[2]), int.Parse(tokens[3])),
                      KeyValuePair.Create(double.Parse(tokens[4]), int.Parse(tokens[5])),
                      KeyValuePair.Create(double.Parse(tokens[5]), int.Parse(tokens[7])) };
            }
        }
    }
    class RawData
    {
        static void Main(string[] args)
        {
            string pattern = @"(?<model>[A-Za-z\d]+)\s*(?<engine>\d+\s*\d+)\s*(?<cargo>\d+\s*[A-Za-z]+)\s(?<tires>.+)";
            List<Car> cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                MatchCollection matches = Regex.Matches(Console.ReadLine(), pattern);
                
                foreach (Match mc in matches)
                {
                    Car currCar = new Car(mc.Groups["model"].Value, 
                        mc.Groups["engine"].Value, 
                        mc.Groups["cargo"].Value, 
                        mc.Groups["tires"].Value);
                    
                    cars.Add(currCar);
                }
            }
            int t = 0;
            string command = Console.ReadLine();
            if (command == "fragile")
            {
                List<string> fragile = cars
                    .Where(x => x.cargoObj.CargoType == "fragile" && x.tyresObj.tires.Any(y => y.Key < 1))
                    .Select(x => x.model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, fragile));
            }
            else
            {
                List<string> flamable = cars
                    .Where(x => x.cargoObj.CargoType == "flamable" && x.engineObj.EnginePower > 250)
                    .Select(x => x.model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, flamable));
            }
        }
    }
}
