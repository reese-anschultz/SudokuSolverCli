using System;
using System.ComponentModel.Composition;
using System.Linq;
using SudokuSolverCli.Views;

namespace SudokuSolverCli.UserRequestHandlers
{
    public class ApplicationFinalHistoryUserRequestHandler : UserRequestHandler
    {
        private ApplicationFinalHistoryUserRequestHandler(ApplicationView _) : base("finalhistory")
        {
        }

        protected override void ReallyHandleRequest(UserRequest request)
        {
            ApplicationView.AllFinalChanges.ToList().ForEach(Console.WriteLine);
        }

        [Export(typeof(UserRequestHandlerFactory<ApplicationView>))]
        public static UserRequestHandler ApplicationFinalHistoryRequestHandlerFactory(ApplicationView applicationView)
        {
            return new ApplicationFinalHistoryUserRequestHandler(applicationView);
        }
    }
}