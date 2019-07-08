using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SudokuSolverCli
{
    public class ElementSet : HashSet<Element>
    {
        public ElementSet(IEnumerable<Element> collection) : base(collection)
        {
        }

        public bool TryParse(string name, out Element element)
        {
            element = this.FirstOrDefault(element1 => element1.ToString() == name);
            return element != default(Element);
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