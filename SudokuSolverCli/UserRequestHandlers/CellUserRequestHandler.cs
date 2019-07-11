using System;
using System.ComponentModel.Composition;
using System.Linq;

namespace SudokuSolverCli.UserRequestHandlers
{
    public class CellUserRequestHandler : UserRequestHandler
    {
        private readonly BoardView _boardView;

        private CellUserRequestHandler(BoardView boardView) : base("cell")
        {
            _boardView = boardView;
        }

        protected override void ReallyHandleRequest(UserRequest request)
        {
            var argument = request.Argument;
            var arguments = argument.Split(null, 2);
            arguments = arguments.Concat(Enumerable.Repeat("", 2 - arguments.Length)).ToArray();
            var indexesArgument = arguments[0];
            var indexesArguments = indexesArgument.Split(',');
            if (indexesArguments.Length != 2)
            {
                Console.WriteLine("Expected x,y positions");
                return;

            }
            var completeElementSet = _boardView.CompleteElementSet;
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
            var parts = arguments[1].Split(null, 2); // Split into two parts based upon white space
            parts = parts.Concat(Enumerable.Repeat("", 2 - parts.Length)).ToArray();
            _boardView.GetCellView(indexes[0], indexes[1]).HandleRequest(new UserRequest { Command = parts[0], Argument = parts[1] });
        }

        [Export(typeof(UserRequestHandlerFactory<BoardView>))]
        public static UserRequestHandler CellUserRequestHandlerFactory(BoardView boardView)
        {
            return new CellUserRequestHandler(boardView);
        }
    }
}
