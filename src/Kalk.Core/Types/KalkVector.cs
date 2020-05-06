using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using MathNet.Numerics.LinearAlgebra.Storage;
using Scriban;
using Scriban.Helpers;
using Scriban.Parsing;
using Scriban.Runtime;
using Scriban.Syntax;

namespace Kalk.Core
{
    public abstract class KalkVector
    {
        public abstract int Length { get; }
    }


    public class KalkVector<T> : KalkVector, IKalkTransformable, IFormattable, IList, IScriptObject, IEquatable<KalkVector<T>>, IKalkVectorObject<T>, IScriptCustomType where T: struct, IEquatable<T>, IFormattable
    {
        private const int x_IndexOffset = 2;
        private readonly T[] _values;

        public KalkVector(int dimension)
        {
            if (dimension <= 0) throw new ArgumentOutOfRangeException(nameof(dimension));
            _values = new T[dimension];
        }

        public KalkVector(IList<T> list)
        {
            _values = list.ToArray();
        }

        public KalkVector(KalkVector<T> values)
        {
            _values = (T[])values._values.Clone();
        }

        public override int Length => _values.Length;

        public Type ElementType => typeof(T);

        public new T this[int index]
        {
            get => _values[index];
            set => _values[index] = value;
        }


        public object GetElement(int index)
        {
            return _values[index];
        }

        public void SetElement(int index, object value)
        {
            _values[index] = (T)value;
        }

        public KalkVector<T> Clone()
        {
            return new KalkVector<T>(this);
        }

        public IScriptObject Clone(bool deep)
        {
            return Clone();
        }

        public object Transform(Func<T, T> apply)
        {
            var newValue = Clone();
            for (int i = 0; i < Length; i++)
            {
                var result = apply(_values[i]);
                newValue._values[i] = (T)result;
            }
            return newValue;
        }

        public object Transform(TemplateContext context, SourceSpan span, Func<double, double> apply)
        {
            return this.Transform(value =>
            {
                var valueDouble = context.ToObject<double>(span, value);
                var result = apply(valueDouble);
                return context.ToObject<T>(span, result);
            });
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            var context = formatProvider as TemplateContext;
            var builder = new StringBuilder();
            builder.Append(typeof(T).ScriptPrettyName()).Append(Length.ToString(CultureInfo.InvariantCulture));
            builder.Append('(');
            for(int i = 0; i < Length; i++)
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

        public int Count => Length;
        public bool IsSynchronized => ((ICollection) _values).IsSynchronized;

        public object SyncRoot => ((ICollection) _values).SyncRoot;

        public IEnumerable<string> GetMembers()
        {
            if (_values == null) yield break;

            for(int i = 0; i < Length; i++)
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

        public int Add(object value)
        {
            return ((IList) _values).Add(value);
        }

        public void Clear()
        {
            Array.Clear(_values, 0, _values.Length);
        }

        public bool Contains(object value)
        {
            return ((IList) _values).Contains(value);
        }

        public int IndexOf(object value)
        {
            return ((IList) _values).IndexOf(value);
        }

        public void Insert(int index, object value)
        {
            ((IList) _values).Insert(index, value);
        }

        public void Remove(object value)
        {
            ((IList) _values).Remove(value);
        }

        public void RemoveAt(int index)
        {
            ((IList) _values).RemoveAt(index);
        }

        public bool IsFixedSize => ((IList) _values).IsFixedSize;

        public bool IsReadOnly
        {
            get => false;
        }

        bool IScriptObject.IsReadOnly
        {
            get => false;
            set => throw new InvalidOperationException("Cannot set this instance readonly");
        }

        object IList.this[int index]
        {
            get => ((IList) _values)[index];
            set => ((IList) _values)[index] = value;
        }

        public bool TryGetValue(TemplateContext context, SourceSpan span, string member, out object result)
        {
            result = null;
            if (_values == null) return false;

            if (member.Length < 1) return false;
            List<T> list = null;
            foreach (var index in ForEachMemberPart(span, member, true))
            {
                var value = index <= 1 ? context.ToObject<T>(span, index): _values[index - x_IndexOffset];

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
                result = new KalkVector<T>(list);
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
                    case '0':
                        index = 0;
                        break;
                    case '1':
                        index = 1;
                        break;
                    case 'x':
                        index = x_IndexOffset;
                        break;
                    case 'y':
                        index = 3;
                        break;
                    case 'z':
                        index = 4;
                        break;
                    case 'w':
                        index = 5;
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

                if (index - x_IndexOffset < Length)
                {
                    yield return index;
                }
                else
                {
                    if (throwIfInvalid)
                    {
                        throw new ScriptRuntimeException(span, $"Swizzle swizzle {c} is out of range ({index}) for this vector length ({Length})");
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
                if (index <= 1) throw new ScriptRuntimeException(span, $"Swizzle with 0 or 1 are not supporting when setting values");
                _values[index - x_IndexOffset] = tValue;
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
            var leftVector = leftValue as KalkVector<T>;
            var rightVector = rightValue as KalkVector<T>;
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
                    var opResult = new KalkVector<T>(leftVector.Length);
                    for (int i = 0; i < opResult.Length; i++)
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

        public bool Equals(KalkVector<T> other)
        {
            return _values.Equals(other._values);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((KalkVector<T>) obj);
        }

        public override int GetHashCode()
        {
            return _values.GetHashCode();
        }


        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable) _values).GetEnumerator();
        }

        public bool TryEvaluate(TemplateContext context, SourceSpan span, ScriptUnaryOperator op, object rightValue, out object result)
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(KalkVector<T> left, KalkVector<T> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(KalkVector<T> left, KalkVector<T> right)
        {
            return !Equals(left, right);
        }
    }
}