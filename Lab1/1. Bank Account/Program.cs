using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



class Program
{  
    static void Main(string[] args)
    {
        Dictionary<int, BankAccount> data = new Dictionary<int, BankAccount>();
        while (true)
        {


            string[] tokens = Console.ReadLine().Split().ToArray();
            if(tokens[0] == "End")
            {
                break;
            }
            int id = int.Parse(tokens[1]);
            if (tokens[0] == "Create")
            {

                if (!data.ContainsKey(id))
                {
                    data[id] = new BankAccount();
                    data[id].Id = id;
                }
                else
                {
                    Console.WriteLine($"Account already exists");
                }
            }
            else if (tokens[0] == "Deposit")
            {

                if (!data.ContainsKey(id))
                {
                    Console.WriteLine($"Account does not exist");
                }
                else
                {
                    decimal amount = decimal.Parse(tokens[2]);
                    data[id].Deposit(amount);
                }
            }
            else if (tokens[0] == "Withdraw")
            {

                if (!data.ContainsKey(id))
                {
                    Console.WriteLine($"Account does not exist");
                }
                else
                {
                    decimal amount = decimal.Parse(tokens[2]);
                    if (!data[id].Withdraw(amount))
                    {
                        Console.WriteLine("Insufficient balance");
                    }
                }
            }
            else if (tokens[0] == "Print")
            {
                if (!data.ContainsKey(id))
                {
                    Console.WriteLine($"Account does not exist");
                }
                else
                {
                    BankAccount temp = data[id];

                    Console.WriteLine(temp.ToString());
                }
            }
        }
             
    }
    
}

