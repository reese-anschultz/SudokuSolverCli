namespace SudokuSolverCli
{
    public class Cell
    {
        private readonly ElementSet _completeElementSet;
        private ElementSet currentElementSet;

        public Cell(ElementSet completeElementSet)
        {
            _completeElementSet = completeElementSet;
            currentElementSet = _completeElementSet;
        }
    }
}