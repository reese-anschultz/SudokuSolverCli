using System;
using System.ComponentModel.Composition;
using SudokuSolverCli.Views;

namespace SudokuSolverCli.UserRequestHandlers
{
    internal class BoardUnhandledUserRequestHandler : UserRequestHandler
    {
        private BoardUnhandledUserRequestHandler(BoardView _) : base("")
        {
        }

        public override int Ordinal { get; } = int.MaxValue;    // Indicate this should be last command handler

        protected override bool Test(UserRequest _) // Handle ALL requests
        {
            return true;
        }

        protected override void ReallyHandleRequest(UserRequest request)
        {
            Console.WriteLine($"Unknown board command '{request.Command}'");
        }

        [Export(typeof(UserRequestHandlerFactory<BoardView>))]
        public static UserRequestHandler BoardUnhandledUserRequestHandlerFactory(BoardView board)
        {
            return new BoardUnhandledUserRequestHandler(board);
        }
    }
}