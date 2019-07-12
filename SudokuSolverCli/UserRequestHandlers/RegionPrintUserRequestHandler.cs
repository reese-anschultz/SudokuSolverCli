using System;
using System.ComponentModel.Composition;
using System.Linq;

namespace SudokuSolverCli.UserRequestHandlers
{
    public class RegionPrintUserRequestHandler : UserRequestHandler
    {
        private readonly Region _region;

        private RegionPrintUserRequestHandler(Region region) : base("print")
        {
            _region = region;
        }

        protected override void ReallyHandleRequest(UserRequest request)
        {
            Console.WriteLine(string.Join(" ", _region
                .Cells
                .Select(cell => (cell.CurrentElementSet.Count == 1 ? cell.CurrentElementSet.Single().ToString() : "."))));
        }

        [Export(typeof(UserRequestHandlerFactory<Region>))]
        public static UserRequestHandler PrintUserRequestHandlerFactory(Region region)
        {
            return new RegionPrintUserRequestHandler(region);
        }
    }
}
