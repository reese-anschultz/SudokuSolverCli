using System;
using System.ComponentModel.Composition;

namespace SudokuSolverCli.UserRequestHandlers
{
    [Export(typeof(UserRequestHandler))]
    public class ElementsUserRequestHandler : UserRequestHandler
    {
        public ElementsUserRequestHandler() : base("elements")
        {
        }

        protected override void ReallyHandleRequest(UserRequest request)
        {
            Console.WriteLine(string.Join(", ", Program.Board.CompleteElementSet));
        }
    }
}