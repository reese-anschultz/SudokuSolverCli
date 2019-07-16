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

        public IEnumerable<Region> GetRegions()
        {
            return GetColumns().Concat(GetRows()).Concat(GetAreas());
        }

        private Region GetColumn(Element row)
        {
            return new Region($"Row {row}", CompleteElementSet.Select(column => _cells[(column, row)]));
        }

        private Region GetRow(Element column)
        {
            return new Region($"Column {column}", CompleteElementSet.Select(row => _cells[(column, row)]));
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
            return rows.SelectMany(row => columns.Select(column => (column, row)));
        }

        private Region GetArea(Element area)
        {
            return new Region($"Area {area}", AreaLocations(area).Select(location => _cells[location]));
        }

        private IEnumerable<Region> GetColumns()
        {
            return CompleteElementSet.Select(GetColumn);
        }

        private IEnumerable<Region> GetRows()
        {
            return CompleteElementSet.Select(GetRow);
        }

        private IEnumerable<Region> GetAreas()
        {
            return CompleteElementSet.Select(GetArea);
        }
    }
}
