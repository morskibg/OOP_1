using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;



public class Human
{
    private string firstName;
    private string lastName;

    protected string FirstName
    {
        get => firstName;
        set
        {
            if (!char.IsUpper(value[0]))
            {
                throw new ArgumentException("Expected upper case letter! Argument: firstName");
            }
            else if (value.Length < 4)
            {
                throw new ArgumentException("Expected length at least 4 symbols! Argument: firstName");
            }
            firstName = value;
        }
    }

    protected string LastName
    {
        get => lastName;
        set
        {
            if (!char.IsUpper(value[0]))
            {
                throw new ArgumentException("Expected upper case letter! Argument: lastName");
            }
            else if (value.Length < 3)
            {
                throw new ArgumentException("Expected length at least 3 symbols! Argument: lastName");
            }
            lastName = value;
        }
    }

    public Human(string input)
    {
        string[] tokens = input.Split().Select(x => x.Trim()).ToArray();
        this.FirstName = tokens[0];
        this.LastName = tokens[1];
    }

    public virtual StringBuilder Print()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("First Name: ");
        sb.Append(this.FirstName);
        sb.Append(Environment.NewLine);
        sb.Append("Last Name: ");
        sb.Append(this.LastName);
        sb.Append(Environment.NewLine);
        return sb;
    }
}

