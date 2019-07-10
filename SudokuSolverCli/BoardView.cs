using System.ComponentModel.Composition.Hosting;
using System.Linq;

namespace SudokuSolverCli
{
    public class BoardView : View
    {
        public CompositionContainer Container { get; }

        public BoardView(CompositionContainer container, Board board)
        {
            Container = container;
            UserRequestHandlers = UserRequestHandler.ComposeUserRequestHandlers(container, this).Concat(UserRequestHandler.ComposeUserRequestHandlers(container, board));
        }
    }
}
