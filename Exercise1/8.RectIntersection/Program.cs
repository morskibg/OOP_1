using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.RectIntersection
{
    class Program
    {
        class Rectangle
        {
            public string Id { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
            public Point A { get; set; }
           
            public Rectangle(string name, int width, int height, double x, double y)
            {
                this.Id = name;
                this.Width = width;
                this.Height = height;
                this.A = new Point(x, y);
                
            }

            internal class Point
            {
                //private int x;
                public double x { get; private set; }

                public double y { get; private set; }

                public Point(double x, double y)
                {
                    this.x = x;
                    this.y = y;
                }
            }

            public bool IsIntersect(Rectangle other)
            {
                bool isIntersect = !((this.A.x + this.Width < other.A.x) ||
                    this.A.x > other.A.x + other.Width ||
                    this.A.y - this.Height > other.A.y ||
                    this.A.y < other.A.y - other.Height);
                return isIntersect;
            }

           
        }
        static void Main(string[] args)
        {
            int[] arg = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = arg[0];
            int m = arg[1];
            Dictionary<string, Rectangle> data = new Dictionary<string, Rectangle>();
            for (int i = 0; i < n; i++)
            {
                string[] sA = Console.ReadLine().Split().ToArray();
                if (!data.ContainsKey(sA[0]))
                {
                    data[sA[0]] = new Rectangle(sA[0], int.Parse(sA[1]), int.Parse(sA[2]), double.Parse(sA[3]), double.Parse(sA[4]));
                }
            }
            for (int i = 0; i < m; i++)
            {
                string[] s2 = Console.ReadLine().Split().ToArray();
                Console.WriteLine(data[s2[0]].IsIntersect(data[s2[1]]) ? "true" : "false");
                
            }
        }
    }
}
