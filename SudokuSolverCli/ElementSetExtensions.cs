using System.Collections.Generic;
using System.Linq;

namespace SudokuSolverCli
{
    public static class ElementSetExtensions
    {
        public static ElementSet Remove(this ElementSet original, IEnumerable<Element> values)
        {
            return values.Aggregate(original, (aggregate, value) => aggregate.Remove(value));
        }
    }
}
