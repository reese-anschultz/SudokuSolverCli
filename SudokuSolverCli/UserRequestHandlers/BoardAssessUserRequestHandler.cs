using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace SudokuSolverCli.UserRequestHandlers
{
    public class BoardAssessUserRequestHandler : UserRequestHandler
    {
        public delegate bool SimpleAssessor(IEnumerable<Cell> singleEnumerable);
        private readonly BoardView _boardView;

        private BoardAssessUserRequestHandler(BoardView boardView) : base("assess")
        {
            _boardView = boardView;
        }

        protected override void ReallyHandleRequest(UserRequest request)
        {
            //var assessors = _boardView.Container.GetExportedValues<SimpleAssessor>();
        }


        [Export(typeof(UserRequestHandlerFactory<BoardView>))]
        public static UserRequestHandler BoardAssessUserRequestHandlerFactory(BoardView boardView)
        {
            return new BoardAssessUserRequestHandler(boardView);
        }
    }
}
