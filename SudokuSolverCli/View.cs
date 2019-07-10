using System.Collections.Generic;
using System.Linq;

namespace SudokuSolverCli
{
    public abstract class View
    {
        private IEnumerable<UserRequestHandler> _userRequestHandlers;
        public IEnumerable<UserRequestHandler> UserRequestHandlers
        {
            get => _userRequestHandlers;
            protected set
            {
                _firstUserRequestHandler = (_userRequestHandlers = value)
                    .OrderByDescending(handler => handler.Ordinal)
                    .Aggregate(default(UserRequestHandler),
                        (previous, handler) =>
                        {
                            handler.SetSuccessor(previous);
                            return handler;
                        });
            }
        }

        private UserRequestHandler _firstUserRequestHandler;

        protected View()
        {
            UserRequestHandlers = Enumerable.Empty<UserRequestHandler>();
        }

        public void HandleRequest(UserRequest userRequest)
        {
            _firstUserRequestHandler.HandleRequest(userRequest);
        }
    }
}
