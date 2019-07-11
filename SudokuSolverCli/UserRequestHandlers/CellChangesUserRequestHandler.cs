using System;
using System.ComponentModel.Composition;
using System.Linq;

namespace SudokuSolverCli.UserRequestHandlers
{
    public class CellChangesUserRequestHandler : UserRequestHandler
    {
        private readonly Cell _cell;

        private CellChangesUserRequestHandler(Cell cell) : base("changes")
        {
            _cell = cell;
        }

        protected override void ReallyHandleRequest(UserRequest request)
        {
            _cell.Changes.ToList().ForEach(change =>
            {
                Console.WriteLine($"Removed {change.RemovedElements} to get {change.ResultingElements} because {change.Why}");
            });
        }

        [Export(typeof(UserRequestHandlerFactory<Cell>))]
        public static UserRequestHandler CellChangesUserRequestHandlerFactory(Cell cell)
        {
            return new CellChangesUserRequestHandler(cell);
        }
    }
}
