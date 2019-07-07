using SudokuSolverCli.UserRequestHandlers;

namespace SudokuSolverCli
{
    internal static class Program
    {
        private static void Main()
        {
            var userRequestHandlers = new SetDimensions();
            userRequestHandlers.HandleRequest(new UserRequest {Command = "dim", Argument = "8,8"});
        }
    }
}