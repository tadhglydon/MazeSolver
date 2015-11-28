using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MazeSolver
{
    public interface IDisplayer
    {
        bool Validate();
        void Show(Maze maze);
    }
}
