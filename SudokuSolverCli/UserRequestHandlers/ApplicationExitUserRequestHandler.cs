using System.ComponentModel.Composition;

namespace SudokuSolverCli.UserRequestHandlers
{
    internal class ApplicationExitUserRequestHandler : UserRequestHandler
    {
        public ApplicationExitUserRequestHandler() : base("exit")
        {
        }

        protected override void ReallyHandleRequest(UserRequest request)
        {
            Program.UserRequestedExit = true;
        }

        [Export(typeof(UserRequestHandlerFactory))]
        public static UserRequestHandler ExitUserRequestHandlerFactory()
        {
            return new ApplicationExitUserRequestHandler();
        }
    }
}