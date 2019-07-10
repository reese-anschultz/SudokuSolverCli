using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;

namespace SudokuSolverCli
{
    public class BoardView
    {
        public readonly IEnumerable<UserRequestHandler> UserRequestHandlers;

        public BoardView(CompositionContainer container, Board board)
        {
            UserRequestHandlers = UserRequestHandler.ComposeUserRequestHandlers(container, this).Concat(UserRequestHandler.ComposeUserRequestHandlers(container, board));
        }
    }
}
