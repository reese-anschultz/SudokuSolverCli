namespace SudokuSolverCli
{
    public class Cell
    {
        private readonly ElementSet _currentElementSet;
        public readonly ElementSet CompleteElementSet;

        public Cell(ElementSet completeElementSet)
        {
            CompleteElementSet = completeElementSet;
            _currentElementSet = CompleteElementSet;
        }

        public bool RemoveElements(ElementSet elements)
        {
            return _currentElementSet.RemoveWhere(elements.Contains) != 0;
        }
    }
}