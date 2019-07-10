using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;

namespace SudokuSolverCli
{
    class ApplicationView : View
    {
        public BoardView BoardView=null;

        public ApplicationView(CompositionContainer container)
        {
            UserRequestHandlers = UserRequestHandler.ComposeUserRequestHandlers(container, this).Concat(UserRequestHandler.ComposeUserRequestHandlers(container));
        }
    }
}
