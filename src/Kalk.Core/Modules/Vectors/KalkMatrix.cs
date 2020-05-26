using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using MathNet.Numerics.LinearAlgebra;
using Scriban;
using Scriban.Functions;
using Scriban.Helpers;
using Scriban.Parsing;
using Scriban.Runtime;
using Scriban.Syntax;

namespace Kalk.Core
{
    [ScriptTypeName("matrix")]
    public abstract class KalkMatrix : KalkValue, IKalkDisplayable
    {
        protected KalkMatrix(int row, int column)
        {
            if (row <= 0) throw new ArgumentOutOfRangeException(nameof(row));
            if (column <= 0) throw new ArgumentOutOfRangeException(nameof(column));
            RowCount = row;
            ColumnCount = column;
        }

        public int RowCount { get; }

        public int ColumnCount { get; }

        protected abstract KalkMatrix Transpose();

        protected abstract KalkMatrix Identity();

        protected abstract KalkVector Diagonal();

        protected abstract object GenericDeterminant();

        protected abstract KalkMatrix GenericInverse();

        public abstract Array Values { get; }

        public bool IsSquare => RowCount == ColumnCount;

        protected abstract KalkVector GenericMultiplyLeft(KalkVector x);

        protected abstract KalkVector GenericMultiplyRight(KalkVector y);

        protected abstract KalkMatrix GenericMultiply(KalkMatrix y);
        

        protected static void AssertSquareMatrix(KalkMatrix m)
        {
            if (m == null) throw new ArgumentNullException(nameof(m));
            if (!m.IsSquare) throw new ArgumentException($"Matrix must be square nxn instead of {m.TypeName}", nameof(m));
        }

        public static KalkMatrix Transpose(KalkMatrix m)
        {
            if (m == null) throw new ArgumentNullException(nameof(m));
            return m.Transpose();
        }

        public static KalkMatrix Identity(KalkMatrix m)
        {
            AssertSquareMatrix(m);
            return m.Identity();
        }

        public static KalkVector Diagonal(KalkMatrix x)
        {
            AssertSquareMatrix(x);
            return x.Diagonal();
        }

        public static object Determinant(KalkMatrix m)
        {
            AssertSquareMatrix(m);
            return m.GenericDeterminant();
        }

        public static KalkMatrix Inverse(KalkMatrix m)
        {
            AssertSquareMatrix(m);
            return m.GenericInverse();
        }

        public static object Multiply(KalkVector x, KalkMatrix y)
        {
            if (x == null) throw new ArgumentNullException(nameof(x));
            if (y == null) throw new ArgumentNullException(nameof(y));
            CheckElementType(x, y);
            if (x.Length != y.RowCount)
                throw new ArgumentException($"Invalid size between the vector type length {x.Length} and the matrix row count {y.RowCount}. They Must be equal.", nameof(x));
            return y.GenericMultiplyLeft(x);
        }

        public static object Multiply(KalkMatrix x, KalkVector y)
        {
            if (x == null) throw new ArgumentNullException(nameof(x));
            if (y == null) throw new ArgumentNullException(nameof(y));
            CheckElementType(x, y);
            if (x.ColumnCount != y.Length)
                throw new ArgumentException($"Invalid size between the vector type length {y.Length} and the matrix column count {x.ColumnCount}. They Must be equal.", nameof(x));
            return x.GenericMultiplyRight(y);
        }

        public static object Multiply(KalkMatrix x, KalkMatrix y)
        {
            if (x == null) throw new ArgumentNullException(nameof(x));
            if (y == null) throw new ArgumentNullException(nameof(y));
            CheckElementType(x, y);
            if (x.ColumnCount != y.RowCount)
                throw new ArgumentException($"Invalid size not between the matrix x {x.TypeName} with a column count {x.ColumnCount} and the matrix y {y.TypeName} with a row count of {y.RowCount}. They Must be equal.", nameof(x));
            return x.GenericMultiply(y);
        }

        private static void CheckElementType(KalkValue x, KalkValue y)
        {
            if (x == null) throw new ArgumentNullException(nameof(x));
            if (y == null) throw new ArgumentNullException(nameof(y));
            if (x.ElementType != y.ElementType)
            {
                throw new ArgumentException($"Unsupported type for matrix multiplication. The combination of {x.GetType().ScriptPrettyName()} * {y.GetType().ScriptPrettyName()} is not supported.", nameof(x));
            }
        }

        public abstract void Display(KalkEngine engine, KalkDisplayMode mode);
    }

    public class KalkMatrix<T> : KalkMatrix, IFormattable, IList, IScriptCustomType where T: unmanaged
    {
        private readonly T[] _values;

        public KalkMatrix(int row, int column) : base(row, column)
        {
            _values = new T[row * column];
            VerifyElementType();
        }

        private KalkMatrix(int row, int column, T[] values) : base(row, column)
        {
            if (values == null) throw new ArgumentNullException(nameof(values));
            if (values.Length != row * column) throw new ArgumentException($"Matrix values must have {row*column} elements instead of {values.Length}");
            _values = values;
            VerifyElementType();
        }

        public KalkMatrix(KalkMatrix<T> values) : base(values.RowCount, values.ColumnCount)
        {
            _values = (T[])values._values.Clone();
            VerifyElementType();
        }

        private static void VerifyElementType()
        {
            if (typeof(T) == typeof(bool) || typeof(T) == typeof(int) || typeof(T) == typeof(float) || typeof(T) == typeof(double))
            {
                return;
            }
            throw new InvalidOperationException($"The type {typeof(T)} is not supported for matrices. Only bool, int, float and double are supported.");
        }

        public override Type ElementType => typeof(T);

        public override Array Values => _values;

        public T this[int index]
        {
            get => _values[index];
            set => _values[index] = value;
        }


        public KalkVector<T> GetRow(int index)
        {
            if ((uint)index >= (uint)RowCount) throw new ArgumentOutOfRangeException(nameof(index));

            var row = new KalkVector<T>(ColumnCount);
            for (int i = 0; i < ColumnCount; i++)
            {
                row[i] = _values[ColumnCount * index + i];
            }

            return row;
        }

        public void SetRow(int index, KalkVector<T> value)
        {
            if ((uint)index >= (uint)RowCount) throw new ArgumentOutOfRangeException(nameof(index));
            if (value == null) throw new ArgumentNullException(nameof(value));
            if (value.Length != ColumnCount) throw new ArgumentOutOfRangeException(nameof(value), $"Invalid vector size. The vector has a length of {value.Length} while the row of this matrix is expecting {ColumnCount} elements.");

            for (int i = 0; i < ColumnCount; i++)
            {
                _values[ColumnCount * index + i] = value[i];
            }
        }

        public KalkVector<T> GetColumn(int index)
        {
            if ((uint)index >= (uint)RowCount) throw new ArgumentOutOfRangeException(nameof(index));

            var column = new KalkVector<T>(RowCount);
            for (int i = 0; i < RowCount; i++)
            {
                column[i] = _values[ColumnCount * i + index];
            }

            return column;
        }

        public void SetColumn(int index, KalkVector<T> value)
        {
            if ((uint)index >= (uint)RowCount) throw new ArgumentOutOfRangeException(nameof(index));
            if (value == null) throw new ArgumentNullException(nameof(value));
            if (value.Length != RowCount) throw new ArgumentOutOfRangeException(nameof(value), $"Invalid vector size. The vector has a length of {value.Length} while the column of this matrix is expecting {RowCount} elements.");

            for (int i = 0; i < RowCount; i++)
            {
                _values[ColumnCount * i + index] = value[i];
            }
        }

        public KalkMatrix<T> Clone()
        {
            return new KalkMatrix<T>(this);
        }

        public override IScriptObject Clone(bool deep)
        {
            return Clone();
        }

        public override string TypeName
        {
            get
            {
                if (RowCount > 4 || ColumnCount > 4)
                {
                    return $"matrix({ElementTypeName}, {RowCount.ToString(CultureInfo.InvariantCulture)}, {ColumnCount.ToString(CultureInfo.InvariantCulture)})";
                }
                else
                {
                    return $"{ElementTypeName}{RowCount.ToString(CultureInfo.InvariantCulture)}x{ColumnCount.ToString(CultureInfo.InvariantCulture)}";
                }
            }
        }

        private string ElementTypeName => typeof(T).ScriptPrettyName();


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

        public override bool CanTransform(Type transformType)
        {
            return typeof(T) == typeof(int) && (typeof(long) == transformType || typeof(int) == transformType) ||
                   (typeof(T) == typeof(float) && (typeof(double) == transformType || typeof(float) == transformType) ||
                    typeof(T) == typeof(double) && typeof(double) == transformType);
        }

        public override Span<byte> AsSpan() => MemoryMarshal.AsBytes(new Span<T>(_values));

        public override bool Visit(TemplateContext context, SourceSpan span, Func<object, bool> visit)
        {
            for (int i = 0; i < _values.Length; i++)
            {
                if (!visit(_values[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public override object Transform(TemplateContext context, SourceSpan span, Func<object, object> apply)
        {
            return this.Transform(value =>
            {
                var result = apply(value);
                return context.ToObject<T>(span, result);
            });
        }

        public void CopyTo(Array array, int index)
        {
            ((ICollection) _values).CopyTo(array, index);
        }

        public override int Count => RowCount;

        public bool IsSynchronized => ((ICollection) _values).IsSynchronized;

        public object SyncRoot => ((ICollection) _values).SyncRoot;

        public override IEnumerable<string> GetMembers()
        {
            if (_values == null) yield break;
            if (RowCount > 8 || ColumnCount > 8) yield break;

            for(int y = 0; y < RowCount; y++)
            {
                for (int x = 0; x < ColumnCount; x++)
                {
                    yield return string.Format(CultureInfo.InvariantCulture, "_m{0}{1}", y, x);
                }
            }
        }

        public override bool Contains(string member)
        {
            // At least _m00 or _00 so 3 characters
            if (member.Length < 3) return false;

            var emptySpan = new SourceSpan();
            foreach (var cell in ForEachMemberPart(emptySpan, member, false))
            {
                // We say that 0 or 1 are members as well
                if (cell.Item1 < 0 || cell.Item2 < 0) return false;
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

        public override bool IsReadOnly
        {
            get => false;
            set => throw new InvalidOperationException("Cannot set this instance readonly");
        }

        object IList.this[int index]
        {
            get => GetRow(index);
            set => SetRow(index, (KalkVector<T>)value);
        }

        public override bool TryGetValue(TemplateContext context, SourceSpan span, string member, out object result)
        {
            result = null;
            if (_values == null) return false;

            if (member.Length < 1) return false;
            List<T> list = null;
            foreach (var cell in ForEachMemberPart(span, member, true))
            {
                var value = _values[cell.Item1 * ColumnCount + cell.Item2];

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
                result = new KalkVector<T>((IReadOnlyList<T>)list);
            }

            return true;
        }

        private struct CharIterator
        {
            public CharIterator(string text)
            {
                Text = text;
                Index = 0;
            }

            public readonly string Text;

            public int Index;

            public bool HasNext => Index < Text.Length;

            public char NextChar()
            {
                if (Index >= Text.Length) return (char)0;
                return Text[Index++];
            }
        }

        private IEnumerable<(int, int)> ForEachMemberPart(SourceSpan span, string member, bool throwIfInvalid)
        {
            var it = new CharIterator(member);

            // -1 None
            // 0 Zero based
            // 1 One based
            int kindOfMember = -1;

            string error = null;
            while (it.HasNext)
            {
                var c = it.NextChar();
                if (c == '_')
                {
                    c = it.NextChar();
                    bool oneBased = true;
                    if (c == 'm')
                    {
                        oneBased = false;
                        c = it.NextChar();
                    }

                    if (kindOfMember < 0)
                    {
                        kindOfMember = oneBased ? 1 : 0;
                    }
                    else
                    {
                        var newKindOfMember = oneBased ? 1 : 0;
                        if (newKindOfMember != kindOfMember)
                        {
                            if (throwIfInvalid)
                            {
                                throw new ScriptRuntimeException(span, $"Invalid mix of 1 based _m11 and zero based _00");
                            }
                            else
                            {
                                yield return (-1, -1);
                                yield break;
                            }
                        }
                    }

                    // parse _00
                    if (CharHelper.TryParseDigit(c, out var rowIndex))
                    {
                        if (oneBased) rowIndex--;

                        c = it.NextChar();
                        if (CharHelper.TryParseDigit(c, out var columnIndex))
                        {
                            if (oneBased) columnIndex--;

                            if (rowIndex >= RowCount)
                            {
                                if (throwIfInvalid)
                                {
                                    error = $"Invalid row index {rowIndex} >= {RowCount} for member {member}.";
                                }
                            }
                            else if (columnIndex >= ColumnCount)
                            {
                                if (throwIfInvalid)
                                {
                                    error = $"Invalid column index {columnIndex} >= {ColumnCount} for member {member}.";
                                }
                            }
                            else
                            {
                                yield return (rowIndex, columnIndex);
                                continue;
                            }
                        }
                    }
                }

                if (error == null && throwIfInvalid)
                {
                    error = c == 0 ? $"Invalid end of member text found when parsing `{member}`." : $"Invalid matrix character `{StringFunctions.Escape(c.ToString())}` found.";
                }

                if (throwIfInvalid)
                {
                    throw new ScriptRuntimeException(span, error);
                }

                yield return (-1, -1);
                yield break;
            }
        }

        public override bool CanWrite(string member)
        {
            return true;
        }

        protected override KalkVector GenericMultiplyLeft(KalkVector x)
        {
            return MultiplyLeft((KalkVector<T>)x);
        }

        protected override KalkVector GenericMultiplyRight(KalkVector y)
        {
            return MultiplyRight((KalkVector<T>)y);
        }

        protected override KalkMatrix GenericMultiply(KalkMatrix y)
        {
            return Multiply((KalkMatrix<T>)y);
        }

        protected override object GenericDeterminant()
        {
            return Determinant();
        }

        protected override KalkMatrix GenericInverse()
        {
            return Inverse();
        }

        protected KalkVector<T> MultiplyLeft(KalkVector<T> x)
        {
            if (typeof(T) == typeof(float))
            {
                var matrix = Matrix<float>.Build.Dense(RowCount, ColumnCount, (float[])(object)_values);
                var vector = (Vector<float>)x.AsMathNetVector();
                var result = new KalkVector<float>(matrix.LeftMultiply(vector));
                return Unsafe.As<KalkVector<float>, KalkVector<T>>(ref result);
            }

            if (typeof(T) == typeof(double))
            {
                var matrix = Matrix<double>.Build.Dense(RowCount, ColumnCount, (double[])(object)_values);
                var vector = (Vector<double>)x.AsMathNetVector();
                var result = new KalkVector<double>(matrix.LeftMultiply(vector));
                return Unsafe.As<KalkVector<double>, KalkVector<T>>(ref result);
            }

            throw new ArgumentException($"The type {ElementType.ScriptPrettyName()} is not supported for this mul operation", nameof(x));
        }

        protected KalkVector<T> MultiplyRight(KalkVector<T> y)
        {
            if (typeof(T) == typeof(float))
            {
                var matrix = Matrix<float>.Build.Dense(RowCount, ColumnCount, (float[])(object)_values);
                var vector = (Vector<float>)y.AsMathNetVector();
                var result = new KalkVector<float>(matrix.Multiply(vector));
                return Unsafe.As<KalkVector<float>, KalkVector<T>>(ref result);
            }

            if (typeof(T) == typeof(double))
            {
                var matrix = Matrix<double>.Build.Dense(RowCount, ColumnCount, (double[])(object)_values);
                var vector = (Vector<double>)y.AsMathNetVector();
                var result = new KalkVector<double>(matrix.Multiply(vector));
                return Unsafe.As<KalkVector<double>, KalkVector<T>>(ref result);
            }

            throw new ArgumentException($"The type {ElementType.ScriptPrettyName()} is not supported for this mul operation", nameof(y));
        }

        protected KalkMatrix Multiply(KalkMatrix<T> y)
        {
            if (typeof(T) == typeof(float))
            {
                var mx = Matrix<float>.Build.Dense(RowCount, ColumnCount, (float[])(object)_values);
                var my = Matrix<float>.Build.Dense(y.RowCount, y.ColumnCount, (float[])(object)y._values);
                var result = mx.Multiply(my);
                var kalkResult = new KalkMatrix<float>(result.RowCount, result.ColumnCount, result.Storage.AsColumnMajorArray());
                return kalkResult;
            }

            if (typeof(T) == typeof(double))
            {
                var mx = Matrix<double>.Build.Dense(RowCount, ColumnCount, (double[])(object)_values);
                var my = Matrix<double>.Build.Dense(y.RowCount, y.ColumnCount, (double[])(object)y._values);
                var result = mx.Multiply(my);
                var kalkResult = new KalkMatrix<double>(result.RowCount, result.ColumnCount, result.Storage.AsColumnMajorArray());
                return kalkResult;
            }

            throw new ArgumentException($"The type {ElementType.ScriptPrettyName()} is not supported for this mul operation", nameof(y));
        }

        protected T Determinant()
        {
            if (typeof(T) == typeof(float))
            {
                var matrix = Matrix<float>.Build.Dense(RowCount, ColumnCount, (float[])(object)_values);
                var value = matrix.Determinant();
                return Unsafe.As<float, T>(ref value);
            }
            else if (typeof(T) == typeof(double))
            {
                var matrix = Matrix<double>.Build.Dense(RowCount, ColumnCount, (double[])(object)_values);
                var value = matrix.Determinant();
                return Unsafe.As<double, T>(ref value);
            }
            else
            {
                throw new InvalidOperationException($"Determinant can only be calculated for float or double matrices but not for {TypeName}.");
            }
        }

        protected KalkMatrix<T> Inverse()
        {
            if (typeof(T) == typeof(float))
            {
                var matrix = Matrix<float>.Build.Dense(RowCount, ColumnCount, (float[])(object)_values);
                matrix = matrix.Inverse();
                var result = new KalkMatrix<float>(matrix.RowCount, matrix.ColumnCount, matrix.Storage.AsColumnMajorArray());
                return Unsafe.As<KalkMatrix<float>, KalkMatrix<T>>(ref result);
            }
            else if (typeof(T) == typeof(double))
            {
                var matrix = Matrix<double>.Build.Dense(RowCount, ColumnCount, (double[])(object)_values);
                matrix = matrix.Inverse();
                var result = new KalkMatrix<double>(matrix.RowCount, matrix.ColumnCount, matrix.Storage.AsColumnMajorArray());
                return Unsafe.As<KalkMatrix<double>, KalkMatrix<T>>(ref result);
            }
            else
            {
                throw new InvalidOperationException("Determinant can only be calculated for float or double matrices.");
            }
        }

        protected override KalkMatrix Transpose()
        {
            var transpose = new KalkMatrix<T>(ColumnCount, RowCount);
            for(int y =0; y < RowCount; y++)
            {
                for(int x = 0; x < ColumnCount; x++)
                {
                    transpose[RowCount * x + y] = this[ColumnCount * y + x];
                }
            }
            return transpose;
        }
        
        protected override KalkMatrix Identity()
        {
            if (RowCount != ColumnCount) throw new InvalidOperationException($"Matrix must be square nxn instead of {TypeName}");

            var transpose = new KalkMatrix<T>(ColumnCount, RowCount);
            if (typeof(T) == typeof(bool))
            {
                var m = (KalkMatrix<bool>) (KalkMatrix) transpose;
                int count = RowCount;
                for (int i = 0; i < count; i++)
                    m[ColumnCount * i + i] = true;
            }
            else if (typeof(T) == typeof(int))
            {
                var m = (KalkMatrix<int>)(KalkMatrix)transpose;
                int count = RowCount;
                for (int i = 0; i < count; i++)
                    m[ColumnCount * i + i] = 1;
            }
            else if (typeof(T) == typeof(float))
            {
                var m = (KalkMatrix<float>)(KalkMatrix)transpose;
                int count = RowCount;
                for (int i = 0; i < count; i++)
                    m[ColumnCount * i + i] = 1.0f;
            }
            else if (typeof(T) == typeof(double))
            {
                var m = (KalkMatrix<double>)(KalkMatrix)transpose;
                int count = RowCount;
                for (int i = 0; i < count; i++)
                    m[ColumnCount * i + i] = 1.0;
            }
            return transpose;
        }

        protected override KalkVector Diagonal()
        {
            if (RowCount != ColumnCount) throw new InvalidOperationException($"Matrix must be square nxn instead of {TypeName}");

            if (typeof(T) == typeof(bool))
            {
                var m = (KalkMatrix<bool>)(KalkMatrix)this;
                int count = RowCount;
                var result = new KalkVector<bool>(RowCount);
                for (int i = 0; i < count; i++)
                    result[i] = m[ColumnCount * i + i];
                return result;
            }
            else if (typeof(T) == typeof(int))
            {
                var m = (KalkMatrix<int>)(KalkMatrix)this;
                int count = RowCount;
                var result = new KalkVector<int>(RowCount);
                for (int i = 0; i < count; i++)
                    result[i] = m[ColumnCount * i + i];
                return result;
            }
            else if (typeof(T) == typeof(float))
            {
                var m = (KalkMatrix<float>)(KalkMatrix)this;
                int count = RowCount;
                var result = new KalkVector<float>(RowCount);
                for (int i = 0; i < count; i++)
                    result[i] = m[ColumnCount * i + i];
                return result;

            }
            else if (typeof(T) == typeof(double))
            {
                var m = (KalkMatrix<double>)(KalkMatrix)this;
                int count = RowCount;
                var result = new KalkVector<double>(RowCount);
                for (int i = 0; i < count; i++)
                    result[i] = m[ColumnCount * i + i];
                return result;
            }

            throw new InvalidOperationException($"Type {ElementType} is not supported for this operation");
        }

        public override bool TrySetValue(TemplateContext context, SourceSpan span, string member, object value, bool readOnly)
        {
            // TODO: could cache this list
            var list = new List<int>();
            foreach (var cell in ForEachMemberPart(span, member, true))
            {
                int nextIndex = cell.Item1 * ColumnCount + cell.Item2;
                // Otherwise check that we are not trying to override an existing element.
                if (list.Contains(nextIndex))
                {
                    throw new ScriptRuntimeException(span, $"The cell({cell.Item1}, {cell.Item2}) was already set and cannot be set more than once by a same set.");
                }
                list.Add(nextIndex);
            }

            // Handle the case where the value to set is a vector or an array
            if (value is IList inputList)
            {
                if (inputList.Count != list.Count) throw new ScriptRuntimeException(span, $"Invalid number of components. Expecting {list.Count} but the value {value} has {inputList.Count} components.");

                if (value is KalkVector<T> vector)
                {
                    int i = 0;
                    foreach (var index in list)
                    {
                        this[index] = vector[i];
                        i++;
                    }

                }
                else
                {
                    int i = 0;
                    foreach (var index in list)
                    {
                        this[index] = context.ToObject<T>(span, inputList[i]); ;
                        i++;
                    }
                }
            }
            else
            {
                // otherwise it is a single value that we dispatch
                var tValue = context.ToObject<T>(span, value);
                foreach (var index in list)
                {
                    this[index] = tValue;
                }
            }

            return true;
        }

        public override bool Remove(string member)
        {
            throw new InvalidOperationException($"Cannot remove member {member} for {this.GetType()}");
        }

        public override void SetReadOnly(string member, bool readOnly)
        {
            throw new InvalidOperationException($"Cannot set readonly member {member} for {this.GetType()}");
        }

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
            var leftMatrix = leftValue as KalkMatrix<T>;
            var rightMatrix = rightValue as KalkMatrix<T>;
            if (leftMatrix == null && rightMatrix == null) return false;
            if (leftMatrix != null && rightMatrix != null && (leftMatrix.RowCount != rightMatrix.RowCount || leftMatrix.ColumnCount != rightMatrix.ColumnCount))
            {
                return false;
            }

            if (leftMatrix == null)
            {
                leftMatrix = new KalkMatrix<T>(rightMatrix.RowCount, rightMatrix.ColumnCount);
                var leftComponentValue = context.ToObject<T>(span, leftValue);
                for (int i = 0; i < leftMatrix._values.Length; i++)
                {
                    leftMatrix[i] = leftComponentValue;
                }
            }

            if (rightMatrix == null)
            {
                rightMatrix = new KalkMatrix<T>(leftMatrix.RowCount, leftMatrix.ColumnCount);
                var rightComponentValue = context.ToObject<T>(span, rightValue);
                for (int i = 0; i < rightMatrix._values.Length; i++)
                {
                    rightMatrix[i] = rightComponentValue;
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
                    var vbool = new KalkMatrix<bool>(leftMatrix.RowCount, leftMatrix.ColumnCount);
                    for (int i = 0; i < vbool._values.Length; i++)
                    {
                        vbool[i] = (bool)ScriptBinaryExpression.Evaluate(context, span, op, leftMatrix._values[i], rightMatrix._values[i]);
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
                    var opResult = new KalkMatrix<T>(leftMatrix.RowCount, leftMatrix.ColumnCount);
                    for (int i = 0; i < opResult._values.Length; i++)
                    {
                        opResult[i] = context.ToObject<T>(span, ScriptBinaryExpression.Evaluate(context, span, op, leftMatrix._values[i], rightMatrix._values[i]));
                    }

                    result = opResult;
                    return true;
                }
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
            if (RowCount != other.RowCount || ColumnCount != other.ColumnCount) return false;
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
            int hashCode = (RowCount * 397) ^ ColumnCount;
            for (int i = 0; i < values.Length; i++)
            {
                hashCode = (hashCode * 397) ^ values[i].GetHashCode();
            }
            return hashCode;
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < RowCount; i++)
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


        public string ToString(string format, IFormatProvider formatProvider)
        {
            var engine = formatProvider as KalkEngine;
            var builder = new StringBuilder();

            if (RowCount > 4 || ColumnCount > 4)
            {
                builder.Append("matrix");
                builder.Append("(");
                builder.Append(engine != null ? engine.GetTypeName(typeof(T)) : typeof(T).ScriptPrettyName());
                builder.Append(", ");
                builder.Append(RowCount.ToString(CultureInfo.InvariantCulture));
                builder.Append(", ");
                builder.Append(ColumnCount.ToString(CultureInfo.InvariantCulture));
                builder.Append(", ");
            }
            else
            {
                builder.Append(engine != null ? engine.GetTypeName(typeof(T)) : typeof(T).ScriptPrettyName());
                builder.Append(RowCount.ToString(CultureInfo.InvariantCulture)).Append('x').Append(ColumnCount.ToString(CultureInfo.InvariantCulture));
                builder.Append('(');
            }

            for (int i = 0; i < _values.Length; i++)
            {
                if (i > 0) builder.Append(", ");
                var valueToFormat = _values[i];
                builder.Append(engine != null ? engine.ObjectToString(valueToFormat) : valueToFormat is IFormattable formattable ? formattable.ToString(null, formatProvider) : valueToFormat.ToString());
            }

            builder.Append(')');
            return builder.ToString();
        }


        private static bool StartsWithNegative(ref T value)
        { 
            if (typeof(T) == typeof(float))
            {
                return Unsafe.As<T, float>(ref value) < 0.0f;
            }
            else if (typeof(T) == typeof(double))
            {
                return Unsafe.As<T, double>(ref value) < 0.0;
            }
            else if (typeof(T) == typeof(int))
            {
                return Unsafe.As<T, int>(ref value) < 0;
            }

            return false;
        }


        public override void Display(KalkEngine engine, KalkDisplayMode mode)
        {
            // Don't display anything beyond 4x4
            if (RowCount > 4 || ColumnCount > 4) return;
            var columnCountDisplay = ColumnCount + 2;
            var rowCountDisplay = RowCount + 1;
            var cells = new string[rowCountDisplay * columnCountDisplay];
            var cellWidth = new int[columnCountDisplay];
            var columnHasNeg = new bool[ColumnCount];

            // Setup a minimum width
            for (int i = 1; i < cellWidth.Length - 1; i++)
            {
                cellWidth[i] = 10;
            }

            for (int x = 0; x < ColumnCount; x++)
            {
                for (int y = 0; y < RowCount; y++)
                {
                    var cellValue = _values[y * ColumnCount + x];
                    if (StartsWithNegative(ref cellValue))
                    {
                        columnHasNeg[x] = true;
                        break;
                    }
                }
            }

            var rowTypeName = $"{engine.GetTypeName(typeof(T))}{ColumnCount.ToString(CultureInfo.InvariantCulture)}";
            for (int y = 0; y < RowCount; y++)
            {
                cells[(y + 1) * columnCountDisplay + ColumnCount + 1] = $") # {y}";
                var col0 = $"{rowTypeName}(";
                cells[(y + 1) * columnCountDisplay + 0] = col0;

                for (int x = 0; x < ColumnCount; x++)
                {
                    var cellValue = _values[y * ColumnCount + x];
                    var text = engine.ObjectToString(cellValue);

                    // Put a space in place of the -, for positive number
                    if (columnHasNeg[x] && !StartsWithNegative(ref cellValue))
                    {
                        text = $" {text}";
                    }

                    cells[(y + 1) * columnCountDisplay + x + 1] = text;
                    if (text.Length > cellWidth[x + 1])
                    {
                        cellWidth[x + 1] = text.Length;
                    }
                }
            }

            cells[0] = "# col";
            cellWidth[0] = rowTypeName.Length + 1; // typeName(
            cells[ColumnCount + 1] = "  / row";
            for (int x = 0; x < ColumnCount; x++)
            {
                cells[1 + x] = columnHasNeg[x] ? $" {x}" : $"{x}";
            }

            var builder = new StringBuilder();
            
            for (int y = 0; y < RowCount + 1; y++)
            {
                builder.Append("      ");
                WriteRow(y * columnCountDisplay, columnCountDisplay, y == 0 ? "  " : ", ");
                engine.WriteHighlightLine(builder.ToString());
                builder.Clear();
            }

            void WriteRow(int index, int column, string sep)
            {
                for (int i = 0; i < column; i++)
                {
                    var width = cellWidth[i];
                    var text = cells[index + i].PadRight(width);
                    builder.Append(text);
                    if (i >= 1 && i + 2 < column)
                    {
                        builder.Append(sep);
                    }
                }
            }
        }
    }
}