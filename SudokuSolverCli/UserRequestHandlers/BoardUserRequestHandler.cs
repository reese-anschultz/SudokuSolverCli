using System;
using System.ComponentModel.Composition;
using System.Linq;

namespace SudokuSolverCli.UserRequestHandlers
{
    public class BoardUserRequestHandler : UserRequestHandler
    {
        private readonly ApplicationView _applicationView;

        private BoardUserRequestHandler(ApplicationView applicationView) : base("board")
        {
            _applicationView = applicationView;
        }

        protected override void ReallyHandleRequest(UserRequest request)
        {
            var parts = request.Argument.Split(null, 2); // Split into two parts based upon white space
            parts = parts.Concat(Enumerable.Repeat("", 2 - parts.Length)).ToArray();
            if (_applicationView.BoardView == null)
            {
                Console.WriteLine("board has not been set yet");
                return;

            }
            _applicationView.BoardView.HandleRequest(new UserRequest { Command = parts[0], Argument = parts[1] });
        }

        [Export(typeof(UserRequestHandlerFactory<ApplicationView>))]
        public static UserRequestHandler BoardUserRequestHandlerFactory(ApplicationView applicationView)
        {
            return new BoardUserRequestHandler(applicationView);
        }
    }
}
