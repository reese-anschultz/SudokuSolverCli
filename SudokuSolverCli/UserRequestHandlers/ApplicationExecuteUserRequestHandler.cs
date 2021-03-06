﻿using System;
using System.ComponentModel.Composition;
using System.IO;
using SudokuSolverCli.Views;

namespace SudokuSolverCli.UserRequestHandlers
{
    internal class ApplicationExecuteUserRequestHandler : UserRequestHandler
    {
        private readonly ApplicationView _applicationView;

        private ApplicationExecuteUserRequestHandler(ApplicationView applicationView) : base("execute")
        {
            _applicationView = applicationView;
        }

        protected override void ReallyHandleRequest(UserRequest request)
        {
            try
            {
                using (var textReader = File.OpenText(request.Argument))
                {
                    _applicationView.HandleUserRequestsFromTextReader(textReader);
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e);
            }
        }

        [Export(typeof(UserRequestHandlerFactory<ApplicationView>))]
        public static UserRequestHandler ExecuteUserRequestsFromFileUserRequestHandlerFactory(ApplicationView applicationView)
        {
            return new ApplicationExecuteUserRequestHandler(applicationView);
        }
    }
}