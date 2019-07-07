using System.ComponentModel.Composition;

namespace SudokuSolverCli.UserRequestHandlers
{
    [Export(typeof(UserRequestHandler))]
    internal class ExitUserRequestHandler : UserRequestHandler
    {
        public ExitUserRequestHandler() : base("exit")
        {
        }

        protected override void ReallyHandleRequest(UserRequest request)
        {
            Program.UserRequestedExit = true;
        }
    }
}