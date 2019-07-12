using System;
using System.ComponentModel.Composition;

namespace SudokuSolverCli.UserRequestHandlers
{
    internal class RegionUnhandledUserRequestHandler : UserRequestHandler
    {
        private RegionUnhandledUserRequestHandler(RegionView _) : base("")
        {
        }

        public override int Ordinal { get; } = int.MaxValue;    // Indicate this should be last command handler

        protected override bool Test(UserRequest _) // Handle ALL requests
        {
            return true;
        }

        protected override void ReallyHandleRequest(UserRequest request)
        {
            Console.WriteLine($"Unknown region command '{request.Command}'");
        }

        [Export(typeof(UserRequestHandlerFactory<RegionView>))]
        public static UserRequestHandler RegionUnhandledUserRequestHandlerFactory(RegionView region)
        {
            return new RegionUnhandledUserRequestHandler(region);
        }
    }
}