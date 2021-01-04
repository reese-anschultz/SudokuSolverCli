using System;
using System.Collections.Generic;
using System.Diagnostics;
using SudokuSolverCli.Views;

namespace SudokuSolverCli
{
    [DebuggerDisplay("Location={Location} Choices={CurrentElementSet.Count}")]
    public class Cell : IEquatable<Cell>
    {
        public readonly ElementSet CompleteElementSet;
        public ElementSet CurrentElementSet { get; private set; }
        public readonly List<Change> Changes = new List<Change>();
        public readonly (Element column, Element row) Location;

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

        public override bool Equals(object obj)
        {
            return Equals(obj as Cell);
        }

        public bool Equals(Cell other)
        {
            // If parameter is null, return false.
            if (other is null)
            {
                return false;
            }

            // Optimization for a common success case.
            if (ReferenceEquals(this, other))
            {
                return true;
            }

            // If run-time types are not exactly the same, return false.
            if (GetType() != other.GetType())
            {
                return false;
            }

            return Location.Equals(other.Location);
        }

        public static bool operator ==(Cell lhs, Cell rhs)
        {
            // Check for null on left side.
            if (lhs is null)
            {
                return rhs is null; // null == null = true.
            }
            // Equals handles case of null on right side.
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Cell lhs, Cell rhs)
        {
            return !(lhs == rhs);
        }

        public override int GetHashCode()
        {
            return Location.GetHashCode();
        }
    }
}