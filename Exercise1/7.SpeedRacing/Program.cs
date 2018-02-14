using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace oop1_7
{
    class Program
    {
        //“<Model> <FuelAmount> <FuelConsumptionFor1km>”
        class Car
        {
            public string Model { get; set; }
            public double fuelInTank { get; set; }
            public double perKm { get; set; }
            public int kmTraveled { get; set; }
            public Car(string model, double fuelInTank, double perKm)
            {
                this.Model = model;
                this.fuelInTank = fuelInTank;
                this.perKm = perKm;
                this.kmTraveled = 0;
            }
            public bool CheckFuelInTank(int km)
            {
                if (km * this.perKm > this.fuelInTank)
                {
                    return false;
                }
                this.kmTraveled += km;
                this.fuelInTank -= km * this.perKm;
                return true;
            }
        }
        static void Main(string[] args)
        {
            Dictionary<string, Car> data = new Dictionary<string, Car>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split().ToArray();
                string model = tokens[0];
                double fuelInTank = double.Parse(tokens[1]);
                double perKm = double.Parse(tokens[2]);
                Car currCar = new Car(model, fuelInTank, perKm);
                if (!data.ContainsKey(model))
                {
                    data[model] = currCar;
                }
                
            }
            while (true)
            {
                string line = Console.ReadLine();
                if (line == "End")
                {
                    break;
                }
                string[] t2 = line.Split().ToArray();
                if (!data.ContainsKey(t2[1]))
                {
                    continue;
                }
                if (!data[t2[1]].CheckFuelInTank(int.Parse(t2[2])))
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }

            }
            foreach (var car in data)
            {
                Console.WriteLine($"{car.Value.Model} {car.Value.fuelInTank.ToString("f2")} {car.Value.kmTraveled}");
            }

        }
    }
}
