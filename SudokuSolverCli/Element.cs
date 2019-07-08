using System;

namespace SudokuSolverCli
{
    public class Element : IComparable
    {
        private readonly string _name;

        public Element(string name)
        {
            _name = name;
        }

        public int CompareTo(object obj)
        {
            return string.Compare(_name, obj.ToString(), StringComparison.Ordinal);
        }

        public override string ToString()
        {
            return _name;
        }
    }
}