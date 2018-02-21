using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace _6.FootballGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<Team> teams = new HashSet<Team>();
            while (true)
            {
                string line = Console.ReadLine();
                if (line == "END")
                {
                    break;
                }
                string[] tokens = line.Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim())
                    .ToArray();
                if (tokens[0] == "Team")
                {
                    Team newTeam = new Team(tokens[1]);
                    if (newTeam == null) continue;
                    teams.Add(newTeam);
                }
                else
                {
                    Team teamToProceed = teams.FirstOrDefault(x => x.Name == tokens[1]);

                    if (tokens[0] == "Add")
                    {
                        if (teamToProceed == null)
                        {
                            Console.WriteLine($"Team {tokens[1]} does not exist.");
                            continue;
                        }
                        teamToProceed.AddPlayer(tokens[2], int.Parse(tokens[3]), int.Parse(tokens[4]),
                                    int.Parse(tokens[5]), int.Parse(tokens[6]), int.Parse(tokens[7]));
                    }
                    else if (tokens[0] == "Remove")
                    {
                        if (!teamToProceed.RemovePlayer(tokens[2]))
                        {
                            Console.WriteLine($"Player {tokens[2]} is not in {tokens[1]} team.");
                        }
                    }
                    else if (tokens[0] == "Rating")
                    {
                        if (teamToProceed == null)
                        {
                            Console.WriteLine($"Team {tokens[1]} does not exist.");
                            continue;
                        }
                        Console.WriteLine($"{tokens[1]} - {(Math.Round(teamToProceed.GetAverageSkils()))}");
                    }
                }
                
            }
            int t = 0;
        }
    }
}
