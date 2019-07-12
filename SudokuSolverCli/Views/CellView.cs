using System.ComponentModel.Composition.Hosting;
using System.Linq;

namespace SudokuSolverCli.Views
{
    public class CellView : View
    {
        public CompositionContainer Container { get; }

        public CellView(CompositionContainer container, Cell cell)
        {
            Container = container;
            UserRequestHandlers = UserRequestHandler.ComposeUserRequestHandlers(container, this).Concat(UserRequestHandler.ComposeUserRequestHandlers(container, cell));
        }
    }
}
