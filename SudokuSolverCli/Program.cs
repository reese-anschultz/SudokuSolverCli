using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace SudokuSolverCli
{
    [Export]
    internal class Program
    {
        public static bool UserRequestedExit = false;

        public static void Main()
        {
            //Create the CompositionContainer with all the parts found in the
            //same assembly as the Program class
            using (var container = new CompositionContainer(new AssemblyCatalog(typeof(Program).Assembly)))
            {
                new ApplicationView(container).HandleUserRequestsFromTextReader(Console.In);
            }
        }
    }
}
