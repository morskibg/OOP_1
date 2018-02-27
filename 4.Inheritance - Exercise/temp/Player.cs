using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public class Player
{
    private string name;
    private int endunrance;
    private int sprint;
    private int dribble;
    private int passing;
    private int shooting;

    public string Name
    {
        get { return name; }
        private set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A name should not be empty.");
            }
            name = value;
        }
    }

    public int Endurance
    {
        get { return endunrance; }
        set
        {
            ValidateStat(value, "Endurance");
            endunrance = value;
        }
    }

    public int Sprint
    {
        get { return sprint; }
        set
        {
            ValidateStat(value, "Sprint");
            sprint = value;
        }
    }

    public int Dribble
    {
        get { return dribble; }
        set
        {
            ValidateStat(value, "Dribble");
            dribble = value;
        }
    }

    public int Passing
    {
        get { return passing; }
        set
        {
            ValidateStat(value, "Passing");
            passing = value;
        }
    }

    public int Shooting
    {
        get { return shooting; }
        set
        {
            ValidateStat(value, "Shooting");
            shooting = value;
        }
    }

    public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
    {
        this.Name = name;
        this.Endurance = endurance;
        this.Sprint = sprint;
        this.Dribble = dribble;
        this.Passing = passing;
        this.Shooting = shooting;
    }

    private static void ValidateStat(int statValue, string statName)
    {
        if (statValue < 0 || statValue > 100)
        {
            throw new ArgumentException($"{statName} should be between 0 and 100.");
        }
    }
}

