﻿using SudokuSolverCli.Commands;
using SudokuSolverCli.Views;
using System.ComponentModel.Composition;

namespace SudokuSolverCli.UserRequestHandlers
{
    public class BoardUserRequestHandler : UserRequestHandler
    {
        private readonly ApplicationView _applicationView;

        private BoardUserRequestHandler(ApplicationView applicationView) : base("board")
        {
            _applicationView = applicationView;
        }

        protected override void ReallyHandleRequest(UserRequest request)
        {
            new ApplicationBoardCommand(_applicationView, request.Argument).Execute();
        }

        [Export(typeof(UserRequestHandlerFactory<ApplicationView>))]
        public static UserRequestHandler BoardUserRequestHandlerFactory(ApplicationView applicationView)
        {
            return new BoardUserRequestHandler(applicationView);
        }
    }
}
