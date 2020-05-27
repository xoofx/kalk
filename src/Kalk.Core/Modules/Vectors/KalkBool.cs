using System;
using Scriban;
using Scriban.Parsing;
using Scriban.Syntax;

namespace Kalk.Core
{
    public struct KalkBool : IEquatable<KalkBool>, IFormattable, IConvertible, IScriptConvertibleTo, IScriptConvertibleFrom, IScriptCustomTypeInfo
    {
        private int _value;

        public KalkBool(bool value)
        {
            _value = value ? -1 : 0;
        }

        public override string ToString()
        {
            return ToString(null, null);
        }

        public bool TryConvertFrom(TemplateContext context, SourceSpan span, object value)
        {
            try
            {
                _value = Convert.ToBoolean(value) ? -1 : 0;
                return true;
            }
            catch
            {
                // ignore
            }
            return false;
        }

        public bool TryConvertTo(TemplateContext context, SourceSpan span, Type type, out object value)
        {
            if (type == typeof(bool))
            {
                value = (bool) this;
                return true;
            }

            try
            {
                value = Convert.ChangeType(_value, type);
                return true;
            }
            catch
            {
                // ignore
            }

            value = null;
            return false;
        }

        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            return _value != 0 ? "true" : "false";
        }

        public bool Equals(KalkBool other)
        {
            return _value == other._value;
        }

        public override bool Equals(object obj)
        {
            return obj is KalkBool other && Equals(other);
        }

        public override int GetHashCode()
        {
            return _value;
        }

        public static bool operator ==(KalkBool left, KalkBool right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(KalkBool left, KalkBool right)
        {
            return !left.Equals(right);
        }

        public static implicit operator bool(KalkBool b) => b._value != 0;
        
        public static implicit operator KalkBool(bool b) => new KalkBool(b);
        TypeCode IConvertible.GetTypeCode()
        {
            return _value.GetTypeCode();
        }

        bool IConvertible.ToBoolean(IFormatProvider? provider)
        {
            return ((IConvertible) _value).ToBoolean(provider);
        }

        byte IConvertible.ToByte(IFormatProvider? provider)
        {
            return ((IConvertible) _value).ToByte(provider);
        }

        char IConvertible.ToChar(IFormatProvider? provider)
        {
            return ((IConvertible) _value).ToChar(provider);
        }

        DateTime IConvertible.ToDateTime(IFormatProvider? provider)
        {
            return ((IConvertible) _value).ToDateTime(provider);
        }

        decimal IConvertible.ToDecimal(IFormatProvider? provider)
        {
            return ((IConvertible) _value).ToDecimal(provider);
        }

        double IConvertible.ToDouble(IFormatProvider? provider)
        {
            return ((IConvertible) _value).ToDouble(provider);
        }

        short IConvertible.ToInt16(IFormatProvider? provider)
        {
            return ((IConvertible) _value).ToInt16(provider);
        }

        int IConvertible.ToInt32(IFormatProvider? provider)
        {
            return ((IConvertible) _value).ToInt32(provider);
        }

        long IConvertible.ToInt64(IFormatProvider? provider)
        {
            return ((IConvertible) _value).ToInt64(provider);
        }

        sbyte IConvertible.ToSByte(IFormatProvider? provider)
        {
            return ((IConvertible) _value).ToSByte(provider);
        }

        float IConvertible.ToSingle(IFormatProvider? provider)
        {
            return ((IConvertible) _value).ToSingle(provider);
        }

        string IConvertible.ToString(IFormatProvider? provider)
        {
            return _value.ToString(provider);
        }

        object IConvertible.ToType(Type conversionType, IFormatProvider? provider)
        {
            return ((IConvertible) _value).ToType(conversionType, provider);
        }

        ushort IConvertible.ToUInt16(IFormatProvider? provider)
        {
            return ((IConvertible) _value).ToUInt16(provider);
        }

        uint IConvertible.ToUInt32(IFormatProvider? provider)
        {
            return ((IConvertible) _value).ToUInt32(provider);
        }

        ulong IConvertible.ToUInt64(IFormatProvider? provider)
        {
            return ((IConvertible) _value).ToUInt64(provider);
        }

        public string TypeName => "bool";
    }
}