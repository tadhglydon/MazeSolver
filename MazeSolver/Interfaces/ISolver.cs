﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MazeSolver
{
    public interface ISolver
    {
        bool Validate();
        Maze Solve(Maze maze);
    }
}
