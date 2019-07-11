using System;
using System.ComponentModel.Composition;
using System.Linq;

namespace SudokuSolverCli.UserRequestHandlers
{
    internal class ApplicationHelpUserRequestHandler : UserRequestHandler
    {
        private readonly ApplicationView _applicationView;

        private ApplicationHelpUserRequestHandler(ApplicationView applicationView) : base("help")
        {
            _applicationView = applicationView;
        }

        protected override void ReallyHandleRequest(UserRequest request)
        {
            _applicationView.UserRequestHandlers
                .Where(handler => !string.IsNullOrEmpty(handler.ToString()))
                .OrderBy(handler => handler.ToString())
                .ToList().ForEach(Console.WriteLine);
        }

        [Export(typeof(UserRequestHandlerFactory<ApplicationView>))]
        public static UserRequestHandler HelpUserRequestHandlerFactory(ApplicationView applicationView)
        {
            return new ApplicationHelpUserRequestHandler(applicationView);
        }
    }
}