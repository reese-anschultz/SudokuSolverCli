using System;
using System.ComponentModel.Composition;

namespace SudokuSolverCli.UserRequestHandlers
{
    public class CellGivenUserRequestHandler : UserRequestHandler
    {
        private readonly Cell _cell;

        private CellGivenUserRequestHandler(Cell cell) : base("given")
        {
            _cell = cell;
        }

        protected override void ReallyHandleRequest(UserRequest request)
        {
            var completeElementSet = _cell.CompleteElementSet;
            if (!completeElementSet.TryParse(request.Argument, out var element))
            {
                Console.WriteLine("Expected an element name");
                return;

            }
            _cell.RemoveElements(completeElementSet.Remove(element), $"given {element}");
        }

        [Export(typeof(UserRequestHandlerFactory<Cell>))]
        public static UserRequestHandler BoardHelpUserRequestHandlerFactory(Cell cell)
        {
            return new CellGivenUserRequestHandler(cell);
        }
    }
}
