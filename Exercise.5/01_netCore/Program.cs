using System;
using System.Reflection;


public interface IPerson
{
    string Name { get; }
    int Age { get; }
}

public interface IIdentifiable
{
    string Id { get; }
}

public interface IBirthable
{
    string Birthdate { get; }
}
public class Citizen : IPerson, IBirthable, IIdentifiable
{
    public string Name { get; private set; }
    public int Age { get; private set; }
    public string Id { get; private set; }
    public string Birthdate { get; private set; }

    public Citizen(string name, int age, string id, string birthdayte)
    {
        this.Name = name;
        this.Age = age;
        this.Id = id;
        this.Birthdate = birthdayte;
    }
}


class Program
{
    static void Main(string[] args)
    {
        Type identifiableInterface = typeof(Citizen).GetInterface("IIdentifiable");
        Type birthableInterface = typeof(Citizen).GetInterface("IBirthable");
        PropertyInfo[] properties = identifiableInterface.GetProperties();
        Console.WriteLine(properties.Length);
        Console.WriteLine(properties[0].PropertyType.Name);
        properties = birthableInterface.GetProperties();
        Console.WriteLine(properties.Length);
        Console.WriteLine(properties[0].PropertyType.Name);
        string name = Console.ReadLine();
        int age = int.Parse(Console.ReadLine());
        string id = Console.ReadLine();
        string birthdate = Console.ReadLine();
        IIdentifiable identifiable = new Citizen(name, age, id, birthdate);
        IBirthable birthable = new Citizen(name, age, id, birthdate);


    }
}

