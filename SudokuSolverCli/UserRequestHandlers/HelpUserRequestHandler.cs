﻿using System;
using System.ComponentModel.Composition;
using System.Linq;

namespace SudokuSolverCli.UserRequestHandlers
{
    [Export(typeof(UserRequestHandler))]
    internal class HelpUserRequestHandler : UserRequestHandler
    {
        public HelpUserRequestHandler() : base("help")
        {
        }

        protected override void ReallyHandleRequest(UserRequest request)
        {
            Program.UserRequestHandlers.OrderBy(handler => handler.ToString()).ToList().ForEach(Console.WriteLine);
        }
    }
}