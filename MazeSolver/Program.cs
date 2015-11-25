using System;
using System.IO;

namespace MazeSolver
{
    class Program
    {
        const int APPLICAION_SUCCESS = 0;
        const int APPLICAION_ERROR = 1;

        static int Main(string[] args)
        {
            //Validate args
            if (args[0] == "/?" || args[0] == "help" || args.Length != 1)
            {
                Console.WriteLine("Provide a single argument of the text file containing maze data");
                return APPLICAION_ERROR;
            }

            if(!File.Exists(args[0]))
            {
                Console.WriteLine("Could not read the file:" + args[0]);
                return APPLICAION_ERROR;
            }

            //Create maze
            var inputFileText = File.ReadAllLines(args[0]);
            Maze maze = new Maze();
            maze.Load(inputFileText);

            //Solve the maze
            if (!maze.Solve())
            {
                Console.WriteLine("Could not solve the maze :(");
                return APPLICAION_ERROR;
            }

            //Send output to console
            Console.WriteLine(maze.Show());

            return APPLICAION_SUCCESS;
        }
    }
}
