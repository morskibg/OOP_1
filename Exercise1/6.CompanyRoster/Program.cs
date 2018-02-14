using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//name, salary, position, department, email and age. The name, salary, position and department are mandatory while the rest are optional
namespace oop1_6
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
        public void Print()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.Name);
            sb.Append(" ");
            sb.Append(this.Salary.ToString("F2"));
            sb.Append(" ");
            sb.Append(this.Email);
            sb.Append(" ");
            sb.Append(this.Age);
            Console.WriteLine(sb.ToString());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, HashSet<Employee>> bigData = new Dictionary<string, HashSet<Employee>>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split().ToArray();
                string department = tokens[3];
                Employee currEmpl = new Employee(tokens[0], decimal.Parse(tokens[1]), tokens[2], tokens[3]);
                int parsed = 0;
                if (tokens.Length > 4)
                {

                    if (int.TryParse(tokens[4], out parsed))
                    {
                        currEmpl.Age = parsed;
                    }
                    else
                    {
                        currEmpl.Email = tokens[4];
                    }

                }
                if (tokens.Length == 6)
                {
                    if (int.TryParse(tokens[5], out parsed))
                    {
                        currEmpl.Age = parsed;
                        currEmpl.Email = tokens[4];
                    }
                    else
                    {
                        currEmpl.Age = int.Parse(tokens[5]);
                    }

                }

                if (!bigData.ContainsKey(department))
                {
                    bigData[department] = new HashSet<Employee>();
                }
                bigData[department].Add(currEmpl);
            }

            string reachestDep = bigData.OrderByDescending(x => x.Value.Average(z => z.Salary)).First().Key;
            Console.WriteLine($"Highest Average Salary: {reachestDep}");

            foreach (var emmployee in bigData[reachestDep].OrderByDescending(x => x.Salary))
            {
                emmployee.Print();
            }
        }
    }
}
