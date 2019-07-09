using System.ComponentModel.Composition;

namespace SudokuSolverCli.UserRequestHandlers
{
    internal class ExitUserRequestHandler : UserRequestHandler
    {
        public ExitUserRequestHandler() : base("exit")
        {
        }

        protected override void ReallyHandleRequest(UserRequest request)
        {
            Program.UserRequestedExit = true;
        }

        [Export(typeof(UserRequestHandlerFactory))]
        public static UserRequestHandler ExitUserRequestHandlerFactory()
        {
            return new ExitUserRequestHandler();
        }
    }
}