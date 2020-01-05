using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniMaze;

namespace UnitTestMiniMaze
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestIsNeighbour()
        {
            var pointA = new Point(0,0);
            var pointB = new Point(0,1);
            //test
            var maze = new Maze();

            Assert.IsTrue(maze.AreNeighBours(pointA,pointB));

        }
    }
}
