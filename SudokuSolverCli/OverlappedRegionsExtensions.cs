using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using SudokuSolverCli.UserRequestHandlers;

namespace SudokuSolverCli
{
    public static class OverlappedRegionsExtensions
    {
        public static BoardAssessUserRequestHandler.OverlappedRegionsAssessor FirstOrDefaultAssessor(this OverlappedRegions overlappedRegions,
            CompositionContainer container, out IEnumerable<Cell> changedCells)
        {
            var temporaryChangedCells = Enumerable.Empty<Cell>();
            var overlappedRegionsAssessors = container.GetExportedValues<BoardAssessUserRequestHandler.OverlappedRegionsAssessor>();
            var firstUsefulAssessor = overlappedRegionsAssessors.FirstOrDefault(assessor => assessor(overlappedRegions, out temporaryChangedCells));
            changedCells = temporaryChangedCells;
            return firstUsefulAssessor;
        }
    }
}
