using System;
using System.ComponentModel.Composition;
using System.Linq;

namespace SudokuSolverCli.UserRequestHandlers
{
    [Export(typeof(UserRequestHandler))]
    internal class GivenUserRequestHandler : UserRequestHandler
    {
        public GivenUserRequestHandler() : base("given")
        {
        }

        protected override void ReallyHandleRequest(UserRequest request)
        {
            var argument = request.Argument;
            var arguments = argument.Split(' ');
            if (arguments.Length != 2)
            {
                Console.WriteLine("Expected two arguments: x,y name");
                return;
            }

            var indexesArgument = arguments[0];
            var elementNameArgument = arguments[1];

            var indexesArguments = indexesArgument.Split(',');
            if (indexesArguments.Length != 2)
            {
                Console.WriteLine("Expected x,y positions");
                return;
            }

            uint[] indexes;
            try
            {
                indexes = indexesArguments.Select(uint.Parse).ToArray();
            }
            catch (FormatException e)
            {
                Console.WriteLine(e);
                return;
            }


            var cell = Program.Board.GetCell(indexes[0], indexes[1]);
            var impossibleElementSet = new ElementSet(cell.CompleteElementSet);
            if (!impossibleElementSet.TryParse(elementNameArgument, out var element))
            {
                Console.WriteLine("Expected an element name");
                return;
            }

            impossibleElementSet.Remove(element);
            cell.RemoveElements(impossibleElementSet);
        }
    }
}