using System;
using System.Collections.Generic;
using System.Text;


public class Team
{
    private string name;
    private List<Person> firstTeam;
    private List<Person> reserveTeam;
    public List<Person> FirstTeam {
        get { return this.firstTeam; }
    }

    public List<Person> ReserveTeam
    {
        get { return this.reserveTeam; }
        
    }

    public Team(string name)
    {
        this.name = name;
        this.firstTeam = new List<Person>();
        this.reserveTeam = new List<Person>();
        
    }

    public void AddPlayer(Person person)
    {
        if (person.Age < 40)
        {
            FirstTeam.Add(person);
        }
        else
        {
            ReserveTeam.Add(person);
        }
    }

    public override string ToString()
    {
        return $"First team has {this.FirstTeam.Count} players. \nReserve team has {this.ReserveTeam.Count} players.";
    }
}

