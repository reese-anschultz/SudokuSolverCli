namespace SudokuSolverCli
{
    public class Change
    {
        public readonly Cell Cell;
        private readonly ElementSet _removedElements;
        private readonly ElementSet _resultingElements;
        private readonly string _why;

        public Change(Cell cell, ElementSet removedElements, ElementSet resultingElements, string why)
        {
            Cell = cell;
            _removedElements = removedElements;
            _resultingElements = resultingElements;
            _why = why;
        }
        public override string ToString()
        {
            return $"{Cell.Location}: removed {_removedElements} to get {_resultingElements} because {_why}";
        }
    }
}
