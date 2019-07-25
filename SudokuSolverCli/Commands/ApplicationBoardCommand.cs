using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SudokuSolverCli.Views;

namespace SudokuSolverCli.Commands
{
    public class ApplicationBoardCommand : Command
    {
        private readonly ApplicationView _applicationView;
        private readonly string _command;

        public ApplicationBoardCommand(ApplicationView applicationView, string command)
        {
            _applicationView = applicationView;
            _command = command;
        }

        public override void Execute()
        {
            var parts = _command.Split(null, 2); // Split into two parts based upon white space
            parts = parts.Concat(Enumerable.Repeat("", 2 - parts.Length)).ToArray();
            if (_applicationView.BoardView == null)
            {
                Console.WriteLine("board has not been set yet");
                return;

            }
            _applicationView.BoardView.HandleRequest(new UserRequest { Command = parts[0], Argument = parts[1] });
        }
    }
}
