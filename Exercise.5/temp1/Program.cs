using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

public interface IBirthDayPrintable
{
    string Name { get; set; }
    string Birthday { get; set; }
    bool GetBirthday(string date);
}
public abstract class Creature : IBirthDayPrintable
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Birthday { get; set; }

    public bool IsIdMatching(string lastThreeDigits)
    {
        return this.Id.Length >= 3 && this.Id.EndsWith(lastThreeDigits);
    }
    public bool GetBirthday(string date)
    {
        string inputYear = date.Substring(date.LastIndexOf("/") + 1);
        string currYear = Birthday.Substring(Birthday.LastIndexOf("/") + 1);
        if (inputYear == currYear)
        {
            return true;
        }
        return false;
    }
}



public class Citizen : Creature
{
    public string Age { get; set; }
    public string Name { get; set; }
    public string Birthday { get; set; }
    

    public Citizen(string name, string age, string id, string bDay)
    {
        this.Age = age;
        base.Id = id;
        this.Name = name;
        this.Birthday = bDay;
        base.Birthday = bDay;
    }
    public bool IsIdMatching(string lastThreeDigits)
    {
        return base.IsIdMatching(lastThreeDigits);
    }

    public bool GetBirthday(string date)
    {
        
        return base.GetBirthday(this.Birthday);
    }
}

public class Pet : Creature
{
    public string Name { get; set; }
    public string Birthday { get; set; }

    public Pet(string name, string bDay)
    {
        this.Name = name;
        this.Birthday = bDay;
        base.Birthday = bDay;
    }

    public bool GetBirthday(string date)
    {
        
        return base.GetBirthday(this.Birthday);
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
            if (tokens[0] == "Citizen")
            {
                slaves.Add(new Citizen(tokens[1], tokens[2], tokens[3], tokens[4]));
            }
            else if (tokens[0] == "Pet")
            {
                slaves.Add(new Pet(tokens[1], tokens[2]));
            }
        }
        string birtdayToPrint = Console.ReadLine();
        
        foreach (var slave in slaves.Where(x => x.GetBirthday(birtdayToPrint)))
        {
            Console.WriteLine(slave.Birthday);
        }
    }
}

