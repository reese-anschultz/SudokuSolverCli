using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;

namespace SudokuSolverCli.UserRequestHandlers
{
    public class BoardAssessUserRequestHandler : UserRequestHandler
    {
        public delegate bool OverlappedRegionsAssessor(OverlappedRegions overlappedRegions, out IEnumerable<Cell> changedCells);

        private readonly Board _board;
        private readonly CompositionContainer _container;

        private BoardAssessUserRequestHandler(Board board, CompositionContainer container) : base("assess")
        {
            _board = board;
            _container = container;
        }

        protected override void ReallyHandleRequest(UserRequest request)
        {
            var firstUsefulAssessor = _board.FirstOrDefaultAssessorName(_container, out var changedCells);
            if (!string.IsNullOrEmpty(firstUsefulAssessor))
            {
                Console.WriteLine($"{firstUsefulAssessor}: Changed {string.Join(", ", changedCells.Select(cell => cell.Location))}");
                return;

            }
            Console.WriteLine("Nothing");
        }


        [Export(typeof(UserRequestHandlerFactory<Board, CompositionContainer>))]
        public static UserRequestHandler BoardAssessUserRequestHandlerFactory(Board board, CompositionContainer container)
        {
            return new BoardAssessUserRequestHandler(board, container);
        }
    }
}
