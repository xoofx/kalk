using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
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
    public abstract class KalkVector : KalkNumber
    {
        public abstract int Length { get; }

        public abstract object GetComponent(int index);
        
    }
    
    public class KalkVector<T> : KalkVector, IScriptTransformable, IFormattable, IList, IScriptObject, IEquatable<KalkVector<T>>, IKalkVectorObject<T>, IScriptCustomType where T: struct, IEquatable<T>, IFormattable
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

        public override object GetComponent(int index)
        {
            return _values[index];
        }

        public override string Kind => $"{typeof(T).ScriptPrettyName()}{Length.ToString(CultureInfo.InvariantCulture)}";
        
        public Type ElementType => typeof(T);

        public T this[int index]
        {
            get => _values[index];
            set => SetComponent(index, value);
        }

        object IList.this[int index]
        {
            get => this[index];
            set => this[index] = (T)value;
        }
        
        public object GetElement(int index)
        {
            return _values[index];
        }

        public void SetElement(int index, object value)
        {
            this[index] = (T)value;
        }

        protected virtual void SetComponent(int index, T value)
        {
            _values[index] = value;
        }

        public virtual KalkVector<T> Clone()
        {
            return new KalkVector<T>(this);
        }

        public override IScriptObject Clone(bool deep)
        {
            return Clone();
        }

        public bool CanTransform(Type transformType)
        {
            return typeof(T) == typeof(int) && (typeof(long) == transformType || typeof(int) == transformType) ||
                   (typeof(T) == typeof(float) && (typeof(double) == transformType || typeof(float) == transformType) ||
                    typeof(T) == typeof(double) && typeof(double) == transformType);
        }

        public object Transform(Func<T, T> apply)
        {
            var newValue = Clone();
            for (int i = 0; i < Length; i++)
            {
                var result = apply(_values[i]);
                newValue[i] = (T)result;
            }
            return newValue;
        }

        public object Transform(TemplateContext context, SourceSpan span, Func<object, object> apply)
        {
            return this.Transform(value =>
            {
                var result = apply(value);
                return context.ToObject<T>(span, result);
            });
        }

        public virtual string ToString(string format, IFormatProvider formatProvider)
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

        public override int Count => Length;

        public bool IsSynchronized => ((ICollection) _values).IsSynchronized;

        public object SyncRoot => ((ICollection) _values).SyncRoot;

        public override IEnumerable<string> GetMembers()
        {
            for (int i = 0; i < Math.Min(4, Length); i++)
            {
                switch (i)
                {
                    case 0:
                        yield return "x";
                        break;
                    case 1:
                        yield return "y";
                        break;
                    case 2:
                        yield return "z";
                        break;
                    case 3:
                        yield return "w";
                        break;
                }
            }
        }

        public override bool Contains(string member)
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

        public int Add(object value) => throw new NotSupportedException();

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

        public void Insert(int index, object value) => throw new NotSupportedException();
        
        public void Remove(object value) => throw new NotSupportedException();

        public void RemoveAt(int index) => throw new NotSupportedException();

        public bool IsFixedSize => true;

        public override bool IsReadOnly
        {
            get => false;
            set => throw new InvalidOperationException("Cannot set this instance readonly");
        }

        public override bool TryGetValue(TemplateContext context, SourceSpan span, string member, out object result)
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
                result = NewVector(list);
            }

            return true;
        }

        protected virtual KalkVector<T> NewVector(IList<T> list) => new KalkVector<T>(list);
        
        private enum ComponentUsed
        {
            none,
            rgba,
            xyzw,
        }


        private static ScriptRuntimeException InvalidMixOfSwizzles(SourceSpan span, ComponentUsed used, char c)
        {
            return new ScriptRuntimeException(span, $"Cannot mix the swizzle `{c}` with swizzles in the domain {used}.");
        }

        private ScriptRuntimeException InvalidUsageOfXYZW(SourceSpan span, char c)
        {
            return new ScriptRuntimeException(span, $"The swizzle `{c}` is not supported by this {Kind} type.");
        }
        
        private IEnumerable<int> ForEachMemberPart(SourceSpan span, string member, bool throwIfInvalid)
        {
            var componentUsed = ComponentUsed.none;
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
                        if (componentUsed == ComponentUsed.rgba) throw InvalidMixOfSwizzles(span, componentUsed, c);
                        componentUsed = ComponentUsed.xyzw;
                        break;
                    case 'r':
                        index = x_IndexOffset;
                        if (componentUsed == ComponentUsed.xyzw) throw InvalidMixOfSwizzles(span, componentUsed, c);
                        componentUsed = ComponentUsed.rgba;
                        break;
                    case 'y':
                        index = x_IndexOffset + 1;
                        if (componentUsed == ComponentUsed.rgba) throw InvalidMixOfSwizzles(span, componentUsed, c);
                        componentUsed = ComponentUsed.xyzw;
                        break;
                    case 'g':
                        index = x_IndexOffset + 1;
                        if (componentUsed == ComponentUsed.xyzw) throw InvalidMixOfSwizzles(span, componentUsed, c);
                        componentUsed = ComponentUsed.rgba;
                        break;
                    case 'z':
                        index = x_IndexOffset + 2;
                        if (componentUsed == ComponentUsed.rgba) throw InvalidMixOfSwizzles(span, componentUsed, c);
                        componentUsed = ComponentUsed.xyzw;
                        break;
                    case 'b':
                        index = x_IndexOffset + 2;
                        if (componentUsed == ComponentUsed.xyzw) throw InvalidMixOfSwizzles(span, componentUsed, c);
                        componentUsed = ComponentUsed.rgba;
                        break;
                    case 'w':
                        index = x_IndexOffset + 2;
                        if (componentUsed == ComponentUsed.rgba) throw InvalidMixOfSwizzles(span, componentUsed, c);
                        componentUsed = ComponentUsed.xyzw;
                        break;
                    case 'a':
                        index = x_IndexOffset + 3;
                        if (componentUsed == ComponentUsed.xyzw) throw InvalidMixOfSwizzles(span, componentUsed, c);
                        componentUsed = ComponentUsed.rgba;
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

        public override bool CanWrite(string member)
        {
            return true;
        }

        public override bool TrySetValue(TemplateContext context, SourceSpan span, string member, object value, bool readOnly)
        {
            var tValue = context.ToObject<T>(span, value);

            // Verify access (TODO: could be more optimized for single element .x access)
            var bitArray = new BitArray(Count);
            var list = new List<int>(ForEachMemberPart(span, member, true));
            for (var i = 0; i < list.Count; i++)
            {
                var index = list[i];
                if (index <= 1) throw new ScriptRuntimeException(span, $"Swizzle with 0 or 1 are not supporting when setting values");
                int finalIndex = index - x_IndexOffset;
                if (bitArray[finalIndex]) throw new ScriptRuntimeException(span, $"Invalid duplicated swizzle `{member[i]}`");
                bitArray[finalIndex] = true;
            }

            foreach (var index in list)
            {
                this[index] = tValue;
            }

            return true;
        }

        public override bool Remove(string member) => throw new NotSupportedException();

        public override void SetReadOnly(string member, bool readOnly) => throw new NotSupportedException();


        public bool TryEvaluate(TemplateContext context, SourceSpan span, ScriptBinaryOperator op, SourceSpan leftSpan, object leftValue, SourceSpan rightSpan, object rightValue, out object result)
        {
            if (leftValue is KalkExpression leftExpression)
            {
                return leftExpression.TryEvaluate(context, span, op, leftSpan, leftValue, rightSpan, rightValue, out result);
            }
            if (rightValue is KalkExpression rightExpression)
            {
                return rightExpression.TryEvaluate(context, span, op, leftSpan, leftValue, rightSpan, rightValue, out result);
            }

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
                    var opResult = NewVector(leftVector.Length);
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

        protected virtual KalkVector<T> NewVector(int length) => new KalkVector<T>(length);

        public bool TryConvertTo(TemplateContext context, SourceSpan span, Type type, out object value)
        {
            value = null;
            return false;
        }

        public bool Equals(KalkVector<T> other)
        {
            if (other == null) return false;
            if (Length != other.Length) return false;
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
            return Equals((KalkVector<T>) obj);
        }

        public override int GetHashCode()
        {
            var values = _values;
            int hashCode = values.Length;
            for (int i = 0; i < values.Length; i++)
            {
                hashCode = (hashCode * 397) ^ values[i].GetHashCode();
            }
            return hashCode;
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