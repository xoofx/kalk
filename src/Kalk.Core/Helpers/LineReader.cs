using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Kalk.Core.Helpers
{
    class LineReader : IEnumerable<string>
    {
        private readonly Func<TextReader> _getReader;

        public LineReader(Func<TextReader> getReader)
        {
            this._getReader = getReader;
        }

        public IEnumerator<string> GetEnumerator()
        {
            return new LineEnumerator(_getReader());
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class LineEnumerator : IEnumerator<string>
        {
            private readonly TextReader _reader;

            public LineEnumerator(TextReader reader)
            {
                _reader = reader;
            }

            public bool MoveNext()
            {
                Current = _reader.ReadLine();
                return Current != null;
            }

            public void Reset()
            {
                throw new NotSupportedException("Cannot reset a line reader");
            }

            public string Current { get; private set; }

            object? IEnumerator.Current => Current;

            public void Dispose()
            {
                _reader.Dispose();
            }
        }
    }
}