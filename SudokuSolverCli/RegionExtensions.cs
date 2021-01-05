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

        public static IDictionary<Element, IList<Cell>> GetElementCellLists(this Region region)
        {
            return region.Cells.Aggregate(new Dictionary<Element, IList<Cell>>(), (dictionary, cell) =>
                cell.CurrentElementSet.Aggregate(dictionary, (dictionary1, element) =>
                {
                    if (!dictionary1.TryGetValue(element, out var listCells))
                    {
                        listCells = new List<Cell>();
                        dictionary1.Add(element, listCells);
                    }
                    listCells.Add(cell);
                    return dictionary1;

                }));
        }
    }
}
