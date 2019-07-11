using System.Collections.Generic;

namespace SudokuSolverCli
{
    public class Board
    {
        private readonly Dictionary<(Element column, Element row), Cell> _cells =
            new Dictionary<(Element column, Element row), Cell>();

        public readonly ElementSet CompleteElementSet;

        public Board(uint width, uint height)
        {
            CompleteElementSet = ElementSet.MakeElementSet(width * height);
            foreach (var columnElement in CompleteElementSet)
                foreach (var rowElement in CompleteElementSet)
                {
                    var location = (columnElement, rowElement);
                    _cells[location] = new Cell(location, CompleteElementSet);
                }
        }

        public Cell GetCell(Element column, Element row)
        {
            return _cells[(column, row)];
        }
    }
}