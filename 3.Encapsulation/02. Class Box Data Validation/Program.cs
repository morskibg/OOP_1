using System;

namespace _02._Class_Box_Data_Validation
{
    public class Box
    {
        private double height;
        public double Height
        {
            get { return this.height; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative ");
                }
                this.height = value;
            }
        }

        private double width;
        public double Width
        {
            get { return this.width; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative ");
                }
                this.width = value;
            }
        }

        private double length;
        public double Length
        {
            get { return this.length; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative ");
                }
                this.length = value;
            }
        }

        public Box(double l, double w, double h)
        {
            this.height = h;
            this.length = l;
            this.width = w;
        }

        public double GetSurfaceArea()
        {
            return 2 * (this.height * this.width + this.height * this.length + this.length * this.width);
        }

        public double GetLatSurface()
        {
            return 2 * this.height * (this.width + this.length);
        }

        public double GetVolume()
        {
            return this.height * this.length * this.width;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            double l = double.Parse(Console.ReadLine());
            double w = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());
            Box box = new Box(l, w, h);
            Console.WriteLine($"Surface Area - {box.GetSurfaceArea():f2}");
            Console.WriteLine($"Lateral Surface Area - {box.GetLatSurface():f2}");
            Console.WriteLine($"Volume - {box.GetVolume():f2}");
        }
    }
}
