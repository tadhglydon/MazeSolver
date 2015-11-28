using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MazeSolver
{
    public class MazeFactory
    {
        private string[] arguments;
        private ILoader loader;
        private ISolver solver;
        private IDisplayer displayer;

        public MazeFactory(string[] arguments, string loaderOption, string solverOption, string displayerOption)
        {
            this.arguments = arguments;
            loader = GetLoader(loaderOption);
            solver = GetSolver(solverOption);
            displayer = GetDisplayer(displayerOption);
        }

        public bool Validate()
        {
            bool result = true;
            if (!loader.Validate()) result = false;
            if (!solver.Validate()) result = false;
            if (!displayer.Validate()) result = false;
            return result;
        }

        public void Process()
        {
            Maze maze = loader.Load();
            maze = solver.Solve(maze);
            displayer.Show(maze);
        }

        public ILoader GetLoader(string option)
        {
            return new StandardLoader(arguments);
        }

        public ISolver GetSolver(string option)
        {
            if (option.ToLower() == "a-star")
                return new AStarSolver();
            else
                return new RecursionSolver();
        }

        public IDisplayer GetDisplayer(string option)
        {
            if (option.ToLower() == "file")
                return new FileDisplayer(arguments);
            else
                return new ConsoleDisplayer();
        }
    }
}
