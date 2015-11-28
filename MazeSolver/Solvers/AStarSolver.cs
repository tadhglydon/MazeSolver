using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MazeSolver
{
    public class AStarSolver : ISolver
    {
        private Maze localMaze;

        public bool Validate()
        {
            return true;
        }

        public Maze Solve(Maze maze)
        {
            localMaze = maze;
            var closedTiles = new List<Cell>();
            var openedTiles = new List<Cell>();
            openedTiles.Add(new Cell(localMaze.start_x,localMaze.start_y));

            while (openedTiles.Count > 0)
            {
                //Pop the first value
                Cell cell = openedTiles.OrderByDescending(o => o.F).First();
                openedTiles.Remove(cell);

                closedTiles.Add(cell);

                if (cell.X == localMaze.end_x && cell.Y == localMaze.end_y)
                {
                    //Found the end!
                    //Now to unravel the trace
                    MarkUpTheSolution(cell);
                    break;
                }

                var adjCells = GetAdjacentTiles(cell.X, cell.Y);
                foreach (var adjCell in adjCells)
                {
                    if (localMaze.mazeLayout[adjCell.X,adjCell.Y].Type != TileType.Wall && !closedTiles.Contains(adjCell))
                    {
                        if (openedTiles.Contains(adjCell))
                        {
                            if (adjCell.G > cell.G + 10)
                            {
                                UpdateCell(adjCell, cell);
                            }
                        }
                        else
                        {
                            UpdateCell(adjCell, cell);
                            openedTiles.Add(adjCell);
                        }
                    }
                }
            }

            return localMaze;
        }

        private void MarkUpTheSolution(Cell cell)
        {
            localMaze.mazeLayout[cell.X, cell.Y].SolutionPath = true;
            if (cell.Parent != null)
            {
                MarkUpTheSolution(cell.Parent);
            }
        }

        private List<Cell> GetAdjacentTiles(int x, int y)
        {
            var tiles = new List<Cell>();

            if(x < localMaze.grid_x - 1)
                tiles.Add(new Cell(x+1, y));
            if (y > 0)
                tiles.Add(new Cell(x, y - 0));
            if (x > 0)
                tiles.Add(new Cell(x - 1, y));
            if (y < localMaze.grid_y - 1)
                tiles.Add(new Cell(x, y + 1));

            return tiles;
        }

        private void UpdateCell(Cell adjacent, Cell current)
        {
            adjacent.G = current.G + 10;
            adjacent.H = GetHeuristic(adjacent);
            adjacent.Parent = current;
            adjacent.F = adjacent.H + adjacent.G;
        }

        private void DisplayPath(int x, int y)
        {
            Console.WriteLine("Tile {0},{1}", x, y);
        }

        private int GetHeuristic(Cell cell)
        {
            return 10 * ((cell.X - localMaze.end_x) + (cell.Y - localMaze.end_y));
        }
    }
}
