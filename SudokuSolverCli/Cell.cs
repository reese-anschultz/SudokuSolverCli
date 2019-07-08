namespace SudokuSolverCli
{
    public class Cell
    {
        public readonly ElementSet CompleteElementSet;

        private ElementSet _currentElementSet;

        public Cell(ElementSet completeElementSet)
        {
            CompleteElementSet = completeElementSet;
            _currentElementSet = CompleteElementSet;
        }

        public bool RemoveElements(ElementSet elements)
        {
            var originalElementSet = _currentElementSet;
            _currentElementSet = originalElementSet.Remove(elements);
            return !originalElementSet.SetEquals(_currentElementSet);
        }
    }
}