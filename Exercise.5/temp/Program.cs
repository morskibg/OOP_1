using System;
using System.Collections.Generic;
using System.Linq;

public interface ICalling
{
    string Number { get; }
    void Calling(string number);
}

public interface IBrousing
{
    string URL { get; }
    void Browsing(string url);
}

public class CellPhone : ICalling, IBrousing
{
    //private readonly List<string> phoneNumbers;
    //private readonly List<string> webSites;
    private string _number;
    private string _url;

    public string Number
    {
        get { return _number; }
        set
        {

            this._number = value;
            //this.phoneNumbers.Add(value);
        }
    }
    public string URL
    {
        get { return _url; }
        set
        {

            this._url = value;
            //this.webSites.Add(value);
        }
    }

    public CellPhone()
    {
        //this.phoneNumbers = new List<string>();
        //this.webSites = new List<string>();
    }
    public void Calling(string number)
    {
        Console.WriteLine($"Calling... {number}");
    }

    public void Browsing(string url)
    {
        Console.WriteLine($"Browsing: {url}!");
    }

    private bool ValidatePhoneNumber(string inputNumber)
    {
        if (inputNumber.ToCharArray().Any(x => !char.IsDigit(x)))
        {
            return false;
        }
        this.Number = inputNumber;
        return true;
    }
    public bool AddPhone(string phone)
    {
        return this.ValidatePhoneNumber(phone);
    }

    private bool ValidateUrl(string inputUrl)
    {
        if (inputUrl.ToCharArray().Any(char.IsDigit))
        {
            return false;
        }
        this.URL = inputUrl;
        return true;
    }
    public bool AddWebSite(string url)
    {
        return this.ValidateUrl(url);
    }
}
class Program
{
    static void Main(string[] args)
    {
        CellPhone phone = new CellPhone();
        string[] numbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();
        foreach (var number in numbers)
        {
            if (phone.AddPhone(number))
            {
                phone.Calling(number);
            }
            else
            {
                Console.WriteLine("Invalid number!");
            }
        }
        string[] web = Console.ReadLine().Split();
        foreach (var site in web)
        {
            if (phone.AddWebSite(site))
            {
                phone.Browsing(site);
            }
            else
            {
                Console.WriteLine("Invalid URL!");
            }
        }
    }
}


//using System;

//public interface ISmartphone : IPhone
//{
//    string Browse(string url);
//}

//public interface IPhone
//{
//    string Model { get; }

//    string Call(string phoneNumber);
//}

//public class Smartphone : ISmartphone
//{
//    public Smartphone(string model)
//    {
//        this.Model = model;
//    }

//    public string Model { get; private set; }

//    public string Browse(string url)
//    {
//        if (this.IsUrlValid(url))
//        {
//            return $"Browsing: {url}!";
//        }

//        return "Invalid URL!";
//    }

//    public string Call(string phoneNumber)
//    {
//        if (this.IsNumberValid(phoneNumber))
//        {
//            return $"Calling... {phoneNumber}";
//        }

//        return "Invalid number!";
//    }

//    private bool IsUrlValid(string url)
//    {
//        for (int i = 0; i < url.Length; i++)
//        {
//            if (char.IsDigit(url[i]))
//            {
//                return false;
//            }
//        }

//        return true;
//    }

//    private bool IsNumberValid(string phoneNumber)
//    {
//        for (int i = 0; i < phoneNumber.Length; i++)
//        {
//            if (!char.IsDigit(phoneNumber[i]))
//            {
//                return false;
//            }
//        }

//        return true;
//    }
//}








//public class StartUp
//{
//    public static void Main()
//    {
//        var phone = new Smartphone("Smartphone");
//        TestPhone(phone);
//    }

//    private static void TestPhone(ISmartphone phone)
//    {
//        var numbersToCall = Console.ReadLine().Split();

//        foreach (var number in numbersToCall)
//        {
//            Console.WriteLine(phone.Call(number));
//        }

//        var sitesToBrowse = Console.ReadLine().Split();

//        foreach (var site in sitesToBrowse)
//        {
//            Console.WriteLine(phone.Browse(site));
//        }
//    }
//}

