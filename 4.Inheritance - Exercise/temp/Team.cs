using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Team
{
    private string name;
    private readonly List<Player> players;

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

    public double Rating =>
        players.Select(p => p.Dribble + p.Endurance + p.Passing + p.Shooting).Average() / 5.0;

    //public double Ranking()
    //{
    //    double ranking = 0;
    //    foreach (var player in players)
    //    {
    //        ranking += (player.Dribble + player.Endurance + player.Passing + player.Shooting + player.Sprint) / 5.0;
    //    }
    //    return ranking;
    //}
    public Team(string name)
    {
        this.Name = name;
        this.players = new List<Player>();
    }

    public void AddPlayer(Player player)
    {
        if (!players.Contains(player))
        {
            players.Add(player);
        }
       
    }

    public void RemovePlayer(string playerName, string teamName)
    {
        if (!players.Any(p => p.Name == playerName))
        {
            throw new ArgumentException($"Player {playerName} is not in {teamName} team.");
        }
        players.RemoveAll(x => x.Name == playerName);
        //for (int i = 0; i < players.Count; i++)
        //{
        //    if (players[i].Name == playerName)
        //    {
        //        players.Remove(players[i]);
        //        break;
        //    }
        //}
    }

    public override string ToString()
    {
        if (players.Count != 0)
        {
            return $"{this.Name} - {(int)Math.Round(Rating)}";
        }
        else return $"{this.Name} - 0";
    }
}