using System.IO;

namespace SudokuSolverCli
{
    public static class TextReaderExtensions
    {
        public static bool TryReadLine(this TextReader textReader, out string line)
        {
            return (line = textReader.ReadLine()) != null;
        }
    }
}