using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using SudokuSolverCli.UserRequestHandlers;

namespace SudokuSolverCli.Assessors
{
    public class NotFirstRegionAssessor
    {
        [Export(typeof(RegionAssessUserRequestHandler.RegionAssessor))]
        public static bool TheTrueRegionAssessor(Region region, out IEnumerable<Cell> changedCells)
        {
            changedCells = region.Cells.Where(cell => cell.RemoveElements(cell.CompleteElementSet.Remove(cell.CompleteElementSet.First()), $"given first"));
            return changedCells.Any();
        }
    }
}
