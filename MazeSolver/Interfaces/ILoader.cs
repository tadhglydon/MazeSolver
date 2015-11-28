using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MazeSolver
{
    public interface ILoader
    {
        bool Validate();
        Maze Load();
    }
}
