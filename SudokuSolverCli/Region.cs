using System.Collections.Generic;

namespace SudokuSolverCli
{
    // A row, column or area
    public class Region
    {
        public readonly string Name;
        public readonly IEnumerable<Cell> Cells;

        public Region(string name, IEnumerable<Cell> cells)
        {
            Name = name;
            Cells = cells;
        }
    }
}
