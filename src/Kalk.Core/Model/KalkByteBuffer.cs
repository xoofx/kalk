using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Scriban;
using Scriban.Helpers;
using Scriban.Parsing;
using Scriban.Syntax;

namespace Kalk.Core
{
    public class KalkByteBuffer : IList<byte>, IList, IScriptCustomBinaryOperation, IScriptCustomTypeInfo, IKalkSpannable
    {
        private readonly byte[] _buffer;
        private readonly int _offset;
        private readonly int _length;
        private GCHandle _lock;
        
        public KalkByteBuffer(int size)
        {
            if (size < 0) throw new ArgumentOutOfRangeException(nameof(size));
            _buffer = new byte[size];
            _offset = 0;
            _length = size;
        }

        public KalkByteBuffer(byte[] buffer)
        {
            _buffer = buffer ?? throw new ArgumentNullException(nameof(buffer));
            _offset = 0;
            _length = buffer.Length;
        }

        private  KalkByteBuffer(byte[] buffer, int offset, int length)
        {
            _buffer = buffer;
            _offset = offset;
            _length = length;
        }

        public string TypeName => "buffer";

        public IntPtr Lock()
        {
            if (!_lock.IsAllocated)
            {
                _lock = GCHandle.Alloc(_buffer, GCHandleType.Pinned);
            }
            
            return IntPtr.Add(_lock.AddrOfPinnedObject(), _offset);
        }

        public void Unlock()
        {
            if (_lock.IsAllocated)
            {
                _lock.Free();
                _lock = default;
            }
        }
        
        public KalkByteBuffer(IEnumerable<byte> buffer)
        {
            _buffer = new List<byte>(buffer).ToArray();
            _offset = 0;
            _length = _buffer.Length;
        }

        public KalkByteBuffer Slice(int index)
        {
            AssertIndex(index);
            return Slice(index, _length - index);
        }
        
        public KalkByteBuffer Slice(int index, int length)
        {
            AssertIndex(index);
            if (length < 0) throw new ArgumentOutOfRangeException(nameof(length));
            if ((uint)(length + index) > (uint)_length) throw new ArgumentOutOfRangeException($"End of slice {index + length - 1} is out of range ({_length}).");

            return new KalkByteBuffer(_buffer, _offset + index, length);
        }
        
        public IEnumerator<byte> GetEnumerator()
        {
            for (int i = 0; i < _length; i++)
            {
                yield return _buffer[_offset + i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < _length; i++)
            {
                yield return _buffer[_offset + i];
            }            
        }
        
        public void Add(byte item) => throw new NotSupportedException("Cannot add to a fixed buffer");

        int IList.Add(object? value) => throw new NotSupportedException("Cannot add to a fixed buffer"); 

        public void Clear()
        {
            Array.Clear(_buffer, _offset, _length);
        }

        bool IList.Contains(object? value)  => throw new NotImplementedException();

        int IList.IndexOf(object? value) => throw new NotImplementedException();

        void IList.Insert(int index, object? value) => throw new NotSupportedException("Cannot add to a fixed buffer");

        void IList.Remove(object? value) => throw new NotSupportedException("Cannot remove from a fixed buffer");

        public bool Contains(byte item)
        {
            return IndexOf(item) >= 0;
        }

        public void CopyTo(byte[] array, int arrayIndex)
        {
            _buffer.AsSpan(_offset, _length).CopyTo(new Span<byte>(array, arrayIndex, array.Length - arrayIndex));
        }

        public bool Remove(byte item) => throw new NotSupportedException("Cannot remove from a fixed buffer");

        void ICollection.CopyTo(Array array, int index)
        {
            for (int i = 0; i < _length; i++)
            {
                array.SetValue(index + i, _buffer[_offset + i]);
            }
        }

        public int Count => _length;
        
        bool ICollection.IsSynchronized => _buffer.IsSynchronized;

        object ICollection.SyncRoot => _buffer.SyncRoot;

        public bool IsReadOnly => _buffer.IsReadOnly;
        
        object? IList.this[int index]
        {
            get
            {
                AssertIndex(index);
                return _buffer[_offset + index];
            }
            set
            {
                AssertIndex(index);
                if (value is byte tValue)
                {
                    this[_offset + index] = tValue;
                }
                else
                {
                    this[_offset + index] = Convert.ToByte(value);
                }
            }
        }

        public int IndexOf(byte item)
        {
            return Array.IndexOf(_buffer, item, _offset, _length) - _offset;
        }

        public void Insert(int index, byte item) => throw new NotSupportedException("Cannot add to a fixed buffer");

        public void RemoveAt(int index) => throw new NotSupportedException("Cannot remove from a fixed buffer");

        bool IList.IsFixedSize => true;

        public byte this[int index]
        {
            get
            {
                AssertIndex(index);
                return _buffer[_offset + index];
            }
            set
            {
                AssertIndex(index);
                _buffer[_offset + index] = value;  
            } 
        }

        private void AssertIndex(int index)
        {
            if ((uint)index >= (uint)_length) throw new ArgumentOutOfRangeException($"Index {index} is out of range ({_length}).");   
        }

        public bool TryEvaluate(TemplateContext context, SourceSpan span, ScriptBinaryOperator op, SourceSpan leftSpan, object leftValue, SourceSpan rightSpan, object rightValue, out object result)
        {
            result = null;
            var leftArray = TryGetArray(leftValue);
            var rightArray = TryGetArray(rightValue);
            int intModifier = 0;
            var intSpan = leftSpan;

            var errorSpan = span;
            string reason = null;
            switch (op)
            {
                case ScriptBinaryOperator.BinaryOr:
                case ScriptBinaryOperator.BinaryAnd:
                case ScriptBinaryOperator.CompareEqual:
                case ScriptBinaryOperator.CompareNotEqual:
                case ScriptBinaryOperator.CompareLessOrEqual:
                case ScriptBinaryOperator.CompareGreaterOrEqual:
                case ScriptBinaryOperator.CompareLess:
                case ScriptBinaryOperator.CompareGreater:
                    break;
                case ScriptBinaryOperator.Multiply:
                    if (leftArray == null && rightArray == null || leftArray != null && rightArray != null)
                    {
                        reason = " Expecting only one array for the left or right argument.";
                    }
                    else
                    {
                        intModifier = context.ToInt(span, leftArray == null ? leftValue : rightValue);
                        if (rightArray == null) intSpan = rightSpan;
                    }
                    break;
                case ScriptBinaryOperator.Add:
                case ScriptBinaryOperator.Divide:
                case ScriptBinaryOperator.DivideRound:
                case ScriptBinaryOperator.Modulus:
                    if (leftArray == null)
                    {
                        errorSpan = leftSpan;
                        reason = " Expecting an array for the left argument.";
                    }
                    else
                    {
                        intModifier = context.ToInt(span, rightValue);
                        intSpan = rightSpan;
                    }
                    break;
                case ScriptBinaryOperator.ShiftLeft:
                case ScriptBinaryOperator.ShiftRight:
                    reason = " Cannot modify a fixed buffer.";
                    break;
                default:
                    reason = string.Empty;
                    break;
            }

            if (intModifier < 0)
            {
                errorSpan = intSpan;
                reason = $" Integer {intModifier} cannot be negative when multiplying";
            }

            if (reason != null)
            {
                throw new ScriptRuntimeException(errorSpan, $"The operator `{op.ToText()}` is not supported between {leftValue?.GetType().ScriptPrettyName()} and {rightValue?.GetType().ScriptPrettyName()}.{reason}");
            }

            switch (op)
            {
                case ScriptBinaryOperator.BinaryOr:
                    result = new KalkByteBuffer(leftArray.Union(rightArray));
                    return true;

                case ScriptBinaryOperator.BinaryAnd:
                    result = new KalkByteBuffer(leftArray.Intersect(rightArray));
                    return true;

                case ScriptBinaryOperator.Add:
                    try
                    {
                        result = Slice(intModifier);
                    }
                    catch (Exception ex)
                    {
                        throw new ScriptRuntimeException(errorSpan, $"Cannot shift pointer array at index {intModifier}. Reason: {ex.Message}");
                    }
                    return true;

                case ScriptBinaryOperator.CompareEqual:
                case ScriptBinaryOperator.CompareNotEqual:
                case ScriptBinaryOperator.CompareLessOrEqual:
                case ScriptBinaryOperator.CompareGreaterOrEqual:
                case ScriptBinaryOperator.CompareLess:
                case ScriptBinaryOperator.CompareGreater:
                    result = CompareTo(context, span, op, leftArray, rightArray);
                    return true;

                case ScriptBinaryOperator.Multiply:
                {
                    // array with integer
                    var array = leftArray ?? rightArray;
                    if (intModifier == 0)
                    {
                        result = new KalkByteBuffer(0);
                        return true;
                    }

                    var newArray = new List<byte>(array);
                    for (int i = 0; i < intModifier; i++)
                    {
                        newArray.AddRange(array);
                    }

                    result = new KalkByteBuffer(newArray);
                    return true;
                }

                case ScriptBinaryOperator.Divide:
                case ScriptBinaryOperator.DivideRound:
                {
                    // array with integer
                    var array = leftArray ?? rightArray;
                    if (intModifier == 0) throw new ScriptRuntimeException(intSpan, "Cannot divide by 0");

                    var newLength = array.Count / intModifier;
                    var newArray = new List<byte>(newLength);
                    for (int i = 0; i < newLength; i++)
                    {
                        newArray.Add(array[i]);
                    }

                    result = new KalkByteBuffer(newArray);
                    return true;
                }

                case ScriptBinaryOperator.Modulus:
                {
                    // array with integer
                    var array = leftArray ?? rightArray;
                    if (intModifier == 0) throw new ScriptRuntimeException(intSpan, "Cannot divide by 0");

                    var newArray = new List<byte>(array.Count);
                    for (int i = 0; i < array.Count; i++)
                    {
                        if ((i % intModifier) == 0)
                        {
                            newArray.Add(array[i]);
                        }
                    }

                    result = new KalkByteBuffer(newArray);
                    return true;
                }
            }

            return false;
        }

        private static IList<byte> TryGetArray(object rightValue)
        {
            var rightArray = rightValue as IList<byte>;
            return rightArray;
        }

        private static bool CompareTo(TemplateContext context, SourceSpan span, ScriptBinaryOperator op, IList<byte> left, IList<byte> right)
        {
            // Compare the length first
            var compare = left.Count.CompareTo(right.Count);
            switch (op)
            {
                case ScriptBinaryOperator.CompareEqual:
                    if (compare != 0) return false;
                    break;
                case ScriptBinaryOperator.CompareNotEqual:
                    if (compare != 0) return true;
                    if (left.Count == 0) return false;
                    break;
                case ScriptBinaryOperator.CompareLessOrEqual:
                case ScriptBinaryOperator.CompareLess:
                    if (compare < 0) return true;
                    if (compare > 0) return false;
                    if (left.Count == 0 && op == ScriptBinaryOperator.CompareLess) return false;
                    break;
                case ScriptBinaryOperator.CompareGreaterOrEqual:
                case ScriptBinaryOperator.CompareGreater:
                    if (compare < 0) return false;
                    if (compare > 0) return true;
                    if (left.Count == 0 && op == ScriptBinaryOperator.CompareGreater) return false;
                    break;
                default:
                    throw new ScriptRuntimeException(span, $"The operator `{op.ToText()}` is not supported between {left?.GetType().ScriptPrettyName()} and {right?.GetType().ScriptPrettyName()}.");
            }

            // Otherwise we need to compare each element
            for (int i = 0; i < left.Count; i++)
            {
                var result = (bool) ScriptBinaryExpression.Evaluate(context, span, op, left[i], right[i]);
                if (!result)
                {
                    return false;
                }
            }

            return true;
        }

        public Span<byte> AsSpan()
        {
            return new Span<byte>(_buffer, _offset, _length);
        }
    }
}