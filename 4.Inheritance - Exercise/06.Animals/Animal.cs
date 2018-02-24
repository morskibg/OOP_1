using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Animals
{
    public abstract class Animal
    {
        private string name;
        private string age;
        private string gendre;
        private int ageAsNumber;

        protected int AgeAsNumber
        {
            get => ageAsNumber;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid input!");
                }
            }
        }

        public string Name
        {
            get => name;
            set
            {
                this.TextValidator(value);
                name = value;
            }
        }

        public string Age
        {
            get => age;
            set
            {
                this.TextValidator(value);
                if (!int.TryParse(value, out this.ageAsNumber) || !this.AgeValidator())
                {
                    throw new ArgumentException("Invalid input!");
                }
                
                age = value;
            }
        }

        public virtual string Gendre
        {
            get => gendre;
            set
            {
                this.TextValidator(value);
                gendre = value;
            }
        }

        protected Animal(string name, string age, string gendre)
        {
            this.Name = name;
            this.Age = age;
            this.gendre = gendre;
        }

        private void TextValidator(string value)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Invalid input!");
            }
        }

        private bool AgeValidator()
        {
            if (this.AgeAsNumber <= 0)
            {
                return false;
            }
            return true;
        }

        public abstract void ProduceSound();



    }
}