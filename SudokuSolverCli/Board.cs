namespace SudokuSolverCli
{
    public class Board
    {
        private readonly ElementSet _elementSet;

        public Board(uint width, uint height)
        {
            _elementSet = ElementSet.MakeElementSet(width * height);
        }
    }
}