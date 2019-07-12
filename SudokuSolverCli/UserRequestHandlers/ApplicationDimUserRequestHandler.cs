using System;
using System.ComponentModel.Composition;
using System.Linq;
using SudokuSolverCli.Views;

namespace SudokuSolverCli.UserRequestHandlers
{
    public class ApplicationDimUserRequestHandler : UserRequestHandler
    {
        private readonly ApplicationView _applicationView;

        private ApplicationDimUserRequestHandler(ApplicationView applicationView) : base("dim")
        {
            _applicationView = applicationView;
        }

        protected override void ReallyHandleRequest(UserRequest request)
        {
            var argument = request.Argument;
            var arguments = argument.Split(',');
            if (arguments.Length != 2)
            {
                Console.WriteLine("Expected two arguments");
                return;
            }

            uint[] sizes;
            try
            {
                sizes = arguments.Select(uint.Parse).ToArray();
            }
            catch (FormatException e)
            {
                Console.WriteLine(e);
                return;
            }

            _applicationView.BoardView = new BoardView(_applicationView.Container, new Board(sizes[0], sizes[1]));
        }

        [Export(typeof(UserRequestHandlerFactory<ApplicationView>))]
        public static UserRequestHandler DimRequestHandlerFactory(ApplicationView applicationView)
        {
            return new ApplicationDimUserRequestHandler(applicationView);
        }
    }
}