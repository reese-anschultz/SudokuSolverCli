namespace SudokuSolverCli
{
    public class Change
    {
        private readonly Cell _cell;
        private readonly ElementSet _removedElements;
        private readonly ElementSet _resultingElements;
        private readonly string _why;

        public Change(Cell cell, ElementSet removedElements, ElementSet resultingElements, string why)
        {
            _cell = cell;
            _removedElements = removedElements;
            _resultingElements = resultingElements;
            _why = why;
        }
        public override string ToString()
        {
            return $"{_cell.Location}: removed {_removedElements} to get {_resultingElements} because {_why}";
        }
    }
}
