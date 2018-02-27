////////////////////////////MAIN

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Team> teams = new List<Team>();

        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            try
            {
                string[] arguments = input.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim())
                    .ToArray(); 
                if (arguments[0] == "Team")
                {
                    string teamName = arguments[1];
                    Team team = new Team(teamName);
                    teams.Add(team);
                }
                else if (arguments[0] == "Add")
                {
                    string teamName = arguments[1];
                    string playerName = arguments[2];
                    int endurance = int.Parse(arguments[3]);
                    int sprint = int.Parse(arguments[4]);
                    int dribble = int.Parse(arguments[5]);
                    int passing = int.Parse(arguments[6]);
                    int shooting = int.Parse(arguments[7]);
                    Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);

                    CheckForTeam(teamName, teams);

                    foreach (var team in teams.Where(t => t.Name == teamName))
                    {
                        team.AddPlayer(player);
                    }
                }
                else if (arguments[0] == "Remove")
                {
                    string teamName = arguments[1];
                    string playerName = arguments[2];

                    CheckForTeam(teamName, teams);

                    foreach (var team in teams.Where(t => t.Name == teamName))
                    {
                        team.RemovePlayer(playerName, teamName);
                    }
                }
                else if (arguments[0] == "Rating")
                {
                    string teamName = arguments[1];

                    CheckForTeam(teamName, teams);
                    double teamRating = 0;
                    foreach (var team in teams.Where(t => t.Name == teamName))
                    {
                        Console.WriteLine(team.ToString());
                        //teamRating += team.GetRating();
                    }
                   // Console.WriteLine($"{teamName} - {Math.Round(teamRating)}");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public static void CheckForTeam(string teamName, List<Team> teams)
    {
        if (!teams.Any(t => t.Name == teamName))
        {
            throw new ArgumentException($"Team {teamName} does not exist.");
        }
    }
}