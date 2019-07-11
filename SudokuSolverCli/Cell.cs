namespace SudokuSolverCli
{
    public class Cell
    {
        public readonly ElementSet CompleteElementSet;

        public ElementSet CurrentElementSet { get; private set; }

        public Cell(ElementSet completeElementSet)
        {
            CompleteElementSet = completeElementSet;
            CurrentElementSet = CompleteElementSet;
        }

        public bool RemoveElements(ElementSet elements)
        {
            var originalElementSet = CurrentElementSet;
            CurrentElementSet = originalElementSet.Remove(elements);
            return !originalElementSet.SetEquals(CurrentElementSet);
        }
    }
}