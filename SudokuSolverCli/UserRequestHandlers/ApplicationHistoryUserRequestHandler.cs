using System;
using System.ComponentModel.Composition;
using System.Linq;
using SudokuSolverCli.Views;

namespace SudokuSolverCli.UserRequestHandlers
{
    public class ApplicationHistoryUserRequestHandler : UserRequestHandler
    {
        private ApplicationHistoryUserRequestHandler(ApplicationView _) : base("history")
        {
        }

        protected override void ReallyHandleRequest(UserRequest request)
        {
            ApplicationView.AllChanges.ToList().ForEach(Console.WriteLine);
        }

        [Export(typeof(UserRequestHandlerFactory<ApplicationView>))]
        public static UserRequestHandler ApplicationHistoryRequestHandlerFactory(ApplicationView applicationView)
        {
            return new ApplicationHistoryUserRequestHandler(applicationView);
        }
    }
}