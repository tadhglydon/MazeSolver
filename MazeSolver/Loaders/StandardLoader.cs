using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MazeSolver
{
    public class StandardLoader : ILoader
    {
        private string[] arguments;

        public StandardLoader(string[] args)
        {
            arguments = args;
        }

        public Maze Load()
        {
            var maze = new Maze();
            var inputFile = File.ReadAllLines(arguments[0]);

            //Load in headings
            maze.grid_x = int.Parse(inputFile[0].Split(' ')[0]);
            maze.grid_y = int.Parse(inputFile[0].Split(' ')[1]);
            maze.start_x = int.Parse(inputFile[1].Split(' ')[0]);
            maze.start_y = int.Parse(inputFile[1].Split(' ')[1]);
            maze.end_x = int.Parse(inputFile[2].Split(' ')[0]);
            maze.end_y = int.Parse(inputFile[2].Split(' ')[1]);

            maze.mazeLayout = new Tile[maze.grid_x, maze.grid_y];
            for (var i = 3; i < inputFile.Length; i++)
            {
                //Assuming single space
                var inputMazeColumn = inputFile[i].Split(' ');
                for (var j = 0; j < inputMazeColumn.Length; j++)
                {
                    TileType type = inputMazeColumn[j] == "0" ? TileType.FreeSpace : TileType.Wall;
                    //Minus 3 to cater for the header rows
                    maze.mazeLayout[i - 3, j] = new Tile(type);
                }
            }
            return maze;
        }

        public bool Validate()
        {
            StringBuilder error = new StringBuilder();

            if (arguments.Length < 1)
            {
                error.AppendLine("Not enough arguments");
            }

            if(error.Length > 0) Console.WriteLine(error);
            return error.Length == 0;
        }
    }
}
