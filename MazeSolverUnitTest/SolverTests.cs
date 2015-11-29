using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MazeSolver;

namespace MazeSolverUnitTest
{
    [TestClass]
    public class SolverTests
    {
        Maze inputMaze;
        Maze expectedMaze;

        [TestInitialize]
        public void Setup()
        {
            inputMaze = CreateTestMaze();
            expectedMaze = CreateTestMaze();
            expectedMaze.mazeLayout[1, 1].SolutionPath = true;
            expectedMaze.mazeLayout[1, 2].SolutionPath = true;
            expectedMaze.mazeLayout[1, 3].SolutionPath = true;
            expectedMaze.mazeLayout[2, 3].SolutionPath = true;
            expectedMaze.mazeLayout[3, 3].SolutionPath = true;
            expectedMaze.mazeLayout[4, 3].SolutionPath = true;
        }

        [TestMethod]
        public void RecursionTest()
        {
            var solver = new RecursionSolver();
            var testMaze = solver.Solve(inputMaze);
            Assert.IsTrue(TestSolutionPath(expectedMaze, testMaze));
        }

        [TestMethod]
        public void AStarTest()
        {
            var solver = new AStarSolver();
            var testMaze = solver.Solve(inputMaze);
            Assert.IsTrue(TestSolutionPath(expectedMaze, testMaze));
        }

        private bool TestSolutionPath(Maze expected, Maze actual)
        {
            for (var i = 0; i < expected.grid_x; i++)
            {
                for (var j = 0; j < expected.grid_y; j++)
                {
                    if (expected.mazeLayout[i, j].SolutionPath != actual.mazeLayout[i, j].SolutionPath)
                        return false;
                }
            }
            return true;
        }

        private Maze CreateTestMaze()
        {
            var maze = new Maze();
            maze.grid_x = 6;
            maze.grid_y = 5;
            maze.start_x = 1;
            maze.start_y = 1;
            maze.end_x = 4;
            maze.end_y = 3;
            maze.mazeLayout = new Tile[,] 
                { 
                    { new Tile(TileType.Wall), new Tile(TileType.Wall), new Tile(TileType.Wall), new Tile(TileType.Wall), new Tile(TileType.Wall)}, 
                    { new Tile(TileType.Wall), new Tile(TileType.FreeSpace), new Tile(TileType.FreeSpace), new Tile(TileType.FreeSpace), new Tile(TileType.Wall)}, 
                    { new Tile(TileType.Wall), new Tile(TileType.FreeSpace), new Tile(TileType.Wall), new Tile(TileType.FreeSpace), new Tile(TileType.Wall)}, 
                    { new Tile(TileType.Wall), new Tile(TileType.FreeSpace), new Tile(TileType.Wall), new Tile(TileType.FreeSpace), new Tile(TileType.Wall)}, 
                    { new Tile(TileType.Wall), new Tile(TileType.FreeSpace), new Tile(TileType.Wall), new Tile(TileType.FreeSpace), new Tile(TileType.Wall)}, 
                    { new Tile(TileType.Wall), new Tile(TileType.Wall), new Tile(TileType.Wall), new Tile(TileType.Wall), new Tile(TileType.Wall)}
                };

            return maze;
        }
    }
}
