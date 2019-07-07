namespace SudokuSolverCli
{
    internal class Element
    {
        private readonly string _name;

        public Element(string name)
        {
            _name = name;
        }

        public override string ToString()
        {
            return _name;
        }
    }
}