using System;
using System.ComponentModel.Composition;

namespace SudokuSolverCli.UserRequestHandlers
{
    public class CellPrintUserRequestHandler : UserRequestHandler
    {
        private readonly Cell _cell;

        private CellPrintUserRequestHandler(Cell cell) : base("print")
        {
            _cell = cell;
        }

        protected override void ReallyHandleRequest(UserRequest request)
        {
            Console.WriteLine("Complete: " + string.Join(", ", _cell.CompleteElementSet));
            Console.WriteLine("Current: " + string.Join(", ", _cell.CurrentElementSet));
        }

        [Export(typeof(UserRequestHandlerFactory<Cell>))]
        public static UserRequestHandler BoardHelpUserRequestHandlerFactory(Cell cell)
        {
            return new CellPrintUserRequestHandler(cell);
        }
    }
}
