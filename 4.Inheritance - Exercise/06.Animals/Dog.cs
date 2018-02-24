using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Animals
{
    public class Dog : Animal
    {
        public Dog(string name, string age, string gendre) : base(name, age, gendre)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Woof!");
        }

       
    }
}
