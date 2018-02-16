using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_15.Drawing_tool
{
    abstract class Shape
    {
        public int SideALen;
        public int SideBLen;
        public virtual void Draw()
        {
        }
    }
    
    class DrawingTool : Shape
    {
        public DrawingTool(Shape shape)
        {
            this.SideALen = shape.SideALen;
            this.SideBLen = shape.SideBLen;
        }

        public override void Draw()
        {
            for (int i = 0; i < this.SideBLen; i++)
            {
                if (i == 0 || i == this.SideBLen - 1)
                {
                    Console.WriteLine("|{0}|", new string('-', SideALen));
                }
                else
                {
                    Console.WriteLine("|{0}|", new string(' ', SideALen));
                }
            }
        }
    }

    class Rect : Shape
    {
        public Rect(Func<string> TakeFirstNum, Func<string> TakeSecondNum)
        {
            this.SideALen = int.Parse(TakeFirstNum());
            this.SideBLen = int.Parse(TakeSecondNum());
        }
    }

    class Square : Shape
    {
        public Square(Func<string> TakeNum)
        {
            this.SideALen = int.Parse(TakeNum());
            this.SideBLen = this.SideALen;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string shapeToDraw = Console.ReadLine();
            Shape shape = shapeToDraw == "Square"
                ? shape = new DrawingTool(new Square(Console.ReadLine))
                : shape = new DrawingTool(new Rect(Console.ReadLine, Console.ReadLine));
            shape.Draw();
        }
    }
}
