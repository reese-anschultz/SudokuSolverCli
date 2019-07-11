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
            Console.WriteLine($"({_cell.Location.column},{_cell.Location.row}): {string.Join(", ", _cell.CurrentElementSet)}");
        }

        [Export(typeof(UserRequestHandlerFactory<Cell>))]
        public static UserRequestHandler CellPrintUserRequestHandlerFactory(Cell cell)
        {
            return new CellPrintUserRequestHandler(cell);
        }
    }
}
