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
    public abstract class KalkVector : KalkValue
    {
        public abstract int Length { get; }

        public abstract object GetComponent(int index);
        
    }

    public class KalkVector<T> : KalkVector, IScriptTransformable, IFormattable, IList, IScriptObject, IKalkVectorObject<T>, IScriptCustomType
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

        public KalkVector(T v1, T v2) => _values = new T[2] { v1, v2 };
        public KalkVector(T v1, T v2, T v3) => _values = new T[3] { v1, v2, v3 };
        public KalkVector(T v1, T v2, T v3, T v4) => _values = new T[4] { v1, v2, v3, v4 };

        public KalkVector(KalkVector<T> values)
        {
            _values = (T[])values._values.Clone();
        }

        public override int Length => _values.Length;

        public override object GetComponent(int index)
        {
            return _values[index];
        }

        public override string Kind => $"{ElementTypeName}{Length.ToString(CultureInfo.InvariantCulture)}";
        
        private string ElementTypeName => typeof(T).ScriptPrettyName();
        
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
            builder.Append(Kind);
            builder.Append('(');
            for(int i = 0; i < Length; i++)
            {
                if (i > 0) builder.Append(", ");
                var valueToFormat = _values[i];
                builder.Append(context != null ? context.ObjectToString(valueToFormat) : valueToFormat is IFormattable formattable ? formattable.ToString(null, formatProvider) : valueToFormat.ToString());
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

            bool isXyzw = false;
            foreach (var c in member)
            {
                if ("xyzw".Contains(c))
                {
                    isXyzw = true;
                    break;
                }
            }

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
                result = NewVector(isXyzw ? ComponentUsed.xyzw : ComponentUsed.rgba, list);
            }

            return true;
        }

        protected virtual KalkVector NewVector(ComponentUsed components, IList<T> list) => new KalkVector<T>(list);
        
        protected enum ComponentUsed
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


        private static ComponentUsed GetComponentUsed(char c, out int index)
        {
            var componentUsed = ComponentUsed.none;
            index = -1;
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
                    componentUsed = ComponentUsed.xyzw;
                    break;
                case 'r':
                    index = x_IndexOffset;
                    componentUsed = ComponentUsed.rgba;
                    break;
                case 'y':
                    index = x_IndexOffset + 1;
                    componentUsed = ComponentUsed.xyzw;
                    break;
                case 'g':
                    index = x_IndexOffset + 1;
                    componentUsed = ComponentUsed.rgba;
                    break;
                case 'z':
                    index = x_IndexOffset + 2;
                    componentUsed = ComponentUsed.xyzw;
                    break;
                case 'b':
                    index = x_IndexOffset + 2;
                    componentUsed = ComponentUsed.rgba;
                    break;
                case 'w':
                    index = x_IndexOffset + 3;
                    componentUsed = ComponentUsed.xyzw;
                    break;
                case 'a':
                    index = x_IndexOffset + 3;
                    componentUsed = ComponentUsed.rgba;
                    break;
            }

            return componentUsed;
        }
        
        private IEnumerable<int> ForEachMemberPart(SourceSpan span, string member, bool throwIfInvalid)
        {
            var componentUsed = ComponentUsed.none;
            for (int i = 0; i < member.Length; i++)
            {
                var c = member[i];
                int index;
                
                var newComponentUsed = GetComponentUsed(c, out index);
                if (newComponentUsed == ComponentUsed.none && throwIfInvalid)
                {
                    throw new ScriptRuntimeException(span, $"Invalid swizzle {c}. Expecting only x,y,z,w.");
                }

                if (componentUsed != ComponentUsed.none && newComponentUsed != componentUsed) throw InvalidMixOfSwizzles(span, componentUsed, c);

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
                this[index - x_IndexOffset] = tValue;
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
            if (leftVector != null && rightVector != null && leftVector.Length != rightVector.Length)
            {
                return false;
            }

            if (leftVector == null)
            {
                leftVector = NewVector(rightVector.Length);
                var leftComponentValue = context.ToObject<T>(span, leftValue);
                for (int i = 0; i < leftVector.Length; i++)
                {
                    leftVector[i] = leftComponentValue;
                }
            }

            if (rightVector == null)
            {
                rightVector = NewVector(leftVector.Length);
                var rightComponentValue = context.ToObject<T>(span, rightValue);
                for (int i = 0; i < rightVector.Length; i++)
                {
                    rightVector[i] = rightComponentValue;
                }
            }
            
            switch (op)
            {
                case ScriptBinaryOperator.CompareEqual:
                case ScriptBinaryOperator.CompareNotEqual:
                case ScriptBinaryOperator.CompareLessOrEqual:
                case ScriptBinaryOperator.CompareGreaterOrEqual:
                case ScriptBinaryOperator.CompareLess:
                case ScriptBinaryOperator.CompareGreater:
                    var vbool = new KalkVector<bool>(leftVector.Length);
                    for (int i = 0; i < leftVector.Length; i++)
                    {
                        vbool[i] = (bool)ScriptBinaryExpression.Evaluate(context, span, op, leftVector[i], rightVector[i]);
                    }
                    result = vbool;
                    return true;

                case ScriptBinaryOperator.Add:
                case ScriptBinaryOperator.Substract:
                case ScriptBinaryOperator.Multiply:
                case ScriptBinaryOperator.Divide:
                case ScriptBinaryOperator.DivideRound:
                case ScriptBinaryOperator.Modulus:
                case ScriptBinaryOperator.ShiftLeft:
                case ScriptBinaryOperator.ShiftRight:
                case ScriptBinaryOperator.Power:
                {
                    var opResult = NewVector(leftVector.Length);
                    for (int i = 0; i < opResult.Length; i++)
                    {
                        opResult[i] = context.ToObject<T>(span, ScriptBinaryExpression.Evaluate(context, span, op, leftVector[i], rightVector[i]));
                    }

                    result = opResult;
                    return true;
                }
            }

            return false;
        }

        public bool TryEvaluate(TemplateContext context, SourceSpan span, ScriptUnaryOperator op, object rightValue, out object result)
        {
            var previousVector = (KalkVector<T>) rightValue;
            var newVector = previousVector.Clone();
            for (int i = 0; i < newVector.Length; i++)
            {
                newVector[i] = (T) ScriptUnaryExpression.Evaluate(context, span, op, newVector[i]);
            }

            result = newVector;
            return true;
        }

        protected virtual KalkVector<T> NewVector(int length) => new KalkVector<T>(length);

        public bool TryConvertTo(TemplateContext context, SourceSpan span, Type type, out object value)
        {
            value = null;
            return false;
        }
      
        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable) _values).GetEnumerator();
        }
    }
}