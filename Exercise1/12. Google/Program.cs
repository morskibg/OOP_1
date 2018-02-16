using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Google
{
    class Program
    {
        class Car
        {
            //public string Name { get; set; }
            public string CarModel { get; set; }
            public int CarSpeed { get; set; }

            public Car(string model, string speed)
            {
                //this.Name = name;
                this.CarModel = model;
                this.CarSpeed = int.Parse(speed);
            }
        }
        class Child
        {
            public string Name { get; set; }
            public string ChildBDay { get; set; }
            

            public Child(string name, string bday)
            {
                this.Name = name;
                this.ChildBDay = bday;
            }
        }
        class Parent
        {
            public string Name { get; set; }
            public string ParentBDay { get; set; }


            public Parent(string name, string bday)
            {
                this.Name = name;
                this.ParentBDay = bday;
            }
        }

        class Pokemon
        {
            public string PokName { get; set; }
            public string PokType { get; set; }

            public Pokemon(string name, string type)
            {
                this.PokName = name;
                this.PokType = type;
            }
        }

        class Company
        {
            //public string Name { get; set; }
            public string Department { get; set; }
            public decimal Salary { get; set; }
            public string CompName { get; set; }

            public Company(string name, string compName, string department, string salary)
            {
                //this.Name = name;
                this.CompName = compName;
                this.Department = department;
                this.Salary = decimal.Parse(salary);

            }
        }

        class Person
        {
            public string Name { get; set; }
            public List<Pokemon> PokData { get; set; }
            public List<Parent> ParentData { get; set; }
            public List<Child> ChildData { get; set; }
            public Company Company { get; set; }
            public Car Car { get; set; }

            public Person(string name)
            {
                this.Name = name;
                this.PokData = new List<Pokemon>();
                this.ParentData = new List<Parent>();
                this.ChildData = new List<Child>();
                this.Car = null;
                this.Company = null;
            }
        }
        static void Main(string[] args)
        {
            Dictionary<string, Person> data = new Dictionary<string, Person>();
            while (true)
            {
                string[] tok = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (tok[0] == "End")
                {
                    break;
                }
                if (!data.ContainsKey(tok[0]))
                {
                    data[tok[0]] = new Person(tok[0]);
                }
                if (tok[1] == "company")
                {
                    data[tok[0]].Company = new Company(tok[0], tok[2], tok[3], tok[4]);
                }
                else if (tok[1] == "pokemon")
                {
                    data[tok[0]].PokData.Add(new Pokemon(tok[0], tok[1]));
                }
                else if (tok[1] == "parents")
                {
                    data[tok[0]].ParentData.Add(new Parent(tok[0], tok[1]));
                }
                else if (tok[1] == "children")
                {
                    data[tok[0]].ChildData.Add(new Child(tok[0], tok[1]));
                }
                else if (tok[1] == "car")
                {
                    data[tok[0]].Car = new Car(tok[2], tok[3]);
                }
            }
            string nameToPrint = Console.ReadLine();
            foreach (var d in data[nameToPrint].PokData)
            {
                Console.WriteLine(d.PokType);
            }
        }
    }
}
