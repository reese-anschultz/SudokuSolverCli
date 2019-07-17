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
            var firstUsefulAssessor = _region.FirstOrDefaultAssessor(_container, out var changedCells);
            Console.WriteLine(firstUsefulAssessor == default(RegionAssessor)
                ? "Nothing"
                : $"{firstUsefulAssessor.GetType().Name}: Changed {string.Join(", ", changedCells.Select(cell => cell.Location))}");
        }

        [Export(typeof(UserRequestHandlerFactory<Region, CompositionContainer>))]
        public static UserRequestHandler PrintUserRequestHandlerFactory(Region region, CompositionContainer container)
        {
            return new RegionAssessUserRequestHandler(region, container);
        }
    }
}
