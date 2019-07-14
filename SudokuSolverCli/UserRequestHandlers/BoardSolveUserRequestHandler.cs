using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;

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
            while (_board.GetRegions().FirstOrDefault(region =>
                       region.FirstOrDefaultAssessor(_container, out var _) != null) != null)
            {
            }
        }

        [Export(typeof(UserRequestHandlerFactory<Board, CompositionContainer>))]
        public static UserRequestHandler BoardSolveUserRequestHandlerFactory(Board board, CompositionContainer container)
        {
            return new BoardSolveUserRequestHandler(board, container);
        }
    }
}
