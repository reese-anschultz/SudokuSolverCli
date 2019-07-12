using System;
using System.ComponentModel.Composition;
using System.Linq;
using SudokuSolverCli.Views;

namespace SudokuSolverCli.UserRequestHandlers
{
    internal class RegionHelpUserRequestHandler : UserRequestHandler
    {
        private readonly RegionView _regionView;

        private RegionHelpUserRequestHandler(RegionView regionView) : base("help")
        {
            _regionView = regionView;
        }

        protected override void ReallyHandleRequest(UserRequest request)
        {
            _regionView.UserRequestHandlers
                .Where(handler => !string.IsNullOrEmpty(handler.ToString()))
                .OrderBy(handler => handler.ToString())
                .ToList().ForEach(Console.WriteLine);
        }

        [Export(typeof(UserRequestHandlerFactory<RegionView>))]
        public static UserRequestHandler RegionHelpUserRequestHandlerFactory(RegionView regionView)
        {
            return new RegionHelpUserRequestHandler(regionView);
        }
    }
}