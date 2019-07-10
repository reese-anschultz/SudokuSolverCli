using System.ComponentModel.Composition.Hosting;
using System.Linq;

namespace SudokuSolverCli
{
    public class BoardView
    {
        public readonly UserRequestHandler FirstRequestHandler;

        public BoardView(CompositionContainer container, Board board)
        {
            var userRequestHandlers = UserRequestHandler.ComposeUserRequestHandlers(container, board);
            FirstRequestHandler =
                userRequestHandlers.OrderByDescending(handler => handler.Ordinal).Aggregate(default(UserRequestHandler),
                    (previous, handler) =>
                    {
                        handler.SetSuccessor(previous);
                        return handler;
                    });
        }
    }
}
