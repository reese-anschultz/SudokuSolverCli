using System;
using System.ComponentModel.Composition;
using System.IO;

namespace SudokuSolverCli.UserRequestHandlers
{
    [Export(typeof(UserRequestHandler))]
    internal class ExecuteUserRequestsFromFileUserRequestHandler : UserRequestHandler
    {
        public ExecuteUserRequestsFromFileUserRequestHandler() : base("execute")
        {
        }

        protected override void ReallyHandleRequest(UserRequest request)
        {
            try
            {
                using (var textReader = File.OpenText(request.Argument))
                {
                    Program.HandleUserRequestsFromTextReader(textReader);
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e);
            }
        }
    }
}