using System;
using System.Linq;

namespace SudokuSolverCli.Commands
{
    public class BoardPrintCommand : Command
    {
        private readonly Board _board;

        public BoardPrintCommand(Board board)
        {
            _board = board;
        }

        public override void Execute()
        {
            foreach (var rowElement in _board.CompleteElementSet)
                Console.WriteLine(string.Join(" ", _board
                    .CompleteElementSet
                    .Select(columnElement => _board.GetCell(columnElement, rowElement))
                    .Select(cell => (cell.CurrentElementSet.Count == 1 ? cell.CurrentElementSet.Single().ToString() : "."))));
        }
    }
}
