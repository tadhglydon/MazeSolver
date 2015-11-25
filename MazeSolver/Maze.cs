﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MazeSolver
{
    public abstract class Maze
    {
        private int grid_x;
        private int grid_y;
        private int start_x;
        private int start_y;
        private int end_x;
        private int end_y;
        private Tile[,] maze;

        public Maze(string[] input)
        {
            Load(input);
        }

        private void Load(string[] input)
        {
            //We could validate at this stage but instructions say not to.
            //Assuming input files are valid
            
            //Load in headings
            grid_x = int.Parse(input[0].Split(' ')[0]);
            grid_y = int.Parse(input[0].Split(' ')[1]);
            start_x = int.Parse(input[1].Split(' ')[0]);
            start_y = int.Parse(input[1].Split(' ')[1]);
            end_x = int.Parse(input[2].Split(' ')[0]);
            end_y = int.Parse(input[2].Split(' ')[1]);

            maze = new Tile[grid_x, grid_y];
            for (var i = 3; i < input.Length; i++)
            {
                //Assuming single space
                var inputMazeColumn = input[i].Split(' ');
                for (var j = 0; j < inputMazeColumn.Length; j++)
                {
                    TileType type = inputMazeColumn[j] == "0" ? TileType.FreeSpace : TileType.Wall;
                    //Minus 3 to cater for the header rows
                    maze[i - 3, j] = new Tile(type);
                }
            }            
        }

        public virtual bool Solve()
        {
            return
        }

        public string Show()
        {
            StringBuilder outputMaze = new StringBuilder();

            for (var i = 0; i < grid_x; i++)
            {
                for (var j = 0; j < grid_y; j++)
                {
                    if (i == start_x && j == start_y)
                    {
                        outputMaze.Append("S");
                    }
                    else if (i == end_x && j == end_y)
                    {
                        outputMaze.Append("E");
                    }
                    else if (maze[i, j].Type == TileType.Wall)
                    {
                        outputMaze.Append("#");
                    }
                    else if (maze[i, j].SolutionPath)
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

            return outputMaze.ToString();
        }
    }
}
