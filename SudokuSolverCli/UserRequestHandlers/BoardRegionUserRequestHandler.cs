using System.ComponentModel.Composition;
using System.Linq;

namespace SudokuSolverCli.UserRequestHandlers
{
    public class BoardRegionUserRequestHandler : UserRequestHandler
    {
        private readonly BoardView _boardView;

        private BoardRegionUserRequestHandler(BoardView boardView) : base("region")
        {
            _boardView = boardView;
        }

        protected override void ReallyHandleRequest(UserRequest request)
        {
            var argument = request.Argument;
            var arguments = argument.Split(null, 2);
            arguments = arguments.Concat(Enumerable.Repeat("", 2 - arguments.Length)).ToArray();
            var patternArgument = arguments[0];
            var parts = arguments[1].Split(null, 2); // Split into two parts based upon white space
            parts = parts.Concat(Enumerable.Repeat("", 2 - parts.Length)).ToArray();
            _boardView.GetRegionView(patternArgument).HandleRequest(new UserRequest { Command = parts[0], Argument = parts[1] });
        }

        [Export(typeof(UserRequestHandlerFactory<BoardView>))]
        public static UserRequestHandler BoardRegionUserRequestHandlerFactory(BoardView boardView)
        {
            return new BoardRegionUserRequestHandler(boardView);
        }
    }
}
