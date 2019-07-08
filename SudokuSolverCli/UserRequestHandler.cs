using System;

namespace SudokuSolverCli
{
    public abstract class UserRequestHandler : ChainOfResponsibilityHandlerWithPredicate<UserRequest>
    {
        private readonly string _command;
        public virtual int Ordinal { get; } = 0;

        protected UserRequestHandler(string command)
        {
            _command = command;
        }

        public override string ToString()
        {
            return _command;
        }

        protected override bool Test(UserRequest request)
        {
            return string.Equals(request.Command, _command, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}