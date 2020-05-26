using System;
using System.Collections;
using Scriban;
using Scriban.Syntax;

namespace Kalk.Core
{
    public abstract class KalkColorConstructor : KalkVectorConstructor<byte>
    {
        protected KalkColorConstructor(int dimension) : base(dimension)
        {
        }

        protected abstract override KalkVector<byte> NewVector(int dimension);

        protected override byte GetArgumentValue(TemplateContext context, object arg)
        {
            switch (arg)
            {
                case float f32:
                    return (byte)(255 * Math.Clamp(f32, 0.0f, 1.0f));
                case double f64:
                    return (byte)(255 * Math.Clamp(f64, 0.0, 1.0));
                case decimal dec:
                    return (byte)(255 * Math.Clamp(dec, 0.0m, 1.0m));
                default:
                    return base.GetArgumentValue(context, arg);
            }
        }

        protected override void ProcessSingleArgument(TemplateContext context, ref int index, object arg, KalkVector<byte> vector)
        {
            int value;
            switch (arg)
            {
                case string rgbStr:
                    try
                    {
                        if (!KalkColorRgb.TryGetKnownColor(rgbStr, out value))
                        {
                            value = int.Parse(rgbStr.TrimStart('#'), System.Globalization.NumberStyles.HexNumber);
                        }
                    }
                    catch
                    {
                        throw new ScriptArgumentException(0, $"Expecting a known color (e.g `AliceBlue`) or an hexadecimal rgb string (e.g #FF80C2) instead of `{rgbStr}`. Type `colors` for listing known colors.");
                    }
                    break;
                default:
                    if (arg is IList)
                    {
                        base.ProcessSingleArgument(context, ref index, arg, vector);
                        return;
                    }
                    value = context.ToObject<int>(context.CurrentSpan, arg);
                    break;
            }

            vector[index++] = (byte)((value >> 16) & 0xFF);
            vector[index++] = (byte)((value >> 8) & 0xFF);
            vector[index++] = (byte)(value & 0xFF);

            if (Dimension == 4)
            {
                vector[index++] = (byte)((value >> 24) & 0xFF);
            }
        }
    }
}