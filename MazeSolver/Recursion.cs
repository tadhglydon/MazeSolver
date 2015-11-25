using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MazeSolver
{
    public class Recursion : IMazeSolver
    {
        private List<Tuple<int, int>> trace;

        public bool Solve()
        {
            //Object to keep track of the path
            trace = new List<Tuple<int, int>>();

            if (!Search(start_x, start_y))
            {
                //Couldn't find the end
                return false;
            }

            //Unwind the trace
            foreach (var cell in trace)
            {
                maze[cell.Item1, cell.Item2].SolutionPath = true;
            }

            return true;
        }


        private bool Search(int x, int y)
        {
            if (x == end_x && y == end_y)
            {
                //Found the end :)
                return true;
            }
            else if (maze[x, y].Type == TileType.Wall)
            {
                return false;
            }
            else if (maze[x, y].Visited)
            {
                //We have been here before
                return false;
            }
            maze[x, y].Visited = true;

            if ((x < grid_x - 1 && Search(x + 1, y)) ||
                (y < grid_y - 1 && Search(x, y + 1)) ||
                (y > 0 && Search(x, y - 1)) ||
                (x > 0 && Search(x - 1, y))
                )
            {
                trace.Add(new Tuple<int, int>(x, y));
                return true;
            }

            //Dead end
            trace.Remove(new Tuple<int, int>(x, y));
            return false;
        }
    }
}
