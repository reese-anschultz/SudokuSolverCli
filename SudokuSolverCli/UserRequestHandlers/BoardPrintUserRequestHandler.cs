using System;
using System.ComponentModel.Composition;
using System.Linq;

namespace SudokuSolverCli.UserRequestHandlers
{
    public class BoardPrintUserRequestHandler : UserRequestHandler
    {
        private readonly Board _board;

        private BoardPrintUserRequestHandler(Board board) : base("print")
        {
            _board = board;
        }

        protected override void ReallyHandleRequest(UserRequest request)
        {
            foreach (var rowElement in _board.CompleteElementSet)
                Console.WriteLine(string.Join(" ", _board
                    .CompleteElementSet
                    .Select(columnElement => _board.GetCell(columnElement, rowElement))
                    .Select(cell => (cell.CurrentElementSet.Count == 1 ? cell.CurrentElementSet.Single().ToString() : "."))));

            Console.WriteLine("---");
            foreach (var cell in _board.GetArea(_board.CompleteElementSet.First()))
                Console.WriteLine(cell.Location);
            Console.WriteLine("---");
            foreach (var cell in _board.GetArea(_board.CompleteElementSet.Last()))
                Console.WriteLine(cell.Location);
        }

        [Export(typeof(UserRequestHandlerFactory<Board>))]
        public static UserRequestHandler PrintUserRequestHandlerFactory(Board board)
        {
            return new BoardPrintUserRequestHandler(board);
        }
    }
}