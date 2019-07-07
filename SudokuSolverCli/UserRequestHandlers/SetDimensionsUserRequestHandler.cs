using System;
using System.ComponentModel.Composition;
using System.Linq;

namespace SudokuSolverCli.UserRequestHandlers
{
    [Export(typeof(UserRequestHandler))]
    public class SetDimensionsUserRequestHandler : UserRequestHandler
    {
        public SetDimensionsUserRequestHandler() : base("dim")
        {
        }

        protected override void ReallyHandleRequest(UserRequest request)
        {
            var argument = request.Argument;
            var arguments = argument.Split(',');
            if (arguments.Length != 2)
            {
                Console.WriteLine("Expected two arguments");
                return;
            }

            uint[] sizes;
            try
            {
                sizes = arguments.Select(uint.Parse).ToArray();
            }
            catch (FormatException e)
            {
                Console.WriteLine(e);
                return;
            }

            var elementSet = ElementSet.MakeElementSet(sizes[0] * sizes[1]);
            elementSet.ToList().ForEach(Console.WriteLine);
        }
    }
}