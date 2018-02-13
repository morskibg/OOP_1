using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



    class Person
    {
        private string name;
        private int age;
        public string Name { get; set; }
        public int Age { get; set; }
    public Person()
    {
        this.Name = "No name";
        this.Age = 0;
    }
    public Person(int age) : this()
    {
        this.Age = age;
    }
    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }
    public string GetName()
    {
        return this.Name;
    }
    public int GetAge()
    {
        return this.Age;
    }
    public override string ToString()
    {
        return $"{this.Name} - {this.Age}";
    }
}

