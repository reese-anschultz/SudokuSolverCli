using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;

namespace SudokuSolverCli
{
    internal class Program
    {
        [ImportMany] private IEnumerable<UserRequestHandler> _userRequestHandlers;

        public static void Main()
        {
            new Program().MainInstance();
        }

        private void MainInstance()
        {
            //An aggregate catalog that combines multiple catalogs
            var catalog = new AggregateCatalog();
            //Adds all the parts found in the same assembly as the Program class
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(Program).Assembly));

            //Create the CompositionContainer with the parts in the catalog
            var container = new CompositionContainer(catalog);

            //Fill the imports of this object
            try
            {
                container.ComposeParts(this);
            }
            catch (CompositionException compositionException)
            {
                Console.WriteLine(compositionException.ToString());
            }

            //var userRequestHandlers = new SetDimensions();
            var firstUserRequestHandler =
                _userRequestHandlers.Aggregate(default(UserRequestHandler), (previous, handler) =>
                {
                    handler.SetSuccessor(previous);
                    return handler;
                });
            firstUserRequestHandler.HandleRequest(new UserRequest {Command = "dim", Argument = "3,3"});
        }
    }
}