using System;
using System.ComponentModel.Composition;
using System.Linq;

namespace SudokuSolverCli.UserRequestHandlers
{
    internal class CellHelpUserRequestHandler : UserRequestHandler
    {
        private readonly CellView _cellView;

        private CellHelpUserRequestHandler(CellView cellView) : base("help")
        {
            _cellView = cellView;
        }

        protected override void ReallyHandleRequest(UserRequest request)
        {
            _cellView.UserRequestHandlers
                .Where(handler => !string.IsNullOrEmpty(handler.ToString()))
                .OrderBy(handler => handler.ToString())
                .ToList().ForEach(Console.WriteLine);
        }

        [Export(typeof(UserRequestHandlerFactory<CellView>))]
        public static UserRequestHandler BoardHelpUserRequestHandlerFactory(CellView cellView)
        {
            return new CellHelpUserRequestHandler(cellView);
        }
    }
}