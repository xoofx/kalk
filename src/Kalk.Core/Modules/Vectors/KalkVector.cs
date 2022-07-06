using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using MathNet.Numerics.LinearAlgebra.Storage;
using Scriban;
using Scriban.Helpers;
using Scriban.Parsing;
using Scriban.Runtime;
using Scriban.Syntax;

namespace Kalk.Core
{
    [ScriptTypeName("vector")]
    public abstract class KalkVector : KalkValue
    {
        public abstract int Length { get; }

        public abstract object GetComponent(int index);

        public abstract void SetComponent(int index, object value);

        public abstract KalkVector Clone();

        public abstract KalkVector FromValue(object value);

        protected abstract KalkVector GenericCross(KalkVector y);

        protected abstract KalkMatrix GenericDiagonal();

        protected abstract object GenericDot(KalkVector y);


        public static KalkMatrix Diagonal(KalkVector x)
        {
            if (x == null) throw new ArgumentNullException(nameof(x));
            return x.GenericDiagonal();
        }

        public static object Dot(KalkVector x, KalkVector y)
        {
            AssertValidVectors(x, y);
            return x.GenericDot(y);
        }

        public static object Cross(KalkVector x, KalkVector y)
        {
            AssertValidVectors(x, y);
            if (x.Length != 3) throw new ArgumentException($"Expecting a vector with 3 elements instead of {x.Length} for cross function.");
            return x.GenericCross(y);
        }

        private static void AssertValidVectors(KalkVector x, KalkVector y)
        {
            if (x == null) throw new ArgumentNullException(nameof(x));
            if (y == null) throw new ArgumentNullException(nameof(y));
            if (x.Length != y.Length) throw new ArgumentException($"Vectors must have the same length instead of {x.Length} vs {y.Length}", nameof(x));
            if (x.ElementType != y.ElementType) throw new ArgumentException($"Vectors must have the same element type instead of {x.ElementType.ScriptPrettyName()} vs {y.ElementType.ScriptPrettyName()}", nameof(x));
        }
    }

    public class KalkVector<T> : KalkVector, IFormattable, IList, IReadOnlyList<T>, IScriptObject, IKalkVectorObject<T>, IScriptCustomType, IKalkDisplayable where T : unmanaged
    {
        private const int x_IndexOffset = 2;
        private readonly T[] _values;

        public KalkVector(int dimension)
        {
            if (dimension <= 0) throw new ArgumentOutOfRangeException(nameof(dimension));
            _values = new T[dimension];
        }

        public KalkVector(IReadOnlyList<T> list)
        {
            _values = list.ToArray();
        }
        
        public KalkVector(IList<T> list)
        {
            _values = list.ToArray();
        }
        
        public KalkVector(T v1, T v2) => _values = new T[2] { v1, v2 };
        public KalkVector(T v1, T v2, T v3) => _values = new T[3] { v1, v2, v3 };
        public KalkVector(T v1, T v2, T v3, T v4) => _values = new T[4] { v1, v2, v3, v4 };
        
        public T x => _values[0];
        public T y => _values.Length >= 2 ? _values[1] : default;
        public T z => _values.Length >= 3 ? _values[2] : default;
        public T w => _values.Length >= 4 ? _values[3] : default;

        public T r => x;
        public T g => y;
        public T b => z;
        public T a => w;

        public override Type ElementType => typeof(T);

        public KalkVector(KalkVector<T> values)
        {
            _values = (T[])values._values.Clone();
        }

        public override int Length => _values.Length;

        public override object GetComponent(int index)
        {
            return _values[index];
        }

        public override void SetComponent(int index, object value)
        {
            _values[index] = value is T tValue ? tValue : (T)Convert.ChangeType(value, typeof(T));
        }

        protected override object GenericDot(KalkVector y)
        {
            return Dot(y);
        }

        internal object AsMathNetVector()
        {
            if (typeof(T) == typeof(float))
            {
                return MathNet.Numerics.LinearAlgebra.Vector<float>.Build.Dense((float[]) (object) _values);
            }

            if (typeof(T) == typeof(KalkHalf))
            {
                return MathNet.Numerics.LinearAlgebra.Vector<float>.Build.Dense(KalkHalf.ToFloatValues((KalkHalf[])(object)_values));
            }

            if (typeof(T) == typeof(double))
            {
                return MathNet.Numerics.LinearAlgebra.Vector<double>.Build.Dense((double[])(object)_values);
            }

            return null;
        }

        public override Span<byte> AsSpan() => MemoryMarshal.AsBytes(new Span<T>(_values));

        protected override KalkMatrix GenericDiagonal()
        {
            var matrix = new KalkMatrix<T>(Length, Length);
            for (int i = 0; i < Length; i++)
            {
                matrix[Length * i + i] = this[i];
            }

            return matrix;
        }

        public override KalkVector FromValue(object value)
        {
            var tValue = (T)value;
            var vector = (KalkVector<T>)Clone();
            for (int i = 0; i < Length; i++)
            {
                vector[i] = tValue;
            }

            return vector;
        }

        protected override KalkVector GenericCross(KalkVector y)
        {
            AssertSameVectors(y);

            var left = (KalkVector<T>) this;
            var right = (KalkVector<T>)y;

            var result = (KalkVector<T>)((KalkVector<T>) left.Multiply(new KalkVector<T>(right[1], right[2], right[0]))).Subtract(
                new KalkVector<T>(left[1], left[2], left[0]).Multiply(right));
            return new KalkVector<T>(result[1], result[2], result[0]);
        }

        private void AssertSameVectors(KalkVector y)
        {
            if (y == null) throw new ArgumentNullException(nameof(y));
            if (Length != y.Length) throw new ArgumentException($"Invalid length for vectors. Lengths {Length} vs {y.Length} must be equal.", nameof(y));
            if (y.GetType() != this.GetType()) throw new ArgumentException($"Invalid type for vectors. Types must match when multiplying. The types {this.TypeName} and {y.TypeName} must be equal.", nameof(y));
        }

        protected virtual T Dot(KalkVector y)
        {
            AssertSameVectors(y);
            
            if (typeof(T) == typeof(float))
            {
                var left = (KalkVector<float>)(KalkVector)this;
                var right = (KalkVector<float>)y;
                float result = 0;
                var length = Length;
                for (int i = 0; i < length; i++)
                {
                    result += left[i] * right[i];
                }
                return Unsafe.As<float, T>(ref result);
            }
            else if (typeof(T) == typeof(double))
            {
                var left = (KalkVector<double>)(KalkVector)this;
                var right = (KalkVector<double>)y;
                double result = 0;
                var length = Length;
                for (int i = 0; i < length; i++)
                {
                    result += left[i] * right[i];
                }
                return Unsafe.As<double, T>(ref result);
            }
            else if (typeof(T) == typeof(int))
            {
                var left = (KalkVector<int>)(KalkVector)this;
                var right = (KalkVector<int>)y;
                int result = 0;
                var length = Length;
                for (int i = 0; i < length; i++)
                {
                    result += left[i] * right[i];
                }
                return Unsafe.As<int, T>(ref result);
            }
            else if (typeof(T) == typeof(KalkHalf))
            {
                var left = (KalkVector<KalkHalf>)(KalkVector)this;
                var right = (KalkVector<KalkHalf>)y;
                var result = (KalkHalf)0.0f;
                var length = Length;
                for (int i = 0; i < length; i++)
                {
                    result = (KalkHalf)((float)result + (float)left[i] * (float)right[i]);
                }
                return Unsafe.As<KalkHalf, T>(ref result);
            }

            throw new InvalidOperationException("This operation is only supported with int, float and double vectors.");
        }

        public override string TypeName
        {
            get
            {
                if (typeof(T) == typeof(KalkBool))
                {
                    switch (Length)
                    {
                        case 2: return "bool2";
                        case 3: return "bool3";
                        case 4: return "bool4";
                        case 8: return "bool8";
                        case 16: return "bool16";
                        case 32: return "bool32";
                        case 64: return "bool64";
                    }
                }
                else if (typeof(T) == typeof(KalkHalf))
                {
                    switch (Length)
                    {
                        case 2: return "half2";
                        case 3: return "half3";
                        case 4: return "half4";
                        case 8: return "half8";
                        case 16: return "half16";
                        case 32: return "half32";
                    }
                }
                else if (typeof(T) == typeof(byte))
                {
                    switch (Length)
                    {
                        case 16: return "byte16";
                        case 32: return "byte32";
                        case 64: return "byte64";
                    }
                }
                else if (typeof(T) == typeof(sbyte))
                {
                    switch (Length)
                    {
                        case 16: return "sbyte16";
                        case 32: return "sbyte32";
                        case 64: return "sbyte64";
                    }
                }
                else if (typeof(T) == typeof(ushort))
                {
                    switch (Length)
                    {
                        case 2: return "ushort2";
                        case 4: return "ushort4";
                        case 8: return "ushort8";
                        case 16: return "ushort16";
                        case 32: return "ushort32";
                    }
                }
                else if (typeof(T) == typeof(short))
                {
                    switch (Length)
                    {
                        case 2: return "short2";
                        case 4: return "short4";
                        case 8: return "short8";
                        case 16: return "short16";
                        case 32: return "short32";
                    }
                }
                else if (typeof(T) == typeof(int))
                {
                    switch (Length)
                    {
                        case 2: return "int2";
                        case 3: return "int3";
                        case 4: return "int4";
                        case 8: return "int8";
                        case 16: return "int16";
                    }
                }
                else if (typeof(T) == typeof(uint))
                {
                    switch (Length)
                    {
                        case 2: return "uint2";
                        case 3: return "uint3";
                        case 4: return "uint4";
                        case 8: return "uint8";
                        case 16: return "uint16";
                    }
                }
                else if (typeof(T) == typeof(float))
                {
                    switch (Length)
                    {
                        case 2: return "float2";
                        case 3: return "float3";
                        case 4: return "float4";
                        case 8: return "float8";
                        case 16: return"float16";
                    }
                }
                else if (typeof(T) == typeof(double))
                {
                    switch (Length)
                    {
                        case 2: return "double2";
                        case 3: return "double3";
                        case 4: return "double4";
                        case 8: return "double8";
                    }
                }
                else if (typeof(T) == typeof(long))
                {
                    switch (Length)
                    {
                        case 2: return "long2";
                        case 3: return "long3";
                        case 4: return "long4";
                        case 8: return "long8";
                    }
                }
                else if (typeof(T) == typeof(ulong))
                {
                    switch (Length)
                    {
                        case 2: return "ulong2";
                        case 3: return "ulong3";
                        case 4: return "ulong4";
                        case 8: return "ulong8";
                    }
                }                

                return "vector";
            }
        }

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

        public override KalkVector Clone()
        {
            return new KalkVector<T>(this);
        }

        public override IScriptObject Clone(bool deep)
        {
            return Clone();
        }

        public override bool CanTransform(Type transformType)
        {
            return (typeof(T) == typeof(int) ||
                    typeof(T) == typeof(byte) ||
                    typeof(T) == typeof(sbyte) ||
                    typeof(T) == typeof(short) ||
                    typeof(T) == typeof(ushort) ||
                    typeof(T) == typeof(uint) ||
                    typeof(T) == typeof(long) ||
                    typeof(T) == typeof(ulong)) && (typeof(long) == transformType || typeof(int) == transformType) ||
                   (typeof(T) == typeof(float) && (typeof(double) == transformType || typeof(float) == transformType) ||
                    typeof(T) == typeof(double) && typeof(double) == transformType) ||
                   (typeof(T) == typeof(KalkHalf) && (typeof(double) == transformType || typeof(float) == transformType || typeof(KalkHalf) == transformType));
        }

        public virtual object Transform(Func<T, T> apply)
        {
            var newValue = (KalkVector<T>)Clone();
            for (int i = 0; i < Length; i++)
            {
                var result = apply(_values[i]);
                newValue[i] = (T)result;
            }
            return newValue;
        }

        public virtual object TransformToBool(Func<T, KalkBool> apply)
        {
            var newValue = new KalkVector<KalkBool>(Length);
            for (int i = 0; i < Length; i++)
            {
                var result = apply(_values[i]);
                newValue[i] = result;
            }
            return newValue;
        }

        public override bool Visit(TemplateContext context, SourceSpan span, Func<object, bool> visit)
        {
            for (int i = 0; i < Length; i++)
            {
                if (!visit(_values[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public override object Transform(TemplateContext context, SourceSpan span, Func<object, object> apply, Type destType)
        {
            if (destType == typeof(KalkBool))
            {
                return TransformToBool(value =>
                {
                    var result = apply(value);
                    return context.ToObject<KalkBool>(span, result);
                });
            }
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
            var kind = TypeName;
            builder.Append(kind);
            builder.Append('(');
            if (kind == "vector")
            {
                builder.Append(typeof(T).ScriptPrettyName());
                builder.Append(", ");
                builder.Append(Length.ToString(CultureInfo.InvariantCulture));
                builder.Append(", ");
            }
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

        public KalkVector Multiply(KalkVector y)
        {
            if (ElementType != y.ElementType) throw new ArgumentException($"Vectors must have the same element type instead of {TypeName} vs {y.TypeName}", nameof(y));
            if (Length != y.Length) throw new ArgumentException($"Vectors must have the same length instead of {Length} vs {y.Length}", nameof(y));

            if (typeof(T) == typeof(float))
            {
                var left = (KalkVector<float>)(KalkVector)this;
                var right = (KalkVector<float>)y;
                var result = new KalkVector<float>(left.Length);
                var length = Length;
                for (int i = 0; i < length; i++)
                {
                    result[i] = left[i] * right[i];
                }
                return result;
            }
            else if (typeof(T) == typeof(float))
            {
                var left = (KalkVector<KalkHalf>)(KalkVector)this;
                var right = (KalkVector<KalkHalf>)y;
                var result = new KalkVector<KalkHalf>(left.Length);
                var length = Length;
                for (int i = 0; i < length; i++)
                {
                    result[i] = (KalkHalf)((float)left[i] * (float)right[i]);
                }
                return result;
            }
            else if (typeof(T) == typeof(double))
            {
                var left = (KalkVector<double>)(KalkVector)this;
                var right = (KalkVector<double>)y;
                var result = new KalkVector<double>(left.Length);
                var length = Length;
                for (int i = 0; i < length; i++)
                {
                    result[i] = left[i] * right[i];
                }
                return result;
            }
            else if (typeof(T) == typeof(int))
            {
                var left = (KalkVector<int>)(KalkVector)this;
                var right = (KalkVector<int>)y;
                var result = new KalkVector<int>(left.Length);
                var length = Length;
                for (int i = 0; i < length; i++)
                {
                    result[i] = left[i] * right[i];
                }
                return result;

            }
            throw new InvalidOperationException("This operation is only supported with int, float and double vectors.");
        }

        public KalkVector Add(KalkVector y)
        {
            if (ElementType != y.ElementType) throw new ArgumentException($"Vectors must have the same element type instead of {TypeName} vs {y.TypeName}", nameof(y));
            if (Length != y.Length) throw new ArgumentException($"Vectors must have the same length instead of {Length} vs {y.Length}", nameof(y));

            if (typeof(T) == typeof(float))
            {
                var left = (KalkVector<float>)(KalkVector)this;
                var right = (KalkVector<float>)y;
                var result = new KalkVector<float>(left.Length);
                var length = Length;
                for (int i = 0; i < length; i++)
                {
                    result[i] = left[i] + right[i];
                }
                return result;
            }
            else if (typeof(T) == typeof(KalkHalf))
            {
                var left = (KalkVector<KalkHalf>)(KalkVector)this;
                var right = (KalkVector<KalkHalf>)y;
                var result = new KalkVector<KalkHalf>(left.Length);
                var length = Length;
                for (int i = 0; i < length; i++)
                {
                    result[i] = (KalkHalf)((float)left[i] + (float)right[i]);
                }
                return result;
            }
            else if (typeof(T) == typeof(double))
            {
                var left = (KalkVector<double>)(KalkVector)this;
                var right = (KalkVector<double>)y;
                var result = new KalkVector<double>(left.Length);
                var length = Length;
                for (int i = 0; i < length; i++)
                {
                    result[i] = left[i] + right[i];
                }
                return result;
            }
            else if (typeof(T) == typeof(int))
            {
                var left = (KalkVector<int>)(KalkVector)this;
                var right = (KalkVector<int>)y;
                var result = new KalkVector<int>(left.Length);
                var length = Length;
                for (int i = 0; i < length; i++)
                {
                    result[i] = left[i] + right[i];
                }
                return result;

            }
            throw new InvalidOperationException("This operation is only supported with int, float and double vectors.");
        }

        public KalkVector Subtract(KalkVector y)
        {
            if (ElementType != y.ElementType) throw new ArgumentException($"Vectors must have the same element type instead of {TypeName} vs {y.TypeName}", nameof(y));
            if (Length != y.Length) throw new ArgumentException($"Vectors must have the same length instead of {Length} vs {y.Length}", nameof(y));

            if (typeof(T) == typeof(float))
            {
                var left = (KalkVector<float>)(KalkVector)this;
                var right = (KalkVector<float>)y;
                var result = new KalkVector<float>(left.Length);
                var length = Length;
                for (int i = 0; i < length; i++)
                {
                    result[i] = left[i] - right[i];
                }
                return result;
            }
            else if (typeof(T) == typeof(KalkHalf))
            {
                var left = (KalkVector<KalkHalf>)(KalkVector)this;
                var right = (KalkVector<KalkHalf>)y;
                var result = new KalkVector<KalkHalf>(left.Length);
                var length = Length;
                for (int i = 0; i < length; i++)
                {
                    result[i] = (KalkHalf)((float)left[i] - (float)right[i]);
                }
                return result;
            }
            else if (typeof(T) == typeof(double))
            {
                var left = (KalkVector<double>)(KalkVector)this;
                var right = (KalkVector<double>)y;
                var result = new KalkVector<double>(left.Length);
                var length = Length;
                for (int i = 0; i < length; i++)
                {
                    result[i] = left[i] - right[i];
                }
                return result;
            }
            else if (typeof(T) == typeof(int))
            {
                var left = (KalkVector<int>)(KalkVector)this;
                var right = (KalkVector<int>)y;
                var result = new KalkVector<int>(left.Length);
                var length = Length;
                for (int i = 0; i < length; i++)
                {
                    result[i] = left[i] - right[i];
                }
                return result;

            }
            throw new InvalidOperationException("This operation is only supported with int, float and double vectors.");
        }

        public KalkVector Divide(KalkVector y)
        {
            if (ElementType != y.ElementType) throw new ArgumentException($"Vectors must have the same element type instead of {TypeName} vs {y.TypeName}", nameof(y));
            if (Length != y.Length) throw new ArgumentException($"Vectors must have the same length instead of {Length} vs {y.Length}", nameof(y));

            if (typeof(T) == typeof(float))
            {
                var left = (KalkVector<float>)(KalkVector)this;
                var right = (KalkVector<float>)y;
                var result = new KalkVector<float>(left.Length);
                var length = Length;
                for (int i = 0; i < length; i++)
                {
                    result[i] = left[i] / right[i];
                }
                return result;
            }
            else if (typeof(T) == typeof(KalkHalf))
            {
                var left = (KalkVector<KalkHalf>)(KalkVector)this;
                var right = (KalkVector<KalkHalf>)y;
                var result = new KalkVector<KalkHalf>(left.Length);
                var length = Length;
                for (int i = 0; i < length; i++)
                {
                    result[i] = (KalkHalf)((float)left[i] / (float)right[i]);
                }
                return result;
            }
            else if (typeof(T) == typeof(double))
            {
                var left = (KalkVector<double>)(KalkVector)this;
                var right = (KalkVector<double>)y;
                var result = new KalkVector<double>(left.Length);
                var length = Length;
                for (int i = 0; i < length; i++)
                {
                    result[i] = left[i] / right[i];
                }
                return result;
            }
            else if (typeof(T) == typeof(int))
            {
                var left = (KalkVector<int>)(KalkVector)this;
                var right = (KalkVector<int>)y;
                var result = new KalkVector<int>(left.Length);
                var length = Length;
                for (int i = 0; i < length; i++)
                {
                    result[i] = left[i] / right[i];
                }
                return result;

            }
            throw new InvalidOperationException("This operation is only supported with int, float and double vectors.");
        }

        public override bool TryGetValue(TemplateContext context, SourceSpan span, string member, out object result)
        {
            result = null;
            if (_values == null) return false;

            if (member.Length < 1) return false;
            List<T> list = null;

            var componentKind = GetComponentKind(member);
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
                result = NewVector(componentKind, list);
            }
            else
            {
                result = GetSwizzleValue(componentKind, (T)result);
            }

            return true;
        }

        private static ComponentKind GetComponentKind(string member)
        {
            var kind = ComponentKind.rgba; 
            foreach (var c in member)
            {
                if ("xyzw".Contains(c))
                {
                    kind = ComponentKind.xyzw;
                    break;
                }
            }

            return kind;
        }
        
        protected virtual object GetSwizzleValue(ComponentKind kind, T result)
        {
            return result;
        }

        protected virtual KalkVector NewVector(ComponentKind kind, IReadOnlyList<T> list) => new KalkVector<T>(list);
        
        protected enum ComponentKind
        {
            none,
            rgba,
            xyzw,
        }


        private static ScriptRuntimeException InvalidMixOfSwizzles(SourceSpan span, ComponentKind kind, char c)
        {
            return new ScriptRuntimeException(span, $"Cannot mix the swizzle `{c}` with swizzles in the domain {kind}.");
        }

        private ScriptRuntimeException InvalidUsageOfXYZW(SourceSpan span, char c)
        {
            return new ScriptRuntimeException(span, $"The swizzle `{c}` is not supported by this {TypeName} type.");
        }


        private static ComponentKind GetComponentUsed(char c, out int index)
        {
            var componentUsed = ComponentKind.none;
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
                    componentUsed = ComponentKind.xyzw;
                    break;
                case 'r':
                    index = x_IndexOffset;
                    componentUsed = ComponentKind.rgba;
                    break;
                case 'y':
                    index = x_IndexOffset + 1;
                    componentUsed = ComponentKind.xyzw;
                    break;
                case 'g':
                    index = x_IndexOffset + 1;
                    componentUsed = ComponentKind.rgba;
                    break;
                case 'z':
                    index = x_IndexOffset + 2;
                    componentUsed = ComponentKind.xyzw;
                    break;
                case 'b':
                    index = x_IndexOffset + 2;
                    componentUsed = ComponentKind.rgba;
                    break;
                case 'w':
                    index = x_IndexOffset + 3;
                    componentUsed = ComponentKind.xyzw;
                    break;
                case 'a':
                    index = x_IndexOffset + 3;
                    componentUsed = ComponentKind.rgba;
                    break;
            }

            return componentUsed;
        }
        
        private IEnumerable<int> ForEachMemberPart(SourceSpan span, string member, bool throwIfInvalid)
        {
            var componentUsed = ComponentKind.none;
            for (int i = 0; i < member.Length; i++)
            {
                var c = member[i];
                int index;
                
                var newComponentUsed = GetComponentUsed(c, out index);
                if (newComponentUsed == ComponentKind.none && index >= x_IndexOffset && throwIfInvalid)
                {
                    throw new ScriptRuntimeException(span, $"Invalid swizzle {c}. Expecting only x,y,z,w.");
                }

                if (componentUsed != ComponentKind.none && newComponentUsed != componentUsed) throw InvalidMixOfSwizzles(span, componentUsed, c);

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

            var componentKind = GetComponentKind(member);

            // Handle the case where the value to set is a vector or an array
            if (value is IList inputList)
            {
                if (inputList.Count != list.Count) throw new ScriptRuntimeException(span, $"Invalid number of components. Expecting {list.Count} but the value {value} has {inputList.Count} components.");

                int i = 0;
                foreach (var index in list)
                {
                    this[index - x_IndexOffset] = TransformComponentToSet(context, span, componentKind, inputList[i]); ;
                    i++;
                }
            }
            else
            {
                // otherwise it is a single value that we dispatch
                var tValue = TransformComponentToSet(context, span, componentKind, value);
                foreach (var index in list)
                {
                    this[index - x_IndexOffset] = tValue;
                }
            }

            return true;
        }

        protected virtual T TransformComponentToSet(TemplateContext context, SourceSpan span, ComponentKind kind, object value)
        {
            return value is T tvalue? tvalue : context.ToObject<T>(span, value);
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
                    var vbool = new KalkVector<KalkBool>(leftVector.Length);
                    for (int i = 0; i < leftVector.Length; i++)
                    {
                        vbool[i] = (bool)ScriptBinaryExpression.Evaluate(context, span, op, leftVector[i], rightVector[i]);
                    }
                    result = vbool;
                    return true;

                case ScriptBinaryOperator.Add:
                    result = leftVector.Add(rightVector);
                    return true;

                case ScriptBinaryOperator.Multiply:
                    result = leftVector.Multiply(rightVector);
                    return true;

                case ScriptBinaryOperator.Subtract:
                    result = leftVector.Subtract(rightVector);
                    return true;

                case ScriptBinaryOperator.Divide:
                    result = leftVector.Divide(rightVector);
                    return true;

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
            var newVector = (KalkVector<T>)previousVector.Clone();
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

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return ((IEnumerable<T>)_values).GetEnumerator();
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable) _values).GetEnumerator();
        }


        private static readonly Type[] SupportedOutput = new Type[] {typeof(long), typeof(ulong), typeof(int), typeof(uint), typeof(short), typeof(ushort), typeof(float), typeof(double), typeof(byte)};

        public void Display(KalkEngine engine, KalkDisplayMode mode)
        {
            if (mode == KalkDisplayMode.Standard || mode == KalkDisplayMode.Raw) return;

            if (Length == 2 || Length == 3 || Length == 4 || Length == 8)
            {
                if (typeof(T) != typeof(long)) Display<long>(engine);
                if (typeof(T) != typeof(ulong)) Display<ulong>(engine);
                if (typeof(T) != typeof(int)) Display<int>(engine);
                if (typeof(T) != typeof(uint)) Display<uint>(engine);
                if (typeof(T) != typeof(short)) Display<short>(engine);
                if (typeof(T) != typeof(ushort)) Display<ushort>(engine);
                if (typeof(T) != typeof(KalkHalf)) Display<KalkHalf>(engine);
                if (typeof(T) != typeof(float)) Display<float>(engine);
                if (typeof(T) != typeof(double)) Display<double>(engine);
                if (typeof(T) != typeof(byte)) Display<byte>(engine);
            }
        }

        private void Display<TTarget>(KalkEngine engine) where TTarget: unmanaged
        {
            var spanBytes = AsSpan();
            var span = MemoryMarshal.Cast<byte, TTarget>(spanBytes);
            var sizeOfTTarget = Unsafe.SizeOf<TTarget>();
            var dim = spanBytes.Length / sizeOfTTarget;
            if ((spanBytes.Length % sizeOfTTarget) != 0) return;

            if (dim == 6) return;

            var dimStr = dim == 1 ? string.Empty : $"{dim.ToString(CultureInfo.InvariantCulture)}";
            
            var builder = new StringBuilder();
            if (typeof(TTarget) == typeof(long))
            {
                builder.Append($"long{dimStr}(");
                for (int i = 0; i < span.Length; i++)
                {
                    if (i > 0) builder.Append(", ");
                    builder.Append(span[i]);
                }
            }
            else if (typeof(TTarget) == typeof(ulong))
            {
                builder.Append($"ulong{dimStr}(");
                for (int i = 0; i < span.Length; i++)
                {
                    if (i > 0) builder.Append(", ");
                    var value = Unsafe.As<TTarget, ulong>(ref span[i]);
                    builder.Append($"0x{(value >> 32):X8}_{(uint)value:X8}");
                }
            }
            else if (typeof(TTarget) == typeof(int))
            {
                builder.Append($"int{dimStr}(");
                for (int i = 0; i < span.Length; i++)
                {
                    if (i > 0) builder.Append(", ");
                    builder.Append(span[i]);
                }
            }
            else if (typeof(TTarget) == typeof(uint))
            {
                builder.Append($"uint{dimStr}(");
                for (int i = 0; i < span.Length; i++)
                {
                    if (i > 0) builder.Append(", ");
                    var value = Unsafe.As<TTarget, uint>(ref span[i]);
                    builder.Append($"0x{(value >> 16):X4}_{(ushort)value:X4}");
                }
            }
            else if (typeof(TTarget) == typeof(short))
            {
                builder.Append($"short{dimStr}(");
                for (int i = 0; i < span.Length; i++)
                {
                    if (i > 0) builder.Append(", ");
                    builder.Append(span[i]);
                }
            }
            else if (typeof(TTarget) == typeof(ushort))
            {
                builder.Append($"ushort{dimStr}(");
                for (int i = 0; i < span.Length; i++)
                {
                    if (i > 0) builder.Append(", ");
                    builder.Append($"0x{Unsafe.As<TTarget, ushort>(ref span[i]):X4}");
                }
            }
            else if (typeof(TTarget) == typeof(float))
            {
                builder.Append($"float{dimStr}(");
                for (int i = 0; i < span.Length; i++)
                {
                    if (i > 0) builder.Append(", ");
                    builder.Append(span[i]);
                }
            }
            else if (typeof(TTarget) == typeof(KalkHalf))
            {
                builder.Append($"half{dimStr}(");
                for (int i = 0; i < span.Length; i++)
                {
                    if (i > 0) builder.Append(", ");
                    builder.Append(span[i]);
                }
            }
            else if (typeof(TTarget) == typeof(double))
            {
                builder.Append($"double{dimStr}(");
                for (int i = 0; i < span.Length; i++)
                {
                    if (i > 0) builder.Append(", ");
                    builder.Append(span[i]);
                }
            }
            else if (typeof(TTarget) == typeof(byte))
            {
                builder.Append($"bytebuffer([");
                for (int i = 0; i < span.Length; i++)
                {
                    if (i > 0) builder.Append(", ");
                    builder.Append($"0x{Unsafe.As<TTarget, byte>(ref span[i]):X2}");
                }
                builder.Append("]");
            }
            
            builder.Append(")");
            
            engine.WriteHighlightLine($"##~## {builder}");
        }
    }
}