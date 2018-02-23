using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Worker : Human
{
    private double workingHoursPerDay;
    private decimal weekSalary;

    protected double WorkingHoursPerDay
    {
        get => workingHoursPerDay;
        set
        {
            if (value > 12 || value < 1)
            {
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
            }
            workingHoursPerDay = value;
        }
    }

    protected decimal WeekSalary
    {
        get => weekSalary;
        set
        {
            if (value <= 10)
            {
                throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
            }
            weekSalary = value;
        }
    }

    public Worker(string input) : base(input)
    {
        string[] tokens = input.Split().Select(x => x.Trim()).ToArray();
        this.WeekSalary = decimal.Parse(tokens[2]);
        this.WorkingHoursPerDay = double.Parse(tokens[3]);
    }

    public override StringBuilder Print()
    {
        StringBuilder sb = base.Print();
        sb.Append("Week Salary: ");
        sb.Append(this.WeekSalary.ToString("F2"));
        sb.Append(Environment.NewLine);
        sb.Append("Hours per day: ");
        sb.Append(this.WorkingHoursPerDay.ToString("F2"));
        sb.Append(Environment.NewLine);
        sb.Append("Salary per hour: ");
        sb.Append((this.weekSalary / (decimal)(this.WorkingHoursPerDay * 5)).ToString("F2"));
        sb.Append(Environment.NewLine);
        return sb;
    }
}


