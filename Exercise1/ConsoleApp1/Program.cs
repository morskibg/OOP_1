using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



    class Program
    {
        static void Main(string[] args)
        {
        List<Person> persons = new List<Person>();
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] tokens = Console.ReadLine().Split().ToArray();
            persons.Add(new Person(tokens[0], int.Parse(tokens[1])));
        }
        foreach (var person in persons.Where(x => x.Age > 30).OrderBy(x => x.Name))
        {
            Console.WriteLine(person.ToString());
        }
        }
    }

