using System.ComponentModel.Composition.Hosting;
using System.Linq;

namespace SudokuSolverCli
{
    public class BoardView : View
    {
        private readonly Board _board;
        public CompositionContainer Container { get; }
        public ElementSet CompleteElementSet => _board.CompleteElementSet;

        public BoardView(CompositionContainer container, Board board)
        {
            _board = board;
            Container = container;
            UserRequestHandlers = UserRequestHandler.ComposeUserRequestHandlers(container, this).Concat(UserRequestHandler.ComposeUserRequestHandlers(container, board));
        }

        public CellView GetCellView(Element column, Element row)
        {
            return new CellView(Container, _board.GetCell(column, row));
        }
    }
}
