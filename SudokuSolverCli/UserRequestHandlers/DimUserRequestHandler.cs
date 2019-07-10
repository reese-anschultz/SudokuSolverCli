﻿using System;
using System.ComponentModel.Composition;
using System.Linq;

namespace SudokuSolverCli.UserRequestHandlers
{
    public class DimUserRequestHandler : UserRequestHandler
    {
        private DimUserRequestHandler() : base("dim")
        {
        }

        protected override void ReallyHandleRequest(UserRequest request)
        {
            var argument = request.Argument;
            var arguments = argument.Split(',');
            if (arguments.Length != 2)
            {
                Console.WriteLine("Expected two arguments");
                return;
            }

            uint[] sizes;
            try
            {
                sizes = arguments.Select(uint.Parse).ToArray();
            }
            catch (FormatException e)
            {
                Console.WriteLine(e);
                return;
            }

            Program.Board = new Board(sizes[0], sizes[1]);
        }

        [Export(typeof(UserRequestHandlerFactory))]
        public static UserRequestHandler SetDimensionsUserRequestHandlerFactory()
        {
            return new DimUserRequestHandler();
        }
    }
}