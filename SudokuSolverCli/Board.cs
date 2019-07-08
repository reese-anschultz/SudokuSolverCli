namespace SudokuSolverCli
{
    public class Board
    {
        private readonly Cell[,] _cells;

        public Board(uint width, uint height)
        {
            var sideLength = width * height;
            var completeElementSet = ElementSet.MakeElementSet(sideLength);
            _cells = new Cell[completeElementSet.Count, completeElementSet.Count];
            for (uint w = 0; w < sideLength; ++w)
            for (uint h = 0; h < sideLength; ++h)
                _cells[w, h] = new Cell(completeElementSet);
        }

        public Cell GetCell(uint x, uint y)
        {
            return _cells[x, y];
        }
    }
}