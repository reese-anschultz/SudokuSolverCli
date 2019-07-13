using System.ComponentModel.Composition.Hosting;
using System.Linq;

namespace SudokuSolverCli.Views
{
    public class RegionView : View
    {
        public RegionView(CompositionContainer container, Region region)
        {
            UserRequestHandlers = UserRequestHandler.ComposeUserRequestHandlers(container, this)
                .Concat(UserRequestHandler.ComposeUserRequestHandlers(container, region)
                .Concat(UserRequestHandler.ComposeUserRequestHandlers(container, region, container)));
        }
    }
}
