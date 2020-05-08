using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Scriban;
using Scriban.Helpers;
using Scriban.Parsing;
using Scriban.Runtime;
using Scriban.Syntax;

namespace Kalk.Core
{
    public abstract class KalkMatrix
    {
        protected KalkMatrix(int row, int column)
        {
            if (row <= 0) throw new ArgumentOutOfRangeException(nameof(row));
            if (column <= 0) throw new ArgumentOutOfRangeException(nameof(column));
            RowLength = row;
            ColumnLength = column;
        }

        public int RowLength { get; }

        public int ColumnLength { get; }
    }

    public class KalkMatrix<T> : KalkMatrix, IScriptTransformable, IFormattable, IList, IScriptObject, IEquatable<KalkMatrix<T>>, IKalkMatrixObject<T>, IScriptCustomType where T: struct, IEquatable<T>, IFormattable
    {
        private readonly T[] _values;

        public KalkMatrix(int row, int column) : base(row, column)
        {
            _values = new T[row * column];
        }

        public KalkMatrix(KalkMatrix<T> values) : base(values.RowLength, values.ColumnLength)
        {
            _values = (T[])values._values.Clone();
        }

        public T this[int index]
        {
            get => _values[index];
            set => _values[index] = value;
        }

        public KalkVector<T> GetRow(int index)
        {
            if ((uint)index >= (uint)RowLength) throw new ArgumentOutOfRangeException(nameof(index));

            var row = new KalkVector<T>(ColumnLength);
            for (int i = 0; i < ColumnLength; i++)
            {
                row[i] = _values[ColumnLength * index + i];
            }

            return row;
        }

        public void SetRow(int index, KalkVector<T> value)
        {
            if ((uint)index >= (uint)RowLength) throw new ArgumentOutOfRangeException(nameof(index));
            if (value == null) throw new ArgumentNullException(nameof(value));
            if (value.Length != ColumnLength) throw new ArgumentOutOfRangeException(nameof(value), $"Invalid vector size. The vector has a length of {value.Length} while the row of this matrix is expecting {ColumnLength} elements.");

            for (int i = 0; i < ColumnLength; i++)
            {
                _values[ColumnLength * index + i] = value[i];
            }
        }

        public KalkVector<T> GetColumn(int index)
        {
            if ((uint)index >= (uint)RowLength) throw new ArgumentOutOfRangeException(nameof(index));

            var column = new KalkVector<T>(RowLength);
            for (int i = 0; i < RowLength; i++)
            {
                column[i] = _values[ColumnLength * i + index];
            }

            return column;
        }

        public void SetColumn(int index, KalkVector<T> value)
        {
            if ((uint)index >= (uint)RowLength) throw new ArgumentOutOfRangeException(nameof(index));
            if (value == null) throw new ArgumentNullException(nameof(value));
            if (value.Length != RowLength) throw new ArgumentOutOfRangeException(nameof(value), $"Invalid vector size. The vector has a length of {value.Length} while the column of this matrix is expecting {RowLength} elements.");

            for (int i = 0; i < RowLength; i++)
            {
                _values[ColumnLength * i + index] = value[i];
            }
        }

        public KalkMatrix<T> Clone()
        {
            return new KalkMatrix<T>(this);
        }

        public IScriptObject Clone(bool deep)
        {
            return Clone();
        }

        public object Transform(Func<T, T> apply)
        {
            var newValue = Clone();
            for (int i = 0; i < _values.Length; i++)
            {
                var result = apply(_values[i]);
                newValue._values[i] = (T)result;
            }
            return newValue;
        }

        public Type ElementType => typeof(T);

        public bool CanTransform(Type transformType)
        {
            return typeof(T) == typeof(int) && (typeof(long) == transformType || typeof(int) == transformType) ||
                   (typeof(T) == typeof(float) && (typeof(double) == transformType || typeof(float) == transformType) ||
                    typeof(T) == typeof(double) && typeof(double) == transformType);
        }

        public object Transform(TemplateContext context, SourceSpan span, Func<object, object> apply)
        {
            return this.Transform(value =>
            {
                var result = apply(value);
                return context.ToObject<T>(span, result);
            });
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            var context = formatProvider as TemplateContext;
            var builder = new StringBuilder();
            builder.Append(typeof(T).ScriptPrettyName()).Append(RowLength.ToString(CultureInfo.InvariantCulture))
                .Append('x').Append(ColumnLength.ToString(CultureInfo.InvariantCulture));
            builder.Append('(');
            for(int i = 0; i < _values.Length; i++)
            {
                if (i > 0) builder.Append(", ");
                builder.Append(context != null ? context.ObjectToString(_values[i]) : _values[i].ToString(null, formatProvider));
            }
            builder.Append(')');
            return builder.ToString();
        }

        public void CopyTo(Array array, int index)
        {
            ((ICollection) _values).CopyTo(array, index);
        }

        public int Count => RowLength;

        public bool IsSynchronized => ((ICollection) _values).IsSynchronized;

        public object SyncRoot => ((ICollection) _values).SyncRoot;

        public IEnumerable<string> GetMembers()
        {
            if (_values == null) yield break;

            for(int i = 0; i < _values.Length; i++)
            {
                switch (i)
                {
                    case 0: yield return "x";
                        break;
                    case 1: yield return "y";
                        break;
                    case 2: yield return "z";
                        break;
                    case 3: yield return "w";
                        break;
                    default:
                        yield return $"{"xyzw"[i % 4]}{(i / 4 + 1).ToString(CultureInfo.InvariantCulture)}";
                        break;
                }
            }
        }

        public bool Contains(string member)
        {
            if (member.Length < 1) return false;

            var emptySpan = new SourceSpan();
            foreach (var index in ForEachMemberPart(emptySpan, member, false))
            {
                // We say that 0 or 1 are members as well
                if (index < 0) return false;
            }

            return true;
        }

        public int Add(object value) => throw new NotSupportedException("This type does not support this operation");

        public void Clear()
        {
            Array.Clear(_values, 0, _values.Length);
        }

        public bool Contains(object value) => throw new NotSupportedException("This type does not support this operation");

        public int IndexOf(object value) => throw new NotSupportedException("This type does not support this operation");

        public void Insert(int index, object value) => throw new NotSupportedException("This type does not support this operation");

        public void Remove(object value) => throw new NotSupportedException("This type does not support this operation");

        public void RemoveAt(int index) => throw new NotSupportedException("This type does not support this operation");
        
        public bool IsFixedSize => ((IList) _values).IsFixedSize;

        public bool IsReadOnly => false;

        bool IScriptObject.IsReadOnly
        {
            get => false;
            set => throw new InvalidOperationException("Cannot set this instance readonly");
        }

        object IList.this[int index]
        {
            get => GetRow(index);
            set => SetRow(index, (KalkVector<T>)value);
        }

        public bool TryGetValue(TemplateContext context, SourceSpan span, string member, out object result)
        {
            result = null;
            if (_values == null) return false;

            if (member.Length < 1) return false;
            List<T> list = null;
            foreach (var index in ForEachMemberPart(span, member, true))
            {
                var value = index < 0 ? context.ToObject<T>(span, index): _values[index];

                if (result == null)
                {
                    result = value;
                }
                else
                {
                    if (list == null)
                    {
                        list = new List<T>() { (T)result };
                    }
                    list.Add(value);
                }
            }

            if (list != null)
            {
                //result = new KalkMatrix<T>(list);
            }

            return true;
        }


        private IEnumerable<int> ForEachMemberPart(SourceSpan span, string member, bool throwIfInvalid)
        {
            for (int i = 0; i < member.Length; i++)
            {
                var c = member[i];
                int index;
                switch (c)
                {
                    case 'x':
                        index = 0;
                        break;
                    case 'y':
                        index = 1;
                        break;
                    case 'z':
                        index = 2;
                        break;
                    case 'w':
                        index = 3;
                        break;
                    default:
                        if (throwIfInvalid)
                        {
                            throw new ScriptRuntimeException(span, $"Invalid swizzle {c}. Expecting only x,y,z,w.");
                        }
                        else
                        {
                            index = -1;
                        }
                        break;
                }

                if (index < 0)
                {
                    yield return index;
                    break;
                }

                if (index < _values.Length)
                {
                    yield return index;
                }
                else
                {
                    if (throwIfInvalid)
                    {
                        throw new ScriptRuntimeException(span, $"Swizzle swizzle {c} is out of range ({index}) for this vector length ({RowLength})");
                    }
                    else
                    {
                        yield return -1;
                        break;
                    }
                }
            }
        }

        public bool CanWrite(string member)
        {
            return true;
        }

        public bool TrySetValue(TemplateContext context, SourceSpan span, string member, object value, bool readOnly)
        {
            var tValue = context.ToObject<T>(span, value);
            foreach (var index in ForEachMemberPart(span, member, true))
            {
                if (index < 0) throw new ScriptRuntimeException(span, $"Swizzle with 0 or 1 are not supporting when setting values");
                _values[index] = tValue;
            }

            return true;
        }

        public bool Remove(string member)
        {
            throw new InvalidOperationException($"Cannot remove member {member} for {this.GetType()}");
        }

        public void SetReadOnly(string member, bool readOnly)
        {
            throw new InvalidOperationException($"Cannot set readonly member {member} for {this.GetType()}");
        }

        public bool TryEvaluate(TemplateContext context, SourceSpan span, ScriptBinaryOperator op, SourceSpan leftSpan, object leftValue, SourceSpan rightSpan, object rightValue, out object result)
        {
            result = null;
            var leftVector = leftValue as KalkMatrix<T>;
            var rightVector = rightValue as KalkMatrix<T>;
            if (leftVector == null && rightVector == null) return false;
            
            switch (op)
            {
                case ScriptBinaryOperator.CompareEqual:
                    result = leftVector.Equals(rightVector);
                    return true;
                case ScriptBinaryOperator.CompareNotEqual:
                    result = !leftVector.Equals(rightVector);
                    return true;
                //case ScriptBinaryOperator.CompareLessOrEqual:
                //    break;
                //case ScriptBinaryOperator.CompareGreaterOrEqual:
                //    break;
                //case ScriptBinaryOperator.CompareLess:
                //    break;
                //case ScriptBinaryOperator.CompareGreater:
                //    break;
                //case ScriptBinaryOperator.LiquidContains:
                //    break;
                //case ScriptBinaryOperator.LiquidStartsWith:
                //    break;
                //case ScriptBinaryOperator.LiquidEndsWith:
                //    break;
                //case ScriptBinaryOperator.LiquidHasKey:
                //    break;
                //case ScriptBinaryOperator.LiquidHasValue:
                //    break;
                case ScriptBinaryOperator.Add:
                case ScriptBinaryOperator.Substract:
                case ScriptBinaryOperator.Multiply:
                {
                    var opResult = new KalkMatrix<T>(leftVector.RowLength, leftVector.ColumnLength);
                    for (int i = 0; i < opResult._values.Length; i++)
                    {
                        opResult[i] = context.ToObject<T>(span, ScriptBinaryExpression.Evaluate(context, span, op, leftVector[i], rightVector[i]));
                    }
                    result = opResult;
                    return true;
                }
                case ScriptBinaryOperator.Divide:
                    break;
                case ScriptBinaryOperator.DivideRound:
                    break;
                case ScriptBinaryOperator.Modulus:
                    break;
                case ScriptBinaryOperator.ShiftLeft:
                    break;
                case ScriptBinaryOperator.ShiftRight:
                    break;
                case ScriptBinaryOperator.Power:
                    break;
                case ScriptBinaryOperator.RangeInclude:
                    break;
                case ScriptBinaryOperator.RangeExclude:
                    break;
                case ScriptBinaryOperator.Custom:
                    break;
            }

            return false;
        }

        public bool TryConvertTo(TemplateContext context, SourceSpan span, Type type, out object value)
        {
            value = null;
            return false;
        }

        public bool Equals(KalkMatrix<T> other)
        {
            if (other == null) return false;
            if (RowLength != other.RowLength || ColumnLength != other.ColumnLength) return false;
            var values = _values;
            var otherValues = other._values;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i].Equals(otherValues[i])) return false;
            }

            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((KalkMatrix<T>) obj);
        }

        public override int GetHashCode()
        {
            var values = _values;
            int hashCode = (RowLength * 397) ^ ColumnLength;
            for (int i = 0; i < values.Length; i++)
            {
                hashCode = (hashCode * 397) ^ values[i].GetHashCode();
            }
            return hashCode;
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < RowLength; i++)
            {
                yield return GetRow(i);
            }
        }

        public bool TryEvaluate(TemplateContext context, SourceSpan span, ScriptUnaryOperator op, object rightValue, out object result)
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(KalkMatrix<T> left, KalkMatrix<T> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(KalkMatrix<T> left, KalkMatrix<T> right)
        {
            return !Equals(left, right);
        }
    }
}