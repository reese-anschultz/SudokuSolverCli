namespace SudokuSolverCli
{
    public abstract class ChainOfResponsibilityHandler<T>
    {
        protected ChainOfResponsibilityHandler<T> Successor;

        public void SetSuccessor(ChainOfResponsibilityHandler<T> successor)
        {
            Successor = successor;
        }

        public abstract void HandleRequest(T request);
    }
}