using System.Collections.Generic;

namespace SudokuSolverCli
{
    public class Cell
    {
        public readonly ElementSet CompleteElementSet;
        public ElementSet CurrentElementSet { get; private set; }
        public List<Change> Changes = new List<Change>();

        public Cell(ElementSet completeElementSet)
        {
            CompleteElementSet = completeElementSet;
            CurrentElementSet = CompleteElementSet;
        }

        public bool RemoveElements(ElementSet elements, string why)
        {
            var originalElementSet = CurrentElementSet;
            CurrentElementSet = originalElementSet.Remove(elements);
            if (originalElementSet.SetEquals(CurrentElementSet))
                return false;
            Changes.Add(new Change(elements, CurrentElementSet, why));
            return true;
        }
    }
}