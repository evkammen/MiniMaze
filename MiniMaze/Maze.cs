using System;
using System.Collections.Generic;
using System.Linq;

namespace MiniMaze
{
    public class Maze
    {

        public bool AreNeighBours(Point p1, Point p2 )
        {
            if (p1.X == p2.X && Math.Abs((p1.Y - p2.Y)) == 1)
            {
                return true;
            }
            if (p1.Y == p2.Y && Math.Abs((p1.X - p2.X)) == 1)
            {
                return true;
            }
            return false;
        }

        private List<Point> FindPoints(string[,] maze)
        {
            var rows = maze.GetLength(0);
            var cols = maze.GetLength(1);
            Point startPoint = null;
            Point endPoint = null;

            List<Point> possibleRoutePoints = new List<Point>();

            for(int i=0; i<rows; i++)
            {
                for(int j=0; j < cols; j++)
                {
                    if (maze[i, j].Equals("0"))
                    {
                        possibleRoutePoints.Add( new Point(i,j));
                    }
                    if (maze[i, j].Equals("S"))
                    {
                        startPoint =new Point(i, j);
                    }
                    if (maze[i, j].Equals("E"))
                    {
                        endPoint = new Point(i, j);
                    }
                 }
            }

            if (startPoint != null)
            {
                possibleRoutePoints.Insert(0, startPoint);
            }

            if(endPoint != null)
            {
                possibleRoutePoints.Add(endPoint);
            }
            return possibleRoutePoints;
        }

        private string[,] FillInPath(string[,] maze  ,List<Point> pathPoints)
        {
            foreach (var point in pathPoints.GetRange(1, pathPoints.Count - 2))
            {
                maze[point.X, point.Y] = "x";
            }
            return maze;
        }

    public string[,] FindSolution(string[,] maze)
        {
            var points = FindPoints(maze);

            var possiblePaths = new List<List<Point>>();
            var startPoint = points.First();
            var endPoint = points.Last();

            points.Remove(startPoint);
            points.Remove(endPoint);

            var startpath = new List<Point> {startPoint};
            possiblePaths.Add(startpath);

            while (possiblePaths.Any())
            {
                var newPaths = new List<List<Point>>();
                foreach (var possiblePath in possiblePaths)
                {
                    var lastPoint = possiblePath.Last();
                    var neighBours = FindNeigbours(points, lastPoint);
                    if (neighBours.Any())
                    {
                        foreach (var point in neighBours)
                        {
                            var newPath = new List<Point>();
                            newPath.AddRange(possiblePath);
                            newPath.Add(point);
                            newPaths.Add(newPath);
                            points.Remove(point);
                        }
                    }
                    if (AreNeighBours(lastPoint, endPoint))
                    {
                        possiblePath.Add(endPoint);

                        return FillInPath(maze, possiblePath);
                    }
                }
                possiblePaths = newPaths;
            }
            return null;
        }

        public List<Point> FindNeigbours(List<Point> pointsToSearch, Point searchPoint)
        {
            var neighBours = new List<Point>();
            foreach (var point in pointsToSearch)
            {
                if (AreNeighBours(searchPoint, point))
                {
                    neighBours.Add(point);
                }
            }
            return neighBours;
        }
    }

    public class Point
    {
        public int X { get;}//rij
        public int Y { get;}//kolom

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
