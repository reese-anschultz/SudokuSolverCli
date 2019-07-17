using System;
using System.ComponentModel.Composition;
using System.Linq;
using SudokuSolverCli.Views;

namespace SudokuSolverCli.UserRequestHandlers
{
    public class ApplicationFullHistoryUserRequestHandler : UserRequestHandler
    {
        private ApplicationFullHistoryUserRequestHandler(ApplicationView _) : base("fullhistory")
        {
        }

        protected override void ReallyHandleRequest(UserRequest request)
        {
            ApplicationView.AllFinalChanges.SelectMany(change => change.Cell.Changes).ToList().ForEach(Console.WriteLine);
        }

        [Export(typeof(UserRequestHandlerFactory<ApplicationView>))]
        public static UserRequestHandler ApplicationFullHistoryRequestHandlerFactory(ApplicationView applicationView)
        {
            return new ApplicationFullHistoryUserRequestHandler(applicationView);
        }
    }
}