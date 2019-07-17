using System.Collections.Generic;
using System.Linq;

namespace SudokuSolverCli
{
    // Two regions that may be overlapped
    public class OverlappedRegions
    {
        public readonly string Name;
        public readonly List<Cell> LeftOnlyCells = new List<Cell>();
        public readonly List<Cell> RightOnlyCells = new List<Cell>();
        public readonly List<Cell> OverlappedCells = new List<Cell>();

        public OverlappedRegions(Region left, Region right)
        {
            Name = $"{left.Name} x {right.Name}";
            left.Cells.Where(right.Cells.Contains).ToList().ForEach(cell => OverlappedCells.Add(cell));
            left.Cells.Where(cell => !OverlappedCells.Contains(cell)).ToList().ForEach(cell => LeftOnlyCells.Add(cell));
            right.Cells.Where(cell => !OverlappedCells.Contains(cell)).ToList().ForEach(cell => RightOnlyCells.Add(cell));
        }
    }
}
