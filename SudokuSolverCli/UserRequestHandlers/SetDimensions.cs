using System;
using System.Linq;

namespace SudokuSolverCli.UserRequestHandlers
{
    public class SetDimensions : UserRequestHandler
    {
        public SetDimensions() : base("dim")
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