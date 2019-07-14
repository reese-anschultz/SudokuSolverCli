//using SudokuSolverCli.UserRequestHandlers;
using System.Collections.Generic;
//using System.ComponentModel.Composition;
using System.Linq;

namespace SudokuSolverCli.Assessors
{
    // This is a diagnostic assessor that eliminates the first element in the
    // element set for all items in the given region.
    // Uncomment the Export to make it active.
    public static class NotFirstRegionAssessor
    {
        //[Export(typeof(RegionAssessUserRequestHandler.RegionAssessor))]
        public static bool TheTrueRegionAssessor(Region region, out IEnumerable<Cell> changedCells)
        {
            changedCells = region
                .Cells
                .Where(cell => cell.RemoveElements(cell.CompleteElementSet.Remove(cell.CompleteElementSet.First()), "given first"))
                .ToList();    // Lock down selection
            return changedCells.Any();
        }
    }
}
