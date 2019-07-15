using System;
using System.ComponentModel.Composition;
using System.Linq;

namespace SudokuSolverCli.UserRequestHandlers
{
    public class CellHistoryUserRequestHandler : UserRequestHandler
    {
        private readonly Cell _cell;

        private CellHistoryUserRequestHandler(Cell cell) : base("history")
        {
            _cell = cell;
        }

        protected override void ReallyHandleRequest(UserRequest request)
        {
            _cell.Changes.ToList().ForEach(Console.WriteLine);
        }

        [Export(typeof(UserRequestHandlerFactory<Cell>))]
        public static UserRequestHandler CellHistoryUserRequestHandlerFactory(Cell cell)
        {
            return new CellHistoryUserRequestHandler(cell);
        }
    }
}
