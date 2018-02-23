using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MordorCruelPlan
{
    class Program
    {
        static void Main(string[] args)
        {
            int happyPoints = 0;
            string[] tokens = Console.ReadLine().Split();
            foreach (var food in tokens)
            {
                Food currFood = Factory.GetInputFood(food);
                happyPoints += currFood.FoodValue;
            }
            Console.WriteLine(happyPoints);
            Console.WriteLine(MoodFactory.GetGandalfMood(happyPoints));
        }
    }
}
