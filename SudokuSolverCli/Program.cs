using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;

namespace SudokuSolverCli
{
    [Export]
    internal class Program
    {
        public static bool UserRequestedExit = false;
        private static CompositionContainer _container;
        public static Board Board;
        public static BoardView BoardView;
        public static ApplicationView ApplicationView;

        public static void Main()
        {
            //Create the CompositionContainer with all the parts found in the
            //same assembly as the Program class
            using (_container = new CompositionContainer(new AssemblyCatalog(typeof(Program).Assembly)))
            {
                Board = new Board(3, 3);
                BoardView = new BoardView(_container, Board);
                ApplicationView = new ApplicationView(_container);
                HandleUserRequestsFromTextReader(Console.In);
            }
        }

        public static void HandleUserRequestsFromTextReader(TextReader textReader)
        {
            while (!UserRequestedExit && textReader.TryReadLine(out var line))
            {
                var parts = line.Split(null, 2); // Split into two parts based upon white space
                parts = parts.Concat(Enumerable.Repeat("", 2 - parts.Length)).ToArray();
                ApplicationView.HandleRequest(new UserRequest { Command = parts[0], Argument = parts[1] });
            }
        }
    }
}
