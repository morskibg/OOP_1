using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _11PokemonTrainer
{
    class Trainer
    {
        public string Name { get; set; }
        public int Badges { get; set; }
        public List<Pokemon> PokData { get; set; }

        public Trainer(string name) 
        {
            
            this.Name = name;
            this.PokData = new List<Pokemon>();
           
            this.Badges = 0;
        }

        public void AddPok(string pokName, string element, int health)
        {
            Pokemon newPok = new Pokemon(pokName, element, health);
            this.PokData.Add(newPok);
        }

        public void AddBadge()
        {
            this.Badges++;
        }

        public void RemoveTenHealth()
        {
            this.PokData = this.PokData.Select(x =>
            {
                x.Health -= 10;
                return x;
            })
            .Where(x => x.Health > 0)
            .ToList();


        }
        public bool HasPokWithElement(string seekedElement)
        {
            return this.PokData.Any(x => x.Element == seekedElement);
        }
        
    }
    class Pokemon
    {
        public string PokName { get; set; }
        public string Element { get; set; }
        public int Health { get; set; }

        public Pokemon(string name, string element, int health)
        {
            this.PokName = name;
            this.Element = element;
            this.Health = health;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
           Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();
            while (true)
            {
                string[] s = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (s[0] == "Tournament")
                {
                    break;
                }
                if (!trainers.ContainsKey(s[0]))
                {
                    trainers[s[0]] = new Trainer(s[0]);
                }
                trainers[s[0]].AddPok(s[1], s[2], int.Parse(s[3]));
            }
            while (true)
            {
                string s = Console.ReadLine();
                if (s == "End")
                {
                    break;
                }
                foreach (var trainer in trainers.Keys)
                {
                    if (trainers[trainer].HasPokWithElement(s))
                    {
                        trainers[trainer].AddBadge();
                    }
                    else
                    {
                        trainers[trainer].RemoveTenHealth();
                    }
                    
                }
                
            }
            foreach (var trainer in trainers.OrderByDescending(x => x.Value.Badges))
            {
                Console.WriteLine($"{trainer.Value.Name} {trainer.Value.Badges} {trainer.Value.PokData.Count}");
            }
        }
    }
}
