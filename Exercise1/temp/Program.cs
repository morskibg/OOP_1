using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

public class Person
{
    //private string _name;
    //private int age;
    public string Name { get; set; }
    public int Age { get; set; }

    //public Person()
    //{
    //    this.Name = "No name";
        
    //    this.Age = 0;
    //}

    //public Person(int age) : this()
    //{
    //    this.Age = age;
    //}

    public Person(int age, string name)
    {
        this.Name = name;
        this.Age = age;
    }

    
}

class DefineAClassPerson
{
    static void Main(string[] args)
    {
        
       // [TestFixture]
        //public class Test_000_001
        //{
            //[Test]
        //    //void ValidatePersonClass()
        //{
        //    Type personType = typeof(Person);
        //    FieldInfo[] fields = personType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
        //    int fieldCount = fields.Length;
        //    Console.WriteLine(fieldCount);
        //    //Assert.That(fieldCount == 2);

        //    PropertyInfo[] properties = personType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
        //    int propertyCount = properties.Length;
        //    Console.WriteLine(propertyCount);
            // Assert.That(propertyCount == 2);
            // }
            //}
        //}
    }
}