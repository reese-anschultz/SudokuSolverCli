using System.Collections.Generic;

namespace SudokuSolverCli
{
    public class Board
    {
        private readonly Cell[,] _cells;
        private readonly ElementSet _completeElementSet;

        public Board(uint width, uint height)
        {
            var sideLength = width * height;
            _completeElementSet = ElementSet.MakeElementSet(sideLength);
            _cells = new Cell[_completeElementSet.Count, _completeElementSet.Count];
            for (uint w = 0; w < sideLength; ++w)
            for (uint h = 0; h < sideLength; ++h)
                _cells[w, h] = new Cell(_completeElementSet);
        }
    }
}