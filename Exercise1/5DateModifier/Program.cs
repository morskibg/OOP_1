using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5DateModifier
{
    public class DateModifier
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int GetDiff(string startDate, string endDate)
        {
            this.StartDate = DateTime.ParseExact(startDate, "yyyy MM dd", null);
            this.EndDate = DateTime.ParseExact(endDate, "yyyy MM dd", null);
            double diff = Math.Abs((EndDate - StartDate).TotalDays);
            return (int) diff;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string startDate = Console.ReadLine();
            string endDate = Console.ReadLine();
            DateModifier dm = new DateModifier();
            Console.WriteLine(dm.GetDiff(startDate, endDate));
        }
    }
}
