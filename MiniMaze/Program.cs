using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMaze
{
    internal class Program
    {
        private static readonly string[,] MiniMaze = {
            {"0","1","0","0","0","0","E"},
            {"0","1","0","0","0","0","0"},
            {"0","0","1","0","1","1","1"},
            {"1","0","1","0","0","0","0"},
            {"1","0","1","1","0","0","0"},
            {"0","0","0","0","0","0","0"},
            {"1","0","1","0","0","0","0"},
            {"1","0","1","0","0","0","0"},
            {"1","0","0","0","0","0","0"},
            {"0","0","1","1","1","1","0"},
            {"0","1","1","0","0","0","0"},
            {"0","1","1","0","0","0","0"},
            {"0","S","1","0","0","0","0"},
            {"1","0","1","1","0","0","0"},
            {"1","0","1","0","0","0","0"},
            {"1","0","1","0","0","0","0"},
        };

        private static void Main(string[] args)
        {

            Console.WriteLine("Maze to solve:");

            PrintMaze(MiniMaze);

            var maze = new Maze();

            var solution = maze.FindSolution(MiniMaze);

            if (solution != null)
            {
                Console.WriteLine("Maze solved:");
                PrintMaze(solution);
            }
            else
            {
                Console.WriteLine("No solution");
            }

            Console.ReadLine();
        }


        private static void PrintMaze(string[,] miniMaze)
        {
            for (var i = 0; i < miniMaze.GetLength(0); i++)
            {
                for (var j = 0; j < miniMaze.GetLength(1); j++)
                {
                    Console.Write(miniMaze[i, j] + " ");
                }
                Console.WriteLine();
            }


        }
    }
}
