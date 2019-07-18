using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;

namespace SudokuSolverCli
{
    public static class BoardExtensions
    {
        public static string FirstOrDefaultAssessorName(this Board board,
            CompositionContainer container, out IEnumerable<Cell> changedCells)
        {
            var temporaryChangedCells = Enumerable.Empty<Cell>();
            var changedRegionAssessor = board.GetRegions().Select(region => region.FirstOrDefaultAssessor(container, out temporaryChangedCells)).FirstOrDefault(assessor => assessor != null);
            if (changedRegionAssessor != null)
            {
                changedCells = temporaryChangedCells;
                return changedRegionAssessor.GetType().Name;

            }

            var columnRowOverlaps = board.GetRows().SelectMany(row =>
                board.GetColumns().Select(column => new OverlappedRegions(column, row)));
            var columnAreaOverlaps = board.GetAreas().SelectMany(area =>
                board.GetColumns().Select(column => new OverlappedRegions(column, area)));
            var rowAreaOverlaps = board.GetAreas()
                .SelectMany(area => board.GetRows().Select(row => new OverlappedRegions(row, area)));
            var allOverlaps = columnRowOverlaps.Concat(columnAreaOverlaps).Concat(rowAreaOverlaps);
            var firstOverlappedRegionsAssessor = allOverlaps.Select(overlap => overlap.FirstOrDefaultAssessor(container, out temporaryChangedCells)).FirstOrDefault(assessor => assessor != null);
            changedCells = temporaryChangedCells;
            return firstOverlappedRegionsAssessor?.GetType().Name ?? "";
        }
    }
}
