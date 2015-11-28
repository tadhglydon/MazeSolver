using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MazeSolver
{
    public class FileDisplayer :IDisplayer
    {
        private string[] args;

        public FileDisplayer(string[] arguments)
        {
            args = arguments;
        }

        public bool Validate()
        {
            bool result = true;
            if (args.Length != 2)
            {
                Console.WriteLine("Need 2 arguments. Found {0}", args);
                result = false;
            }
            return result;
        }

        public void Show(Maze maze)
        {
            StringBuilder outputMaze = new StringBuilder();

            for (var i = 0; i < maze.grid_x; i++)
            {
                for (var j = 0; j < maze.grid_y; j++)
                {
                    if (i == maze.start_x && j == maze.start_y)
                    {
                        outputMaze.Append("S");
                    }
                    else if (i == maze.end_x && j == maze.end_y)
                    {
                        outputMaze.Append("E");
                    }
                    else if (maze.mazeLayout[i, j].Type == TileType.Wall)
                    {
                        outputMaze.Append("#");
                    }
                    else if (maze.mazeLayout[i, j].SolutionPath)
                    {
                        outputMaze.Append("X");
                    }
                    else
                    {
                        outputMaze.Append(" ");
                    }
                }
                //Move to the next row
                outputMaze.Append(Environment.NewLine);
            }

            File.WriteAllText(args[1] ,outputMaze.ToString());
        }
    }
}
