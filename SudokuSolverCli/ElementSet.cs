using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SudokuSolverCli
{
    internal class ElementSet : HashSet<Element>
    {
        private ElementSet(IEnumerable<Element> collection) : base(collection)
        {
        }

        public static ElementSet MakeElementSet(uint count)
        {
            return new ElementSet(EnumerableElementNames(count).Select(name => new Element(name)));
        }

        private static IEnumerable<string> EnumerableElementNames(uint count)
        {
            var currentChar = '1';
            while (count > 0 && currentChar < '9' + 1)
            {
                yield return currentChar.ToString();
                ++currentChar;
                --count;
            }

            if (count > 0)
            {
                yield return '0'.ToString();
                --count;
            }

            currentChar = 'A';
            while (count > 0 && currentChar < 'Z' + 1)
            {
                yield return currentChar.ToString();
                ++currentChar;
                --count;
            }

            currentChar = 'a';
            while (count > 0 && currentChar < 'z' + 1)
            {
                yield return currentChar.ToString();
                ++currentChar;
                --count;
            }

            Debug.Assert(count == 0);
        }
    }
}