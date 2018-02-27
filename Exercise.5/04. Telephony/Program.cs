
using System;

public interface ISmartphone : IPhone
{
    string Browse(string url);
}

public interface IPhone
{
    string Model { get; }

    string Call(string phoneNumber);
}

public class Smartphone : ISmartphone
    {
        public Smartphone(string model)
        {
            this.Model = model;
        }

        public string Model { get; private set; }

        public string Browse(string url)
        {
            if (this.IsUrlValid(url))
            {
                return $"Browsing: {url}!";
            }

            return "Invalid URL!";
        }

        public string Call(string phoneNumber)
        {
            if (this.IsNumberValid(phoneNumber))
            {
                return $"Calling... {phoneNumber}";
            }

            return "Invalid number!";
        }

        private bool IsUrlValid(string url)
        {
            for (int i = 0; i < url.Length; i++)
            {
                if (char.IsDigit(url[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsNumberValid(string phoneNumber)
        {
            for (int i = 0; i < phoneNumber.Length; i++)
            {
                if (!char.IsDigit(phoneNumber[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }






 

    public class StartUp
    {
        public static void Main()
        {
            var phone = new Smartphone("Smartphone");
            TestPhone(phone);
        }

        private static void TestPhone(ISmartphone phone)
        {
            var numbersToCall = Console.ReadLine().Split();

            foreach (var number in numbersToCall)
            {
                Console.WriteLine(phone.Call(number));
            }

            var sitesToBrowse = Console.ReadLine().Split();

            foreach (var site in sitesToBrowse)
            {
                Console.WriteLine(phone.Browse(site));
            }
        }
    }

