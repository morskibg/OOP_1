using System;
using System.Linq;

namespace P03_JediGalaxy
{
    
    class Program
    {
        static int[] InputToIntArr(Func<string> Input)
        {
            int[] arr = Input().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            return arr;
        }
        static int[] InputStringToIntArr(string Input)
        {
            int[] arr = Input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            return arr;
        }

        static void FillMatrix(int[,] matrix)
        {
            int x = matrix.GetLength(0);
            int y = matrix.GetLength(1);
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    matrix[i, j] = y * i + j;
                }
            }
        }

        
        static void Main()
        {
            
            int[] dimestions = InputToIntArr(Console.ReadLine);
            int rows = dimestions[0];
            int cols = dimestions[1];
            int[,] matrix = new int[rows, cols];
            FillMatrix(matrix);
            

            
            long sum = 0;
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Let the Force be with you")
                {
                    break;
                }
                int[] ivoS = InputStringToIntArr(command);
                int[] evil = InputToIntArr(Console.ReadLine);
                int xE = evil[0];
                int yE = evil[1];
               
                while (xE >= 0 && yE >= 0)
                {
                    if (xE >= 0 && xE < matrix.GetLength(0) && yE >= 0 && yE < matrix.GetLength(1))
                    {
                        matrix[xE, yE] = 0;
                    }
                    xE--;
                    yE--;
                }

                int xI = ivoS[0];
                int yI = ivoS[1];
              

                while (xI >= 0 && yI < matrix.GetLength(1))
                {
                    if (xI >= 0 && xI < matrix.GetLength(0) && yI >= 0 && yI < matrix.GetLength(1))
                    {
                        sum += matrix[xI, yI];
                    }

                    yI++;
                    xI--;
                }


            }

            Console.WriteLine(sum);

        }
    }
}
