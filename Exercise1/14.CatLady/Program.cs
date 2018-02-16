using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.CatLady
{
    class Cat
    {
        public string Name { get; set; }
        virtual public string BreedSpecific { get; set; }
        public string Breed { get; set; }

        public Cat(string breed, string name, string breedSpecific)
        {
            decimal tryParse = 0;
            if(breed == "Cymric")
            {
                 decimal.TryParse(breedSpecific, out tryParse);
                 BreedSpecific = tryParse.ToString("f2");   
            }
            else
            {
                BreedSpecific = breedSpecific;
            }
            Name = name;            
            Breed = breed;
        }
        public override string ToString()
        {
            return $"{Breed} {Name} {BreedSpecific}";

        }
    }
    class Siamese : Cat
    {
        public override string BreedSpecific { get => base.BreedSpecific; set => base.BreedSpecific = value; }
        public Siamese(string breed, string name, string earSize) : base(breed, name, earSize) { }         
    }
    class Cymric : Cat
    {
        public override string BreedSpecific { get => base.BreedSpecific; set => base.BreedSpecific = value; }
        public Cymric(string breed, string name, string furrLen) : base(breed, name, furrLen) { }        
    }
    class StreetExtraordinaire : Cat
    {
        public override string BreedSpecific { get => base.BreedSpecific; set => base.BreedSpecific = value; }
        public StreetExtraordinaire(string breed, string name, string meowDB) : base(breed, name, meowDB) { }
       
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            Dictionary<string, Cat> cataDB = new Dictionary<string, Cat>();
            while (true)
            {
                string line = Console.ReadLine();
                if(line == "End")
                {
                    break;
                }
                string[] tok = line.Split().ToArray();

                if (!cataDB.ContainsKey(tok[1]))
                {
                    cataDB[tok[1]] = new Cat(tok[0], tok[1], tok[2]);
                }
            }
            Console.WriteLine(cataDB[Console.ReadLine()].ToString());
        }
    }
}
