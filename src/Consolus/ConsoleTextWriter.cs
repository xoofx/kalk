using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace Consolus
{
    public class ConsoleTextWriter : TextWriter
    {
        private char[] _buffer;
        private int _count;

        public ConsoleTextWriter(TextWriter writer)
        {
            Backend = writer ?? throw new ArgumentNullException(nameof(writer));
            _buffer = new char[4096];
        }

        public override Encoding Encoding => Backend.Encoding;

        public TextWriter Backend { get; }

        public void WriteBatch()
        {
            Backend.Write(_buffer, 0, _count);
            _count = 0;
        }

        public override void Write(char[] buffer, int index, int count)
        {
            EnsureCapacity(_count + count);
            Array.Copy(buffer, index, _buffer, _count, count);
            _count += count;
        }

        public override void Write(string value)
        {
            if (value == null) return;
            EnsureCapacity(_count + value.Length);
            value.CopyTo(0, _buffer, _count, value.Length);
            _count += value.Length;
        }

        public override void Write(char value)
        {
            WriteInternal(value);
        }

        private void EnsureCapacity(int min)
        {
            if (_buffer.Length < min)
            {
                int newCapacity = _buffer.Length * 2;
                // Allow the list to grow to maximum possible capacity (~2G elements) before encountering overflow.
                // Note that this check works even when _items.Length overflowed thanks to the (uint) cast
                if ((uint)newCapacity > int.MaxValue) newCapacity = int.MaxValue;
                if (newCapacity < min) newCapacity = min;

                var newBuffer  = new char[newCapacity];
                if (_count > 0)
                {
                    Array.Copy(_buffer, 0,newBuffer, 0, _count);
                }
                _buffer = newBuffer;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void WriteInternal(char value)
        {
            var newCount = _count + 1;
            if (_buffer.Length < newCount)
            {
                EnsureCapacity(newCount);
            }
            _buffer[_count] = value;
            _count++;
        }
    }
}