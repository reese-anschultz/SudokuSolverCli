﻿using System;
using System.ComponentModel.Composition;
using SudokuSolverCli.Views;

namespace SudokuSolverCli.UserRequestHandlers
{
    internal class ApplicationUnhandledUserRequestHandler : UserRequestHandler
    {
        private ApplicationUnhandledUserRequestHandler(ApplicationView _) : base("")
        {
        }

        public override int Ordinal { get; } = int.MaxValue;    // Indicate this should be last command handler

        protected override bool Test(UserRequest _) // Handle ALL requests
        {
            return true;
        }

        protected override void ReallyHandleRequest(UserRequest request)
        {
            Console.WriteLine($"Unknown command '{request.Command}'");
        }

        [Export(typeof(UserRequestHandlerFactory<ApplicationView>))]
        public static UserRequestHandler UnhandledUserRequestHandlerFactory(ApplicationView applicationView)
        {
            return new ApplicationUnhandledUserRequestHandler(applicationView);
        }
    }
}