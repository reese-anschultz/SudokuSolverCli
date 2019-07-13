using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;

namespace SudokuSolverCli.UserRequestHandlers
{
    public class RegionAssessUserRequestHandler : UserRequestHandler
    {
        public delegate bool RegionAssessor(Region region, out IEnumerable<Cell> changedCells);

        private readonly Region _region;
        private readonly CompositionContainer _container;

        private RegionAssessUserRequestHandler(Region region, CompositionContainer container) : base("assess")
        {
            _region = region;
            _container = container;
        }

        protected override void ReallyHandleRequest(UserRequest request)
        {
            var changedCells = Enumerable.Empty<Cell>();
            var regionAssessors = _container.GetExportedValues<RegionAssessor>();
            var firstUsefulAssessor = regionAssessors.FirstOrDefault(assessor => assessor(_region, out changedCells));
            if (firstUsefulAssessor == default(RegionAssessor))
            {
                Console.WriteLine("Nothing");
                return;

            }
            Console.WriteLine($"Changed {string.Join(", ", changedCells.Select(cell => cell.Location))}");
        }

        [Export(typeof(UserRequestHandlerFactory<Region, CompositionContainer>))]
        public static UserRequestHandler PrintUserRequestHandlerFactory(Region region, CompositionContainer container)
        {
            return new RegionAssessUserRequestHandler(region, container);
        }
    }
}
