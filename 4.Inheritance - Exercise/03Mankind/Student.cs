using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



public class Student : Human
    {
        private string fNumber;

        protected string FNumber
        {
            get => fNumber;
            set
            {
                if (!value.All(char.IsLetterOrDigit) || value.Length > 10 || value.Length < 5)
                {
                    throw new ArgumentException("Invalid faculty number!");
                }
                fNumber = value;
            }
        }
     
        public Student(string input) : base(input)
        {
            string[] tokens = input.Split().Select(x => x.Trim()).ToArray();
            this.FNumber = tokens[2];
        }

        public override StringBuilder Print()
        {
            StringBuilder sb = base.Print();
            sb.Append("Faculty number: ");
            sb.Append(this.FNumber);
            sb.Append(Environment.NewLine);
            return sb;
        }
    }

