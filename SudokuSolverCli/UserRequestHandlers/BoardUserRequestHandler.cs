using System.ComponentModel.Composition;
using System.Linq;

namespace SudokuSolverCli.UserRequestHandlers
{
    public class BoardUserRequestHandler : UserRequestHandler
    {
        private BoardUserRequestHandler() : base("board")
        {
        }

        protected override void ReallyHandleRequest(UserRequest request)
        {
            var parts = request.Argument.Split(null, 2); // Split into two parts based upon white space
            parts = parts.Concat(Enumerable.Repeat("", 2 - parts.Length)).ToArray();
            var firstRequestHandler =
                Program.BoardView.UserRequestHandlers.OrderByDescending(handler => handler.Ordinal).Aggregate(default(UserRequestHandler),
                    (previous, handler) =>
                    {
                        handler.SetSuccessor(previous);
                        return handler;
                    });
            firstRequestHandler.HandleRequest(new UserRequest
            { Command = parts[0], Argument = parts[1] });
        }

        [Export(typeof(UserRequestHandlerFactory))]
        public static UserRequestHandler BoardUserRequestHandlerFactory()
        {
            return new BoardUserRequestHandler();
        }
    }
}
