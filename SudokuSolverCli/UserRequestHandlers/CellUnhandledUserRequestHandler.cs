using System;
using System.ComponentModel.Composition;

namespace SudokuSolverCli.UserRequestHandlers
{
    internal class CellUnhandledUserRequestHandler : UserRequestHandler
    {
        private CellUnhandledUserRequestHandler(CellView _) : base("")
        {
        }

        public override int Ordinal { get; } = int.MaxValue;    // Indicate this should be last command handler

        protected override bool Test(UserRequest _) // Handle ALL requests
        {
            return true;
        }

        protected override void ReallyHandleRequest(UserRequest request)
        {
            Console.WriteLine($"Unknown cell command '{request.Command}'");
        }

        [Export(typeof(UserRequestHandlerFactory<CellView>))]
        public static UserRequestHandler BoardUnhandledUserRequestHandlerFactory(CellView cell)
        {
            return new CellUnhandledUserRequestHandler(cell);
        }
    }
}