using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



    class Family
    {
        private List<Person> persons;
        public Family()
        {
            this.persons = new List<Person>();
        }
        public void AddMember(Person member)
        {
            this.persons.Add(member);
        }
        public Person GetOldestMember()
        {
            Person oldestPerson = new Person();
            if(this.persons.Count > 0)
            {
                oldestPerson = this.persons.OrderByDescending(x => x.Age).First();
            }
            return oldestPerson;
        }
    }

