using System;
using System.Collections.Generic;
using System.Text;


public class Person
{
    private string firstName;
    private string lastName;
    private int age;
    private decimal salary;

    public string FirstName
    {
        get { return firstName; }
        private set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
            }
            lastName = value;
        }
    }

    public string LastName
    {
        get { return lastName; }
        private set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
            }
            lastName = value;
        }
    }

    public int Age
    {
        get { return age; }
        private set
        {
            if (value <=0 )
            {
                throw new ArgumentException("Age cannot be zero or a negative integer!");
            }
            age = value;
        }
    }

    public decimal Salary
    {
        get { return salary; }
        private set
        {
            if (value < 460)
            {
                throw new ArgumentException("Salary cannot be less than 460 leva!");
            }
        }
    }
   
    public Person(string fName, string lName, int pAge)
    {
        FirstName = fName;
        LastName = lName;
        Age = pAge;
    }

    public Person(string fName, string lName, int pAge, decimal sal):this(fName, lName, pAge)
    {
        Salary = sal;
    }

    public void IncreaseSalary(decimal bonus)
    {
        decimal increase = salary * (bonus / 100);
        if (age < 30)
        {
            salary += increase / 2;
        }
        else
        {
            salary += increase;
        }
    }

    public override string ToString()
    {
        return $"{FirstName} {LastName} receives {salary:f2} leva.";
    }
}

