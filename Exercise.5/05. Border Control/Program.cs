using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Creature
{
    public string Id { get; set; }

    public bool IsIdMatching(string lastThreeDigits)
    {
        return this.Id.Length >= 3 && this.Id.EndsWith(lastThreeDigits);
    }
}

public class Citizen : Creature
{
    public string Age { get; set; }
    public string Name { get; set; }
    

    public Citizen(string name, string age, string id)
    {
        this.Name = name;
        this.Age = age;
        base.Id = id;
    }
    public bool IsIdMatching(string lastThreeDigits)
    {
        return base.IsIdMatching(lastThreeDigits);
    }
}

public class Robot : Creature
{
    public string Model { get; set; }

    public Robot(string model, string id)
    {
        this.Model = model;
        base.Id = id;
    }
    public bool IsIdMatching(string lastThreeDigits)
    {
        return base.IsIdMatching(lastThreeDigits);
    }
}
class Program
{
    static void Main(string[] args)
    {
        List<Creature> slaves = new List<Creature>();
        while (true)
        {
            string line = Console.ReadLine();
            if (line == "End")
            {
                break;
            }
            string[] tokens = line.Split();
            if (tokens.Length == 2)
            {
                Robot currRobot = new Robot(tokens[0], tokens[1]);
                slaves.Add(currRobot);
            }
            else
            {
                Citizen currCitizen = new Citizen(tokens[0], tokens[1], tokens[2]);
                slaves.Add(currCitizen);
            }
        }
        string endNum = Console.ReadLine();
        foreach (var slave in slaves.Where(x => x.IsIdMatching(endNum)))
        {
            Console.WriteLine(slave.Id);
        }
    }
}

