using System;
using System.ComponentModel.Composition;
using System.Linq;

namespace SudokuSolverCli.UserRequestHandlers
{
    public class BoardVerboseUserRequestHandler : UserRequestHandler
    {
        private readonly Board _board;

        private BoardVerboseUserRequestHandler(Board board) : base("verbose")
        {
            _board = board;
        }

        protected override void ReallyHandleRequest(UserRequest request)
        {
            _board.CompleteElementSet.SelectMany(r => _board.CompleteElementSet.Select(c => _board.GetCell(c, r)))
                    .Select(cell => $"{cell.Location}: {cell.CurrentElementSet}")
                    .ToList()
                    .ForEach(Console.WriteLine);
        }

        [Export(typeof(UserRequestHandlerFactory<Board>))]
        public static UserRequestHandler BoardVerboseUserRequestHandlerFactory(Board board)
        {
            return new BoardVerboseUserRequestHandler(board);
        }
    }
}