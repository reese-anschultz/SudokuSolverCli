using System.ComponentModel.Composition;

namespace SudokuSolverCli.UserRequestHandlers
{
    public class CellResetUserRequestHandler : UserRequestHandler
    {
        private readonly Cell _cell;

        private CellResetUserRequestHandler(Cell cell) : base("reset")
        {
            _cell = cell;
        }

        protected override void ReallyHandleRequest(UserRequest request)
        {
            _cell.Reset();
        }

        [Export(typeof(UserRequestHandlerFactory<Cell>))]
        public static UserRequestHandler CellResetUserRequestHandlerFactory(Cell cell)
        {
            return new CellResetUserRequestHandler(cell);
        }
    }
}
