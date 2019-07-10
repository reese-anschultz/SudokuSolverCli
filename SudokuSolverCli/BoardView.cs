using System.ComponentModel.Composition.Hosting;
using System.Linq;

namespace SudokuSolverCli
{
    public class BoardView : View
    {
        public BoardView(CompositionContainer container, Board board)
        {
            UserRequestHandlers = UserRequestHandler.ComposeUserRequestHandlers(container, this).Concat(UserRequestHandler.ComposeUserRequestHandlers(container, board));
        }
    }
}
