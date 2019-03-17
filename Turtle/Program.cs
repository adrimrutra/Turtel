
using System;
using TurtleLibrary;
using TurtleLibrary.BusinessLogic.Interfaces;

namespace Turtle
{
    class Program
    {
        static void Main(string[] args)
        {
            string arg = args.Length != 0 ? args[0]: string.Empty ;
            if (!String.IsNullOrWhiteSpace(arg))
            {
                ICore core = Core.Create(arg);
                core.Start();
            }
            else
            {
                Console.WriteLine("Please provide file with game settings !!!");
            }
        }
    }
}
