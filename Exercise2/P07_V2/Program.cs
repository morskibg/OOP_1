using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace P07_V2
{
    //class FamilyTree
    //{
    //    public List<Person> Parents { get; set; }
    //    public List<Person> Childr { get; set; }
    //}
    class Person
    {
        public string Name { get; set; }
        public string BDay { get; set; }
        public List<Person> Parents { get; set; }
        public List<Person> Children { get; set; }

        public Person(string input)
        {
            Parents = new List<Person>();
            Children = new List<Person>();
            if (input.Contains("/"))
            {
                BDay = input;
            }
            else
            {
                Name = input;
            }
        }

        public Person GetChild(string childInfo)
        {

            Person seekedChild = childInfo.Contains("/")
                ? Children.FirstOrDefault(x => x.BDay == childInfo)
                : Children.FirstOrDefault(x => x.Name == childInfo);
            return seekedChild;
        }
    }
    
    class Program
    {
        static bool MatchingParent(HashSet<Person> familyTree, string nameToMatch, string dateToMatch)
        {
            Person personWithMatchingName = familyTree.FirstOrDefault(x => x.Name == nameToMatch);
            Person personWithMatchingDate = familyTree.FirstOrDefault(x => x.BDay == dateToMatch);
            if (personWithMatchingDate == null && personWithMatchingName == null)
            {
                return false;
            }
            if (personWithMatchingName != null)
            {
                personWithMatchingName.BDay = dateToMatch;
                if (personWithMatchingDate != null)
                {
                    personWithMatchingName.Children = pe
                }
            }
            
            return true;
        }

        static void Main(string[] args)
        {
            Person personToPrintFor = new Person(Console.ReadLine());
            HashSet<Person> familyTree = new HashSet<Person>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }
                if (input.Contains("-"))
                {
                    string[] tokens = input.Split(new[] {" - "}, StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string parentData = tokens[0];
                    string childData = tokens[1];
                    Person currParent = parentData.Contains("/")
                        ? familyTree.FirstOrDefault(x => x.BDay == parentData)
                        : familyTree.FirstOrDefault(x => x.Name == parentData);
                    Person currChild = familyTree.FirstOrDefault(x => x.GetChild(childData) != null);
                    if (currParent == null)
                    {
                        currParent = new Person(parentData);
                    }
                    if (currChild == null)
                    {
                        currChild = new Person(childData);
                    }
                    currParent.Children.Add(currChild);
                    currChild.Parents.Add(currParent);
                    familyTree.Add(currChild);
                    familyTree.Add(currParent);
                }
                else
                {
                    string pattern = @"(?<name>[A-Za-z]+\s{1}[A-Za-z]+)(?:\s*)(?<date>\d+\/\d+\/\d+)";
                    //MatchCollection matches = Regex.Matches(input, pattern);
                    Match match = Regex.Match(input, pattern);
                    string nameToMatch = match.Groups["name"].Value;
                    string dateToMatch = match.Groups["date"].Value;
                    MatchingParent(familyTree, nameToMatch, dateToMatch);
                    int y = 0;
                }
            }
            int t = 0;
        }
    }
}
