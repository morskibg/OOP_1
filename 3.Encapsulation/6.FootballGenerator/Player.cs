using System;
using System.Collections.Generic;
using System.Text;

namespace _6.FootballGenerator
{
    public class Player
    {
        private string name;
        private Stats stats;
        private bool isPlayerInitialized = true;

        public bool IsPlayerInitialized
        {
            get => isPlayerInitialized;
            set => isPlayerInitialized = value;
        }
        public string Name
        {
            get => this.name;

            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("A name should not be empty.");
                    this.IsPlayerInitialized = false;
                }
                this.name = value;
            }
        }

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            if (!IsPlayerInitialized) return;
            Stats playerStats = new Stats(endurance, sprint, dribble, passing, shooting);
            if (!playerStats.GetStatus())
            {
                this.IsPlayerInitialized = false;
                return;
            }
            this.stats = playerStats;
            this.Name = name;
        }

        public bool GetStatus() => this.IsPlayerInitialized;
        public double GetAverage(){

            return this.stats.GetAverageStats();
        }
        internal class Stats //endurance, sprint, dribble, passing and shooting
        {
            private int endurance;
            private int sprint;
            private int dribble;
            private int passing;
            private int shooting;
            private bool isStatsInitialized = true;
            public bool IsStatsInitialized
            {
                get => this.isStatsInitialized;
                set => this.isStatsInitialized = value;
            }

            public int Endurance
            {
                get => this.endurance;
                set
                {
                    if (value < 0 || value > 100)
                    {
                        this.Print("Endurance");
                        IsStatsInitialized = false;
                    }
                    this.endurance = value;
                }
            }
            public int Sprint
            {
                get => this.sprint;
                set
                {
                    if (value < 0 || value > 100)
                    {
                        this.Print("Sprint");
                        IsStatsInitialized = false;
                    }
                    this.sprint = value;
                }
            }
            public int Dribble
            {
                get => this.dribble;
                set
                {
                    if (value < 0 || value > 100)
                    {
                        this.Print("Dribble");
                        IsStatsInitialized = false;
                    }
                    this.dribble = value;
                }
            }
            public int Passing
            {
                get => this.passing;
                set
                {
                    if (value < 0 || value > 100)
                    {
                        this.Print("Passing");
                        IsStatsInitialized = false;
                    }
                    this.passing = value;
                }
            }
            public int Shooting
            {
                get => this.shooting;
                set
                {
                    if (value < 0 || value > 100)
                    {
                        this.Print("Shooting");
                        IsStatsInitialized = false;
                    }
                    this.shooting = value;
                }
            }

            public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
            {
                this.Endurance = endurance;
                this.Sprint = sprint;
                this.Dribble = dribble;
                this.Passing = passing;
                this.Shooting = shooting;
            }

            private void Print(string msg)
            {
                Console.WriteLine($"{msg} should be between 0 and 100.");
                this.IsStatsInitialized = false;
            }
            public double GetAverageStats()
            {
                return  (this.Endurance + this.Dribble + this.Passing + this.Shooting + this.Sprint) / 5.0;
                
            }
            public bool GetStatus() => this.IsStatsInitialized;
        }
    }
}
