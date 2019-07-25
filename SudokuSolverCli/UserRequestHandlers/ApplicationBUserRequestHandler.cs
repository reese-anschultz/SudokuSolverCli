using SudokuSolverCli.Commands;
using SudokuSolverCli.Views;
using System.ComponentModel.Composition;

namespace SudokuSolverCli.UserRequestHandlers
{
    public class BUserRequestHandler : UserRequestHandler
    {
        private readonly ApplicationView _applicationView;

        private BUserRequestHandler(ApplicationView applicationView) : base("b")
        {
            _applicationView = applicationView;
        }

        protected override void ReallyHandleRequest(UserRequest request)
        {
            new ApplicationBoardCommand(_applicationView, request.Argument).Execute();
        }

        [Export(typeof(UserRequestHandlerFactory<ApplicationView>))]
        public static UserRequestHandler BoardUserRequestHandlerFactory(ApplicationView applicationView)
        {
            return new BUserRequestHandler(applicationView);
        }
    }
}
