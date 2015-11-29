using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MazeSolver
{
    public class RecursionSolver : ISolver
    {
        private List<Cell> trace;
        private Maze localMaze;

        public Maze Solve(Maze maze)
        {
            localMaze = maze;
            //Object to keep track of the path
            trace = new List<Cell>();

            if (!Search(localMaze.start_x, localMaze.start_y))
            {
                //Couldn't find the end
                throw new ApplicationException("Could not solve the maze");
            }

            //Unwind the trace
            foreach (var cell in trace)
            {
                maze.mazeLayout[cell.X, cell.Y].SolutionPath = true;
            }
            maze.mazeLayout[maze.end_x, maze.end_y].SolutionPath = true;

            return localMaze;
        }

            
        private bool Search(int x, int y)
        {
            if (x == localMaze.end_x && y == localMaze.end_y)
            {
                //Found the end :)
                return true;
            }
            else if (localMaze.mazeLayout[x, y].Type == TileType.Wall)
            {
                return false;
            }
            else if (localMaze.mazeLayout[x, y].Visited)
            {
                //We have been here before
                return false;
            }
            localMaze.mazeLayout[x, y].Visited = true;

            if ((x < localMaze.grid_x - 1 && Search(x + 1, y)) ||
                (y < localMaze.grid_y - 1 && Search(x, y + 1)) ||
                (y > 0 && Search(x, y - 1)) ||
                (x > 0 && Search(x - 1, y))
                )
            {
                trace.Add(new Cell(x, y));
                return true;
            }

            //Dead end
            trace.Remove(new Cell(x, y));
            return false;
        }

        public bool Validate()
        {
            return true;
        }
    }
}
