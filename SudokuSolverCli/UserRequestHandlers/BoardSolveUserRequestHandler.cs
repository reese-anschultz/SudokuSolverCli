using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using SudokuSolverCli.Commands;

namespace SudokuSolverCli.UserRequestHandlers
{
    public class BoardSolveUserRequestHandler : UserRequestHandler
    {
        private readonly Board _board;
        private readonly CompositionContainer _container;

        private BoardSolveUserRequestHandler(Board board, CompositionContainer container) : base("solve")
        {
            _board = board;
            _container = container;
        }

        protected override void ReallyHandleRequest(UserRequest request)
        {
            while (!string.IsNullOrEmpty(_board.FirstOrDefaultAssessorName(_container, out _)))
            {
            }
            new BoardPrintCommand(_board).Execute();
        }

        [Export(typeof(UserRequestHandlerFactory<Board, CompositionContainer>))]
        public static UserRequestHandler BoardSolveUserRequestHandlerFactory(Board board, CompositionContainer container)
        {
            return new BoardSolveUserRequestHandler(board, container);
        }
    }
}
