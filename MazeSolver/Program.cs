using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;


namespace MazeSolver
{
    public class Program
    {
        const int APPLICATION_SUCCESS = 0;
        const int APPLICATION_ERROR = 1;

        static int Main(string[] args)
        {
            try
            {
                var loadType = ConfigurationManager.AppSettings["LoadType"];
                var solverType = ConfigurationManager.AppSettings["SolverType"];
                var outputType = ConfigurationManager.AppSettings["OutputType"];

                var mazeFactory = new MazeFactory(args, loadType, solverType, outputType);
                if (!mazeFactory.Validate())
                {
                    Console.WriteLine("Failed validation");
                    return APPLICATION_ERROR;
                }

                mazeFactory.Process();

                return APPLICATION_SUCCESS;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return APPLICATION_ERROR;
            }
        }
    }
}
