using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



    class Person
    {
        private int age;
        private string name;
        private List<BankAccount> accounts;
        public Person(string name, int age) : this(name, age, new List<BankAccount>()) { }       
        public Person(string name, int age, List<BankAccount> accounts) 
        {
            this.age = age;
            this.name = name;
            this.accounts = accounts;
        }
        public decimal GetBalance()
        {
            return this.accounts.Sum(x => x.Balance);
        }
    }

