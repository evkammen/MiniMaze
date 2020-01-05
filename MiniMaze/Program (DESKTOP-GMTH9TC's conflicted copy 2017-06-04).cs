using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMaze
{
    class Program
    {
        static void Main(string[] args)
        {
            var maze = new Maze();

            string[,] miniMaze = new string[,]
            {
                {"0","0","0","0","0"},
                {"0","0","0","0","0"},
                {"0","0","0","0","0"},
                {"0","0","0","0","0"},
                {"S","1","0","0","0"},
                {"1","0","0","1","0"},
                {"E","0","0","0","0"},
                {"0","0","0","0","1"},
                {"0","0","0","0","0"}
            };

            var mazePoints = maze.FindPoints(miniMaze);
            var solution = maze.FindSolution(mazePoints);

            Console.WriteLine("Maze to solve:");

            for (int i = 0; i < miniMaze.GetLength(0); i++)
            {
                for (int j = 0; j < miniMaze.GetLength(1); j++)
                {
                    Console.Write(miniMaze[i, j] + " ");

                }
                Console.WriteLine();
            }

            if (solution != null)
            {
                foreach (var point in solution.GetRange(1, solution.Count - 2))
                {
                    miniMaze[point.X, point.Y] = "x";
                }

                Console.WriteLine("Maze solved:");

                for (int i = 0; i < miniMaze.GetLength(0); i++)
                {
                    for (int j = 0; j < miniMaze.GetLength(1); j++)
                    {
                        Console.Write(miniMaze[i, j] + " ");
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No solution");
            }

            Console.ReadLine();
        }
    }
}
