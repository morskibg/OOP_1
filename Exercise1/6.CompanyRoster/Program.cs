using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.CompanyRoster
{
    class Program
    {
        class Employee
        {
            public string Name { get; set; }
            public decimal Salary { get; set; }
            public string Position { get; set; }
            public string Department { get; set; }
            public string Email { get; set; }
            public int Age { get; set; }

            public Employee(string name, decimal salary, string position, string department, string email = "n/a", int age = -1)
            {
                this.Name = name;
                this.Salary = salary;
                this.Position = position;
                this.Department = department;
                this.Email = email;
                this.Age = age;
            }

            
        }
        static void Main(string[] args)
        {
            HashSet<Employee> database = new HashSet<Employee>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split().ToArray();

                Employee newIzaura = new Employee(tokens[0], decimal.Parse(tokens[1]), tokens[2], tokens[3]);
                if (tokens.Length > 4)
                {
                    newIzaura.Email = tokens[4];
                }
                if (tokens.Length == 6)
                {
                    newIzaura.Age = int.Parse(tokens[5]);
                }
                database.Add(newIzaura);

            }
            foreach (var worker in database)
            {
                
            }
            int t = 0;
            //name, salary, position, department, email and age. 
        }
    }
}
