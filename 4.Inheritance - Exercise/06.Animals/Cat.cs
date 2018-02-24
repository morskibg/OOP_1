using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Animals
{
    public class Cat : Animal
    {
        
        public Cat(string name, string age, string gendre) : base(name, age, gendre)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Meow meow");
        }
    }

    public class Kitten : Cat
    {
        private string _gendre;

        public override string Gendre
        {
            get { return _gendre; }
            set { _gendre = "fmale"; }
        }

        public Kitten(string name, string age, string gendre) : base(name, age, gendre)
        {
            
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Meow");
        }
    }

    public class Tomkat : Cat
    {
        public override string Gendre { get => Gendre; set => Gendre = "male"; }

        public Tomkat(string name, string age, string gendre) : base(name, age, gendre)
        {
        }
        public override void ProduceSound()
        {
            Console.WriteLine("MEOW");
        }
    }
}
