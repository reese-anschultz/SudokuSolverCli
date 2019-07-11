namespace SudokuSolverCli
{
    public class Change
    {
        public readonly ElementSet RemovedElements;
        public readonly ElementSet ResultingElements;
        public readonly string Why;

        public Change(ElementSet removedElements, ElementSet resultingElements, string why)
        {
            RemovedElements = removedElements;
            ResultingElements = resultingElements;
            Why = why;
        }
    }
}
