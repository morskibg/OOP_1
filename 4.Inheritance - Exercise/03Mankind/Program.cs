using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



    class Program
    {
        static void Main(string[] args)
        {
            
            try
            {
                string student = Console.ReadLine();
                string worker = Console.ReadLine();
                Student newStudent = new Student(student);
                Worker newWorker = new Worker(worker);
                Console.WriteLine(newStudent.Print().ToString());
                Console.WriteLine(newWorker.Print().ToString());
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
           
        }
    }

