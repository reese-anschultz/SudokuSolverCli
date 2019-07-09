using System;
using System.ComponentModel.Composition;

namespace SudokuSolverCli.UserRequestHandlers
{
    internal class UnhandledUserRequestHandler : UserRequestHandler
    {
        public UnhandledUserRequestHandler() : base("")
        {
        }

        public override int Ordinal { get; } = int.MaxValue;    // Indicate this should be last command handler

        protected override bool Test(UserRequest _) // Handle ALL requests
        {
            return true;
        }

        protected override void ReallyHandleRequest(UserRequest request)
        {
            Console.WriteLine($"Unknown command '{request.Command}'");
        }

        [Export(typeof(UserRequestHandlerFactory))]
        public static UserRequestHandler UnhandledUserRequestHandlerFactory()
        {
            return new UnhandledUserRequestHandler();
        }
    }
}