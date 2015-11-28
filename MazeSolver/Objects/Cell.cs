using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MazeSolver
{
    public class Cell : IEquatable<Cell>
    {
        public Cell(int x, int y)
        {
            X = x;
            Y = y;

            F = 0;
            G = 0;
            H = 0;
        }

        public Cell Parent { get; set; }

        public int F { get; set; }
        public int G { get; set; }
        public int H { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        public bool Equals(Cell other)
        {
            return this.X == other.X && this.Y == other.Y;
        }
    }
}
