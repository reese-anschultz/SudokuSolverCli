using System;
using System.ComponentModel.Composition;
using System.Linq;

namespace SudokuSolverCli.UserRequestHandlers
{
    internal class BoardHelpUserRequestHandler : UserRequestHandler
    {
        private readonly BoardView _boardView;

        private BoardHelpUserRequestHandler(BoardView boardView) : base("help")
        {
            _boardView = boardView;
        }

        protected override void ReallyHandleRequest(UserRequest request)
        {
            _boardView.UserRequestHandlers
                .Where(handler => !string.IsNullOrEmpty(handler.ToString()))
                .OrderBy(handler => handler.ToString())
                .ToList().ForEach(Console.WriteLine);
        }

        [Export(typeof(UserRequestHandlerFactory<BoardView>))]
        public static UserRequestHandler BoardHelpUserRequestHandlerFactory(BoardView boardView)
        {
            return new BoardHelpUserRequestHandler(boardView);
        }
    }
}