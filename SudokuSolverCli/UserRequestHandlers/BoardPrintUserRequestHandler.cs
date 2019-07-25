using System.ComponentModel.Composition;
using SudokuSolverCli.Commands;

namespace SudokuSolverCli.UserRequestHandlers
{
    public class BoardPrintUserRequestHandler : UserRequestHandler
    {
        private readonly Command _boardPrintCommand;

        private BoardPrintUserRequestHandler(Board board) : base("print")
        {
            _boardPrintCommand = new BoardPrintCommand(board);
        }

        protected override void ReallyHandleRequest(UserRequest request)
        {
            _boardPrintCommand.Execute();
        }

        [Export(typeof(UserRequestHandlerFactory<Board>))]
        public static UserRequestHandler PrintUserRequestHandlerFactory(Board board)
        {
            return new BoardPrintUserRequestHandler(board);
        }
    }
}