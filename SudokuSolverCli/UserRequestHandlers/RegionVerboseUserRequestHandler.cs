using System;
using System.ComponentModel.Composition;
using System.Linq;

namespace SudokuSolverCli.UserRequestHandlers
{
    public class RegionVerboseUserRequestHandler : UserRequestHandler
    {
        private readonly Region _region;

        private RegionVerboseUserRequestHandler(Region region) : base("verbose")
        {
            _region = region;
        }

        protected override void ReallyHandleRequest(UserRequest request)
        {
            _region.Cells
                .Select(cell => $"{cell.Location}: {cell.CurrentElementSet}")
                .ToList()
                .ForEach(Console.WriteLine);
        }

        [Export(typeof(UserRequestHandlerFactory<Region>))]
        public static UserRequestHandler VerboseUserRequestHandlerFactory(Region region)
        {
            return new RegionVerboseUserRequestHandler(region);
        }
    }
}
