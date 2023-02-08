using Capstone.Classes;
using System;

namespace Capstone
{
    /// <summary>
    /// This class is the main entry point for the application.
    /// 
    /// You likely will not need to modify this file at all.
    /// </summary>
    public sealed class Program
    {
        public static void Main(string[] args)
        {
            UserInterface consoleInterface = new UserInterface();
            consoleInterface.Run();
        }
    }
}
