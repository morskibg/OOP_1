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
        private string gendre;

        public override string Gendre
        {
            get { return gendre; }
            set { gendre = value; }
        }

        public Kitten(string name, string age, string gendre) : base(name, age, "Female")
        {
            
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Meow");
        }
    }

    public class Tomcat : Cat
    {
        private string gendre;
        public override string Gendre
        {
            get { return gendre; }
            set { gendre = value; }
        }

        public Tomcat(string name, string age, string gendre) : base(name, age, "Male")
        {

        }
        public override void ProduceSound()
        {
            Console.WriteLine("MEOW");
        }
    }
}
