using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MazeSolver
{
    public class Tile
    {
        public TileType Type { get; set; }
        public bool Visited { get; set; }
        public bool SolutionPath { get; set; }

        public Tile(TileType type)
        {
            SolutionPath = false;
            Visited = false;
            Type = type;
        }
    }


    public enum TileType { FreeSpace, Wall }
}
