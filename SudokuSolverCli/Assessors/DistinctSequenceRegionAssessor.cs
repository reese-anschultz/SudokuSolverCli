using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using SudokuSolverCli.UserRequestHandlers;

namespace SudokuSolverCli.Assessors
{
    public static class DistinctSequenceRegionAssessor
    {
        [Export(typeof(RegionAssessUserRequestHandler.RegionAssessor))]
        public static bool TheDistinctSequence(Region region, out IEnumerable<Cell> changedCells)
        {
            var cellsByElementSets = new Dictionary<ElementSet, IList<Cell>>();
            region.Cells.ToList().ForEach(cell =>
            {
                var elementSet = cell.CurrentElementSet;
                if (!cellsByElementSets.TryGetValue(elementSet, out var listCells))
                {
                    listCells = new List<Cell>();
                    cellsByElementSets.Add(elementSet, listCells);
                }
                listCells.Add(cell);
            });
            foreach (var elementSetAndListCells in cellsByElementSets)
            {
                var (elementSet, listCells) = elementSetAndListCells;
                if (elementSet.Count != listCells.Count) continue;
                var why = $"{string.Join(", ", listCells.Select(cell => cell.Location))} must be {elementSet}";
                // Actually try to change the cells now
                changedCells = region
                    .Cells
                    .Where(cell => cell.CurrentElementSet != elementSet)
                    .Where(cell => cell.RemoveElements(elementSet, why))
                    .ToList();  // Lock down selection
                if (changedCells.Any())
                    return true;
            }

            changedCells = Enumerable.Empty<Cell>();
            return false;
        }
    }
}
