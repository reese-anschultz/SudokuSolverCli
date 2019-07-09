using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;

namespace SudokuSolverCli
{
    public abstract class UserRequestHandler : ChainOfResponsibilityHandlerWithPredicate<UserRequest>
    {
        public delegate UserRequestHandler UserRequestHandlerFactory();
        public delegate UserRequestHandler UserRequestHandlerFactory<in T1>(T1 argument1);
        public delegate UserRequestHandler UserRequestHandlerFactory<in T1, in T2>(T1 argument1, T2 argument2);

        public virtual int Ordinal { get; } = 0;

        private readonly string _command;

        protected UserRequestHandler(string command)
        {
            _command = command;
        }

        public override string ToString()
        {
            return _command;
        }

        protected override bool Test(UserRequest request)
        {
            return string.Equals(request.Command, _command, StringComparison.InvariantCultureIgnoreCase);
        }

        public static IEnumerable<UserRequestHandler> ComposeUserRequestHandlers(CompositionContainer container)
        {
            return container.GetExportedValues<UserRequestHandlerFactory>().Select(factory => factory());
        }

        public static IEnumerable<UserRequestHandler> ComposeUserRequestHandlers<T1>(CompositionContainer container, T1 argument1)
        {
            return container.GetExportedValues<UserRequestHandlerFactory<T1>>().Select(factory => factory(argument1));
        }

        public static IEnumerable<UserRequestHandler> ComposeUserRequestHandlers<T1, T2>(CompositionContainer container, T1 argument1, T2 argument2)
        {
            return container.GetExportedValues<UserRequestHandlerFactory<T1, T2>>().Select(factory => factory(argument1, argument2));
        }
    }
}
