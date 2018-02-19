using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Program
{

    static void Main(string[] args)
    {
        var lines = int.Parse(Console.ReadLine());
        var persons = new List<Person>();
        for (int i = 0; i < lines; i++)
        {
            var cmdArgs = Console.ReadLine().Split();
            var person = new Person(cmdArgs[0], cmdArgs[1], int.Parse(cmdArgs[2]));
            persons.Add(person);
        }

        Team t = new Team("soft");
        foreach (var person in persons)
        {
            t.AddPlayer(person);
        }
        Console.WriteLine(t.ToString());
    }
}

