using SudokuSolverCli.UserRequestHandlers;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;

namespace SudokuSolverCli
{
    public static class RegionExtensions
    {
        public static RegionAssessUserRequestHandler.RegionAssessor FirstOrDefaultAssessor(this Region region,
            CompositionContainer container, out IEnumerable<Cell> changedCells)
        {
            var temporaryChangedCells = Enumerable.Empty<Cell>();
            var regionAssessors = container.GetExportedValues<RegionAssessUserRequestHandler.RegionAssessor>();
            var firstUsefulAssessor = regionAssessors.FirstOrDefault(assessor => assessor(region, out temporaryChangedCells));
            changedCells = temporaryChangedCells;
            return firstUsefulAssessor;
        }
    }
}
