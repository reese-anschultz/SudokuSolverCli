using System;
using System.ComponentModel.Composition;
using System.Linq;

namespace SudokuSolverCli.UserRequestHandlers
{
    internal class GivenUserRequestHandler : UserRequestHandler
    {
        private readonly Board _board;

        private GivenUserRequestHandler(Board board) : base("given")
        {
            _board = board;
        }

        protected override void ReallyHandleRequest(UserRequest request)
        {
            var argument = request.Argument;
            var arguments = argument.Split(' ');
            if (arguments.Length != 2)
            {
                Console.WriteLine("Expected two arguments: x,y name");
                return;

            }
            var indexesArgument = arguments[0];
            var elementNameArgument = arguments[1];
            var indexesArguments = indexesArgument.Split(',');
            if (indexesArguments.Length != 2)
            {
                Console.WriteLine("Expected x,y positions");
                return;

            }
            var completeElementSet = _board.CompleteElementSet;
            Element[] indexes;
            try
            {
                indexes = indexesArguments.Select(indexName => completeElementSet.Parse(indexName)).ToArray();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
                return;

            }
            if (!completeElementSet.TryParse(elementNameArgument, out var element))
            {
                Console.WriteLine("Expected an element name");
                return;

            }
            Program.Board.GetCell(indexes[0], indexes[1]).RemoveElements(completeElementSet.Remove(element));
        }

        [Export(typeof(UserRequestHandlerFactory<Board>))]
        public static UserRequestHandler GivenUserRequestHandlerFactory(Board board)
        {
            return new GivenUserRequestHandler(board);
        }
    }
}