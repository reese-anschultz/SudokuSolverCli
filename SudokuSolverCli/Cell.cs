using System.Collections.Generic;

namespace SudokuSolverCli
{
    public class Cell
    {
        public readonly ElementSet CompleteElementSet;
        public ElementSet CurrentElementSet { get; private set; }
        public readonly List<Change> Changes = new List<Change>();
        public (Element column, Element row) Location;

        public Cell((Element column, Element row) location, ElementSet completeElementSet)
        {
            CompleteElementSet = completeElementSet;
            CurrentElementSet = CompleteElementSet;
            Location = location;
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

        public void Reset()
        {
            CurrentElementSet = CompleteElementSet;
            Changes.Add(new Change(CurrentElementSet.Remove(CurrentElementSet), CurrentElementSet, "Reset"));
        }
    }
}