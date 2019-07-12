using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;

namespace SudokuSolverCli.Views
{
    public class ApplicationView : View
    {
        public CompositionContainer Container { get; }
        public BoardView BoardView = null;

        public ApplicationView(CompositionContainer container)
        {
            Container = container;
            UserRequestHandlers = UserRequestHandler.ComposeUserRequestHandlers(container, this).Concat(UserRequestHandler.ComposeUserRequestHandlers(container));
        }

        public void HandleUserRequestsFromTextReader(TextReader textReader)
        {
            while (!Program.UserRequestedExit && textReader.TryReadLine(out var line))
            {
                var parts = line.Split(null, 2); // Split into two parts based upon white space
                parts = parts.Concat(Enumerable.Repeat("", 2 - parts.Length)).ToArray();
                HandleRequest(new UserRequest { Command = parts[0], Argument = parts[1] });
            }
        }
    }
}
