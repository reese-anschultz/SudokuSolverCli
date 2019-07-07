namespace SudokuSolverCli
{
    public abstract class ChainOfResponsibilityHandlerWithPredicate<T> : ChainOfResponsibilityHandler<T>
    {
        public sealed override void HandleRequest(T request)
        {
            if (Test(request))
                ReallyHandleRequest(request);
            else
                Successor?.HandleRequest(request);
        }

        protected abstract bool Test(T request);
        protected abstract void ReallyHandleRequest(T request);

        protected delegate bool Predicate(T request);
    }
}