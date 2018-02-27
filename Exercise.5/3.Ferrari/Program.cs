using System;

public interface Car
{
    string Name { get; }
    string Model { get; }
    string DriverName { get; }
    string PushGazPedal();
    string PushBrakePedal();
    
}

public class Ferrari : Car
{
    public string Name { get; set; }
    public string Model { get; set; }
    public string DriverName { get; set; }
    

    public Ferrari(string driverName, string name = "Ferrari", string model = "488-Spider")
    {
        this.DriverName = driverName;
        this.Model = model;
        this.Name = name;
    }

    public string PushGazPedal()
    {
        return "Zadu6avam sA!";
      
    }
    public string PushBrakePedal()
    {
        return "Brakes!"; 
    }
}
class Program
{
    static void Main(string[] args)
    {
        
        string driverName = Console.ReadLine();
        Car Ferrari = new Ferrari(driverName);
        Console.WriteLine($"{Ferrari.Model}/{Ferrari.PushBrakePedal()}/{Ferrari.PushGazPedal()}/{Ferrari.DriverName}");
    }
}


