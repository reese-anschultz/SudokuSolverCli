﻿using System;
using System.ComponentModel.Composition;

namespace SudokuSolverCli.UserRequestHandlers
{
    public class BoardElementsUserRequestHandler : UserRequestHandler
    {
        private readonly Board _board;

        private BoardElementsUserRequestHandler(Board board) : base("elements")
        {
            _board = board;
        }

        protected override void ReallyHandleRequest(UserRequest request)
        {
            Console.WriteLine(string.Join(", ", _board.CompleteElementSet));
        }

        [Export(typeof(UserRequestHandlerFactory<Board>))]
        public static UserRequestHandler ElementsUserRequestHandlerFactory(Board board)
        {
            return new BoardElementsUserRequestHandler(board);
        }
    }
}