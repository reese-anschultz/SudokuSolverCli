using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;

namespace SudokuSolverCli
{
    public class ElementSet : IEnumerable<Element>
    {
        private readonly IImmutableSet<Element> _immutableSetImplementation;

        public ElementSet(IEnumerable<Element> collection)
        {
            if (collection is IImmutableSet<Element> immutableSetImplementation)
                _immutableSetImplementation = immutableSetImplementation;
            else
                _immutableSetImplementation = ImmutableHashSet.CreateRange(collection);
        }

        public int Count => _immutableSetImplementation.Count;

        public IEnumerator<Element> GetEnumerator()
        {
            return _immutableSetImplementation.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) _immutableSetImplementation).GetEnumerator();
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

        public ElementSet Add(Element value)
        {
            return new ElementSet(_immutableSetImplementation.Add(value));
        }

        public ElementSet Clear()
        {
            return new ElementSet(_immutableSetImplementation.Clear());
        }

        public bool Contains(Element value)
        {
            return _immutableSetImplementation.Contains(value);
        }

        public ElementSet Except(IEnumerable<Element> other)
        {
            return new ElementSet(_immutableSetImplementation.Except(other));
        }

        public ElementSet Intersect(IEnumerable<Element> other)
        {
            return new ElementSet(_immutableSetImplementation.Intersect(other));
        }

        public bool IsProperSubsetOf(IEnumerable<Element> other)
        {
            return _immutableSetImplementation.IsProperSubsetOf(other);
        }

        public bool IsProperSupersetOf(IEnumerable<Element> other)
        {
            return _immutableSetImplementation.IsProperSupersetOf(other);
        }

        public bool IsSubsetOf(IEnumerable<Element> other)
        {
            return _immutableSetImplementation.IsSubsetOf(other);
        }

        public bool IsSupersetOf(IEnumerable<Element> other)
        {
            return _immutableSetImplementation.IsSupersetOf(other);
        }

        public bool Overlaps(IEnumerable<Element> other)
        {
            return _immutableSetImplementation.Overlaps(other);
        }

        public ElementSet Remove(Element value)
        {
            return new ElementSet(_immutableSetImplementation.Remove(value));
        }

        public bool SetEquals(IEnumerable<Element> other)
        {
            return _immutableSetImplementation.SetEquals(other);
        }

        public ElementSet SymmetricExcept(IEnumerable<Element> other)
        {
            return new ElementSet(_immutableSetImplementation.SymmetricExcept(other));
        }

        public bool TryGetValue(Element equalValue, out Element actualValue)
        {
            return _immutableSetImplementation.TryGetValue(equalValue, out actualValue);
        }

        public ElementSet Union(IEnumerable<Element> other)
        {
            return new ElementSet(_immutableSetImplementation.Union(other));
        }
    }
}