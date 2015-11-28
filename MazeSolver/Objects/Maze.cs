using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MazeSolver
{
    public class Maze
    {
        public int grid_x {get; set;}
        public int grid_y {get; set;}
        public int start_x {get; set;}
        public int start_y {get; set;}
        public int end_x {get; set;}
        public int end_y {get; set;}
        public Tile[,] mazeLayout {get; set;}
    }
}
