using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _6.FootballGenerator
{
    public class Team
    {
        private HashSet<Player> players;
        private string name;
        private bool isTeamInitialized = true;
        public bool IsTeamInitialized
        {
            get => isTeamInitialized;
            set => isTeamInitialized = value;
        }
        public string Name
        {
            get => this.name;

            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("A name should not be empty.");
                    IsTeamInitialized = false;
                }
                this.name = value;
            }
        }
        
        public Team(string name)
        {
            if (!IsTeamInitialized) return;
            this.Name = name;
            this.players = new HashSet<Player>();
        }

        public void AddPlayer(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Player newPlayerToAdd = new Player(name, endurance, sprint, dribble, passing, shooting);
            if (!newPlayerToAdd.GetStatus()) return;
            this.players.Add(newPlayerToAdd);
        }

        public bool RemovePlayer(string name)
        {
            if (this.players.All(x => x.Name != name))
            {
                return false;
            }
            players.RemoveWhere(x => x.Name == name);
            return true;

        }

        public double GetAverageSkils()
        {
            double average = 0;
            foreach (var player in players)
            {
                average += player.GetAverage();
            }
            return average;
        }
    }
}
