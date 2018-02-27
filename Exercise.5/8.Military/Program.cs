using System;
using System.Collections.Generic;

public class test : ISoldier
{
    public string FirstName { get; }
    public string LastName { get; }
    public string Id { get; }
    public void ToString()
    {
        throw new NotImplementedException();
    }
}
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
    }
}

