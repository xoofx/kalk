using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Numerics;
using CsvHelper;
using Scriban.Runtime;

namespace Kalk.Core.Helpers
{
    class KalkCsvReader : IEnumerable<ScriptArray>
    {
        private readonly Func<TextReader> _getReader;
        private readonly bool _readHeaders;

        public KalkCsvReader(Func<TextReader> getReader, bool readHeaders)
        {
            _getReader = getReader;
            _readHeaders = readHeaders;
        }

        public IEnumerator<ScriptArray> GetEnumerator()
        {
            return new CsvFileEnumerator(_getReader(), _readHeaders);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class CsvFileEnumerator : IEnumerator<ScriptArray>
        {
            private readonly bool _readHeader;
            private readonly TextReader _reader;
            private readonly CsvReader _csvReader;
            private readonly string[] _headers;

            public CsvFileEnumerator(TextReader reader, bool readHeader)
            {
                _readHeader = readHeader;
                _reader = reader;
                _csvReader = new CsvReader(_reader, CultureInfo.InvariantCulture);
                if (_readHeader && _csvReader.Read())
                {
                    if (_csvReader.ReadHeader())
                    {
                        _headers = _csvReader.Context.HeaderRecord;
                    }
                }
            }

            public bool MoveNext()
            {
                if (_csvReader.Read())
                {
                    var array = new ScriptArray();
                    Current = array;

                    var row = _csvReader.Context.Record;
                    if (row != null)
                    {
                        int columnCount = row?.Length ?? 0;

                        if (_headers != null)
                        {
                            for (int i = 0; i < columnCount; i++)
                            {
                                var cell = ParseCell(row[i]);
                                array.Add(cell);
                                if (i < _headers.Length)
                                {
                                    array.SetValue(_headers[i], cell, false);
                                }
                            }
                        }
                        else
                        {
                            for (int i = 0; i < columnCount; i++)
                            {
                                var cell = ParseCell(row[i]);
                                array.Add(cell);
                            }
                        }
                    }

                    return true;
                }

                return false;
            }

            private static object ParseCell(string cell)
            {
                if (int.TryParse(cell, out var intResult))
                {
                    return intResult;
                }
                if (long.TryParse(cell, out var longResult))
                {
                    return longResult;
                }
                if (BigInteger.TryParse(cell, out var bigIntResult))
                {
                    return bigIntResult;
                }
                if (double.TryParse(cell, out var result))
                {
                    return result;
                }
                if (DateTime.TryParse(cell, out var dateTime))
                {
                    return dateTime;
                }
                return cell;
            }

            public void Reset()
            {
                throw new InvalidOperationException("Reset not supported on csv reader");
            }

            public ScriptArray Current { get; private set; }

            object? IEnumerator.Current => Current;

            public void Dispose()
            {
                _csvReader.Dispose();
                _reader.Dispose();
            }
        }
    }
}