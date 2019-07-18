using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using SudokuSolverCli.UserRequestHandlers;

namespace SudokuSolverCli.Assessors
{
    public static class DistinctSharedElementsAssessor
    {
        [Export(typeof(BoardAssessUserRequestHandler.OverlappedRegionsAssessor))]
        public static bool TheSharedElements(OverlappedRegions overlappedRegions, out IEnumerable<Cell> changedCells)
        {
            var enumeratedOverlappedCells = overlappedRegions.OverlappedCells;
            var enumeratedLeftCells = overlappedRegions.LeftOnlyCells;
            var enumeratedRightCells = overlappedRegions.RightOnlyCells;
            changedCells = Enumerable.Empty<Cell>();
            var overlappedElements = enumeratedOverlappedCells.Select(cell => cell.CurrentElementSet).Aggregate(
                new ElementSet(Enumerable.Empty<Element>()), (aggregate, elementSet) => aggregate.Union(elementSet));
            var leftSharedOnly = enumeratedLeftCells.Select(cell => cell.CurrentElementSet)
                .Aggregate(overlappedElements, (aggregate, elementSet) => aggregate.Except(elementSet));
            if (leftSharedOnly.Count > 0)
            {
                var whyLeft = $"{string.Join(" and/or ", enumeratedOverlappedCells.Select(cell => cell.Location))} must be {leftSharedOnly}";
                // Actually try to change the cells now
                changedCells = enumeratedRightCells
                    .Where(cell => cell.RemoveElements(leftSharedOnly, whyLeft))
                    .ToList();  // Lock down selection
                if (changedCells.Any())
                    return true;

            }
            var rightSharedOnly = enumeratedRightCells.Select(cell => cell.CurrentElementSet)
                .Aggregate(overlappedElements, (aggregate, elementSet) => aggregate.Except(elementSet));
            if (rightSharedOnly.Count <= 0) return false;

            var whyRight = $"{string.Join(" and/or ", enumeratedOverlappedCells.Select(cell => cell.Location))} must be {rightSharedOnly}";
            // Actually try to change the cells now
            changedCells = enumeratedLeftCells
                .Where(cell => cell.RemoveElements(rightSharedOnly, whyRight))
                .ToList();  // Lock down selection
            return changedCells.Any();
        }
    }
}
