using System;
using System.ComponentModel.Composition;
using System.Linq;

namespace SudokuSolverCli.UserRequestHandlers
{
    public class RegionElementsUserRequestHandler : UserRequestHandler
    {
        private readonly Region _region;

        private RegionElementsUserRequestHandler(Region region) : base("elements")
        {
            _region = region;
        }

        protected override void ReallyHandleRequest(UserRequest request)
        {
            _region.GetElementCellLists()
                .Select(elementWithList => $"{elementWithList.Key}: {string.Join(", ", elementWithList.Value.Select(cell => cell.Location))}")
                .ToList()
                .ForEach(Console.WriteLine);
        }

        [Export(typeof(UserRequestHandlerFactory<Region>))]
        public static UserRequestHandler ElementsUserRequestHandlerFactory(Region region)
        {
            return new RegionElementsUserRequestHandler(region);
        }
    }
}
