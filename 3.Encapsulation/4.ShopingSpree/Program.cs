using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace _4.ShopingSpree
{
    class Program
    {
        public class Person
        {
            private string name;
            private decimal money;
            private List<string> basket;

            public List<string> Basket
            {
                get { return this.basket; }
                private set { }
            }
            public string Name
            {
                get { return this.name; }
                set
                {
                    if (string.IsNullOrEmpty(value))
                    {
                        Console.WriteLine("Name cannot be empty");
                        Environment.Exit(1);
                    }
                    this.name = value;
                }
            }

            public decimal Money
            {
                get { return this.money; }
                set
                {
                    if (value < 0)
                    {
                        Console.WriteLine("Money cannot be negative");
                        Environment.Exit(1);
                    }
                    this.money = value;
                }
            }

            public Person(string name, decimal money)
            {
                this.Name = name;
                this.Money = money;
                this.basket = new List<string>();
            }

            public string AddItemToBasket(string item, decimal price)
            {
                if (this.money < price)
                {
                    return $"{this.name} can't afford {item}";
                }
                this.basket.Add(item);
                this.Money -= price;
                return $"{this.name} bought {item}";
            }

            public int BasketCount()
            {
                return this.basket.Count;
            }
        }

        public class Product
        {
            private string name;
            private decimal cost;
           

            public string Name
            {
                get { return this.name; }
                set
                {
                    if (string.IsNullOrEmpty(value))
                    {
                        Console.WriteLine("Name cannot be empty");
                        Environment.Exit(1);
                    }
                    this.name = value;
                }
            }
            public decimal Cost
            {
                get { return this.cost; }
                set
                {
                    if (value < 0)
                    {
                        Console.WriteLine("Money cannot be negative");
                        Environment.Exit(1);
                    }
                    this.cost = value;
                }
            }

            public Product(string name, decimal cost)
            {
                this.Name = name;
                this.Cost = cost;
               
            }

           
        }
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            Dictionary<string, decimal> products = new Dictionary<string, decimal>();
            string pattern = @"(?<name>[A-Za-z]*)\=(?<money>\-*\d+)";
            
            MatchCollection matches = Regex.Matches(Console.ReadLine(), pattern);
            foreach (Match match in matches){
               
                Person newPerson = new Person(match.Groups["name"].Value, decimal.Parse(match.Groups["money"].Value));
                persons.Add(newPerson);
            }
            MatchCollection matchedProducts = Regex.Matches(Console.ReadLine(), pattern);
            foreach (Match matchedProduct in matchedProducts)
            {
                Product newProduct = new Product(matchedProduct.Groups["name"].Value, decimal.Parse(matchedProduct.Groups["money"].Value));
                products[newProduct.Name] = newProduct.Cost;
            }
            while (true)
            {
                string line = Console.ReadLine();
                if (line == "END")
                {
                    break;
                }
                string[] tokens = line.Split().ToArray();
                Person tempPerson = persons.FirstOrDefault(x => x.Name == tokens[0]);
                decimal priceForThisProduct = products[tokens[1]];
                string result = tempPerson.AddItemToBasket(tokens[1], priceForThisProduct);
                Console.WriteLine(result);

            }
            foreach (var person in persons)
            {
                Console.WriteLine($"{person.Name} -" +
                                  $" {(person.BasketCount() == 0 ? "Nothing bought" : string.Join(", ",person.Basket))}");
            }
            
        }
    }
}
