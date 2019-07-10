﻿using System;
using System.ComponentModel.Composition;
using System.Linq;

namespace SudokuSolverCli.UserRequestHandlers
{
    internal class HelpUserRequestHandler : UserRequestHandler
    {
        private HelpUserRequestHandler() : base("help")
        {
        }

        protected override void ReallyHandleRequest(UserRequest request)
        {
            Program.ApplicationView.UserRequestHandlers
                .Where(handler => !string.IsNullOrEmpty(handler.ToString()))
                .OrderBy(handler => handler.ToString())
                .ToList().ForEach(Console.WriteLine);
        }

        [Export(typeof(UserRequestHandlerFactory))]
        public static UserRequestHandler HelpUserRequestHandlerFactory()
        {
            return new HelpUserRequestHandler();
        }
    }
}