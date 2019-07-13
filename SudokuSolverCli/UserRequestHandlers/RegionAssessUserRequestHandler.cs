using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace SudokuSolverCli.UserRequestHandlers
{
    public class RegionAssessUserRequestHandler : UserRequestHandler
    {
        private readonly Region _region;
        private readonly CompositionContainer _container;

        private RegionAssessUserRequestHandler(Region region, CompositionContainer container) : base("assess")
        {
            _region = region;
            _container = container;
        }

        protected override void ReallyHandleRequest(UserRequest request)
        {
            Console.WriteLine("assessed");
        }

        [Export(typeof(UserRequestHandlerFactory<Region, CompositionContainer>))]
        public static UserRequestHandler PrintUserRequestHandlerFactory(Region region, CompositionContainer container)
        {
            return new RegionAssessUserRequestHandler(region, container);
        }
    }
}
