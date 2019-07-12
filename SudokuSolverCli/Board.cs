using System;
using System.Collections.Generic;
using System.Linq;

namespace SudokuSolverCli
{
    public class Board
    {
        private readonly uint _width;
        private readonly uint _height;

        private readonly Dictionary<(Element column, Element row), Cell> _cells =
            new Dictionary<(Element column, Element row), Cell>();

        public readonly ElementSet CompleteElementSet;

        public Board(uint width, uint height)
        {
            _width = width;
            _height = height;
            CompleteElementSet = ElementSet.MakeElementSet(_width * _height);
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

        public IEnumerable<Cell> GetColumn(Element row)
        {
            return CompleteElementSet.Select(column => _cells[(column, row)]);
        }

        public IEnumerable<Cell> GetRow(Element column)
        {
            return CompleteElementSet.Select(row => _cells[(column, row)]);
        }

        private IEnumerable<(Element column, Element row)> AreaLocations(Element area)
        {
            var elementIndex = (uint)CompleteElementSet.ToList().IndexOf(area);
            var areaColumns = _height;
            var areaRow = Math.DivRem(elementIndex, areaColumns, out var areaColumn);
            var firstColumn = (uint)(areaColumn * _width);
            var firstRow = (uint)(areaRow * _height);
            var columns = CompleteElementSet.Skip((int)firstColumn).Take((int)_width);
            var rows = CompleteElementSet.Skip((int)firstRow).Take((int)_height);
            return columns.SelectMany(column => rows.Select(row => (column, row)));
        }

        public IEnumerable<Cell> GetArea(Element area)
        {
            return AreaLocations(area).Select(location => _cells[location]);
        }

        public IEnumerable<IEnumerable<Cell>> GetColumns()
        {
            return CompleteElementSet.Select(GetColumn);
        }

        public IEnumerable<IEnumerable<Cell>> GetRows()
        {
            return CompleteElementSet.Select(GetRow);
        }

        public IEnumerable<IEnumerable<Cell>> GetAreas()
        {
            return CompleteElementSet.Select(GetArea);
        }
    }
}
