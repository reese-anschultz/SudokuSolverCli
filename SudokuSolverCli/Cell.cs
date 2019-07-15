using System.Collections.Generic;
using SudokuSolverCli.Views;

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

            var removedElementSet = originalElementSet.Remove(CurrentElementSet);
            var change = new Change(this, removedElementSet, CurrentElementSet, why);
            Changes.Add(change);
            ApplicationView.AllChanges.Add(change);
            if (CurrentElementSet.Count == 1)
                ApplicationView.AllFinalChanges.Add(change);
            return true;
        }

        public void Reset()
        {
            CurrentElementSet = CompleteElementSet;
            Changes.Add(new Change(this, CurrentElementSet.Remove(CurrentElementSet), CurrentElementSet, "Reset"));
        }
    }
}