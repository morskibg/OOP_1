using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace temp2
{
    public class Team
    {
        private string name;
        private IList<Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"A name should not be empty.");
                }

                this.name = value;
            }
        }

        private IList<Player> Players
        {
            get { return this.players; }
            set { this.players = value; }
        }

        public int Rating
        {
            get { return CalculateTeamRating(); }
        }

        private int CalculateTeamRating()
        {
            if (this.players.Any())
            {
                return (int)Math.Round(this.players.Average(p => p.Stats));
            }
            else
            {
                return 0;
            }
        }

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(string player)
        {
            if (!this.players.Any(p => p.Name == player))
            {
                throw new ArgumentException($"Player {player} is not in {this.Name} team. ");
            }

            Player pl = this.players.FirstOrDefault(p => p.Name == player);
            this.players.Remove(pl);
        }

        public override string ToString()
        {
            return $"{this.name} - {this.Rating}";
        }
    }
    public class Player
    {
        private int dribble;
        private int endurance;
        private string name;
        private int passing;
        private int shooting;
        private int sprint;

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"A name should not be empty.");
                }

                this.name = value;
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

        public int Stats { get { return CalculateAverageStats(); } }

        private int Dribble
        {
            get { return this.dribble; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"Dribble should be between 0 and 100.");
                }

                this.dribble = value;
            }
        }

        private int Endurance
        {
            get { return this.endurance; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"Endurance should be between 0 and 100.");
                }

                this.endurance = value;
            }
        }

        private int Passing
        {
            get { return this.passing; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"Passing should be between 0 and 100.");
                }

                this.passing = value;
            }
        }

        private int Shooting
        {
            get { return this.shooting; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"Shooting should be between 0 and 100.");
                }

                this.shooting = value;
            }
        }

        private int Sprint
        {
            get { return this.sprint; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"Sprint should be between 0 and 100.");
                }

                this.sprint = value;
            }
        }

        private int CalculateAverageStats()
        {
            return (int)Math.Round((this.Dribble + this.Endurance + this.Passing + this.Shooting + this.Sprint) / (double)5);
        }
    }
    public class StartUp
    {
        public static void Main()
        {
            List<Team> teams = new List<Team>();

            var input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                var tokens = input.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                var command = tokens[0];
                try
                {
                    switch (command)
                    {
                        case "Team":
                            teams.Add(new Team(tokens[1]));
                            break;

                        case "Add":
                            if (!teams.Any(t => t.Name == tokens[1]))
                            {
                                throw new ArgumentException($"Team {tokens[1]} does not exist.");
                            }
                            else
                            {
                                var currentTeam = teams.First(t => t.Name == tokens[1]);
                                currentTeam.AddPlayer(new Player(tokens[2], int.Parse(tokens[3]), int.Parse(tokens[4]), int.Parse(tokens[5]), int.Parse(tokens[6]), int.Parse(tokens[7])));
                            }
                            break;

                        case "Remove":
                            var teamToRemove = teams.First(t => t.Name == tokens[1]);
                            teamToRemove.RemovePlayer(tokens[2]);
                            break;

                        case "Rating":
                            if (!teams.Any(t => t.Name == tokens[1]))
                            {
                                throw new ArgumentException($"Team {tokens[1]} does not exist.");
                            }
                            else
                            {
                                Console.WriteLine(teams.First(t => t.Name == tokens[1]).ToString());
                            }
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
   
}
