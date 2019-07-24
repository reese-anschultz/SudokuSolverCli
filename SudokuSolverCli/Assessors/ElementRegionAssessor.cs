using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using SudokuSolverCli.UserRequestHandlers;

namespace SudokuSolverCli.Assessors
{
    public static class ElementRegionAssessor
    {
        [Export(typeof(RegionAssessUserRequestHandler.RegionAssessor))]
        public static bool TheDistinctElement(Region region, out IEnumerable<Cell> changedCells)
        {
            // Convert Cells with possible Elements into Elements with possible Cells
            var cellsByElements = new Dictionary<Element, IList<Cell>>();
            region.Cells.ToList().ForEach(cell =>
            {
                cell.CurrentElementSet.ToList().ForEach(element =>
                {
                    if (!cellsByElements.TryGetValue(element, out var listCells))
                    {
                        listCells = new List<Cell>();
                        cellsByElements.Add(element, listCells);
                    }
                    listCells.Add(cell);
                });
            });

            // Enumerator that provides an enumerable for each element and its subsequent elements
            IEnumerable<IEnumerable<KeyValuePair<Element, IList<Cell>>>> EnumerableEnumerables(IEnumerable<KeyValuePair<Element, IList<Cell>>> enumerable)
            {
                // ReSharper disable once PossibleMultipleEnumeration
                while (enumerable.Any())
                {
                    // ReSharper disable once PossibleMultipleEnumeration
                    yield return enumerable;
                    // ReSharper disable once PossibleMultipleEnumeration
                    enumerable = enumerable.Skip(1);
                }
            }

            var temporaryChangedCells = Enumerable.Empty<Cell>();
            var firstCell = EnumerableEnumerables(cellsByElements.OrderBy(elementWithCells => elementWithCells.Value.Count)).FirstOrDefault(thisElementEnumerable =>
                {
                // ReSharper disable once PossibleMultipleEnumeration
                var (element, listCells) = thisElementEnumerable.First();
                // ReSharper disable once PossibleMultipleEnumeration
                //var subsequentElements = thisElementEnumerable.Skip(1);
                if (listCells.Count != 1) return false;
                    var theCell = listCells.Single();
                    var why = $"{string.Join(", ", listCells.Select(cell => cell.Location))} must be {element}";
                // Actually try to change the cells now
                temporaryChangedCells = listCells
                        .Where(cell => cell.RemoveElements(theCell.CompleteElementSet.Remove(element), why));
                    temporaryChangedCells = temporaryChangedCells.Concat(region
                            .Cells
                            .Where(cell => cell != theCell)
                            .Where(cell => cell.RemoveElements(new ElementSet(new[] { element }), why)))
                        .ToList();  // Lock down selection
                return temporaryChangedCells.Any();
                });
            changedCells = temporaryChangedCells;
            return firstCell != null;
        }
    }
}
