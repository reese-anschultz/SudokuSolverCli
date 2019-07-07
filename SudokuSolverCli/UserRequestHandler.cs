using System;

namespace SudokuSolverCli
{
    public abstract class UserRequestHandler : ChainOfResponsibilityHandlerWithPredicate<UserRequest>
    {
        private readonly string _command;

        protected UserRequestHandler(string command)
        {
            _command = command;
        }

        protected override bool Test(UserRequest request)
        {
            return string.Equals(request.Command, _command, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}