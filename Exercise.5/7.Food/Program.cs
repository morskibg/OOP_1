using System;
using System.Collections.Generic;
using System.Linq;

public interface IName
{
    string Name { get; set; }
}

public interface IAge
{
    string Age { get; set; }
}

public interface IId
{
     string Id { get; set; }
}

public interface IBday
{
    string Bday { get; set; }
}

public interface IBuyer
{
    int Food { get; set; }
    int BuyFood();
}

public class Citizen : IName, IAge, IBday, IId, IBuyer
{
    public string Name { get; set; }
    public string Age { get; set; }
    public string Bday { get; set; }
    public string Id { get; set; }
    public int Food { get; set; }

    public Citizen(string name, string age, string id,string bday, int food = 0)
    {
        Name = name;
        Age = age;
        Bday = bday;
        Id = id;
        Food = food;
    }

    public int BuyFood()
    {
        return  10;
    }
}

public class Rebel : IName, IAge, IBuyer
{
    public string Name { get; set; }
    public string Age { get; set; }
    public int Food { get; set; }
    public  string Group { get; set; }

    public Rebel(string name, string age, string group, int food = 0)
    {
        Name = name;
        Age = age;
        Food = food;
        Group = group;
    }

    public int BuyFood()
    {
        return  5;
    }
}
class Program
{
    static void Main(string[] args)
    {
        HashSet<Rebel> rebels = new HashSet<Rebel>();
        HashSet<Citizen> citizens = new HashSet<Citizen>();
        
        int n = int.Parse(Console.ReadLine());
        int purchasedFood = 0;
        for (int i = 0; i < n; i++)
        {
            string[] tokens = Console.ReadLine().Split();
            if (tokens.Length == 3)
            {
                Rebel rebel = new Rebel(tokens[0], tokens[1], tokens[2]);
                rebels.Add(rebel);
            }
            else
            {
                Citizen citizen = new Citizen(tokens[0], tokens[1], tokens[2], tokens[3]);
                citizens.Add(citizen);
            }
        }
        while (true)
        {
            string line = Console.ReadLine();
            if (line == "End")
            {
                break;
            }
            if (rebels.Any(x => x.Name == line))
            {
                purchasedFood += rebels.FirstOrDefault(x => x.Name == line).BuyFood();
            }
            else if (citizens.Any(x => x.Name == line))
            {
                purchasedFood += citizens.FirstOrDefault(x => x.Name == line).BuyFood();
            }
        }
        Console.WriteLine(purchasedFood);
    }
}

