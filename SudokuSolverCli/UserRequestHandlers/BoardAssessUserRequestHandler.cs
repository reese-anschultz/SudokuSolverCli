using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;

namespace SudokuSolverCli.UserRequestHandlers
{
    public class BoardAssessUserRequestHandler : UserRequestHandler
    {
        private readonly Board _board;
        private readonly CompositionContainer _container;

        private BoardAssessUserRequestHandler(Board board, CompositionContainer container) : base("assess")
        {
            _board = board;
            _container = container;
        }

        protected override void ReallyHandleRequest(UserRequest request)
        {
            var changedCells = Enumerable.Empty<Cell>();
            var changedRegion = _board.GetRegions().FirstOrDefault(region => region.FirstOrDefaultAssessor(_container, out changedCells) != null);
            if (changedRegion == null)
            {
                Console.WriteLine("Nothing");
                return;

            }
            Console.WriteLine($"Changed {changedRegion.Name}: {string.Join(", ", changedCells.Select(cell => cell.Location))}");
        }


        [Export(typeof(UserRequestHandlerFactory<Board, CompositionContainer>))]
        public static UserRequestHandler BoardAssessUserRequestHandlerFactory(Board board, CompositionContainer container)
        {
            return new BoardAssessUserRequestHandler(board, container);
        }
    }
}
